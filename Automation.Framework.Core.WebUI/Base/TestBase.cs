using Automation.Framework.Core.WebUI.Abstractions;
using Automation.Framework.Core.WebUI.WebElements;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Base
{
    public class TestBase
    {
        IObjectContainer _iobjectContainer;
        AtBy _atBy;
        private IObjectContainer objectContainer;

        public TestBase(IObjectContainer objectContainer) 
        {
            _iobjectContainer=objectContainer;
            _atBy = new AtBy();
        }

        public AtBy GetBy(LocatorType type, string value)
        {
            By by;
            IAtBy iatBy=_iobjectContainer.Resolve<IAtBy>();
            switch (type)
            {
                case LocatorType.XPath:
                    by = By.XPath(value);
                    break;
                case LocatorType.Css:
                    by = By.CssSelector(value);
                    break;
                case LocatorType.LinkText:
                    by = By.LinkText(value);
                    break;
                case LocatorType.Id:
                    by = By.Id(value);
                    break;
                case LocatorType.ClassName:
                    by = By.ClassName(value);
                    break;
                case LocatorType.TagName:
                    by = By.TagName(value);
                    break;
                case LocatorType.PartialLinkText:
                    by = By.PartialLinkText(value);
                    break;
                default:
                    by = By.Name(value);
                    break;
            }
            _atBy.By = by;

            return _atBy;

        }
    }
}
