﻿using Automation.Framework.Core.WebUI.Abstractions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.WebElements
{
    public class AtBy : IAtBy
    {

        public By by { get; set; }
    }
}
