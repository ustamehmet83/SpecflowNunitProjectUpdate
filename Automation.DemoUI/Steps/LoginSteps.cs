using Automation.DemoUI.Pages;
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
        LoginPage loginPage;
        public LoginSteps()
        {
            loginPage = new LoginPage();
        }

        [Given(@"login with valid credentials")]
        public void GivenLoginWithValidCredentials()
        {
            loginPage.LoginWithValidCredentials("standard_user", "secret_sauce");
        }



        [Given(@"login with invalid credentials")]
        public void GivenLoginWithİnvalidCredentials()
        {
            loginPage.LoginWithValidCredentials("standard", "sceret_sauce");
        }



    }

}
