using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFS.Library.Data;
using TFSWebChart.Filters;

namespace TFSWebChart.Controllers
{
    [TfsAuthorize]
    public class ChartController : TfsController
    {
        //
        // GET: /Chart/
        public ActionResult Index()
        {
            HttpCookie project = Request.Cookies["project"];
            HttpCookie query = Request.Cookies["query"];
            if (project != null && query != null)
            {
                //string query = "SELECT [System.Id],[Microsoft.VSTS.Scheduling.RemainingWork],[Microsoft.VSTS.Scheduling.Effort], [System.Title] FROM WorkItems WHERE ";
                var items = context.GetHandler<IProjectHandler>().RunQueryAll(project.Value, new Guid(query.Value));
                return View(items.Cast<WorkItem>().ToArray());
            }

            //context.GetHandler<IProjectHandler>().RunQuery()
            return View();
        }

    }
}