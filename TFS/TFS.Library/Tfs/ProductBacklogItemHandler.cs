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
using TFS.Library.Models;
using System.Collections;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Web;
using System.Web.Caching;
using TFS.Library.Data;

namespace TFS.Library.Tfs
{
    public class ProductBacklogItemHandler : IProductBacklogItemHandler
    {
        public const string ProductBacklogItemFields = TfsServices.ItemFields + ",[Scrum.v3.EstimatedEffort],[Scrum.v3.WorkRemaining],[Scrum.v3.BusinessValue],[Scrum.v3.DeliveryOrder],[System.Description],[Microsoft.VSTS.Scheduling.StoryPoints],[Niteco.Scheduling.UnplannedPoints]";

        private ITfsServices _tfs;

        public ProductBacklogItemHandler(ITfsServices tfs)
        {
            _tfs = tfs;
        }

        public IList<ProductBacklogItem> GetProductBacklogs(string tfsProject, string iterationPath)
        {
            Hashtable context = new Hashtable();
            context.Add("project", tfsProject);
            context.Add("iterationPath", iterationPath);
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();
            WorkItemCollection retVal;

            string q = "SELECT " + ProductBacklogItemFields + " FROM WorkItems WHERE [System.TeamProject] = @project AND [System.WorkItemType]='Product Backlog Item' AND [System.IterationPath] UNDER @iterationPath ORDER BY [Scrum.v3.BusinessValue] DESC,[Scrum.v3.DeliveryOrder] DESC";

            retVal = workItemStore.Query(q, context);

            List<ProductBacklogItem> items = new List<ProductBacklogItem>();
            for (int i = 0; i < retVal.Count; i++)
            {
                WorkItem pbiSource = retVal[i];
                ProductBacklogItem pbi = WorkItemToProductBacklogItem(pbiSource);
                if (pbi == null)
                {
                    continue;
                }
                items.Add(pbi);
            }

            return items;
        }

        public ProductBacklogItem WorkItemToProductBacklogItem(WorkItem pbiSource)
        {
            ProductBacklogItem pbi = _tfs.CreateItem<ProductBacklogItem>(pbiSource);

            pbi.BusinessValue = pbiSource.Fields[Scrum.BusinessValue].Value != null ? (int)pbiSource.Fields[Scrum.BusinessValue].Value : 0;
            pbi.DeliveryOrder = pbiSource.Fields[Scrum.DeliveryOrder].Value != null ? (int)pbiSource.Fields[Scrum.DeliveryOrder].Value : 0;
            pbi.StoryPoints = pbiSource.Fields[Scrum.StoryPoints].Value != null ? (double)pbiSource.Fields[Scrum.StoryPoints].Value : 0;
            pbi.UnplannedStoryPoints = pbiSource.Fields[Scrum.UnplannedStoryPoints].Value != null ? (double)pbiSource.Fields[Scrum.UnplannedStoryPoints].Value : 0;
            pbi.SprintBacklog = new List<SprintBacklogTask>();

            if (pbiSource.Description != null)
            {
                pbi.Description = pbiSource.Description;
            }

            if (pbiSource.Fields.Contains(Scrum.RemainStoryPoints))
            {
                pbi.WorkRemaining = pbiSource.Fields[Scrum.RemainStoryPoints].Value != null ? (double)pbiSource.Fields[Scrum.RemainStoryPoints].Value : 0;
            }

            if (pbiSource.Fields.Contains(Scrum.ConsumedPoints))
            {
                pbi.ConsumedPoints = pbiSource.Fields[Scrum.ConsumedPoints].Value != null ? (double)pbiSource.Fields[Scrum.ConsumedPoints].Value : 0;
            }

            return pbi;
        }

        public ProductBacklogItem GetProductBacklogItem(int id)
        {
            return GetProductBacklogItem(id, 0);
        }

        private ProductBacklogItem GetProductBacklogItem(int id, int revision)
        {
            WorkItem wi = revision > 0 ? _tfs.GetWorkItem(id, revision) : _tfs.GetWorkItem(id);
            return WorkItemToProductBacklogItem(wi);
        }

        public int CreateProductBacklogItem(ProductBacklogItem pbi)
        {
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();
            WorkItem workItem = BacklogToWorkItem(pbi, workItemStore);
            workItem.Save();
            return workItem.Id;
        }

        private static WorkItem BacklogToWorkItem(ProductBacklogItem item, WorkItemStore workItemStore)
        {
            WorkItemType wit = workItemStore.Projects[item.Project].WorkItemTypes[Scrum.WorkItemTypes.ProductBacklogItem];
            
            WorkItem workItem = new WorkItem(wit);

            workItem.Title = item.Title;
            workItem.IterationPath = item.IterationPath;
            workItem.Description = item.Description;
            workItem.Fields[Scrum.StoryPoints].Value = item.StoryPoints;
            workItem.Fields[Scrum.UnplannedStoryPoints].Value = item.UnplannedStoryPoints;
            return workItem;
        }


    }
}
