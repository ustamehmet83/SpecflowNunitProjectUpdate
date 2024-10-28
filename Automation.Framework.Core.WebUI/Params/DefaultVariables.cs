using Automation.Framework.Core.WebUI.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Params
{
    public class DefaultVariables : IDefaultVariables
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

        public string getExtentReport
        {
            get
            {
                return getReport + "\\index.html";
            }
        }

        public string getFrameworkSettingsjson
        {
            get {

                return System.IO.Directory
                    .GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName + "\\Resources\\frameworkSettings.json";
 
            }
        }

        public string getApplicationConfigjson
        {
            get
            {

                return System.IO.Directory
                    .GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName + "\\Resources\\applicationConfig.json";


            }
        }

        public string gridhuburl
        {

            get {

                return "https://localhost:4444/wd/hub";
            }
        
        }

        public string dataSetLocation
        {

            get
            {
                return System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\DataSetLocation";
            
            }
        }
    }
}
