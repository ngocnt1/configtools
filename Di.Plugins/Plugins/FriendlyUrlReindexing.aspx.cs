using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;
using Bonnier.Core.Common;
using Bonnier.Core.Common.Extensions;
using Bonnier.Core.Common.Interfaces;
using Bonnier.Core.Querying.Solr;
using Bonnier.Core.Querying.Solr.Configuration;
using Bonnier.Core.Querying.Solr.Models;
using Bonnier.Core.Querying.Solr.Models.Index;
using Bonnier.UrlRewriting.PlugIns;
using Bonnier.UrlRewriting.SolrDataObjects;
using EPiServer;
using EPiServer.Configuration;
using EPiServer.Core;
using EPiServer.Globalization;
using EPiServer.Personalization;
using EPiServer.PlugIn;
using EPiServer.Security;
using Autofac;
using EPiServer.UI;

namespace Di.Plugins.Plugins
{
    [GuiPlugIn(DisplayName = "FriendlyUrl Reindexing", Description = "", Area = PlugInArea.AdminMenu, Url = "~/Plugins/FriendlyUrlReindexing.aspx")]
    public partial class FriendlyUrlReindexing : SystemPageBase
    {
        private static bool isWorking;

        private static bool isStopWorking;

        private static volatile FriendlyUrlBatchGeneratorStatus statusInfo;

        private FriendlyUrlBatchGenerator friendlyUrlBatchGenerator;

        protected FriendlyUrlBatchGenerator FurlBatchGenerator
        {
            get
            {
                return friendlyUrlBatchGenerator ?? (friendlyUrlBatchGenerator = new FriendlyUrlBatchGenerator());
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                tbTakesCountFromSolr.Text = "500";
                lblServerUrl.Text = SolrConfigurationManager.Instance.ServerUrl;

                SetObjectsCount();

                iprPageRoot.PageLink = PageReference.RootPage;
                txbBatchSize.Text = SolrConfigurationManager.Instance.BatchSize.ToString();

     

                FillDDLRegenerationType();
            }

            ToggleActionButtonsState();
        }

        protected override void OnPreRender(EventArgs e)
        {
            SetBatchStatus();
            SetFriendlyUrlStatus();
            ToggleActionButtonsState();

            base.OnPreRender(e);
        }

        private void SetBatchStatus()
        {
            ltlReindexStatus.Text = isWorking ? "Working" : "Idle";
        }

        private void SetFriendlyUrlStatus()
        {
            if (statusInfo != null)
            {
                var batchCount = statusInfo.BatchSize == 0 || statusInfo.AllPagesCount == 0
                    ? "unknown"
                    : Math.Ceiling(statusInfo.AllPagesCount / (decimal)statusInfo.BatchSize).ToString();

                var batchInfo = string.Format(
                    "<br/>Current batch # <span class='label label-success'>{0}</span> of  <span class='label label-info'>{3}</span> has {1} page(s) for which {2} furls generated. ",
                    statusInfo.BatchNumber,
                    statusInfo.BatchPagesCount,
                    statusInfo.GeneratedFurlInBatchCount,
                    batchCount
                    );

                var statusText = string.Format(
                    @"
<br/>{0} - pages found. {1}
<br/>Total: <span class='label label-info'>{2}/{3}</span> (generated/saved) friendly urls. <br/>Number of errors: <span class='label label-danger'>{4}</span>",
                    statusInfo.AllPagesCount,
                    statusInfo.IsWorking ? batchInfo : string.Empty,
                    statusInfo.AllGeneratedFurlCount,
                    statusInfo.AllSavedFurlCount,
                    statusInfo.Errors == null ? 0 : statusInfo.Errors.Count());

                ltFriendlyUrlStatus.Text = statusText;
            }
        }

