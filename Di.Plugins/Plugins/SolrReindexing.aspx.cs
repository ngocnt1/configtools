using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using EPiServer.Personalization;
using EPiServer.PlugIn;
using EPiServer.Security;
using EPiServer.Util.PlugIns;
using System.Web.UI;
using Bonnier.Core.Querying.Solr.Plugin;
using EPiServer.Core;
using Bonnier.Core.Querying.Solr.Configuration;
using System.Threading;
using EPiServer;
using Bonnier.Core.Querying.Solr;
using EPiServer.Configuration;
using Bonnier.Core.Querying.Solr.Models.Index;

namespace Di.Plugins.Plugins
{
    [GuiPlugIn(
        DisplayName = "[Admin] Solr Reindexing",
        Description = "SolrCore Indexer Plugin: Administrate the SolrCore indexer.",
        Area = PlugInArea.AdminMenu,
        Url = "~/Plugins/SolrReindexing.aspx",
        SortIndex = 3)]
    public partial class SolrReindexing : PluginBase
    {
        private static bool isStopWorking;

        private static bool isWorking;

        private static volatile SolrPagesBatchHandlerStatus statusInfo;

        private SolrPagesBatchHandler solrPagesBatchHandler;
        private double MaxNumberToIndex;
        private double ProcessedCount;

