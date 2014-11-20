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
using System.Collections;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.Client;
using System.Web;
using TFS.Library.Models;
using System.Web.Caching;
using Microsoft.TeamFoundation.Server;
using System.Configuration;
using System.Security.Principal;
using Microsoft.TeamFoundation.Framework.Client;
using TFS.Library.Data;
using Microsoft.TeamFoundation.Framework.Common;
using System.Net;

namespace TFS.Library.Tfs
{
    public class TfsServices : ITfsServices
    {
        private Dictionary<string, User> _userLookup;
        private TfsTeamProjectCollection _tfs;
        private User _currentUser;
        private string _reportUrl = string.Empty;

        public const string ItemFields = "[System.Id],[System.Rev],[System.Title],[System.State],[System.CreatedDate],[System.AssignedTo],[System.ChangedDate],[System.ChangedBy],[System.WorkItemType],[System.TeamProject],[System.IterationPath]";

        public TfsServices()
        {
            try
            {
                if (HttpContext.Current.Session["User"] == null)  //!WindowsIdentity.GetCurrent().IsAuthenticated)
                {
                    throw new UnauthorizedAccessException();
                }

                string userName = (string)HttpContext.Current.Session["User"]; //WindowsIdentity.GetCurrent().Name;
                string password = (string)HttpContext.Current.Session["Password"];
                string domain = (string)HttpContext.Current.Session["Domain"];
                var uri = TfsTeamProjectCollection.GetFullyQualifiedUriForName(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["tfsServer"]].ConnectionString);
                //TfsTeamProjectCollection baseUserTpcConnection = new TfsTeamProjectCollection(uri);
                //IIdentityManagementService ims = baseUserTpcConnection.GetService<IIdentityManagementService>();

                //// Read out the identity of the user we want to impersonate
                //TeamFoundationIdentity identity = ims.ReadIdentity(IdentitySearchFactor.AccountName, "ngoc",
                //    MembershipQuery.None, ReadIdentityOptions.None);

                NetworkCredential crediential = new NetworkCredential(
                    userName,// ConfigurationManager.AppSettings["tfsUser"],
                   password,//  ConfigurationManager.AppSettings["tfsPwd"],
                    domain// ConfigurationManager.AppSettings["tfsDomain"]
                    );
                _tfs = new TfsTeamProjectCollection(
                    uri, crediential);
                _tfs.EnsureAuthenticated();
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }
        }

        public WorkItemCollection ExecuteQuery(string project, Guid queryId)
        {
            Hashtable context = new Hashtable();
            context.Add("project", project);
            WorkItemStore workItemStore = this.GetService<WorkItemStore>();
            QueryDefinition qd;

            try
            {
                qd = workItemStore.GetQueryDefinition(queryId);
            }
            catch (ArgumentException)
            {
                //Weird bug in the TFS API, queries stored in TFS2008 cannot be accessed
                //using the new 2010 API, must use the old deprecated method.
                StoredQuery storedQ = workItemStore.GetStoredQuery(queryId);
                return workItemStore.Query(storedQ.QueryText, context);
            }


            switch (qd.QueryType)
            {
                case QueryType.OneHop:
                    goto case QueryType.Tree;
                case QueryType.Tree:
                    BatchReadParameterCollection batch = new BatchReadParameterCollection();
                    Query q = new Query(workItemStore, qd.QueryText, context);
                    WorkItemLinkInfo[] links = q.RunLinkQuery();
                    if (links.Length == 0)
                    {
                        return null;
                    }
                    foreach (WorkItemLinkInfo lnk in links)
                    {
                        //The root leafs have an empty source, we ignore childs
                        if (lnk.SourceId > 0)
                        {
                            continue;
                        }
                        if (!batch.Contains(lnk.TargetId))
                        {
                            batch.Add(new BatchReadParameter(lnk.TargetId));
                        }
                    }

                    return workItemStore.Query(batch, "SELECT [System.Id], [System.Title] FROM WorkItems");
                default:
                    return workItemStore.Query(qd.QueryText, context);
            }
        }

