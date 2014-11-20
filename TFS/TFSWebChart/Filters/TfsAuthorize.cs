using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace TFSWebChart.Filters
{
    public class TfsAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["User"]==null)
            {
                httpContext.Response.Redirect(System.Web.Security.FormsAuthentication.LoginUrl);
            }
            return base.AuthorizeCore(httpContext);
        }
    }
}