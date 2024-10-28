using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Runner;
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

        //IGlobalProperties iglobalProperties;
        //IChromeWebDriver _ichromeWebDriver;
        //IFirefoxWebDriver _ifirefoxWebDriver;
        //IExtentFeatureReport _iextentFeatureReport;
        ScenarioContext _scenarioContext;
        IDriver _idrivers;
        //public SpecflowBase(IChromeWebDriver _chromeDriver, IFirefoxWebDriver ifirefoxWebDriver)
        //{

        //    _ichromeWebDriver = _chromeDriver;
        //    _ifirefoxWebDriver = ifirefoxWebDriver;
        //}
        public SpecflowBase(IDriver idrivers)
        {
            _idrivers = idrivers;
        }

        //[BeforeScenario(Order = 2)]
        //public void BeforeScenario(IObjectContainer iobjectContainer)
        //{
        //    _idrivers = iobjectContainer.Resolve<IDriver>();
        //}

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(ScenarioContext scenarioContext, FeatureContext fs)
        {
            _scenarioContext = scenarioContext;
            IExtentReport extentReport = (IExtentReport)fs["iextentreport"];
            extentReport.CreateScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterSteps(ScenarioContext sc, FeatureContext fs)
        {
            IExtentReport extentReport = (IExtentReport)fs["iextentreport"];
            IGlobalProperties iglobalProperties=SpecflowRunner._iserviceProvider.GetRequiredService<IGlobalProperties>();
            string base64 = null; 
            if (sc.TestError != null)
            {
                base64 = _idrivers.GetScreenShot();
                extentReport.Fail(sc.StepContext.StepInfo.Text, base64);
            }
            else
            {

                if (iglobalProperties.stepscreenshot)
                {
                    base64 = _idrivers.GetScreenShot();
                }
                extentReport.Pass(sc.StepContext.StepInfo.Text,base64);
            }

        }

        [AfterScenario]
        public void AfterScenario()
        {
            IExtentFeatureReport extentFeatureReport = SpecflowRunner._iserviceProvider.GetRequiredService<IExtentFeatureReport>();
            extentFeatureReport.FlushExtent();
            _idrivers.CloseBrowser();
        }
    }
}
