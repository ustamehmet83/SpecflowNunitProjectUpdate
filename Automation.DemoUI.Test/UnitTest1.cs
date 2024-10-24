using Automation.Framework.Core.WebUI.Reports;

namespace Automation.DemoUI.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Logging logging=new Logging();
            logging.Warning("Hello Warning");
            logging.Information
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}