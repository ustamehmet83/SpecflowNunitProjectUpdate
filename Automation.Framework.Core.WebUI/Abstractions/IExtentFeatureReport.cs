namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IExtentFeatureReport
    {

        void InitiliazeExtentReport();
        AventStack.ExtentReports.ExtentReports GetExtentReport();
        void FlushExtent();
    }
}
