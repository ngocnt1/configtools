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
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Collections;
using TFS.Library.Data;

namespace TFS.Library.Tfs
{
    public class BacklogItemHandler : IBacklogItemHandler
    {
        public const string BacklogItemFields = TfsServices.ItemFields + ",[Scrum.v3.PlannedWork],[Scrum.v3.WorkRemaining]";

        private ITfsServices _tfs;

        public BacklogItemHandler(ITfsServices tfs)
        {
            _tfs = tfs;
        }

        public BacklogItem GetBacklogItem(int workItemId)
        {
            WorkItem wi = _tfs.GetWorkItem(workItemId);
            switch (wi.Type.Name)
            {
                case Scrum.WorkItemTypes.SprintBacklogTask:
                    return WorkItemToSprintBacklogTask(wi, null);
                case Scrum.WorkItemTypes.AcceptanceTest:
                    return WorkItemToAcceptanceTest(wi, null);
                case Scrum.WorkItemTypes.Impediment:
                    return WorkItemToImpediment(wi, null);
                case Scrum.WorkItemTypes.Bug:
                    return WorkItemToBug(wi, null);
            }
            throw new Exception("Unknown work item type: " + wi.Type.Name);
        }

        public IList<BacklogItem> GetBacklogItems(string tfsProject, string iterationPath)
        {
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();
            Hashtable context = new Hashtable();
            context.Add("project", tfsProject);
            context.Add("iterationPath", iterationPath);

            string wiql = @"SELECT [System.Id],[System.Links.LinkType], [System.WorkItemType]
                            FROM WorkItemLinks
                            WHERE [Source].[System.TeamProject] = @project AND [Source].[System.State] <> 'Descoped'
                            AND [Source].[System.IterationPath] UNDER @iterationPath
                            AND [Target].[System.WorkItemType] = 'Product Backlog Item'
                            ORDER BY [System.State] ASC,[Scrum.v3.TaskPriority] ASC,[System.CreatedDate] ASC mode(MustContain)";

            Query q = new Query(workItemStore, wiql, context, false);

            WorkItemLinkInfo[] links = q.RunLinkQuery();

            BatchReadParameterCollection batchRead = new BatchReadParameterCollection();
            Dictionary<int, int> workItemToPBI = new Dictionary<int, int>();

            foreach (WorkItemLinkInfo link in links)
            {
                if (link.SourceId == 0)
                {
                    continue;
                }
                if (!workItemToPBI.ContainsKey(link.SourceId))
                {
                    workItemToPBI.Add(link.SourceId, link.TargetId);
                    batchRead.Add(new BatchReadParameter(link.SourceId));
                }
            }

            string batchFields = "SELECT " + BacklogItemFields + " FROM WorkItems";
            Query batch = new Query(workItemStore, batchFields, batchRead);
            WorkItemCollection wic = batch.RunQuery();
            IList<BacklogItem> retval = new List<BacklogItem>(wic.Count);
            foreach (WorkItem wi in wic)
            {
                BacklogItem item;
                switch (wi.GetWorkItemType())
                {
                    case Scrum.WorkItemTypes.SprintBacklogTask:
                        item = WorkItemToSprintBacklogTask(wi, workItemToPBI[wi.Id]);
                        break;
                    case Scrum.WorkItemTypes.Impediment:
                        item = WorkItemToImpediment(wi, workItemToPBI[wi.Id]);
                        break;
                    case Scrum.WorkItemTypes.AcceptanceTest:
                        item = WorkItemToAcceptanceTest(wi, workItemToPBI[wi.Id]);
                        break;
                    case Scrum.WorkItemTypes.Bug:
                        item = WorkItemToBug(wi, workItemToPBI[wi.Id]);
                        break;
                    default:
                        continue;
                }
                retval.Add(item);
            }

            return retval;

        }

        public IList<BugItem> GetBugs(string tfsProject, string iterationPath)
        {
            Hashtable context = new Hashtable();
            context.Add("project", tfsProject);
            context.Add("iterationPath", iterationPath);
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();
            WorkItemCollection retVal;

            string q = "SELECT " + BacklogItemFields + ",[Scrum.v3.DevState] FROM WorkItems WHERE [System.TeamProject] = @project AND [System.WorkItemType]='Bug' AND [System.IterationPath] UNDER @iterationPath";

            retVal = workItemStore.Query(q, context);

            List<BugItem> items = new List<BugItem>();
            for (int i = 0; i < retVal.Count; i++)
            {
                WorkItem pbiSource = retVal[i];
                BugItem pbi = WorkItemToBug(pbiSource, null);
                if (pbi == null)
                {
                    continue;
                }
                items.Add(pbi);
            }

            return items;
        }
        /// <summary>
        /// Changes work remaining for a specific work item
        /// </summary>
        /// <param name="id">The work item ID</param>
        /// <param name="time">The time in hours</param>
        public void UpdateWorkRemaining(int id, float time)
        {
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();
            WorkItem wi = workItemStore.GetWorkItem(id);
            wi.Fields[Scrum.WorkRemaining].Value = time;
            wi.Save();
        }

        public int CreateBacklogItem(BacklogItem item)
        {
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();
            WorkItem workItem = BacklogToWorkItem(item, workItemStore);
            workItem.Save();

            return workItem.Id;
        }

