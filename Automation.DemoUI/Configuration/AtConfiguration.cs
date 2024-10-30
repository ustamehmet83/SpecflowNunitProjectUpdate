using Automation.DemoUI.WebAbstraction;
using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Params;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.Configuration
{
    public class AtConfiguration:IAtConfiguration
    {
        IConfiguration _iconfiguration;
        IDefaultVariables _idefaultVariables;
        public AtConfiguration(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables= idefaultVariables;
             _iconfiguration = new ConfigurationBuilder().AddJsonFile(_idefaultVariables.getApplicationConfigjson).Build();


        }


        public string GetConfiguration(string key) {

            return _iconfiguration[key];



        }
    }
}
