using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TFS.Library.Data;
using TFS.Library.Tfs;

namespace TFSWebChart
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            
            RepositoryFactory.Container = new Container(x =>
            {
                x.For<IRepository>().Use<TfsRepository>();
                //x.For<IRepository>().HttpContextScoped().Use<MemRepository>();
            }
);
        }

      
        protected void Application_Error(object sender, EventArgs e)
        {

            if (Server.GetLastError() is UnauthorizedAccessException)
            {
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            }
        }

    }
}