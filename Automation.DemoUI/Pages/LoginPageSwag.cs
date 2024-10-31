using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.DemoUI.Configuration;
using Automation.Framework.Core.WebUI.Base;
using BoDi;
using Automation.Framework.Core.WebUI.DriverContext;

namespace Automation.DemoUI.Pages
{
    public class LoginPageSwag:TestBase,ILoginSwagPage
    {

      
        IConfigurationReader _iatConfiguration;
        IDriver _idrivers;

        IAtBy byUsername => GetBy(LocatorType.XPath, "//input[@id='user-name']");      
        IAtWebElement UserName => _idrivers.FindElement(byUsername);
        IAtBy byPassword=> GetBy(LocatorType.XPath, "//input[@id='password']");
        IAtWebElement Password => _idrivers.FindElement(byPassword);      
        IAtBy byLogin => GetBy(LocatorType.XPath, "//input[@id='login-button']");
        IAtWebElement Login => _idrivers.FindElement(byLogin);
        public LoginPageSwag(IConfigurationReader iatConfiguration, IDriver idrivers,IObjectContainer objectContainer):base(objectContainer)
        {
            _iatConfiguration = iatConfiguration;
            _idrivers = idrivers;

        }
        public void LoginWithValidCredentials(string username, string password)
        {
            string url = _iatConfiguration.GetConfiguration("url");        
            _idrivers.NavigateTo(url);
            Thread.Sleep(3000);
        
            UserName.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
        }

        public void LoginWithInvalidCredentials(string username, string password)
        {
            string url = _iatConfiguration.GetConfiguration("url");
            _idrivers.NavigateTo(url);
            Thread.Sleep(3000);
            UserName.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
        }





    }
}
