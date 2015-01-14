using EPiServer;
using EPiServer.Core;
using EPiServer.PlugIn;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bonnier.Core.Querying;
using Bonnier.Core.Common;
using EPiServer.Filters;
using System.Threading;
using EPiServer.DataAbstraction;
using System.Web.Hosting;
using EPiServer.Web.Hosting;
using EPiServer.Security;
using System.Diagnostics;
using EPiServer.UI;
using Di.Plugins.Plugins;
using log4net;
using Bonnier.Di.PageTypes;

namespace DagensNyheter.Plugins.RemoveSlaskContent
{
    [GuiPlugIn(DisplayName = "[Admin] Old sections clean up",
        Description = "Remove some old sections and content published in them",
        SortIndex = 0,
        Area = PlugInArea.AdminMenu,
        Url = "~/Plugins/PagesRemovingTool.aspx")]
    public partial class PagesRemovingTool : PluginBase
    {
        static bool IsProcessing;
        static int ProcessedCount = 0;
        static int ProcessedSectionsCount = 0;
        static double PagePerSec = 0;
        static int MaxNumberToDelete = 0;
        static List<int> Articles = new List<int>();
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            txtMaxItemToDelete.CssClass = "form-control input-sm";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                UpdateUI();
            }
        }


        void UpdateUI()
        {
            int totalItemsCount = TotalArticlesCount;
            pnlMaxNumber.Visible = !IsProcessing && totalItemsCount > 0;
            Timer1.Enabled = IsProcessing;
            //PlaceHolderRefreshScript.Visible = IsProcessing;
            btnLoad.Visible = !IsProcessing;
            //pnl.Visible = !IsProcessing;
            btnDelete.Visible = !IsProcessing && totalItemsCount > 0;
            btnCancel.Visible = IsProcessing;
            btnRefresh.Visible = IsProcessing;
            pnlProgress.Visible = IsProcessing;
            lbSpeed.Visible = IsProcessing;
            lbSpeed.Text = string.Format("Performance: {0:N1} pages/s", PagePerSec);
            lbRemainingArticles.Text = string.Format("{0}", totalItemsCount);
          // lbRemainingSections.Text = string.Format("{0}", Articles.Count);

            //rpt.DataSource = Articles;
            //rpt.DataBind();
        }

        int TotalArticlesCount
        {
            get
            {
                return Articles.Count - ProcessedCount;
            }
        }

        public string DeletingKey
        {
            get;
            private set;
        }
        #region Loading

        IEnumerable<int> OldSectionIds
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["OldSections"]) ?
                    ConfigurationManager.AppSettings["OldSections"].Split(',').Select(x => int.Parse(x)) : null;
            }
        }

        void LoadDescendants()
        {
            // tv.Nodes.Clear();
            var roots = OldSectionIds;
            IPageQueryHandler svc = ServiceLocator.Resolve<IPageQueryHandler>();

            //  SelectedSections = new Dictionary<string, int>();

            //if (roots != null)
            //{

            //    foreach (var id in roots)
            //    {
            //        var pref = new PageReference(id);
            //        PageData rootPage =null;
            //        try
            //        {
            //            rootPage = DataFactory.Instance.GetPage(pref);
            //        }
            //        catch (Exception)
            //        {
            //            continue;
            //        }

            //        if (rootPage != null)
            //        {
            var items = svc.QueryPages<ArticlePageData>()
                          .Where(x => x.Created)
                          .IsLesserOrEqual(DateTime.Now.AddYears(-1))
                          .UnCachedPageReferencesResult()
                          .Select(t=>t.ID);
            Articles.Clear();
            ProcessedCount = 0;
            Articles.AddRange(items);

            //foreach (var child in DataFactory.Instance.GetDescendents(pref))
            //{
            //    //TotalSectionCount += 1;
            //    var childPage = DataFactory.Instance.GetPage(child);

            //    count = svc.QueryPages<ArticlePageData>()
            //        .Where(x => x.SectionCore)
            //        .IsEqualTo(child)
            //        .UnCachedPageReferencesResult()
            //        .Count();

            //    if (count == 0)
            //    {
            //        continue;
            //    }

            //    SelectedSections.Add(childPage.PageName, count);
            //}
            //        }
            //    }

            //}

            UpdateUI();
        }
        #endregion

        #region Message
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        void ShowMessage(object msg)
        {
            if (msg is Exception)
            {
                ltMsgTile.Text = ((Exception)msg).Message;
                ltMsgContent.Text = ((Exception)msg).StackTrace;
                msgPane.Visible = true;
                msgPane.Attributes["class"] = "bs-callout bs-callout-warning";
            }
            else if (msg is string)
            {
                ltMsgTile.Text = "Message";
                ltMsgContent.Text = (string)msg;
                msgPane.Visible = !string.IsNullOrWhiteSpace(msg as string);
                msgPane.Attributes["class"] = "bs-callout bs-callout-success";
            }
        }
        void HideMessage()
        {
            msgPane.Visible = false;
        }
        #endregion

        #region Processed Counting

        public int ProcessedPercentage
        {
            get
            {
                double a = ProcessedCount + ProcessedSectionsCount;
                double b = MaxNumberToDelete;// TotalItemsCount;
                b = b == 0 ? 1 : b;
                var r = (int)Math.Round(a * 100 / b, 0);
                return r > 100 ? 100 : r;
            }
        }

        //public int Total { get { return } }

        #endregion

        #region Deleting Thread
        ILog log = LogManager.GetLogger("migrationLogger");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageId"></param>
        private void DeletePage(PageReference pageId)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                //try
                //{
                var page = DataFactory.Instance.GetPage(pageId);// as WebTvArticlePageData;

                if (page == null)
                {
                    return;
                }

                //var publishedVersions = PageVersion.ListPublishedVersions(pageId);
                //if (publishedVersions == null || publishedVersions.Count == 0)
                //{
                //var dir = page.GetPageDirectory(false);
                //if (dir != null)
                //{
                //    DeleteFolderRecursiveLy(dir);
                //    log.InfoFormat("Deleted VPP dir {3} for page [{0}] {1}, {2}.", page.PageTypeName, page.PageName, pageId, dir);
                //}
              //  Articles.Remove(pageId.ID);
                DataFactory.Instance.Delete(pageId, true, AccessLevel.NoAccess);

                log.InfoFormat("Deleted page [{0}] {1}, {2}.", page.PageTypeName, page.PageName, pageId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Stop();
                PagePerSec = 1 / sw.Elapsed.TotalSeconds;
            }
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex);
            //}
            //}
            //else
            //{
            //    CleanVersionVPP(page);
            //    CLeanPageVersions(page);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        //private void CLeanPageVersions(PageData page)
        //{
        //    var versions = PageVersion.List(page.PageLink).OrderBy(p => p.Saved).ToArray();
        //    int i = 0;
        //    while (i < versions.Count() - 2)
        //    {
        //        if (versions[i].Status != VersionStatus.Published
        //            && versions[i].Status != VersionStatus.PreviouslyPublished
        //            && versions[i].Status != VersionStatus.DelayedPublish)
        //        {
        //            DataFactory.Instance.DeleteVersion(versions[i].ID);
        //        }
        //        i++;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        private void CleanVersionVPP(PageData page)
        {
            try
            {
                return;
                // Get all file in page file of webtv page
                var pageDir = page.GetPageDirectory(false);
                if (pageDir != null)
                {
                    var flag = false;
                    foreach (VirtualFile file in pageDir.Files)
                    {
                        var versioningFile = file as VersioningFile;
                        // We have a file, check that the path points to a versioning file and not a native file
                        if (versioningFile == null)
                        {
                            //_log.Info(string.Format("WebTv: {0} has file name: {1} which can't get versioning file", pageData.PageGuid, file.Name));
                        }
                        else
                        {
                            // Remove all old version of file more than 1 version
                            if (versioningFile.GetVersions().Count() > 1)
                            {
                                // Load all old version 
                                var versions = versioningFile.GetVersions().OrderByDescending(v => v.Created);
                                var lastVersion = versions.FirstOrDefault(); // Get lastest version
                                var secondVersion = versions.Take(2).LastOrDefault(); // Get second last version
                                var deletingVersions = versions.Skip(2);
                                if (lastVersion.Length < 0.667 * secondVersion.Length)
                                {
                                    // Log error about lastest file version be deleted
                                    //_log.Error(string.Format("[Deleted version is lastest version] - Saved Tine {0}: WebTv page name {1} deleted file with version {2} created time {3}", pageData.Saved,
                                    //    pageData.PageName, lastVersion.Name, lastVersion.Created));
                                    // Do not delete 2 lastest version
                                    //lastVersion.Delete();
                                }
                                else
                                {
                                    // Log info about file version be deleted
                                    //_log.Info(string.Format("{0}: WebTv page name {1} deleted file with version {2} created time {3}", pageData.Saved,
                                    //    pageData.PageName, secondVersion.Name, secondVersion.Created));
                                    secondVersion.Delete();
                                }

                                foreach (var v in deletingVersions)
                                {
                                    //// Log info about file version be deleted
                                    //_log.Info(string.Format("{0}: WebTv page name {1} deleted file with version {2} created time {3}", pageData.Saved,
                                    //    pageData.PageName, v.Name, v.Created));
                                    v.Delete();
                                    //CounterVersionFileRemoved++;
                                    flag = true;
                                }
                            }
                        }
                    }
                    if (flag)
                    {
                        //CounterPageHaveFileRemoved++;
                    }
                }

                //CounterUpdated++;
                // savedDate = pageData.Saved;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dir"></param>
        private void DeleteFolderRecursiveLy(EPiServer.Web.Hosting.UnifiedDirectory dir)
        {
            var files = dir.Files;

            foreach (var file in files)
            {
                var f = file as VersioningFile;
                if (f != null)
                    f.Delete();
            }

            var dirs = dir.Directories;

            foreach (var directory in dirs)
            {
                var d = directory as VersioningDirectory;
                if (d != null)
                    DeleteFolderRecursiveLy(d);
            }

            dir.Delete();
        }

        bool CanDelete
        {
            get
            {
                return MaxNumberToDelete > ProcessedCount + ProcessedSectionsCount && IsProcessing;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        void ProcessingThread(object o)
        {
            try
            {
                foreach (var item in Articles)
                {
                    if (!CanDelete)
                    {
                        throw new Exception("Aborted by user.");
                    }
                    try
                    {
                        DeletePage(new PageReference(item));
                        ProcessedCount += 1;                      
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                //var roots = OldSectionIds;

                //if (roots != null)
                //{
                //    IPageQueryHandler svc = ServiceLocator.Resolve<IPageQueryHandler>();
                //    foreach (var id in roots)
                //    {
                //        if (!CanDelete)
                //        {
                //            break;
                //        }
                //        var pref = new PageReference(id);

                //        PageData rootPage = null;
                //        try
                //        {
                //            rootPage = DataFactory.Instance.GetPage(pref);
                //        }
                //        catch (Exception)
                //        {
                //            continue;
                //        }
                //        if (rootPage != null)
                //        {
                //            var items = svc.QueryPages<ArticlePageData>()
                //                          .Where(x => x.SectionCore)
                //                          .IsEqualTo(pref)
                //                          .UnCachedPageReferencesResult();

                //            DeleteAll(items, rootPage.PageName);
                //            foreach (var child in DataFactory.Instance.GetDescendents(pref))
                //            {
                //                try
                //                {
                //                    if (!CanDelete)
                //                    {
                //                        break;
                //                    }
                //                    var childPage = DataFactory.Instance.GetPage(child);

                //                    var articles = svc.QueryPages<ArticlePageData>()
                //                        .Where(x => x.SectionCore)
                //                        .IsEqualTo(child)
                //                        .UnCachedPageReferencesResult();

                //                    //if have articles do the deletation
                //                    DeleteAll(articles, childPage.PageName);
                //                    if (CanDelete)
                //                    {
                //                        //delete section
                //                        DeletePage(child);
                //                        //ProcessedSectionsCount += 1;
                //                    }
                //                }
                //                catch (Exception ex)
                //                {
                //                    ltJustDeleted.Text = ex.Message;
                //                    log.Error(ex);
                //                }
                //            }
                //            if (CanDelete)
                //            {
                //                //delete section
                //                DeletePage(pref);
                //                ProcessedSectionsCount += 1;

                //                if (Articles.ContainsKey(rootPage.PageName))
                //                {
                //                    Articles.Remove(rootPage.PageName);
                //                }
                //            }
                //            //delete root section then
                //            //DeletePage(pref);
                //            //ProcessedSectionsCount += 1;
                //        }
                //    }

                //}
            }
            catch (Exception ex)
            {
                ltJustDeleted.Text = ex.Message;
                log.Error(ex);

            }
            finally
            {
                IsProcessing = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pages"></param>
        //void DeleteAll(IEnumerable<PageReference> pages, string sectionName)
        //{
        //    if (pages != null)
        //    {
        //        DeletingKey = sectionName;
        //        foreach (var item in pages)
        //        {
        //            if (!CanDelete)
        //            {
        //                throw new Exception("Aborted by user.");
        //            }
        //            try
        //            {
        //                DeletePage(item);
        //                ProcessedCount += 1;
        //                if (Articles.ContainsKey(sectionName))
        //                {
        //                    Articles[sectionName] -= 1;
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        void RegisterRefreshScript()
        {
            if (IsProcessing && !Page.ClientScript.IsClientScriptBlockRegistered("RandomQuoteCallback"))
            {
                string clientScript = "function refresh(){document.getElementById('" + btnRefresh.ClientID + "').click();} $(document).ready(function(){ window.setTimeout('refresh()',2000);});";
                // Register the client script
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                "RandomQuoteCallback", clientScript, true);
            }
        }
        #endregion

        #region Actions
        protected void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDescendants();
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMessage(null);
                MaxNumberToDelete = int.Parse(txtMaxItemToDelete.Text);
                //Sections = Sections;
                IsProcessing = true;
                ProcessedCount = 0;
                ProcessedSectionsCount = 0;
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessingThread), null);
                UpdateUI();

                this.RegisterRefreshScript();

            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            IsProcessing = false;
            this.UpdateUI();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!IsProcessing)
            {
                ShowMessage(string.Format("Deleted {0} article(s) and {1} section(s)", ProcessedCount, ProcessedSectionsCount));
            }
            UpdateUI();
        }
        #endregion

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            UpdateUI();
        }
    }


}