        protected SolrPagesBatchHandler SolrPagesBatchHandler
        {
            get
            {
                return solrPagesBatchHandler ?? (solrPagesBatchHandler = new SolrPagesBatchHandler());
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            iprPageRoot.AutoPostBack = true;
            iprPageRoot.ValueChanged += iprPageRoot_ValueChanged;
        }

        void iprPageRoot_ValueChanged(object sender, EventArgs e)
        {
            if (iprPageRoot.PageLink != null && iprPageRoot.PageLink != PageReference.EmptyReference)
            {
                var catalogs = DataFactory.Instance.GetChildren(iprPageRoot.PageLink);
                cblCatalogs.DataSource = catalogs;
                cblCatalogs.DataTextField = "PageName";
                cblCatalogs.DataValueField = "PageLink";
                cblCatalogs.DataBind();
                foreach (ListItem item in cblCatalogs.Items)
                {
                    item.Selected = true;
                }
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

                btnEnable.Enabled = !SolrConfigurationManager.Instance.EventsEnabled;
                phBtnEnable.Visible = !SolrConfigurationManager.Instance.EventsEnabled;
                btnDisable.Enabled = SolrConfigurationManager.Instance.EventsEnabled;
                phBtnDisable.Visible = SolrConfigurationManager.Instance.EventsEnabled;

                iprPageRoot.PageLink = PageReference.RootPage;
                txbBatchSize.Text = SolrConfigurationManager.Instance.BatchSize.ToString();
                chbCommitAfterEachBatch.Checked = SolrConfigurationManager.Instance.ReindexCommitAfterEachBatch;


            }

            ToggleActionButtonsState();
        }
        public int ProcessedPercentage
        {
            get
            {
                double a = ProcessedCount;
                double b = MaxNumberToIndex;// TotalItemsCount;
                b = b == 0 ? 1 : b;
                var r = (int)Math.Round(a * 100 / b, 0);
                return r > 100 ? 100 : r;
            }
        }
        private void SetObjectsCount()
        {
            var status = Indexer.Instance.GetStatus();

            var siteId = Settings.Instance.Parent.SiteId;
            var siteKey = string.Format("{0}/{1}", SolrConfigurationManager.Instance.IndexId, string.IsNullOrEmpty(siteId) ? "*" : siteId);

            var flt = new Dictionary<string, string>
                {
                    { "_type", typeof(PageData).FullName },
                    { IndexDoc.IndexIdFieldName, siteKey }
                };

            var indexedPagesStatus = Indexer.Instance.GetIndexedCountStatus(flt);
            lblIndicesCount.Text = string.Format("{0}/{1}", status.NumDocs, indexedPagesStatus.NumDocs);
        }

        private void ToggleActionButtonsState()
        {
            btnReIndex.Visible = !isWorking;
            btnClearIndex.Visible = !isWorking;
            btnOptimizeIndex.Visible = !isWorking;
            btnCommitIndex.Visible = !isWorking;
            btnStopAction.Visible = isWorking;
            pnlProgress.Visible = isWorking;
            ltlWorkingStatus.CssClass = isStopWorking ? "label label-warning" : isWorking ? "label label-success" : "";
            lblIndicesCount.CssClass = isWorking ? "label label-primary" : "";
            panelSettings.Enabled = !isWorking;
            iprPageRoot.Enabled = !isWorking;
            btnEnable.Enabled = !isWorking;
            btnDisable.Enabled = !isWorking;
            panelStatus.CssClass = panelSettings.CssClass = isWorking ? "panel panel-primary" : "panel panel-default";
            //spanStopButton.Attributes.Add("style", "display:" + (isWorking ? "inline-block" : "none"));
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

        protected void BtnEnable_Click(object sender, EventArgs e)
        {
            SolrConfigurationManager.Instance.EventsEnabled = true;
            btnEnable.Enabled = !SolrConfigurationManager.Instance.EventsEnabled;
            phBtnEnable.Visible = !SolrConfigurationManager.Instance.EventsEnabled;
            btnDisable.Enabled = SolrConfigurationManager.Instance.EventsEnabled;
            phBtnDisable.Visible = SolrConfigurationManager.Instance.EventsEnabled;
        }

        protected void BtnDisable_Click(object sender, EventArgs e)
        {
            SolrConfigurationManager.Instance.EventsEnabled = false;
            btnEnable.Enabled = !SolrConfigurationManager.Instance.EventsEnabled;
            phBtnEnable.Visible = !SolrConfigurationManager.Instance.EventsEnabled;
            btnDisable.Enabled = SolrConfigurationManager.Instance.EventsEnabled;
            phBtnDisable.Visible = SolrConfigurationManager.Instance.EventsEnabled;
        }

        protected void BtnReIndex_Click(object sender, EventArgs e)
        {
            if (!isWorking)
            {
                isWorking = true;
                isStopWorking = false;

                var settings = ReadSolrPagesBatchHandlerSettings();
                settings.ActionType = SolrPagesBatchHandlerActionType.Index;

                ThreadPool.QueueUserWorkItem(ThreadProc, settings);
            }
        }

        private SolrPagesBatchHandlerSettings ReadSolrPagesBatchHandlerSettings()
        {
            // var siteContext = ServiceLocator.Resolve<ISiteContext>();
            var settings = new SolrPagesBatchHandlerSettings();
            settings.BatchSize = GetBatchSize();
            settings.FromBatchIndex = GetFromBatchIndex();
            settings.ToBatchIndex = GetToBatchIndex();
            settings.Roots = GetRootPageReferences();
            settings.ThrowIfException = chbStopOnException.Checked;
            settings.TakesCountPerRequestFromSolr = GetTakesCountPerRequestFromSolr();
            settings.CommitAfterEachBatch = chbCommitAfterEachBatch.Checked;
            settings.SiteId = Settings.Instance.Parent.SiteId;

            SolrConfigurationManager.Instance.ReindexCommitAfterEachBatch = settings.CommitAfterEachBatch;
            SolrConfigurationManager.Instance.ReindexStopOnException = settings.ThrowIfException;
            SolrConfigurationManager.Instance.BatchSize = settings.BatchSize;

            return settings;
        }

        private void ThreadProc(object obj)
        {
            SolrPagesBatchHandler.Status += SolrPagesBatchHandler_Status;

            var settings = obj as SolrPagesBatchHandlerSettings;
            statusInfo = new SolrPagesBatchHandlerStatus();
            SolrPagesBatchHandler.Start(settings);
            isWorking = false;
        }

        private void SolrPagesBatchHandler_Status(object sender, SolrPagesBatchHandlerStatus e)
        {
            statusInfo = e;

            if (!e.IsWorking)
            {
                SolrPagesBatchHandler.Status -= SolrPagesBatchHandler_Status;
                isWorking = false;
            }

            e.StopWorking = isStopWorking;
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

        private PageReferenceCollection GetRootPageReferences()
        {
            var rootRefs = new PageReferenceCollection();

            foreach (ListItem item in cblCatalogs.Items)
            {
                if (item.Selected)
                {
                    rootRefs.Add(PageReference.Parse(item.Value));
                }
            }

            if (rootRefs.Count == 0)
            {
                rootRefs.Add(iprPageRoot.PageLink);
            }

            return rootRefs;
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

        protected void BtnClearIndex_Click(object sender, EventArgs e)
        {
            if (!isWorking)
            {
                isWorking = true;
                isStopWorking = false;

                var settings = ReadSolrPagesBatchHandlerSettings();
                settings.ActionType = SolrPagesBatchHandlerActionType.Clear;

                ThreadPool.QueueUserWorkItem(ThreadProc, settings);
            }
        }

        protected void BtnOptimizeIndex_Click(object sender, EventArgs e)
        {
            if (!isWorking)
            {
                isWorking = true;
                isStopWorking = false;

                var settings = ReadSolrPagesBatchHandlerSettings();
                settings.ActionType = SolrPagesBatchHandlerActionType.Optimize;

                ThreadPool.QueueUserWorkItem(ThreadProc, settings);
            }
        }

        protected void BtnCommitIndex_Click(object sender, EventArgs e)
        {
            if (!isWorking)
            {
                isWorking = true;
                isStopWorking = false;

                var settings = ReadSolrPagesBatchHandlerSettings();
                settings.ActionType = SolrPagesBatchHandlerActionType.Commit;

                ThreadPool.QueueUserWorkItem(ThreadProc, settings);
            }
        }

        protected void BtnStopAction_Click(object sender, EventArgs e)
        {
            if (isWorking)
            {
                isStopWorking = true;
                SolrPagesBatchHandler.Stop();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            SetBatchStatus();
            SetPageIndexerStatus();
            ToggleActionButtonsState();

            base.OnPreRender(e);
        }

        private void SetPageIndexerStatus()
        {
            if (statusInfo != null)
            {
                // PA: I don't know why but Linq extesion Count() generate strage error here,
                // so today is friday and I can't think about wtf?!
                var enumerator = statusInfo.Errors == null ? null : statusInfo.Errors.GetEnumerator();
                var errorsCount = 0;

                while (enumerator != null && enumerator.MoveNext())
                {
                    errorsCount++;
                }

                var batchCount = statusInfo.BatchSize == 0 || statusInfo.AllPagesCount == 0
                    ? "unknown"
                    : Math.Ceiling(statusInfo.AllPagesCount / (decimal)statusInfo.BatchSize).ToString();

                ProcessedCount = statusInfo.BatchNumber;
                double.TryParse(batchCount, out MaxNumberToIndex);


                var batchInfo = string.Format(
                    "Current batch #{0} of {2} has {1} page(s). ",
                    statusInfo.BatchNumber,
                    statusInfo.BatchPagesCount,
                    batchCount
                    );

                var statusText = string.Format(
                    "{0} - pages found. {1}Total: {2} indexed pages. Number of errors: {3}.",
                    statusInfo.AllPagesCount,
                    statusInfo.IsWorking ? batchInfo : string.Empty,
                    statusInfo.AllIndexedPagesCount,
                    errorsCount);

                ltAdditionalWorkingStatus.Text = statusText;
            }
        }

        private void SetBatchStatus()
        {
            ltlWorkingStatus.Text = isWorking ? isStopWorking ? "Stoping..." : "Working ..." : "Idle";
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            SetObjectsCount();
        }
    }
}