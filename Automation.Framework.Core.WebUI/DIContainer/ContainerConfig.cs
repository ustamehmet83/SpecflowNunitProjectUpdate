using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.Params;
using Automation.Framework.Core.WebUI.Reports;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.DIContainer
{
    public class ContainerConfig
    {
        public static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDefaultVariables,DefaultVariables>();
            services.AddSingleton<ILogging,Logging>();
            services.AddSingleton<IGlobalProperties,GlobalProperties>();
            return services.BuildServiceProvider();
        }


    }
}
