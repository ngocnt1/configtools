using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Library.Data;
using TFS.Library.Models;

namespace TFS.Library.InMemory
{
    class MemProjectHandler : IProjectHandler
    {
        private IProductBacklogItemHandler _pbi;

        public MemProjectHandler(IProductBacklogItemHandler pbi)
        {
            _pbi = pbi;
        }

        public IEnumerable<Models.TeamProjectQuery> GetQueries(string projectName)
        {
            yield return new TeamProjectQuery { Id = Guid.NewGuid(), Title = "InMemoryQuery1 - " + projectName };
            yield return new TeamProjectQuery { Id = Guid.NewGuid(), Title = "InMemoryQuery2 - " + projectName };
        }

        public IEnumerable<Models.GenericWorkItem> RunQuery(string projectName, Guid queryId)
        {
            for (int i = 0; i < 100; i++)
            {
                yield return new GenericWorkItem { Id = i, Title = "InMemoryWI - " + i.ToString() + " - " + projectName, LinkedToActiveSprint = (i % 10) ==0, WorkItemType=((i % 2)==0 ? "Bug" : "Product Backlog Item") };
            }
        }

        public IEnumerable<Models.TeamProject> GetProjects()
        {
            yield return new TeamProject() { Name = "InMemoryScrumProj1", IsScrumProject = true };
            yield return new TeamProject() { Name = "InMemoryScrumProj2", IsScrumProject = true };
            yield return new TeamProject() { Name = "InMemoryOtherProj", IsScrumProject = false };
        }



        public void SetIterationPath(int[] workItemIds, string iterationPath)
        {
            foreach(int workItemId in workItemIds)
            {
                ProductBacklogItem pbi = _pbi.GetProductBacklogItem(workItemId);
                pbi.IterationPath = iterationPath;
            }
        }


        public Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItemCollection RunQuery(string projectName, string query)
        {
            throw new NotImplementedException();
        }


        public Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItemCollection RunQueryAll(string projectName, Guid queryId)
        {
            throw new NotImplementedException();
        }
    }
}
