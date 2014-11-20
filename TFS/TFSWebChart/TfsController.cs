using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFS.Library.Data;
using TFSWebChart.Filters;

namespace TFSWebChart
{
    [TfsAuthorize]
    public class TfsController : Controller
    {
        protected readonly IRepository context;

        public TfsController()
            : this(RepositoryFactory.GetRespository())
        {
        }

        public TfsController(IRepository repo)
        {
            context = repo;
        }

    }
}