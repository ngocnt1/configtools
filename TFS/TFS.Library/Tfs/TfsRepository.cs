/*
COPYRIGHT (C) 2010 EPISERVER AB

THIS FILE IS PART OF SCRUM DASHBOARD.

SCRUM DASHBOARD IS FREE SOFTWARE: YOU CAN REDISTRIBUTE IT AND/OR MODIFY IT UNDER THE TERMS OF 
THE GNU LESSER GENERAL PUBLIC LICENSE VERSION v2.1 AS PUBLISHED BY THE FREE SOFTWARE FOUNDATION.

SCRUM DASHBOARD IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, BUT WITHOUT ANY WARRANTY; WITHOUT
EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU LESSER
GENERAL PUBLIC LICENSE FOR MORE DETAILS.

YOU SHOULD HAVE RECEIVED A COPY OF THE GNU LESSER GENERAL PUBLIC LICENSE ALONG WITH SCRUM DASHBOARD. 
IF NOT, SEE <HTTP://WWW.GNU.ORG/LICENSES/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap;
using TFS.Library.Tfs;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
using TFS.Library.Data;

namespace TFS.Library.Tfs
{
    public class TfsRepository : IRepository
    {
        Container _container;
        private static object _initLock = new object();

        public TfsRepository()
        {
        }

        private void Init()
        {      
            TfsServices tfs = HttpRuntime.Cache["TfsServices-" + HttpContext.Current.User.Identity.Name] as TfsServices;
            if (tfs == null)
            {
                tfs = new TfsServices();
                HttpRuntime.Cache.Insert("TfsServices-" + HttpContext.Current.User.Identity.Name, tfs, null, Cache.NoAbsoluteExpiration, TimeSpan.FromMinutes(10), CacheItemPriority.High, null);
            }

            _container = new Container(x =>
            {
                x.For<IBacklogItemHandler>().Singleton().Use<BacklogItemHandler>();
                x.For<ISprintHandler>().Singleton().Use<SprintHandler>();
                x.For<ITeamSprintHandler>().Singleton().Use<TeamSprintHandler>();
                x.For<ITfsServices>().Singleton().Use(tfs);
                x.For<IProductBacklogItemHandler>().Singleton().Use<ProductBacklogItemHandler>();
                x.For<IProjectHandler>().Singleton().Use<ProjectHandler>();
            }
            );
        }

        public T GetHandler<T>()
        {
            LazyInit();
            return _container.GetInstance<T>();
        }

        private void LazyInit()
        {
            if (_container == null)
            {
                lock (_initLock)
                {
                    if (_container == null)
                    {
                        Init();
                    }
                }
            }
        }

        public Models.User CurrentUser { get { return GetHandler<TfsServices>().CurrentUser; } }
    }
}
