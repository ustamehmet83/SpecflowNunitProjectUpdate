using Automation.Framework.Core.WebUI.Abstractions;
using BoDi;
using TechTalk.SpecFlow;

namespace Automation.Business.Container
{
    [Binding]
    public class ContainerConfig
    {
        [BeforeScenario(Order = 1)]
        public void BeforeScenario(IObjectContainer iobjectContainer)
        {
            iobjectContainer.RegisterCoreServices();
            iobjectContainer.RegisterWebDrivers();
            var driver = iobjectContainer.Resolve<IDriver>();
            iobjectContainer.RegisterInstanceAs(driver.GetWebDriver());
            iobjectContainer.RegisterTypes(iobjectContainer.Resolve<IDriver>());


        }
    }
}
