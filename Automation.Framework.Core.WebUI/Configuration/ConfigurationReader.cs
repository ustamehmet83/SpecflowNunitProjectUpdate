using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.Configuration
{
    public class ConfigurationReader:IAtConfiguration
    {
        IConfiguration _iconfiguration;
        public ConfigurationReader()
        {
            IDefaultVariables idefaultVariables=SpecflowRunner._iserviceProvider.GetRequiredService<IDefaultVariables>();
            _iconfiguration = new ConfigurationBuilder().AddJsonFile(idefaultVariables.getApplicationConfigjson).Build();


        }


        public string GetConfiguration(string key) {

            return _iconfiguration[key];



        }


        public static string GetJsonConfigurationValue(string key)
        {

            string path = System.IO.Directory
                   .GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName + "\\Resources\\applicationConfig.json";
            var builder = new ConfigurationBuilder().AddJsonFile(path).Build();

            return builder[key];
        }

        public static string GetJsonConfigurationFrameWorkValue(string key)
        {
            string path = System.IO.Directory
                    .GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName + "\\Resources\\frameworkSettings.json";
            var builder = new ConfigurationBuilder().AddJsonFile(path).Build();

            return builder[key];
        }
    }
}
