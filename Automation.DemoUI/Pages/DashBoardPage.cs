using Automation.Framework.Core.WebUI.Abstractions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.Pages
{
    public class DashBoardPage:BasePage
    {
        public DashBoardPage(IDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='10']/div/div/div/span")]
        public IWebElement MarketData { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='20']/div/div/div/span")]
        public IWebElement Treasury { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='30']/div/div/div/span")]
        public IWebElement Reports { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='40']/div/div/div/span")]
        public IWebElement Definitions { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='50']/div/div/div/span")]
        public IWebElement AccountingEngine { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='60']/div/div/div/span")]
        public IWebElement Reconciliation { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='70']/div/div/div/span")]
        public IWebElement RateEngine { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='80']/div/div/div/span")]
        public IWebElement BatchItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='90']/div/div/div/span")]
        public IWebElement Administration { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='20.17']/div/div/div/span")]
        public IWebElement SecurityIssue { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@data-item-id='20.17.10']/div/div/div/span")]
        public IWebElement IssuedBondsBtn { get; set; }


    }
}
