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
    public abstract class BasePage : BrowserUtils
    {       
        public BasePage(IDriver driver) : base(driver)
        {
        }      
    }
}
