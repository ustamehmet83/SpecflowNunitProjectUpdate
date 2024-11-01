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
        private readonly IDriver _idriver;
        public LoginFeatureStepDefinitions(LoginPage loginPage, DashBoardPage dashBoardPage, IDriver idriver)
        {
            _loginPage = loginPage;
            _dashBoardPage = dashBoardPage;
            _idriver = idriver;         
        }


        [Given(@"kullanıcı netrex giris sayfasında olmalı")]
        public void GivenKullanıcıNetrexGirisSayfasındaOlmalı()
        {
            _idriver.GetWebDriver().Navigate().GoToUrl(ConfigurationReader.GetJsonConfigurationValue("url"));
        }

        [When(@"admin SOEID Yi girer passwordu girer ve login butonuna basar")]
        public void WhenAdminSOEIDYiGirerPassworduGirerVeLoginButonunaBasar()
        {
            _loginPage.Login(ConfigurationReader.GetJsonConfigurationValue("adminsoeid"),ConfigurationReader.GetJsonConfigurationValue("adminpassword"));
        }

        [Then(@"admin sağ üst köşede ""([^""]*)"" görmeli")]
        public void ThenAdminSağUstKosedeGormeli(string expectedName)
        {
            expectedName = ConfigurationReader.GetJsonConfigurationValue("adminsoeid").ToUpperInvariant();
            _loginPage.WaitForVisibilityClickableAndClickWithJS(_dashBoardPage.UserIcon);
            string actualStateMaker = _dashBoardPage.HeaderUserName.Text.Trim();
            Assert.That(actualStateMaker, Is.EqualTo(expectedName));
            string stateMakerAdmin = actualStateMaker;
            string stateMaker = actualStateMaker;
            string traderValue = actualStateMaker;

            ((IJavaScriptExecutor)_idriver.GetWebDriver()).ExecuteScript("$('#userPopup').dxPopup('hide');");
        }

        [When(@"kullanıcı SOEID Yi girer passwordu girer ve login butonuna basar")]
        public void WhenKullanıcıSOEIDYiGirerPassworduGirerVeLoginButonunaBasar()
        {
            _loginPage.Login(ConfigurationReader.GetJsonConfigurationValue("usersoeid"), ConfigurationReader.GetJsonConfigurationValue("userpassword"));
        }

        [Then(@"kullanıcı sağ üst köşede ""([^""]*)"" görmeli")]
        public void ThenKullanıcıSağUstKosedeGormeli(string expectedName)
        {
            expectedName = ConfigurationReader.GetJsonConfigurationValue("usersoeid").ToUpperInvariant();
            _loginPage.WaitForVisibilityClickableAndClickWithJS(_dashBoardPage.UserIcon);         
            string actualStateMaker = _dashBoardPage.HeaderUserName.Text.Trim();
            Assert.That(actualStateMaker, Is.EqualTo(expectedName));           
            string stateMakerAdmin = actualStateMaker;
            string stateMaker = actualStateMaker;
            string traderValue = actualStateMaker;

            ((IJavaScriptExecutor)_idriver.GetWebDriver()).ExecuteScript("$('#userPopup').dxPopup('hide');");
        }

        [When(@"kullanıcı geçersiz ""([^""]*)"" ve geçersiz ""([^""]*)"" girer")]
        public void WhenKullanıcıGecersizVeGecersizGirer(string userName, string password)
        {
            _loginPage.Login(userName, password);
        }

        [Then(@"kullanıcı ""([^""]*)"" mesajı görmeli")]
        public void ThenKullanıcıMesajıGormeli(string expectedText)
        {
            String actual = _loginPage.Alert.Text.Substring(_loginPage.Alert.Text.IndexOf("Error"));
            Assert.That(expectedText, Is.EqualTo(actual));
        }
    }
}
