using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.Pages
{
    public abstract class BasePage : BrowserUtils
    {       
        public BasePage(IDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbRefresh']/div")]
        public IWebElement RefreshBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbDisplay']/div")]
        public IWebElement ViewBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbNew']/div")]
        public IWebElement NewBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbVerify']/div")]
        public IWebElement VerifyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbReject']/div")]
        public IWebElement RejectBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbDelete']/div")]
        public IWebElement DeleteBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbAccounting']/div")]
        public IWebElement AccountingBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbRejectAndUndo']/div")]
        public IWebElement RejectUndoBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbEdit']/div")]
        public IWebElement EditBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[.='Sync']")]
        public IWebElement SyncBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFrameworkIsFirstLoad']/..//span[@class='popup-title-span']/..")]
        public IWebElement NewTypeText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='user-name-wrapper manuel-theme-color']")]
        public IWebElement HeaderUserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='userIcon']")]
        public IWebElement UserIcon { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[.='Log out']")]
        public IWebElement LogOutBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='sbStateFilter']/div/div/div/input")]
        public IWebElement State { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-1")]
        public IWebElement ActiveRecordsBtn { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-2")]
        public IWebElement AllRecordsBtn { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-3")]
        public IWebElement UnverifiedRecordsBtn { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-4")]
        public IWebElement VerifiedRecordsBtn { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-5")]
        public IWebElement RejectedRecordsBtn { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-6")]
        public IWebElement TodayBtn { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-7")]
        public IWebElement TodayRecordsBtn { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-8")]
        public IWebElement TodayFWDValueBtn { get; set; }

        [FindsBy(How = How.Id, Using = "global-stateFilter-21")]
        public IWebElement DeletedRecordsBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[.='Verify'])[2]")]
        public IWebElement DeleteVerify { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[.='View'])")]
        public IWebElement ViewRightClickBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btnTbRefresh']/div")]
        public IWebElement RefreshColumnText { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[.='Save']")]
        public IWebElement SaveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'dx-loadpanel-wrapper')]")]
        public static IWebElement Loading { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='framework-notify']/div")]
        public IWebElement ErrorText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='framework-notify']//button")]
        public IWebElement ErrorClose { get; set; }

        [FindsBy(How = How.XPath, Using = "//td[contains(@class,'header-state-date') and @role='columnheader']")]
        public IWebElement StateDateBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[.='Yes']")]
        public IWebElement YesBtn { get; set; }

        [FindsBy(How = How.Id, Using = "dx-col-27")]
        public IWebElement StateColumnText { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='dx-icon dx-icon-isblank']/following-sibling::span")]
        public IWebElement OkBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//i[@class='dx-icon dx-icon-clear']/../span)[2]")]
        public IWebElement CancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//i[@class='dx-icon dx-icon-close']")]
        public IWebElement CloseBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "((//div[@id='divFrameworkIsFirstLoad']/following-sibling::div)//span/..)[1]")]
        public IWebElement PageTypeBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='divFrameworkIsFirstLoad']/..//span[@class='popup-title-span']/..")]
        public IWebElement BondTypeText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'_ProductId')]")]
        public IWebElement ProductTypeBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'_ProductName')]")]
        public IWebElement ProductTypeViewBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@id='lkpDepotIdWrapper']//span[@class='dx-button-text'])[1]")]
        public IWebElement DepotSearchCancelBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@id='lkpCusTxnTransferTypeIdWrapper']//span[@class='dx-button-text'])[2]")]
        public IWebElement TransferTypeSearchClearBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@id='lkpDepotIdWrapper']//span[@class='dx-button-text'])[2]")]
        public IWebElement DepotSearchClearBtn { get; set; }
    }
}
