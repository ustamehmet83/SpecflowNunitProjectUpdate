using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Params
{
    public class DefaultVariables
    {


        public string getReport
        {
            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName  + "\\Result\\Report"
                                    + DateTime.Now.ToString("yyyyMMdd HHmmss") + "\\log.txt";
            }
        }

        public string getLog
        {
            get {
               return  getReport + "\\log.txt";
            }
        }
    }
}
