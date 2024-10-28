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
        IDriver _idrivers;
        //public SpecflowBase(IChromeWebDriver _chromeDriver, IFirefoxWebDriver ifirefoxWebDriver)
        //{

        //    _ichromeWebDriver = _chromeDriver;
        //    _ifirefoxWebDriver = ifirefoxWebDriver;
        //}
        public SpecflowBase(IDriver idrivers)
        {
            _idrivers= idrivers;
        }

        //[BeforeScenario(Order = 2)]
        //public void BeforeScenario(IObjectContainer iobjectContainer)
        //{
        //    _idrivers = iobjectContainer.Resolve<IDriver>();
        //}
        [AfterScenario]
        public void AfterScenario()
        {
            _idrivers.CloseBrowser();
        }
    }
}