        public WorkItemCollection ExecuteQuery(string project, string query)
        {
            //Hashtable context = new Hashtable();
            //context.Add("project", project);
            WorkItemStore workItemStore = this.GetService<WorkItemStore>();
            // QueryDefinition qd;


            BatchReadParameterCollection batch = new BatchReadParameterCollection();
            //Query q = new Query(workItemStore, qd.QueryText, context);
            //WorkItemLinkInfo[] links = q.RunLinkQuery();
            //if (links.Length == 0)
            //{
            //    return null;
            //}
            //foreach (WorkItemLinkInfo lnk in links)
            //{
            //    //The root leafs have an empty source, we ignore childs
            //    if (lnk.SourceId > 0)
            //    {
            //        continue;
            //    }
            //    if (!batch.Contains(lnk.TargetId))
            //    {
            //        batch.Add(new BatchReadParameter(lnk.TargetId));
            //    }
            //}

            return workItemStore.Query(batch, query);
        }

        public IList<string> GetProjectContributors(string tfsProject)
        {
            string cacheKey = tfsProject + "-GetProjectContributors";
            IList<string> contributors = HttpRuntime.Cache[cacheKey] as IList<string>;
            if (contributors == null)
            {
                contributors = Enumerable.Select<KeyValuePair<string, User>, string>(Enumerable.OrderBy<KeyValuePair<string, User>, string>(this.GetProjectContributorsLookup(tfsProject), delegate(KeyValuePair<string, User> l)
                {
                    return l.Key;
                }), delegate(KeyValuePair<string, User> l)
                {
                    return l.Key;
                }).ToList<string>().AsReadOnly();
                HttpRuntime.Cache.Add(cacheKey, contributors, null, DateTime.Now.AddHours(1.0), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            }
            return contributors;
        }

        private Dictionary<string, User> GetProjectContributorsLookup(string tfsProject)
        {
            string cacheKey = tfsProject + "-GetProjectContributorsLookup";
            Dictionary<string, User> contributors = HttpRuntime.Cache[cacheKey] as Dictionary<string, User>;
            if (contributors == null)
            {
                contributors = new Dictionary<string, User>();
                Project project = this.GetService<WorkItemStore>().Projects[tfsProject];
                IGroupSecurityService sec = this.GetService<IGroupSecurityService>();
                string groupName = string.Format(@"[{0}]\Contributors", tfsProject);
                Identity contributorsGroup = sec.ReadIdentity(SearchFactor.AccountName, groupName, QueryMembership.Expanded);
                if (contributorsGroup == null)
                {
                    throw new Exception("Could not read group: " + groupName);
                }
                if (contributorsGroup.Members == null)
                {
                    throw new Exception("Members of group " + groupName + " is NULL");
                }
                foreach (string memberSid in contributorsGroup.Members)
                {
                    Identity memberInfo = sec.ReadIdentity(SearchFactor.Sid, memberSid, 0);
                    if (((memberInfo.Type == IdentityType.WindowsUser) && !memberInfo.Deleted) && !contributors.ContainsKey(memberInfo.DisplayName))
                    {
                        contributors.Add(memberInfo.DisplayName, new User(memberInfo.DisplayName, memberInfo.AccountName, memberInfo.Domain));
                    }
                }
                HttpRuntime.Cache.Add(cacheKey, contributors, null, DateTime.Now.AddHours(1.0), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
            }
            return contributors;
        }

        public Project[] GetProjectsWithWorkItemType(params string[] witNames)
        {
            ArrayList projs = new ArrayList();
            WorkItemStore workItemStore = GetService<WorkItemStore>();
            foreach (Project proj in workItemStore.Projects)
            {
                if (!proj.HasWorkItemReadRights)
                {
                    continue;
                }
                bool failedToFindType = false;
                foreach (string witName in witNames)
                {
                    if (!proj.WorkItemTypes.Contains(witName))
                    {
                        failedToFindType = true;
                        break;
                    }
                }
                if (!failedToFindType)
                {
                    projs.Add(proj);
                }
            }
            return (Project[])projs.ToArray(typeof(Project));
        }

        public QueryHierarchy GetQueries(string project)
        {
            Hashtable context = new Hashtable();
            return GetService<WorkItemStore>().Projects[project].QueryHierarchy;
        }

        public T GetService<T>()
        {
            return (T)this.Server.GetService(typeof(T));
        }

        public string GetTeamProjectProperty(string teamProject, string property)
        {
            IRegistration reg = GetService<IRegistration>();
            RegistrationEntry[] entries = reg.GetRegistrationEntries("TeamProjects");

            foreach (RegistrationEntry entry in entries)
            {
                foreach (ServiceInterface sInterface in entry.ServiceInterfaces)
                {
                    if (String.Compare(sInterface.Name, String.Format("{0}:{1}", teamProject, property), true) == 0)
                    {
                        return sInterface.Url;
                    }
                }
            }

            return null;
        }

        public string ReportWebServiceUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_reportUrl))
                {
                    IRegistration reg = GetService<IRegistration>();
                    RegistrationEntry[] entries = reg.GetRegistrationEntries("Reports");

                    foreach (RegistrationEntry entry in entries)
                    {
                        foreach (ServiceInterface service in entry.ServiceInterfaces)
                        {
                            if (String.Compare(service.Name, "ReportWebServiceUrl", true) == 0)
                            {
                                _reportUrl = service.Url.Substring(0, service.Url.LastIndexOf('/'));
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(_reportUrl))
                            break;
                    }
                }
                return _reportUrl;
            }
        }

        public User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    IGroupSecurityService sec = GetService<IGroupSecurityService>();
                    Identity memberInfo = sec.ReadIdentity(SearchFactor.Sid, Server.AuthorizedIdentity.Descriptor.Identifier, 0);
                    _currentUser = new User(memberInfo.DisplayName, memberInfo.AccountName, memberInfo.Domain);
                }
                return _currentUser;
            }
        }

        private TfsTeamProjectCollection Server
        {
            get
            {
                return this._tfs;
            }
        }


        public User GetUser(string tfsProject, object displayNameObj)
        {
            string displayName = displayNameObj as string;
            if (!string.IsNullOrEmpty(displayName))
            {
                User user;
                if (this._userLookup == null)
                {
                    this._userLookup = this.GetProjectContributorsLookup(tfsProject);
                }
                if (this._userLookup.TryGetValue(displayName, out user))
                {
                    return user;
                }
            }
            return User.Empty;
        }

        public WorkItem GetWorkItem(int id)
        {
            return this.GetService<WorkItemStore>().GetWorkItem(id);
        }
        public WorkItem GetWorkItem(int id, int revision)
        {
            return this.GetService<WorkItemStore>().GetWorkItem(id, revision);
        }

        public T CreateItem<T>(WorkItem wi) where T : Item, new()
        {
            T bi = new T();
            bi.Id = wi.Id;
            bi.RevisionId = wi.Revision;
            bi.Title = wi.Title;
            bi.State = wi.State;
            bi.Created = wi.CreatedDate;
            bi.AssignedTo = GetUser(wi.GetTeamProject(), wi.Fields["System.AssignedTo"].Value);
            bi.Changed = wi.ChangedDate;
            bi.ChangedBy = wi.ChangedBy;
            bi.IterationPath = wi.Fields["System.IterationPath"].Value as string;
            bi.Project = wi.GetTeamProject();
            return bi;
        }

        public void ResolveProductBacklogId(BacklogItem item, WorkItem wi)
        {
            foreach (Link lnk in wi.Links)
            {
                RelatedLink rel = lnk as RelatedLink;
                if (rel == null)
                {
                    continue;
                }
                if (rel.LinkTypeEnd.ImmutableName == item.ProductBacklogLinkType)
                {
                    item.ProductBacklogId = rel.RelatedWorkItemId;
                    break;
                }
            }
        }

        public void Dispose()
        {
            if (_tfs != null)
            {
                _tfs.Dispose();
                _tfs = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}
