using Automation.Framework.Core.WebUI.Abstractions;
using AventStack.ExtentReports.Reporter;

namespace Automation.Framework.Core.WebUI.Reports
{
    public class ExtentFeatureReport : IExtentFeatureReport
    {

        IDefaultVariables _idefaultVariables;
        AventStack.ExtentReports.ExtentReports extentReports;
        public ExtentFeatureReport(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
        }

        public void InitiliazeExtentReport()
        {
            ExtentHtmlReporter extentHtmlReporter = new ExtentHtmlReporter(_idefaultVariables.getExtentReport);
            extentReports = new AventStack.ExtentReports.ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        public AventStack.ExtentReports.ExtentReports GetExtentReport()
        {
            return extentReports;
        }

        public void FlushExtent()
        {
            extentReports.Flush();
        }
    }
}
