using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.WebAbstraction
{
    public interface IConfigurationReader
    {

        public string GetConfiguration(string key);
    }
}
