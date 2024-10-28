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
        IAtConfiguration _iatConfiguration;
        public LoginSteps(IAtConfiguration iatConfiguration,IDriver idrivers, IObjectContainer objectContainer,ILoginPage iloginpage)
        {
            _iatConfiguration = iatConfiguration;
            _iloginPage = iloginpage;
            
            
        }

        [Given(@"login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            _iloginPage.LoginWithValidCredentials(_iatConfiguration.GetConfiguration("username"), _iatConfiguration.GetConfiguration("password"));
        }



        [Given(@"login with invalid credentials")]
        public void GivenLoginWithİnvalidCredentials()
        {
            _iloginPage.LoginWithInvalidCredentials("", "");
        }



    }

}
