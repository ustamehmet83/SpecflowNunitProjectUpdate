using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IAtWebElement
    {
        void Click();
        void SendKeys(string text);
        void Set(IWebDriver iwebDriver, IAtBy iatBy, IObjectContainer iobjectContainer);
        void ClearText();
        string GetText();
        string GetAttribute(string attributeName);
        void MouseHover();
        bool IsDisplayed();
        void DoubleClick();
        void ClickWithJs();
        IWebElement GetElement();
        int NumberOfElement { get; }
    }
}
