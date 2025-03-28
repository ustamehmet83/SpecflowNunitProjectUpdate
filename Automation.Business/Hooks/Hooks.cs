﻿using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Utilities;
using OpenQA.Selenium;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace Automation.Business.Hooks
{

    [Binding]

    public class Hooks
    {

        private readonly IDriver _idriver;
        private readonly IGlobalProperties _iglobalProperties;
        private readonly ScenarioContext _scenarioContext;
        private readonly IExtentFeatureReport _iextentFeatureReport;
        private readonly IExtentReport _extentReport;

        public Hooks(IDriver idriver, IGlobalProperties iglobalProperties, ScenarioContext scenarioContext, IExtentFeatureReport iextentFeatureReport, IExtentReport extentReport
            )
        {
            _idriver = idriver;
            _iglobalProperties = iglobalProperties;
            _scenarioContext = scenarioContext;
            _iextentFeatureReport = iextentFeatureReport;
            _extentReport = extentReport;

        }

        [BeforeScenario(Order = 2)]
        public void BeforeScenario(FeatureContext featureContext)
        {
            _extentReport.CreateFeature(featureContext.FeatureInfo.Title);
            featureContext["iextentreport"] = _extentReport;
            _extentReport.CreateScenario(_scenarioContext.ScenarioInfo.Title);
        }


        [AfterStep]
        public void AfterSteps(ScenarioContext sc, FeatureContext fs, ISpecFlowOutputHelper specFlowOutputHelper)
        {
            IExtentReport extentReport = (IExtentReport)fs["iextentreport"];
            string base64 = null;

            if (sc.TestError != null)
            {
                base64 = _idriver.GetScreenShot();
                extentReport.Fail(sc.StepContext.StepInfo.Text, base64);
                var filename = $"Screenshot_{DateTime.Now:dd.MM.yyyy-HH.mm.ss}{"  " + ScenarioContext.Current.ScenarioInfo.Title}.png";
                var screenshot = ((ITakesScreenshot)_idriver.GetWebDriver()).GetScreenshot();
                screenshot.SaveAsFile(filename);
                specFlowOutputHelper.AddAttachment(filename);

            }
            else
            {

                if (_iglobalProperties.stepscreenshot)
                {
                    base64 = _idriver.GetScreenShot();
                }
                extentReport.Pass(sc.StepContext.StepInfo.Text, base64);
            }

        }

        [AfterScenario]
        public void AfterScenario()
        {
            _iextentFeatureReport.FlushExtent();
            _idriver.CloseBrowser();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            try
            {
                using Process process = new();
                ProcessStartInfo startInfo = new()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = string.Format(@"/C livingdoc test-assembly {0}.dll -t TestExecution.json & LivingDoc.html", "Automation.Business")
                };
                process.StartInfo = startInfo;
                process.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
