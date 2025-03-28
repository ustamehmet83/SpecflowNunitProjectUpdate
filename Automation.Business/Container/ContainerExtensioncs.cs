﻿using Automation.Business.Pages;
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Base;
using Automation.Framework.Core.WebUI.Configuration;
using Automation.Framework.Core.WebUI.Driver;
using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reports;
using Automation.Framework.Core.WebUI.Utilities;
using BoDi;

namespace Automation.Business.Container;


public static class ContainerExtension
{
    /// <summary>
    /// </summary>
    /// <param name="container"></param>

    public static void RegisterTypes(this IObjectContainer container, params object[] args)
    {
        var typeOfBase = typeof(BasePage);

        var derivedTypes = typeOfBase.Assembly.GetTypes()
          .Where(t => typeOfBase.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);



        Parallel.ForEach(derivedTypes, derivedType =>
        {
            var obj = Activator.CreateInstance(derivedType, args);
            container.RegisterInstanceAs(obj);
        });
    }

    public static void RegisterCoreServices(this IObjectContainer container)
    {
        container.RegisterTypeAs<DefaultVariables, IDefaultVariables>();
        container.RegisterTypeAs<Logging, ILogging>();
        container.RegisterTypeAs<GlobalProperties, IGlobalProperties>();
        container.RegisterTypeAs<ExtentFeatureReport, IExtentFeatureReport>();
        container.RegisterTypeAs<ExtentReport, IExtentReport>();
        container.RegisterTypeAs<ConfigurationReader, IConfigurationReader>();
        container.RegisterTypeAs<BrowserUtils, BrowserUtils>();
        container.RegisterTypeAs<RestBuilder, IRestBuilder>();
        container.RegisterTypeAs<RestLibrary, IRestLibrary>();
    }

    public static void RegisterWebDrivers(this IObjectContainer container)
    {
        container.RegisterTypeAs<ChromeWebDriver, IChromeWebDriver>();
        container.RegisterTypeAs<FirefoxWebDriver, IFirefoxWebDriver>();
        container.RegisterTypeAs<Driver, IDriver>();
    }
}