        private static WorkItem BacklogToWorkItem(BacklogItem item, WorkItemStore workItemStore)
        {
            WorkItem parent = workItemStore.GetWorkItem(item.ProductBacklogId);
            WorkItemType wit;

            switch (item.BacklogType)
            {
                case BacklogItemType.SprintBacklogTask:
                    wit = parent.Project.WorkItemTypes[Scrum.WorkItemTypes.SprintBacklogTask];
                    break;
                case BacklogItemType.Impediment:
                    wit = parent.Project.WorkItemTypes[Scrum.WorkItemTypes.Impediment];
                    break;
                case BacklogItemType.AcceptanceTest:
                    wit = parent.Project.WorkItemTypes[Scrum.WorkItemTypes.AcceptanceTest];
                    break;
                case BacklogItemType.Bug:
                    wit = parent.Project.WorkItemTypes[Scrum.WorkItemTypes.Bug];
                    break;
                default:
                    throw new ArgumentOutOfRangeException("item", String.Format("Not support type: {0}", item.BacklogType));
            }

            WorkItem workItem = new WorkItem(wit);

            workItem.Title = item.Title;
            workItem.IterationPath = parent.IterationPath;
            workItem.Description = item.Description;

            if (!String.IsNullOrEmpty(parent.AreaPath))
            {
                workItem.AreaPath = parent.AreaPath;
            }

            if (item.BacklogType == BacklogItemType.SprintBacklogTask)
            {
                var task = (SprintBacklogTask)item;
                if (task.WorkRemaining == 0 && task.EstimatedEffort.HasValue && task.Id == 0)
                {
                    task.WorkRemaining = task.EstimatedEffort.Value;
                }
                workItem.Fields[Scrum.WorkRemaining].Value = task.WorkRemaining;
                workItem.Fields[Scrum.EstimatedEffort].Value = task.EstimatedEffort;
            }

            workItem.Links.Add(new RelatedLink(workItemStore.WorkItemLinkTypes.LinkTypeEnds[item.ProductBacklogLinkType], item.ProductBacklogId));
            return workItem;
        }

        /// <summary>
        /// Move work item into a new state
        /// </summary>
        /// <param name="workItemID"></param>
        /// <param name="state"></param>
        /// <remarks>Will throw an exception for invalid states</remarks>
        public bool MoveToState(int workItemID, string state, string assignedTo)
        {
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();

            WorkItem wi = workItemStore.GetWorkItem(workItemID);
            wi.State = state;
            if (!String.IsNullOrEmpty(assignedTo))
                wi.Fields["System.AssignedTo"].Value = assignedTo;
            ArrayList errors = wi.Validate();
            if (errors.Count == 0)
            {
                wi.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
        public BugItem WorkItemToBug(WorkItem wi, int? productBacklogId)
        {
            BugItem imp = _tfs.CreateItem<BugItem>(wi);
            imp.DevState = wi.Fields["Scrum.v3.DevState"].Value as string;
            if (productBacklogId.HasValue)
            {
                imp.ProductBacklogId = productBacklogId.Value;
            }
            else
            {
                _tfs.ResolveProductBacklogId(imp, wi);
            }

            return imp;
        }

        public AcceptanceTest WorkItemToAcceptanceTest(WorkItem wi, int? productBacklogId)
        {
            AcceptanceTest imp = _tfs.CreateItem<AcceptanceTest>(wi);

            if (productBacklogId.HasValue)
            {
                imp.ProductBacklogId = productBacklogId.Value;
            }
            else
            {
                _tfs.ResolveProductBacklogId(imp, wi);
            }

            return imp;
        }

        public Impediment WorkItemToImpediment(WorkItem wi, int? productBacklogId)
        {
            Impediment imp = _tfs.CreateItem<Impediment>(wi);

            if (productBacklogId.HasValue)
            {
                imp.ProductBacklogId = productBacklogId.Value;
            }
            else
            {
                _tfs.ResolveProductBacklogId(imp, wi);
            }

            return imp;
        }

        public SprintBacklogTask WorkItemToSprintBacklogTask(WorkItem sbiSource, int? productBacklogId)
        {
            SprintBacklogTask sbi = _tfs.CreateItem<SprintBacklogTask>(sbiSource);

            sbi.EstimatedEffort = sbiSource.Fields[Scrum.EstimatedEffort].Value != null ? (double)sbiSource.Fields[Scrum.EstimatedEffort].Value : (double?)null;
            sbi.WorkRemaining = sbiSource.Fields[Scrum.WorkRemaining].Value != null ? (double)sbiSource.Fields[Scrum.WorkRemaining].Value : 0;

            if (productBacklogId.HasValue)
            {
                sbi.ProductBacklogId = productBacklogId.Value;
            }
            else
            {
                _tfs.ResolveProductBacklogId(sbi, sbiSource);
            }

            return sbi;
        }


        public IEnumerable<BacklogItem> ImportWorkItemsToBacklog(int productBacklogId, BacklogItemType type, int[] workItemIds)
        {
            WorkItemStore store = _tfs.GetService<WorkItemStore>();
            List<WorkItem> toImport = new List<WorkItem>();
            foreach (int workItemId in workItemIds)
            {
                WorkItem wi = store.GetWorkItem(workItemId);

                BacklogItem task = BacklogItem.CreateType(type);
                task.ProductBacklogId = productBacklogId;
                task.Title = wi.Title;
                WorkItem workItem = BacklogToWorkItem(task, store);
                RelatedLink lnk = new RelatedLink(workItemId);
                lnk.Comment = "ImportedToScrumDashboard";
                workItem.Links.Add(lnk);

                toImport.Add(workItem);
            }

            BatchSaveError[] errors = store.BatchSave(toImport.ToArray());

            foreach (WorkItem wi in toImport)
            {
                yield return WorkItemToSprintBacklogTask(wi, productBacklogId);
            }
        }
    }
}
