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
using TFS.Library.Data;
using TFS.Library.Models;

namespace TFS.Library.InMemory
{
    class MemProductBacklogItemHandler : IProductBacklogItemHandler
    {
        private IList<ProductBacklogItem> _pb = new List<ProductBacklogItem>();

        public MemProductBacklogItemHandler()
        {
            _pb.Add(new ProductBacklogItem() { Id = 1, Title="InMemoryPBI1", State="Not Started", Project="InMemory" });
            _pb.Add(new ProductBacklogItem() { Id = 2, Title = "InMemoryPBI2", State = "In Progress", Project = "InMemory" });
            _pb.Add(new ProductBacklogItem() { Id = 3, Title = "InMemoryPBI3", State = "Broken", Project = "InMemory" });
            _pb.Add(new ProductBacklogItem() { Id = 4, Title = "InMemoryPBI4", State = "Done", Project = "InMemory" });
        }

        public Models.ProductBacklogItem GetProductBacklogItem(int id)
        {
            return (from p in _pb where p.Id == id select p).FirstOrDefault();
        }

        public IList<Models.ProductBacklogItem> GetProductBacklogs(string tfsProject, string iterationPath)
        {
            return _pb;
        }

        public int CreateProductBacklogItem(ProductBacklogItem pbi)
        {
            pbi.Id = _pb.Count + 1;
            pbi.State = "Not Started";
            _pb.Add(pbi);
            return pbi.Id;
        }
    }
}