        #region Common
        private void SetObjectsCount()
        {
            SolrCoreStatus status = Indexer.Instance.GetStatus();
            lblStatus.Text = status.Status.ToString();
            lblIndexedPages.Text = status.NumDocs.ToString();

            var siteId = Settings.Instance.Parent.SiteId;
            var siteKey = string.Format("{0}/{1}", SolrConfigurationManager.Instance.IndexId, string.IsNullOrEmpty(siteId) ? "*" : siteId);

            var flt = new Dictionary<string, string>
                {
                    { "_type", typeof(FriendlyUrlSolrDO).FullName },
                    { IndexDoc.IndexIdFieldName, siteKey }
                };

            var indexedFurlsStatus = Indexer.Instance.GetIndexedCountStatus(flt);
            lblIndexedFurls.Text = indexedFurlsStatus.NumDocs.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        private void ToggleActionButtonsState()
        {
            btnReindex.Enabled = !isWorking;
            btnRefresh.Visible = isWorking;
            btnStop.Visible = isWorking;

            //spanStopButton.Attributes.Add("style", "display:" + (isWorking ? "inline-block" : "none"));
        }

        void ShowError(string msg)
        {
            lbWarning.CssClass = "alert alert-danger";
            lbWarning.Text = msg;
        }

        void ShowMessage(string msg)
        {
            lbWarning.CssClass = "alert alert-info";
            lbWarning.Text = msg;
        }

        #endregion

        #region Processing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void ThreadProc(object obj)
        {
            try
            {
                FurlBatchGenerator.Status += FurlBatchGenerator_Status;

                var settings = (FriendlyUrlBatchGeneratorSettings)obj;
                statusInfo = new FriendlyUrlBatchGeneratorStatus();
                FurlBatchGenerator.Start(settings);
            }
            catch (Exception)
            {
                FurlBatchGenerator.Status -= FurlBatchGenerator_Status;
            }

            isWorking = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FurlBatchGenerator_Status(object sender, FriendlyUrlBatchGeneratorStatus e)
        {
            statusInfo = e;

            if (!e.IsWorking)
            {
                FurlBatchGenerator.Status -= FurlBatchGenerator_Status;
                isWorking = false;
            }

            e.StopWorking = isStopWorking;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private FriendlyUrlBatchGeneratorSettings ReadSettings()
        {
            
          //  var siteContext = ServiceLocator.Current.Resolve<ISiteContext>();
            var settings = new FriendlyUrlBatchGeneratorSettings();
            settings.ActionType = FriendlyUrlBatchActionType.Clear;
            settings.BatchSize = GetBatchSize();
            settings.FromBatchIndex = GetFromBatchIndex();
            settings.ToBatchIndex = GetToBatchIndex();
            settings.Roots = GetRootPageReferences();
            settings.ThrowIfException = chbStopOnException.Checked;
            settings.TakesCountPerRequestFromSolr = GetTakesCountPerRequestFromSolr();
            settings.RegenerationType = GetRegenerationType();
            settings.SiteId = Settings.Instance.Parent.SiteId;//siteContext.SiteId;

            return settings;
        }
        #endregion

        #region Settings
        private void FillDDLRegenerationType()
        {
            ddlRegenerationType.Items.Add(new ListItem("RegenerateAll", ((int)FriendlyUrlBatchRegenerationType.RegenerateAll).ToString()));
            ddlRegenerationType.Items.Add(new ListItem("RegenerateEmpty", ((int)FriendlyUrlBatchRegenerationType.RegenerateEmpty).ToString()));
            var li = new ListItem("RegenerateNotManual", ((int)FriendlyUrlBatchRegenerationType.RegenerateNotManual).ToString());
            li.Selected = true;
            ddlRegenerationType.Items.Add(li);
        }
        private PageReferenceCollection GetRootPageReferences()
        {
            var rootRefs = new PageReferenceCollection();

            // var selectedItems = cblCatalogs.Items.Cast<ListItem>().Where(o => o.Selected);

            // if (selectedItems.Any())
            //{
            //    selectedItems.ForEach(o => rootRefs.Add(PageReference.Parse(o.Value)));
            //}
            //else
            //{
            rootRefs.Add(iprPageRoot.PageLink);
            //}

            return rootRefs;
        }

        private FriendlyUrlBatchRegenerationType GetRegenerationType()
        {
            foreach (ListItem listItem in ddlRegenerationType.Items)
            {
                if (listItem.Selected)
                {
                    return (FriendlyUrlBatchRegenerationType)Enum.Parse(typeof(FriendlyUrlBatchRegenerationType), listItem.Value);
                }
            }

            return FriendlyUrlBatchRegenerationType.RegenerateAll;
        }


        private int GetTakesCountPerRequestFromSolr()
        {
            int val;

            if (!int.TryParse(tbTakesCountFromSolr.Text, out val))
            {
                val = 200;
            }

            return val;
        }

        private int GetToBatchIndex()
        {
            int toBatch;

            if (!int.TryParse(txbToBatchIndex.Text, out toBatch))
            {
                toBatch = int.MaxValue;
            }

            return toBatch;
        }

        private int GetFromBatchIndex()
        {
            int fromBatch;

            if (!int.TryParse(txbFromBatchIndex.Text, out fromBatch))
            {
                fromBatch = 0;
            }

            return fromBatch;
        }

        private int GetBatchSize()
        {
            var batchSize = SolrConfigurationManager.Instance.BatchSize;

            if (int.TryParse(txbBatchSize.Text, out batchSize))
            {
                SolrConfigurationManager.Instance.BatchSize = batchSize;
            }

            return batchSize;
        }

        #endregion

        #region Actions
        protected void btnReindex_Click(object sender, EventArgs e)
        {
            if (!isWorking)
            {
                isWorking = true;
                isStopWorking = false;

                var settings = ReadSettings();
                settings.ActionType = FriendlyUrlBatchActionType.Regenerate;

                ThreadPool.QueueUserWorkItem(ThreadProc, settings);
                RegisterRefreshScript();
            }
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            if (isWorking)
            {
                isStopWorking = true;
                FurlBatchGenerator.Stop();
                RegisterRefreshScript();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            SetObjectsCount();
            if (isWorking)
            {
                RegisterRefreshScript();
            }
        }

        void RegisterRefreshScript()
        {
            if (isWorking && !Page.ClientScript.IsClientScriptBlockRegistered("RandomQuoteCallback"))
            {
                string clientScript = "function refresh(){document.getElementById('" + btnRefresh.ClientID + "').click();} $(document).ready(function(){ window.setTimeout('refresh()',3000);});";
                // Register the client script
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                "RandomQuoteCallback", clientScript, true);
            }
        } 
        #endregion
    }
}