using Automation.DemoUI.Configuration;
using Automation.DemoUI.Pages;
using Automation.Framework.Core.WebUI.Abstractions;
using FluentAssertions.Equivalency;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Steps
{
    [Binding]
    public class CalculatorTests : BaseTests
    {
        private readonly HomePage _loginPage;
        private readonly CalculatorPage _calculatorPage;
        private readonly IDriver _idriver;
        ScenarioContext _scenarioContext;
        public CalculatorTests(HomePage loginPage, IDriver idriver, ScenarioContext scenarioContext, CalculatorPage calculatorPage)
        {
            _loginPage = loginPage;
            _idriver = idriver;
            _scenarioContext = scenarioContext;
            _calculatorPage = calculatorPage;
        }

        [Given(@"I navigate to ""([^""]*)""")]
        public void GivenINavigateTo(string p0)
        {
            String url = ConfigurationReader.GetJsonConfigurationValue("url");
            _idriver.GetWebDriver().Navigate().GoToUrl(url);
        }

        [When(@"I click the search button at the top of the portal page")]
        public void WhenIClickTheSearchButtonAtTheTopOfThePortalPage()
        {
            _loginPage.searchBtn.Click();
        }

        [When(@"I enter ""([^""]*)"" into the search field")]
        public void WhenIEnterİntoTheSearchField(string googleCloudText)
        {
            _loginPage.searchInputBtn.SendKeys(googleCloudText + Keys.Enter);
        }

        [When(@"I click ""([^""]*)"" in the search results")]
        public void WhenIClickİnTheSearchResults(string p0)
        {
            _loginPage.WaitForVisibility(_loginPage.cloudPricingCalBtn);
            _loginPage.cloudPricingCalBtn.Click();
        }


        [When(@"I click COMPUTE ENGINE at the top of the page")]
        public void WhenIClickCOMPUTEENGINEAtTheTopOfThePage()
        {
            _loginPage.WaitForVisibilityClickableAndClick(_loginPage.addToEstimateBtn);
            _loginPage.WaitForVisibilityClickableAndClick(_loginPage.computeEngineAddBtn);
        }

        [When(@"I fill out the form with the following data:")]
        public void WhenIFillOutTheFormWithTheFollowingData(Table table)
        {
            var numberOfInstances = table.Rows
                .FirstOrDefault(row => row["Field"] == "Number of instances")?["Value"];
            var operatingSystemSoftware = table.Rows
                .FirstOrDefault(row => row["Field"] == "Operating System / Software")?["Value"];
            var provisioningModel = table.Rows
                .FirstOrDefault(row => row["Field"] == "VM Class")?["Value"];
            var machinetype = table.Rows
                .FirstOrDefault(row => row["Field"] == "Instance type")?["Value"];
            var numberOfGPUs = table.Rows
                .FirstOrDefault(row => row["Field"] == "Number of GPUs")?["Value"];
            var gpuModel = table.Rows
               .FirstOrDefault(row => row["Field"] == "GPU type")?["Value"];
            var localSSD = table.Rows
               .FirstOrDefault(row => row["Field"] == "Local SSD")?["Value"];
            var region = table.Rows
              .FirstOrDefault(row => row["Field"] == "Datacenter location")?["Value"];
            var commitUsage = table.Rows
              .FirstOrDefault(row => row["Field"] == "Committed usage")?["Value"];

            _calculatorPage.WaitForVisibilityClickableAndClick(_calculatorPage.numberOfInstanceInputBtn);
            _calculatorPage.numberOfInstanceInputBtn.Clear();
            _calculatorPage.numberOfInstanceInputBtn.Click();
            _calculatorPage.numberOfInstanceInputBtn.SendKeys(numberOfInstances);
            _calculatorPage.ScrollToElement(_calculatorPage.operatingSystemSoftwareBtn).Click();
            _calculatorPage.freeDebianBtns
                .FirstOrDefault(btn => btn.GetAttribute("textContent").Equals(operatingSystemSoftware))?.Click();
            _calculatorPage.ScrollToElement(_calculatorPage.ProvisioningModelRegularBtn(provisioningModel)).Click();
            _calculatorPage.ScrollToElement(_calculatorPage.machineTypeBtn).Click();
            _calculatorPage.machineTypesBtn
                .FirstOrDefault(btn => btn.GetAttribute("textContent").Equals(machinetype))?.Click();
            _calculatorPage.ScrollToElement(_calculatorPage.addGPUCheckBoxBtn).Click();
            _calculatorPage.WaitForVisibilityClickableAndClick(_calculatorPage.gpuModelBtn);
            _calculatorPage.gpuModelsBtn
                .FirstOrDefault(btn => btn.GetAttribute("textContent").Equals(gpuModel))?.Click();
            _calculatorPage.numberOfGPUsBtn.Click();
            _calculatorPage.numberOfGPUssBtn
                .FirstOrDefault(btn => btn.GetAttribute("textContent").Equals(numberOfGPUs))?.Click();
            _calculatorPage.ScrollToElement(_calculatorPage.localSSDBtn).Click();
            _calculatorPage.localSSDsBtn
                .FirstOrDefault(btn => btn.GetAttribute("textContent").Equals(localSSD))?.Click();
            _calculatorPage.ScrollToElement(_calculatorPage.regionBtn).Click();

            _calculatorPage.regionsBtn
                .FirstOrDefault(btn => btn.GetAttribute("textContent").Contains(region))?.Click();
            _calculatorPage.ScrollToElement(_calculatorPage.CommitUsage(commitUsage)).Click();
        }

        [When(@"I click more options")]
        public void WhenIClickMoreOptions()
        {
            _calculatorPage.ScrollToElement(_calculatorPage.moreOptionsBtn).Click();

        }


        [Then(@"the estimated data should be correct:")]
        public void ThenTheEstimatedDataShouldBeCorrect(Table table)
        {
            Thread.Sleep(1000);
            _calculatorPage.WaitForStaleWebElement(_calculatorPage.computeTotalPrice);

            string computeTotalPrice= _calculatorPage.computeTotalPrice.GetAttribute("textContent").Replace("$", "").Replace(",", "").Trim();
            double computeTotalPriceDouble = Double.Parse(computeTotalPrice);

            _scenarioContext.Add("computeTotalPriceDouble", computeTotalPriceDouble);
            _loginPage.WaitForVisibilityClickableAndClick(_calculatorPage.viewDetailsBtn);
            var provisioningModel = table.Rows
                .FirstOrDefault(row => row["Field"] == "VM Class")?["Expected Value"];
            var machinetype = table.Rows
                .FirstOrDefault(row => row["Field"] == "Instance type")?["Expected Value"];
            var region = table.Rows
              .FirstOrDefault(row => row["Field"] == "Region")?["Expected Value"];
            var localSSD = table.Rows
               .FirstOrDefault(row => row["Field"] == "Local SSD")?["Expected Value"];
            var commitUsage = table.Rows
              .FirstOrDefault(row => row["Field"] == "Commitment term")?["Expected Value"];

            string machineTypeText = _calculatorPage.instancesMachineType.GetAttribute("textContent");
            string provisioningModelText = _calculatorPage.instancesProvisioningModel.Text;
            string regiontext = _calculatorPage.instancesRegion.GetAttribute("textContent");
            string localSSDText = _calculatorPage.instancesLocalSSD.Text;
            string committedUseDiscountOptionstext = _calculatorPage.instancesCommittedUseDiscountOptions.Text;

            Assert.That(provisioningModelText, Is.EqualTo(provisioningModel));
            Assert.That(machinetype, Is.EqualTo(machineTypeText));
            Assert.That(region, Is.EqualTo(regiontext));
            Assert.That(localSSD, Is.EqualTo(localSSDText));
            Assert.That(commitUsage, Is.EqualTo(committedUseDiscountOptionstext));



        }

        [Then(@"the monthly rent should match the manual calculation result")]
        public void ThenTheMonthlyRentShouldMatchTheManualCalculationResult()
        {
            string machineTypePrice = _calculatorPage.instancesMachineTypePrice.GetAttribute("textContent").Replace("$", "").Replace(",", "").Trim(); 
            string numberOfGPUPrice = _calculatorPage.instancesNumberOfGPUPrice.GetAttribute("textContent").Replace("$", "").Replace(",", "").Trim(); 
            string localSSDPrice = _calculatorPage.instancesLocalSSDPrice.GetAttribute("textContent").Replace("$", "").Replace(",", "").Trim(); 
            string bootDiskSizePrice = _calculatorPage.instancesBootDiskSizePrice.GetAttribute("textContent").Replace("$", "").Replace(",", "").Trim(); 

            double machineTypePriceDouble = Double.Parse(machineTypePrice);
            double numberOfGPUPriceDouble = Double.Parse(numberOfGPUPrice);
            double localSSDPriceDouble = Double.Parse(localSSDPrice);
            double bootDiskSizePriceDouble = Double.Parse(bootDiskSizePrice);
            double totalPrice = machineTypePriceDouble + numberOfGPUPriceDouble + localSSDPriceDouble + bootDiskSizePriceDouble;
            Assert.That(totalPrice, Is.EqualTo(_scenarioContext["computeTotalPriceDouble"]));
        }
























    }
}
