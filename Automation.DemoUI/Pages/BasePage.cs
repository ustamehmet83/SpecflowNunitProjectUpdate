using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Utilities;


namespace Automation.WebUI.Pages
{
    public abstract class BasePage : BrowserUtils
    {
        public BasePage(IDriver driver) : base(driver)
        {
        }
    }
}
