using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.DriverContext;
using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reports;
using Automation.Framework.Core.WebUI.Selenium.LocalWebDrivers;
using Automation.Framework.Core.WebUI.WebElements;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.DIContainer
{
    public class CoreContainerConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDefaultVariables,DefaultVariables>();
            services.AddSingleton<ILogging,Logging>();
            services.AddSingleton<IGlobalProperties,GlobalProperties>();
            services.AddSingleton<IExtentFeatureReport, ExtentFeatureReport>();
            services.AddTransient<IExtentReport,ExtentReport>();
            return services.BuildServiceProvider();
        }

        public static IObjectContainer SetContainer(IObjectContainer iobjectContainer) 
        { 
            iobjectContainer.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
            iobjectContainer.RegisterTypeAs<FirefoxWebDriver, IFirefoxWebDriver>();
            iobjectContainer.RegisterTypeAs<Driver, IDriver>();
            iobjectContainer.RegisterTypeAs<AtBy, IAtBy>();
            iobjectContainer.RegisterTypeAs<AtWebElement, IAtWebElement>();
            return iobjectContainer;
        }


    }
}
