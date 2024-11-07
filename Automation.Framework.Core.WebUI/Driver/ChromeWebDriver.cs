using Automation.Framework.Core.WebUI.Abstractions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Framework.Core.WebUI.Driver
{
    public class ChromeWebDriver : IChromeWebDriver
    {
        IGlobalProperties _iglobalProperties;
        public ChromeWebDriver(IGlobalProperties iglobalProperties)
        {
            _iglobalProperties = iglobalProperties;
        }

        public IWebDriver GetChromeWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver iwebDriver = new ChromeDriver(GetOptions());
            iwebDriver.Manage().Window.Maximize();
            iwebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return iwebDriver;

        }

        public ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddExcludedArgument("enable-automation");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddArgument("disable-extensions");
            options.AddArgument("disable-infobars");
            options.AddArgument("disable-notifications");
            options.AddArgument("disable-web-security");
            options.AddArgument("dns-prefetch-disable");
            options.AddArgument("disable-browser-side-navigation");
            options.AddArgument("disable-gpu");
            options.AddArgument("always-authorize-plugins");
            options.AddArgument("load-extension=src/main/resources/chrome_load_stopper");
            options.AddUserProfilePreference("download.default_directory", _iglobalProperties.datasetlocation);
            return options;


        }
    }
}
