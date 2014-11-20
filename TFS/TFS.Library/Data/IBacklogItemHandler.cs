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
using TFS.Library.Models;
using System.Collections.Generic;
namespace TFS.Library.Data
{
    public interface IBacklogItemHandler
    {
        int CreateBacklogItem(TFS.Library.Models.BacklogItem item);
        System.Collections.Generic.IList<TFS.Library.Models.BacklogItem> GetBacklogItems(string tfsProject, string iterationPath);
        TFS.Library.Models.BacklogItem GetBacklogItem(int workItemId);
        bool MoveToState(int workItemID, string state, string assignedTo);
        void UpdateWorkRemaining(int id, float time);
        IList<BugItem> GetBugs(string tfsProject, string iterationPath);
        System.Collections.Generic.IEnumerable<Models.BacklogItem> ImportWorkItemsToBacklog(int productBacklogId, BacklogItemType backlogType, int[] workItemId);
    }
}
