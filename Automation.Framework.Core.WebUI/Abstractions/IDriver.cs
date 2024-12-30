using OpenQA.Selenium;

namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IDriver
    {
        IWebDriver GetWebDriver();
        void CloseBrowser();
        void NavigateTo(string url);
        string GetPageTitle();
        void GetNewTab();
        void CloseCurrentBrowser();
        void SwitchToWindowWithHandle(string handle);
        void SwitchToWindowWithTitle(string title);
        void SwitchToFrameWithName(string frameName);
        void Maximize();
        void ExecuteJavaScript(string script);
        void ScrollWithPixel();
        void ScrollByheight();
        string GetScreenShot();
    }
}
