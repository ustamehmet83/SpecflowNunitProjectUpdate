using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IExtentFeatureReport
    {

        void InitiliazeExtentReport();
        AventStack.ExtentReports.ExtentReports GetExtentReport();
        void FlushExtent();
    }
}
