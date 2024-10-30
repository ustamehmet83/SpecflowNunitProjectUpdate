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

        IGlobalProperties _iglobalProperties;  
        ScenarioContext _scenarioContext;
        IDriver _idrivers;
        IExtentReport extentReport;
        IExtentFeatureReport _iextentFeatureReport;
        public SpecflowBase(IDriver idrivers)
        {
            _idrivers = idrivers;
        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(ScenarioContext scenarioContext, FeatureContext fs, IGlobalProperties iglobalProperties,IExtentFeatureReport iextentFeatureReport, IExtentReport _extentReport)
        {
            _scenarioContext = scenarioContext;
            extentReport = _extentReport;
            extentReport.CreateFeature(fs.FeatureInfo.Title);
            fs["iextentreport"] = extentReport;
            extentReport = (IExtentReport)fs["iextentreport"];
            extentReport.CreateScenario(scenarioContext.ScenarioInfo.Title);
            _iglobalProperties= iglobalProperties;
            _iextentFeatureReport= iextentFeatureReport;
        }

        [AfterStep]
        public void AfterSteps(ScenarioContext sc, FeatureContext fs)
        {
            IExtentReport extentReport = (IExtentReport)fs["iextentreport"];         
            string base64 = null; 
            if (sc.TestError != null)
            {
                base64 = _idrivers.GetScreenShot();
                extentReport.Fail(sc.StepContext.StepInfo.Text, base64);
            }
            else
            {

                if (_iglobalProperties.stepscreenshot)
                {
                    base64 = _idrivers.GetScreenShot();
                }
                extentReport.Pass(sc.StepContext.StepInfo.Text,base64);
            }

        }

        [AfterScenario]
        public void AfterScenario()
        {
            _iextentFeatureReport.FlushExtent();
            _idrivers.CloseBrowser();
        }
    }
}
