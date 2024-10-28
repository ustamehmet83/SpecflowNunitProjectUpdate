using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.DemoUI.WebAbstraction
{
    public interface ILoginPage
    {

        public void LoginWithValidCredentials(string username, string password);
        public void LoginWithInvalidCredentials(string username, string password);
    }
}
