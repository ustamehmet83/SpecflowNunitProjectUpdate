using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Framework.Core.WebUI.Utilities
{
    public class CustomTrustManager
    {


        public bool CheckClientTrusted(X509Certificate[] certificates, string authType)
        {
            // Add logic here if needed
            return true;
        }

        public bool CheckServerTrusted(X509Certificate[] certificates, string authType)
        {
            // Add logic here if needed
            return true;
        }

        public X509Certificate[] GetAcceptedIssuers()
        {
            return new X509Certificate[0];
        }
    }
}
