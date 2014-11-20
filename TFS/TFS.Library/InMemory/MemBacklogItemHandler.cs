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
    class MemBacklogItemHandler : IBacklogItemHandler
    {
        IList<BacklogItem> _tasks = new List<BacklogItem>();
        IList<BugItem> _bugs = new List<BugItem>();
        static MemBacklogItemHandler()
        {
        }

        public int CreateBacklogItem(Models.BacklogItem item)
        {
            item.Id = _tasks.Count+1;
            switch (item.BacklogType)
            {
                case BacklogItemType.AcceptanceTest:
                    item.State = "Not Implemented";
                    break;
                case BacklogItemType.Impediment:
                    item.State = "Open";
                    break;
                case BacklogItemType.SprintBacklogTask:
                    item.State = "Not Started";
                    break;
                case BacklogItemType.Bug:
                    item.State = "Active";
                    break;
            }
            item.AssignedTo = User.Empty;
            _tasks.Add(item);
            return item.Id;
        }

        public IList<Models.BacklogItem> GetBacklogItems(string tfsProject, string iterationPath)
        {
            return _tasks;
        }
        public IList<Models.BugItem> GetBugs(string tfsProject, string iterationPath)
        {
            return _bugs;
        }
        public Models.BacklogItem GetBacklogItem(int workItemId)
        {
            return (from t in _tasks where t.Id == workItemId select t).FirstOrDefault();
        }

        public bool MoveToState(int id, string state, string assignedTo)
        {
            BacklogItem bl = GetBacklogItem(id);
            bl.State = state;
            bl.AssignedTo = new User("Kalle Kule", "kalle", "domain");
            return true;
        }


        public void UpdateWorkRemaining(int id, float time)
        {
            ((SprintBacklogTask)GetBacklogItem(id)).WorkRemaining = time;
        }


        public IEnumerable<BacklogItem> ImportWorkItemsToBacklog(int productBacklogId, BacklogItemType type, int[] workItemIds)
        {
            foreach (int workItemId in workItemIds)
            {
                BacklogItem item = BacklogItem.CreateType(type);
                item.ProductBacklogId = productBacklogId;
                item.Title = "ImportedTask - " + workItemId.ToString();
                CreateBacklogItem(item);
                yield return item;
            }
        }
    }
}
