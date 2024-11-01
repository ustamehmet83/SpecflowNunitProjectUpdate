using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Utilities;
using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Hooks
{

    [Binding]

    public class SpecflowBase
    {

        private readonly IDriver _idrivers;
        private readonly IGlobalProperties _iglobalProperties;
        private readonly ScenarioContext _scenarioContext;
        private readonly IExtentFeatureReport _iextentFeatureReport;
        private readonly IExtentReport _extentReport;

        public SpecflowBase(IDriver idrivers, IGlobalProperties iglobalProperties, ScenarioContext scenarioContext, IExtentFeatureReport iextentFeatureReport, IExtentReport extentReport)
        {
            _idrivers = idrivers;
            _iglobalProperties = iglobalProperties;
            _scenarioContext = scenarioContext;
            _iextentFeatureReport = iextentFeatureReport;
            _extentReport = extentReport;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            DBUtils.CreateConnection();
            DBUtils.SslContext();
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(FeatureContext featureContext)
        {
            _extentReport.CreateFeature(featureContext.FeatureInfo.Title);
            featureContext["iextentreport"] = _extentReport;
            _extentReport.CreateScenario(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _iextentFeatureReport.FlushExtent();
            _idrivers.CloseBrowser();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            DBUtils.Destroy();
        }
    }
}
