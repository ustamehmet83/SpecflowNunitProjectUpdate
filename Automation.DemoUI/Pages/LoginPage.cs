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
    public class LoginPage:BasePage
    {
        public LoginPage(IDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "username")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='btn-login']/div/span")]
        public IWebElement LoginBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-danger alert-dismissible fade show']")]
        public IWebElement Alert { get; set; }

        public void Login(string userName, string passWord)
        {
            WaitForVisibilityClickableAndClickWithJS(Username);
            Username.SendKeys(userName);

            WaitForVisibilityClickableAndClickWithJS(Password);
            Password.SendKeys(passWord);

            LoginBtn.Click();
        }


    }
}
