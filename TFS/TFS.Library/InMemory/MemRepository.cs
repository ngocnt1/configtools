﻿/*
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
using TFS.Library.Data;
using StructureMap;

namespace TFS.Library.InMemory
{
    public class MemRepository : IRepository
    {
        Container _container;

        public MemRepository()
        {
            _container = new Container(x =>
            {
                x.For<IProjectHandler>().Singleton().Use<MemProjectHandler>();
                x.For<IBacklogItemHandler>().Singleton().Use<MemBacklogItemHandler>();
                x.For<ISprintHandler>().Singleton().Use<MemSprintHandler>();
                x.For<ITeamSprintHandler>().Singleton().Use<MemTeamSprintHandler>();
                x.For<IProductBacklogItemHandler>().Singleton().Use<MemProductBacklogItemHandler>();
            }
          );
        }

        public T GetHandler<T>()
        {
            return _container.GetInstance<T>();
        }

        public Models.User CurrentUser
        {
            get { return new Models.User("Kalle Kule","kalle","domain"); }
        }
    }
}
