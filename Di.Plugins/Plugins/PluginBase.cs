using EPiServer.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Di.Plugins.Plugins
{
    public class PluginBase : SystemPageBase
    {

        public override EPiServer.Security.AccessLevel RequiredAccess()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return EPiServer.Security.AccessLevel.FullAccess;
            }
            return EPiServer.Security.AccessLevel.NoAccess;
        }

        protected void CheckPermission(string securityCode)
        {
            if (string.Compare(WebConfigurationManager.AppSettings["SecurityCode"], securityCode, true) != 0)
            {
                throw new Exception("Please input correct security code.");
            }
        }
    }
}