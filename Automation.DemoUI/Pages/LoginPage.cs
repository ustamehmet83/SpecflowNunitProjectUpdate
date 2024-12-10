using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Driver;
using Automation.Framework.Core.WebUI.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Runtime.Intrinsics.X86;


namespace Automation.DemoUI.Pages
{
    public class LoginPage : BasePage
    {

        private IWebDriver _driver;
      
        public LoginPage(IDriver driver) : base(driver)
        {
            
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='YSM5S']")]
        public IWebElement searchBtn;

        [FindsBy(How = How.Id, Using = "i4")]
        public IWebElement searchInputBtn;

        [FindsBy(How = How.XPath, Using = "//a[@href='https://cloud.google.com/products/calculator']")]
        public IWebElement cloudPricingCalBtn;

        [FindsBy(How = How.XPath, Using = "(//span[.='Add to estimate'])[1]")]
        public IWebElement addToEstimateBtn;

        [FindsBy(How = How.XPath, Using = "//h2[.='Compute Engine']/..//p[@class='BPgnDc']")]
        public IWebElement computeEngineAddBtn;
       
    }
}
