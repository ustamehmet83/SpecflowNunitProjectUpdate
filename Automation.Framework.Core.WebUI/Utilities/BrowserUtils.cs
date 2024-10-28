using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Utilities
{
    public class BrowserUtils
    {


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
