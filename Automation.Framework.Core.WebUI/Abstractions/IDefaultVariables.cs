namespace Automation.Framework.Core.WebUI.Abstractions
{
    public interface IDefaultVariables
    {

        string getLog { get; }
        string getFrameworkSettingsjson { get; }

        string dataSetLocation { get; }

        string gridhuburl { get; }

        string getApplicationConfigjson { get; }

        string getExtentReport { get; }


    }
}
