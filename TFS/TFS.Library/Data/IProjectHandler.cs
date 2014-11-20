using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Library.Models;

namespace TFS.Library.Data
{
    public interface IProjectHandler
    {
        IEnumerable<TeamProjectQuery> GetQueries(string projectName);
        IEnumerable<GenericWorkItem> RunQuery(string projectName, Guid queryId);
        WorkItemCollection RunQueryAll(string projectName, Guid queryId);
        WorkItemCollection RunQuery(string projectName, string query);
        System.Collections.Generic.IEnumerable<TFS.Library.Models.TeamProject> GetProjects();
        void SetIterationPath(int[] workItemId, string iterationPath);
    }
}
