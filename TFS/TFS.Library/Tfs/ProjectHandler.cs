using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Library.Data;
using TFS.Library.Models;
using Microsoft.TeamFoundation.WorkItemTracking;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TFS.Library.Tfs
{
    class ProjectHandler : IProjectHandler
    {
        public static readonly string[] ScrumWorkItemTypes = new string[] { "Team Sprint", "Sprint Backlog Task" };
        ITfsServices _tfs;
        ITeamSprintHandler _teamSprints;

        public ProjectHandler(ITfsServices tfs, ITeamSprintHandler sprints)
        {
            _tfs = tfs;
            _teamSprints = sprints;
        }
        public IEnumerable<TeamProjectQuery> GetQueries(string projectName)
        {
            var queries = _tfs.GetQueries(projectName);

            string path = "";
            return GetAllQueries(queries, path);
        }

        private static IEnumerable<TeamProjectQuery> GetAllQueries(QueryFolder queries, string path)
        {
            List<TeamProjectQuery> list = new List<TeamProjectQuery>();
            foreach (var q in queries)
            {
                if (q is QueryDefinition)
                {
                    list.Add(new TeamProjectQuery { Title = path + q.Name, Id = q.Id });
                    continue;
                }
                if (q is QueryFolder)
                {
                    list.AddRange(GetAllQueries((QueryFolder)q, path + q.Name + "\\"));
                    continue;
                }
                
            }

            return list;
        }

        public IEnumerable<GenericWorkItem>  RunQuery(string projectName, Guid queryId)
        {
            WorkItemCollection wic = _tfs.ExecuteQuery(projectName, queryId);
            if (wic == null)
            {
                yield break;
            }
            foreach (WorkItem wi in wic)
            {
                yield return new GenericWorkItem { Id = wi.Id, Title = wi.Title, LinkedToActiveSprint=IsLinkedToActiveSprint(wi), WorkItemType=wi.GetWorkItemType() };
            }
        }
        public WorkItemCollection RunQuery(string projectName, string query)
        {
            return _tfs.ExecuteQuery(projectName, query);           
        }
        public WorkItemCollection RunQueryAll(string projectName, Guid queryId)
        {
            return _tfs.ExecuteQuery(projectName, queryId);
        }
        private bool IsLinkedToActiveSprint(WorkItem wi)
        {
            if(wi.RelatedLinkCount==0)
            {
                return false;
            }

            foreach(Link lnk in wi.Links)
            {
                RelatedLink relLink = lnk as RelatedLink;
                if(relLink!=null)
                {
                    int workItemId = relLink.RelatedWorkItemId;
                    WorkItem relatedWI = _tfs.GetWorkItem(workItemId);
                    if (relatedWI.GetWorkItemType() == "Sprint Backlog Task")
                    {
                        TeamSprint sprint = _teamSprints.GetTeamSprintByIteration(relatedWI.IterationId);
                        
                        if (sprint!=null && sprint.SprintStart < DateTime.Now && sprint.SprintEnd > DateTime.Now)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public IEnumerable<TeamProject> GetProjects()
        {
            IList<TeamProject> list = new List<TeamProject>();
            foreach (Project proj in _tfs.GetProjectsWithWorkItemType())
            {
                TeamProject teamProj = new TeamProject() { Name = proj.Name };
                list.Add(teamProj);
                foreach (string witName in ScrumWorkItemTypes)
                {
                    if (proj.WorkItemTypes.Contains(witName))
                    {
                        teamProj.IsScrumProject = true;
                        break;
                    }
                }
            }
            return list;
        }


        public void SetIterationPath(int[] workItemIds, string iterationPath)
        {
            WorkItemStore store = _tfs.GetService<WorkItemStore>();
            List<WorkItem> wis = new List<WorkItem>();

            foreach(int workItemId in workItemIds)
            {
                WorkItem wi = store.GetWorkItem(workItemId);
                wi.IterationPath = iterationPath;
                wis.Add(wi);
            }

            BatchSaveError[] errors = store.BatchSave(wis.ToArray());
            foreach (BatchSaveError error in errors)
            {
                throw error.Exception;//Will only throw first error, good enough
            }

        }
    }
}
