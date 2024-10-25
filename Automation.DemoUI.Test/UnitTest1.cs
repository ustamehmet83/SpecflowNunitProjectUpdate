
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.DIContainer;
using Automation.Framework.Core.WebUI.Params;

using Microsoft.Extensions.DependencyInjection;

namespace Automation.DemoUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Logging logging = new Logging();
            IServiceProvider serviceProvider = ContainerConfig.ConfigureServices();
            IGlobalProperties globalProperties =serviceProvider.GetService<IGlobalProperties>();
            ////globalProperties.Configuration();
            //ILogging logging = serviceProvider.GetRequiredService<ILogging>();
            //logging.Warning("Hello World!");
            //logging.Information("Information");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}