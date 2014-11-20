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
using System.Web.Caching;
using System.Web;
using System.Collections;
using TFS.Library.Data;

namespace TFS.Library.Tfs
{
    public class SprintBacklogTaskHandler
    {
        private ITfsServices _tfs;

        public SprintBacklogTaskHandler(ITfsServices tfs)
        {
            _tfs = tfs;
        }

      


        /// <summary>
        /// Load a single sprint backlog item
        /// </summary>
        /// <param name="workItemId"></param>
        /// <returns></returns>
        public SprintBacklogTask GetSprintBacklogTask(int workItemId)
        {
            WorkItem wi = _tfs.GetWorkItem(workItemId);
            return WorkItemToSprintBacklogTask(wi);
        }

        public SprintBacklogTask WorkItemToSprintBacklogTask(WorkItem sbiSource)
        {
            return WorkItemToSprintBacklogTask(sbiSource, null);
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
    }
}
