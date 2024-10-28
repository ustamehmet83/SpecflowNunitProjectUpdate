using Automation.DemoUI.Configuration;
using Automation.DemoUI.Pages;
using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.DIContainer;
using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Container
{
    [Binding]
    public class ContainerConfig
    {
        [BeforeScenario(Order =1)]
        public void BeforeScenario(IObjectContainer iobjectContainer) 
        {
            iobjectContainer.RegisterTypeAs<AtConfiguration, IAtConfiguration>();
            iobjectContainer.RegisterTypeAs<LoginPage, ILoginPage>();
            iobjectContainer=CoreContainerConfig.SetContainer(iobjectContainer);
        }   
    }
}
