using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IDefaultVariables
    {

        string getLog { get; }

        string getFrameworkSettingsjson { get; }

        string dataSetLocation { get; }

        string gridhuburl { get; }

        string getApplicationConfigjson { get; }


    }
}
