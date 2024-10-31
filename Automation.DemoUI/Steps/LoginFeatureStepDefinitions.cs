using Automation.DemoUI.Configuration;
using Automation.DemoUI.Pages;
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Steps
{
    [Binding]
    public class LoginFeatureStepDefinitions:BaseTests
    {
        private readonly LoginPage _loginPage;
        private readonly DashBoardPage _dashBoardPage;
        private readonly IWebDriver _driver;
        public LoginFeatureStepDefinitions(LoginPage loginPage, IDriver driver, DashBoardPage dashBoardPage)
        {
            _loginPage = loginPage;
            _dashBoardPage = dashBoardPage;
            _driver = driver.GetWebDriver();
        }


        [Given(@"kullanıcı netrex giris sayfasında olmalı")]
        public void GivenKullanıcıNetrexGirisSayfasındaOlmalı()
        {
            _driver.Navigate().GoToUrl(ConfigurationReader.GetJsonConfigurationValue("url"));
        }

        [When(@"admin SOEID Yi girer passwordu girer ve login butonuna basar")]
        public void WhenAdminSOEIDYiGirerPassworduGirerVeLoginButonunaBasar()
        {
            _loginPage.Login(ConfigurationReader.GetJsonConfigurationValue("adminsoeid"),ConfigurationReader.GetJsonConfigurationValue("adminpassword"));
        }

        [Then(@"admin sağ üst köşede ""([^""]*)"" görmeli")]
        public void ThenAdminSağUstKosedeGormeli(string usersoeid)
        {
            
        }

        [When(@"kullanıcı SOEID Yi girer passwordu girer ve login butonuna basar")]
        public void WhenKullanıcıSOEIDYiGirerPassworduGirerVeLoginButonunaBasar()
        {
            _loginPage.Login(ConfigurationReader.GetJsonConfigurationValue("usersoeid"), ConfigurationReader.GetJsonConfigurationValue("userpassword"));
        }

        [Then(@"kullanıcı sağ üst köşede ""([^""]*)"" görmeli")]
        public void ThenKullanıcıSağUstKosedeGormeli(string expectedName)
        {
            expectedName = ConfigurationReader.GetJsonConfigurationValue("adminsoeid").ToUpperInvariant();
            _loginPage.WaitForVisibilityClickableAndClickWithJS(_dashBoardPage.UserIcon);         
            string actualStateMaker = _dashBoardPage.HeaderUserName.Text.Trim();
            Assert.That(actualStateMaker, Is.EqualTo(expectedName));           
            string stateMakerAdmin = actualStateMaker;
            string stateMaker = actualStateMaker;
            string traderValue = actualStateMaker;

            ((IJavaScriptExecutor)_driver).ExecuteScript("$('#userPopup').dxPopup('hide');");
        }

        [When(@"kullanıcı geçersiz ""([^""]*)"" ve geçersiz ""([^""]*)"" girer")]
        public void WhenKullanıcıGecersizVeGecersizGirer(string userName, string password)
        {
            _loginPage.Login(userName, password);
        }

        [Then(@"kullanıcı ""([^""]*)"" mesajı görmeli")]
        public void ThenKullanıcıMesajıGormeli(string expectedName)
        {
            expectedName = ConfigurationReader.GetJsonConfigurationValue("usersoeid").ToUpperInvariant();
            _loginPage.WaitForVisibilityClickableAndClickWithJS(_dashBoardPage.UserIcon);
            string actualStateMaker = _dashBoardPage.HeaderUserName.Text.Trim();
            Assert.That(actualStateMaker, Is.EqualTo(expectedName));
            string stateMakerAdmin = actualStateMaker;
            string stateMaker = actualStateMaker;
            string traderValue = actualStateMaker;

            ((IJavaScriptExecutor)_driver).ExecuteScript("$('#userPopup').dxPopup('hide');");
        }
    }
}
