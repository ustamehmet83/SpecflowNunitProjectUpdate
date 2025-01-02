using Automation.Framework.Core.WebUI.Abstractions;
using Microsoft.Extensions.Configuration;

namespace Automation.Framework.Core.WebUI.Configuration
{
    public class ConfigurationReader : IConfigurationReader
    {
        IConfiguration _iconfiguration;
        IDefaultVariables _idefaultVariables;
        public ConfigurationReader(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
            _iconfiguration = new ConfigurationBuilder().AddJsonFile(_idefaultVariables.getApplicationConfigjson).Build();
        }


        public string GetConfiguration(string key)
        {
            
            return _iconfiguration[key];
        }


        public static string GetJsonConfigurationValue(string key)
        {
            

            string path = Directory
                   .GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName + "\\Resources\\applicationConfig.json";
            var builder = new ConfigurationBuilder().AddJsonFile(path).Build();

            return builder[key];
        }

        public static string GetJsonConfigurationFrameWorkValue(string key)
        {
            
            string path = Directory
                    .GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName + "\\Resources\\frameworkSettings.json";
            var builder = new ConfigurationBuilder().AddJsonFile(path).Build();

            return builder[key];
        }
    }
}
