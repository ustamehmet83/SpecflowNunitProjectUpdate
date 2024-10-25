using Automation.Framework.Core.WebUI.DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.Framework.Core.WebUI.Runner
{

    [Binding]
    public class SpecflowRunner
    {

       static  IServiceProvider _iserviceProvider;
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _iserviceProvider = ContainerConfig.ConfigureServices();      
        }
    }
}
