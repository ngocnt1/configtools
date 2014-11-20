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
using System.Web;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System.Web.Caching;
using TFS.Library.Data;

namespace TFS.Library.Tfs
{
    public class TeamSprintHandler : ITeamSprintHandler
    {
        public const string TeamSprintFields = TfsServices.ItemFields + ",[Scrum.v3.PlannedWork],[Scrum.v3.WorkRemaining],[Scrum.v3.SprintStart],[Scrum.v3.SprintEnd],[System.Description]";

        private ITfsServices _tfs;

        public TeamSprintHandler(ITfsServices tfs)
        {
            _tfs = tfs;
        }


        /// <summary>
        /// Get all defined team sprints in current project
        /// </summary>
        /// <returns></returns>
        public IList<TeamSprint> GetTeamSprints(string tfsProject, int sprintNumber)
        {
            Hashtable context = new Hashtable();
            context.Add("project", tfsProject);
            
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();

            string wiql = String.Format(@"SELECT {0} FROM WorkItemLinks
                WHERE ([Source].[System.TeamProject] = @project)  And  ([Source].[System.WorkItemType] = 'Team Sprint')
                    And ([System.Links.LinkType] = 'Scrum.ImplementedBy-Reverse') 
                    And ([Target].[System.Id] = {1}) 
                ORDER BY [System.Id] 
                mode(MustContain)", TeamSprintFields, sprintNumber, tfsProject);

            Query q = new Query(workItemStore, wiql, context);
            WorkItemLinkInfo[] retVal = q.RunLinkQuery();
            BatchReadParameterCollection batchRead = new BatchReadParameterCollection();
            IList<TeamSprint> sprints = new List<TeamSprint>();
            for (int i = 0; i < retVal.Length; i++)
            {
                if (retVal[i].TargetId != sprintNumber || retVal[i].SourceId == 0)
                {
                    continue;
                }

                batchRead.Add(new BatchReadParameter(retVal[i].SourceId));
            }

            Query batch = new Query(workItemStore,"SELECT " + TeamSprintFields + " FROM WorkItems",batchRead);
            WorkItemCollection wic = batch.RunQuery();
            foreach (WorkItem sprintSource in wic)
            {                
                if (!sprintSource.Fields.ContainsValueFor(Scrum.SprintStart))
                {
                    // filter beta 2 projects
                    continue;
                }


                TeamSprint sprint = WorkItemToTeamSprint(sprintSource);
                if (sprint == null)
                {
                    continue;
                }
                sprints.Add(sprint);
            }
            
            return sprints;
        }

        /// <summary>
        /// Get the workitem for a specific team sprint number
        /// </summary>
        /// <param name="teamSprintNumber">The team sprint number</param>
        /// <returns>The work item representing the sprint</returns>
        public TeamSprint GetTeamSprint(int teamSprintNumber)
        {
            string cacheKey = "GetSprint-" + teamSprintNumber.ToString();
            WorkItem wi = _tfs.GetWorkItem(teamSprintNumber);
            TeamSprint sprint = WorkItemToTeamSprint(wi);
            return sprint;
        }

        public TeamSprint WorkItemToTeamSprint(WorkItem sprintSource)
        {
            TeamSprint sprint = _tfs.CreateItem<TeamSprint>(sprintSource);

            if (sprint.Title.IndexOf(@"\")>=0)
            {
                sprint.Title = sprint.Title.Substring(sprint.Title.LastIndexOf(@"\")+1);
            }

            sprint.SprintStart = sprintSource.Fields.ContainsValueFor(Scrum.SprintStart) ? (DateTime)sprintSource.Fields[Scrum.SprintStart].Value : DateTime.Now;
            sprint.SprintEnd = sprintSource.Fields.ContainsValueFor(Scrum.SprintEnd) ? (DateTime)sprintSource.Fields[Scrum.SprintEnd].Value : DateTime.Now;
            sprint.Goal = sprintSource.Description ?? "";

            return sprint;
        }

        public TeamSprint GetTeamSprintByIteration(int iterationId)
        {
            Hashtable context = new Hashtable();
            WorkItemStore workItemStore = _tfs.GetService<WorkItemStore>();

            WorkItemCollection retVal = workItemStore.Query("SELECT " + TeamSprintFields + " FROM WorkItem WHERE [System.IterationId]='" + iterationId.ToString() + "' AND [System.WorkItemType]='Team Sprint' AND [System.State]<>'Deleted' ORDER BY [Scrum.v3.SprintStart] DESC,[System.CreatedDate] DESC", context);
            int resultCount = retVal.Count;
            IList<Sprint> sprints = new List<Sprint>();
            for (int i = 0; i < resultCount; i++)
            {
                WorkItem sprintSource = retVal[i];
                TeamSprint sprint = WorkItemToTeamSprint(sprintSource);
                if (sprint == null)
                {
                    continue;
                }
                return sprint;
            }

            return null;
        }
    }
}
