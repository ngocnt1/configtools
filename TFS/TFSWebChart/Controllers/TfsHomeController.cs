using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFS.Library.Data;
using TFS.Library.Models;

namespace TFSWebChart.Controllers
{
    public class TfsHomeController : TfsController
    {
        //
        // GET: /TfsHome/
        public ActionResult Index()
        {
            return View();
        }

        #region Data
        public IEnumerable<TeamProject> Projects()
        {
            if (Session["Projects"] == null)
            {
                var query = context.GetHandler<IProjectHandler>();
                Session["Projects"] = query.GetProjects();
            }

            return Session["Projects"] as IEnumerable<TeamProject>;
        }
        #endregion

        public PartialViewResult TfsProjectsBox()
        {
            return PartialView(this.Projects());
        }

        public PartialViewResult TfsQueriesBox()
        {
            try
            {
                string project = Request.Cookies["project"] == null ? Projects().FirstOrDefault().Name : Request.Cookies["project"].Value;
                string ck = "Queries" + project;
                if (Session[ck] == null)
                {
                    var query = context.GetHandler<IProjectHandler>();
                    Session[ck] = query.GetQueries(project);
                }
                return PartialView(Session[ck]);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("",ex);
            }
            return PartialView();
        }
    }
}