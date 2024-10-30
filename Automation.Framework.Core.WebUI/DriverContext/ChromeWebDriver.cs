using Automation.Framework.Core.WebUI.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.Framework.Core.WebUI.DriverContext
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
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver iwebDriver = new ChromeDriver(GetOptions());
            iwebDriver.Manage().Window.Maximize();
            return iwebDriver;

        }

        public ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;

            options.AddExcludedArgument("enable-automation");
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
