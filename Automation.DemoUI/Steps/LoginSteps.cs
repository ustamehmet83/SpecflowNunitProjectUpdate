using Automation.DemoUI.Configuration;
using Automation.DemoUI.Pages;
using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstractions;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Steps
{
    [Binding]
    public class LoginSteps
    {
        ILoginPage _iloginPage;
        
        public LoginSteps(IDriver idrivers,ILoginPage iloginpage)
        {
            
            _iloginPage = iloginpage;
            
            
        }

        [Given(@"login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _iloginPage.LoginWithValidCredentials(ConfigurationReader.GetJsonConfigurationValue("username"), ConfigurationReader.GetJsonConfigurationValue("password"));
        }



        [Given(@"login with invalid credentials")]
        public void GivenLoginWithİnvalidCredentials()
        {
            _iloginPage.LoginWithInvalidCredentials("", "");
        }



    }

}
