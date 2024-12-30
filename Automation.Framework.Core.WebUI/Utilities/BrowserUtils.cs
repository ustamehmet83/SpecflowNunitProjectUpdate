using Automation.Framework.Core.WebUI.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Automation.Framework.Core.WebUI.Utilities
{
    public class BrowserUtils
    {
        
        private IWebDriver driver;
        public BrowserUtils(IDriver _driver)
        {
            driver = _driver.GetWebDriver();

            PageFactory.InitElements(driver, this);
        }


        public void WaitForVisibility(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    wait.Until(d => webElement.Displayed);
                    break; // Exit the loop if the element is visible
                }
                catch (StaleElementReferenceException)
                {                   
                    continue;
                }
                catch (WebDriverTimeoutException)
                {
                    throw new TimeoutException($"Element is not visible after 30 seconds.");
                }
                catch (Exception e)
                {
                    throw new Exception($"Element is not visible: {e.Message}");
                }
            }
        }

        public void WaitForClickable(IWebElement webElement)
        {
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            for (int i = 0; i < 5; i++)
            {

                try
                {
                    wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
                }
                catch (StaleElementReferenceException)
                {
                    continue;
                }
                catch (WebDriverTimeoutException)
                {
                    throw new TimeoutException($"Element is not clickable after 15 seconds.");
                }
                catch (Exception e)
                {
                    throw new Exception($"Error while waiting for element to be clickable: {e.Message}");
                }
                finally
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }
            }
        }

        public void ClickWithJS(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            jsExecutor.ExecuteScript("arguments[0].click();", element);
        }

        public void WaitForVisibilityClickableAndClickWithJS(IWebElement element)
        {
            WaitForVisibility(element);
            WaitForClickable(element);
            ClickWithJS(element);
        }

        public void WaitForVisibilityClickableAndClick(IWebElement element)
        {
            WaitForVisibility(element);
            WaitForClickable(element);
            element.Click();
        }

        public  void WaitForInvisibility(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    wait.Until(d => !webElement.Displayed);
                    break; // Exit the loop if the element is visible
                }
                catch (StaleElementReferenceException)
                {
                    continue;
                }
                catch (WebDriverTimeoutException)
                {
                    throw new TimeoutException($"Element is visible after 30 seconds.");
                }
                catch (Exception e)
                {
                    throw new Exception($"Element is visible: {e.Message}");
                }
            }
        }

        public void WaitForTextVisibility(IWebDriver driver, IWebElement webElement, string text, int timeoutInSeconds = 30)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementValue(webElement, text));
        }

        public void WaitForTextNotVisibility(IWebElement webElement, string text)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(TextToBeNotEqualElementValue(webElement, text));
        }


        public Func<IWebDriver, bool> TextToBeNotEqualElementValue(IWebElement element, string text)
        {
            return driver =>
            {
                try
                {
                    string elementText = element.GetAttribute("value");
                    return elementText != null && !elementText.Equals(text);
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }

        public IWebElement ScrollToElement(IWebElement element)
        {            
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("const rect = arguments[0].getBoundingClientRect();" +
                             "const y = rect.top + window.scrollY - (window.innerHeight / 2);" +
                             "window.scrollTo(0, y);", element);
            return element;
        }

        public  void WaitForStaleWebElement(IWebElement element)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);  // Disable implicit wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(Refreshed(ExpectedConditions.ElementToBeClickable(element)));
        }

        private static Func<IWebDriver, IWebElement> Refreshed(Func<IWebDriver, IWebElement> condition)
        {
            return new Func<IWebDriver, IWebElement>((driver) =>
            {
                bool stale = true;
                int retries = 0;
                IWebElement result = null;

                while (stale && retries < 5)
                {
                    try
                    {
                        result = condition(driver);
                        stale = false;
                        Thread.Sleep(1000);  // Adding sleep for retry interval
                    }
                    catch (StaleElementReferenceException)
                    {
                        retries++;
                    }
                }

                if (stale)
                {
                    throw new Exception("Element is still stale after 5 attempts.");
                }

                return result;
            });
        }
    }
}
