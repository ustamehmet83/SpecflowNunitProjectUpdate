using Automation.Framework.Core.WebUI.Abstractions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace Automation.WebUI.Pages
{
    public class CalculatorPage : BasePage
    {
        IWebDriver _driver;
        public CalculatorPage(IDriver driver) : base(driver)
        {
            _driver = driver.GetWebDriver();
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='c22']")]
        public IWebElement numberOfInstanceInputBtn;

        [FindsBy(How = How.XPath, Using = "//button[@jsname='DMn7nd' and @aria-label='Advanced settings']")]
        public IWebElement advancedSettingBtn;

        [FindsBy(How = How.XPath, Using = "//span[@id='c33']/following-sibling::div")]
        public IWebElement operatingSystemSoftwareBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@aria-label='Operating System / Software']/li")]
        public IList<IWebElement> freeDebianBtns;

        [FindsBy(How = How.XPath, Using = "//span[@id='c45']/following-sibling::div")]
        public IWebElement machineTypeBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@aria-label='Machine type']/li")]
        public IList<IWebElement> machineTypesBtn;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Add GPUs']//span[@class='eBlXUe-hywKDc']")]
        public IWebElement addGPUCheckBoxBtn;

        [FindsBy(How = How.XPath, Using = "//span[.='1' and @jsname='Fb0Bif']/../..//div[@class='VfPpkd-aPP78e']")]
        public IWebElement numberOfGPUsBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@aria-label='Number of GPUs']/li")]
        public IList<IWebElement> numberOfGPUssBtn;

        [FindsBy(How = How.XPath, Using = "//span[.='NVIDIA T4' and @jsname='Fb0Bif']/../..//div[@class='VfPpkd-aPP78e']")]
        public IWebElement gpuModelBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@aria-label='GPU Model']/li")]
        public IList<IWebElement> gpuModelsBtn;

        [FindsBy(How = How.XPath, Using = "//span[.='None' and @jsname='Fb0Bif']/../..//div[@class='VfPpkd-aPP78e']")]
        public IWebElement localSSDBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@aria-label='Local SSD']/li")]
        public IList<IWebElement> localSSDsBtn;

        [FindsBy(How = How.XPath, Using = "//span[.='Iowa (us-central1)' and @jsname='Fb0Bif']/../..//div[@class='VfPpkd-aPP78e']")]
        public IWebElement regionBtn;

        [FindsBy(How = How.XPath, Using = "//ul[@aria-label='Region']/li")]
        public IList<IWebElement> regionsBtn;

        [FindsBy(How = How.XPath, Using = "//input[@id='1161-year']/following-sibling::label")]
        public IWebElement commitUsage;

        [FindsBy(How = How.XPath, Using = "//i[.='more_vert']/../following-sibling::div")]
        public IWebElement moreOptionsBtn;

        [FindsBy(How = How.XPath, Using = "//span[.='View details' and @jsname='K4r5Ff']/../..")]
        public IWebElement viewDetailsBtn;

        [FindsBy(How = How.XPath, Using = "//div[.='Machine type' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesMachineType;

        [FindsBy(How = How.XPath, Using = "//div[.='GPU Model' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesGPUModel;

        [FindsBy(How = How.XPath, Using = "//div[.='Number of GPUs' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesNumbersOfGPUS;

        [FindsBy(How = How.XPath, Using = "//div[.='Local SSD' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesLocalSSD;

        [FindsBy(How = How.XPath, Using = "//div[.='Number of Instances' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesNumberOfInstances;

        [FindsBy(How = How.XPath, Using = "//div[.='Operating System / Software' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesOperatingSystemSoftware;

        [FindsBy(How = How.XPath, Using = "//div[.='Provisioning Model' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesProvisioningModel;

        [FindsBy(How = How.XPath, Using = "//div[.='Add GPUs' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesAddGPUs;

        [FindsBy(How = How.XPath, Using = "//div[.='Region' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesRegion;

        [FindsBy(How = How.XPath, Using = "//div[.='Committed use discount options' and @class='lr0LQ']/following-sibling::div")]
        public IWebElement instancesCommittedUseDiscountOptions;

        [FindsBy(How = How.XPath, Using = "//div[.='Machine type' and @class='lr0LQ']/../following-sibling::div")]
        public IWebElement instancesMachineTypePrice;

        [FindsBy(How = How.XPath, Using = "//div[.='Number of GPUs' and @class='lr0LQ']/../following-sibling::div")]
        public IWebElement instancesNumberOfGPUPrice;

        [FindsBy(How = How.XPath, Using = "//div[.='Local SSD' and @class='lr0LQ']/../following-sibling::div")]
        public IWebElement instancesLocalSSDPrice;

        [FindsBy(How = How.XPath, Using = "//div[.='Boot disk size (GiB)' and @class='lr0LQ']/../following-sibling::div")]
        public IWebElement instancesBootDiskSizePrice;

        [FindsBy(How = How.XPath, Using = "//div[.='Compute']/following-sibling::label")]
        public IWebElement computeTotalPrice;
        public IWebElement ProvisioningModelRegularBtn(string modelText)
        {
            return _driver.FindElement(By.XPath("//label[.='" + modelText + "']"));
        }
        public IWebElement CommitUsage(string commitUsageText)
        {
            return _driver.FindElement(By.XPath("//label[.='" + commitUsageText + "']"));
        }
    }
}
