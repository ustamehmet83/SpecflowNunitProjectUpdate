using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Framework.Core.WebUI.Abstractions;
using SeleniumExtras.WaitHelpers;
using Automation.Framework.Core.WebUI.DriverContext;
using SeleniumExtras.PageObjects;
using Automation.DemoUI.WebAbstraction;
using AngleSharp.Dom;

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






    }
}
