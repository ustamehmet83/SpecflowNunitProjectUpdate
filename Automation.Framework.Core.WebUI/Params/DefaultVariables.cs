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


        public string getReport => Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\Result\\Report";
                                    //+ DateTime.Now.ToString("yyyyMMdd HHmmss") + "\\log.txt";        
        public string getLog=>getReport + "\\log.txt";
        public string getExtentReport=>getReport + "\\index.html";       
        public string getFrameworkSettingsjson=> Directory
                    .GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName + "\\Resources\\frameworkSettings.json";         
        public string getApplicationConfigjson => Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName + "\\Resources\\applicationConfig.json";
        public string gridhuburl=> "https://localhost:4444/wd/hub";       
        public string dataSetLocation => Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory + "../../../").FullName + "\\DataSetLocation";
    }
}
