using Automation.DemoUi.Pages;
using Automation.DemoUi.WebAbstraction;
using Automation.DemoUI.Configuration;
using Automation.DemoUI.Pages;
using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.DriverContext;
using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reports;
using Automation.Framework.Core.WebUI.WebElements;
using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Automation.DemoUI.Container
{
    [Binding]
    public class ContainerConfig
    {
        [BeforeScenario(Order =1)]
        public void BeforeScenario(IObjectContainer iobjectContainer) 
        {
          
            iobjectContainer.RegisterTypeAs<DefaultVariables, IDefaultVariables>();
            iobjectContainer.RegisterTypeAs<Logging, ILogging>();
            iobjectContainer.RegisterTypeAs<GlobalProperties, IGlobalProperties>();
            iobjectContainer.RegisterTypeAs<ExtentFeatureReport, IExtentFeatureReport>();
            iobjectContainer.RegisterTypeAs<ExtentReport, IExtentReport>();
            iobjectContainer.RegisterTypeAs<AtConfiguration, IAtConfiguration>();
            iobjectContainer.RegisterTypeAs<LoginPage, ILoginPage>();
            iobjectContainer.RegisterTypeAs<SwagLabPage, ISwagLabPage>();         
            iobjectContainer.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            iobjectContainer.RegisterTypeAs<FirefoxWebDriver, IFirefoxWebDriver>();
            iobjectContainer.RegisterTypeAs<Driver, IDriver>();
            iobjectContainer.RegisterTypeAs<AtBy, IAtBy>();
            iobjectContainer.RegisterTypeAs<AtWebElement, IAtWebElement>();
            iobjectContainer.RegisterTypeAs<ConfigurationReader, IAtConfiguration>();
            
        }   
    }
}
