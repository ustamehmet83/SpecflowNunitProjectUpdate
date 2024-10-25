using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Automation.DemoUI.Pages
{
    public class LoginPage
    {

        IWebDriver _iwebDriver;
        IWebElement UserName => _iwebDriver.FindElement(By.XPath("//input[@id='user-name']"));
        IWebElement Password => _iwebDriver.FindElement(By.XPath("//input[@id='password']"));
        IWebElement Login => _iwebDriver.FindElement(By.XPath("//input[@id='login-button']"));
        public LoginPage()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _iwebDriver = new ChromeDriver();
            _iwebDriver.Manage().Window.Maximize();
        }
        public void LoginWithValidCredentials(string username, string password)
        {
            _iwebDriver.Navigate().GoToUrl("https://www.saucedemo.com");
            Thread.Sleep(3000);

            UserName.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
        }

     



    }
}
