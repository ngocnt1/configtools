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
namespace TFS.Library.Tfs
{
    public interface ITfsServices
    {
        T CreateItem<T>(Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem wi) where T : TFS.Library.Models.Item, new();
        TFS.Library.Models.User CurrentUser { get; }
        void Dispose();
        Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItemCollection ExecuteQuery(string project, Guid queryId);
        Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItemCollection ExecuteQuery(string project, string query);
        System.Collections.Generic.IList<string> GetProjectContributors(string tfsProject);
        Microsoft.TeamFoundation.WorkItemTracking.Client.Project[] GetProjectsWithWorkItemType(params string[] witNames);
        Microsoft.TeamFoundation.WorkItemTracking.Client.QueryHierarchy GetQueries(string project);
        T GetService<T>();
        TFS.Library.Models.User GetUser(string tfsProject, object displayNameObj);
        Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem GetWorkItem(int id);
        Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem GetWorkItem(int id, int revision);
        void ResolveProductBacklogId(TFS.Library.Models.BacklogItem item, Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem wi);
        string ReportWebServiceUrl{get;}
        string GetTeamProjectProperty(string teamProject, string property);
    }
}
