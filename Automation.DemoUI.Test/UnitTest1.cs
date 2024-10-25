using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.DIContainer;
using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reports;
using Microsoft.Extensions.DependencyInjection;

namespace Automation.DemoUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //GlobalProperties globalProperties = new GlobalProperties();
            //Logging logging=new Logging();
            IServiceProvider iserviceProvider = ContainerConfig.ConfigureServices();
            IGlobalProperties globalProperties = iserviceProvider.GetRequiredService<IGlobalProperties>();
            globalProperties.Configuration();
            ILogging logging=iserviceProvider.GetRequiredService<ILogging>();
            logging.Warning("Hello Warning");
            logging.Information("Information");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}