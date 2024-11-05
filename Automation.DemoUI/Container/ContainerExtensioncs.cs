using Automation.DemoUI.Pages;
using Automation.Framework.Core.WebUI.Abstractions;
using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Automation.DemoUI.Container;


public static class ContainerExtension
{
    /// <summary>
    /// BasePage'ten türeyen tüm class'ları DI'ya register eder
    /// </summary>
    /// <param name="container"></param>

    public static void RegisterTypes(this IObjectContainer container, params object[] args)
    {
        var typeOfBase = typeof(BasePage);

        var derivedTypes = typeOfBase.Assembly.GetTypes()
          .Where(t => typeOfBase.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);


        
        Parallel.ForEach(derivedTypes, derivedType =>
        {
            var obj = Activator.CreateInstance(derivedType, args);
            container.RegisterInstanceAs(obj);
        });
    }
}
