﻿using OpenQA.Selenium;
using BoDi;
using Automation.Framework.Core.WebUI.Abstractions;

namespace Automation.Framework.Core.WebUI.Driver
{
    public class Driver : IDriver
    {
        //ISpecflow output helper
        //spec sync
        private readonly IChromeWebDriver _ichromeWebDriver;
        private readonly IFirefoxWebDriver _ifirefoxWebDriver;
        private readonly IObjectContainer _iobjectContainer;
        private readonly IGlobalProperties _iglobalProperties;
        private IWebDriver driver;

        public Driver(IChromeWebDriver ichromeWebDriver, IFirefoxWebDriver ifirefoxWebDriver, IObjectContainer iobjectContainer, IGlobalProperties iglobalProperties)
        {
            _ichromeWebDriver = ichromeWebDriver;
            _ifirefoxWebDriver = ifirefoxWebDriver;
            _iobjectContainer = iobjectContainer;
            _iglobalProperties = iglobalProperties;
        }

        public IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                GetNewWebDriver();
            }
            return driver;
        }

        public void GetNewWebDriver()
        {
            switch (_iglobalProperties.browsertype.ToLower())
            {
                case "chrome":
                    driver = _ichromeWebDriver.GetChromeWebDriver();
                    break;
                case "firefox":
                    driver = _ifirefoxWebDriver.GetFirefoxDriver();
                    break;
                default:
                    driver = _ichromeWebDriver.GetChromeWebDriver();
                    break;
            }
        }

        public void CloseBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
            }

            
        }

        public void NavigateTo(string url)
        {
            GetWebDriver().Navigate().GoToUrl(url);
        }
        public string GetPageTitle()
        {
            return GetWebDriver().Title;
        }

        public void GetNewTab()
        {

            GetWebDriver().SwitchTo().NewWindow(WindowType.Tab);
        }

        public void CloseCurrentBrowser()
        {
            GetWebDriver().Close();
        }

        public void SwitchToWindowWithHandle(string handle)
        {
            GetWebDriver().SwitchTo().Window(handle);
        }

        public void SwitchToWindowWithTitle(string title)
        {
            IList<string> windowhandles = GetWebDriver().WindowHandles;

            foreach (string handle in windowhandles)
            {
                if (GetWebDriver().SwitchTo().Window(handle).Title.Contains(title))
                {
                    break;
                }
            }
        }

        public void SwitchToFrameWithName(string frameName)
        {
            GetWebDriver().SwitchTo().Frame(frameName);
        }

        public void Maximize()
        {
            GetWebDriver().Manage().Window.Maximize();
        }

        public void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript(script);
        }

        public void ScrollWithPixel()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("window.scrollBy(0,500)");
        }

        public void ScrollByheight()
        {

            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("window.scrollTo(0,document.body.scrollHeight)");
        }

        public void ScrollIntoView(IWebElement iwebElement) { 
            IJavaScriptExecutor js = (IJavaScriptExecutor)GetWebDriver();
            js.ExecuteScript("agruments[0].scrollIntoView", iwebElement);
        }

        public string GetScreenShot()
        {
            return ((ITakesScreenshot)GetWebDriver()).GetScreenshot().AsBase64EncodedString;
        }

    }
}
