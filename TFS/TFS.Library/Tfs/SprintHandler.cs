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
using System.Web;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using TFS.Library.Models;
using System.Collections;
using System.Web.Caching;
using TFS.Library.Data;

namespace TFS.Library.Tfs
{
    public class SprintHandler : ISprintHandler
    {
        public const string SprintFields = TfsServices.ItemFields + ",[Scrum.v3.EstimatedEffort],[Scrum.v3.WorkRemaining],[Scrum.v3.SprintStart],[Scrum.v3.SprintEnd],[System.Description]";

        private ITfsServices _tfs;

        public SprintHandler(ITfsServices tfs)
        {
            _tfs = tfs;
        }

        /// <summary>
        /// Get all defined sprints in current project
        /// </summary>
        /// <returns></returns>
        public IList<Sprint> GetSprints(string tfsProject)
        {
            Hashtable context = new Hashtable();
            context.Add("project", tfsProject);
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();

            WorkItemCollection retVal = workItemStore.Query("SELECT " + SprintFields + " FROM WorkItem WHERE [System.TeamProject] = @project AND [System.WorkItemType]='Sprint' AND [System.State]<>'Deleted' ORDER BY [Scrum.v3.SprintStart] DESC,[System.CreatedDate] DESC", context);
            int resultCount = retVal.Count;
            IList<Sprint> sprints = new List<Sprint>();
            for (int i = 0; i < resultCount; i++)
            {
                WorkItem sprintSource = retVal[i];
                Sprint sprint = WorkItemToSprint(sprintSource);
                if (sprint == null)
                {
                    continue;
                }
                sprints.Add(sprint);
            }

            return sprints;
        }

        /// <summary>
        /// Get the workitem for a specific sprint number
        /// </summary>
        /// <param name="id">The sprint number</param>
        /// <returns>The work item representing the sprint</returns>
        public Sprint GetSprint(int id)
        {
            WorkItem wi = _tfs.GetWorkItem(id);
            Sprint sprint = WorkItemToSprint(wi);
            return sprint;
        }

        public Sprint WorkItemToSprint(WorkItem sprintSource)
        {
            // Do a smoke test for a property in v3 first so references
            // into older projects don't cause exceptions
            if (!sprintSource.Fields.Contains("Scrum.v3.ActualWorkStarts"))
                return null;

            Sprint sprint = _tfs.CreateItem<Sprint>(sprintSource);

            if (sprint.Title.StartsWith(sprint.Project))
            {
                sprint.Title = sprint.Title.Substring(sprint.Project.Length + 1);
            }

            sprint.SprintStart = sprintSource.Fields[Scrum.SprintStart].Value != null ? (DateTime)sprintSource.Fields[Scrum.SprintStart].Value : DateTime.Now;
            sprint.SprintEnd = sprintSource.Fields[Scrum.SprintEnd].Value != null ? (DateTime)sprintSource.Fields[Scrum.SprintEnd].Value : DateTime.Now;
            sprint.Goal = sprintSource.Description != null ? sprintSource.Description : "";

            return sprint;
        }
    }
}
