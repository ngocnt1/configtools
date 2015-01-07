using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using EPiServer.Personalization;
using EPiServer.PlugIn;
using EPiServer.Security;
using EPiServer.Util.PlugIns;
using System.Web.UI;
using EPiServer;
using System.Text;
using EPiServer.Core;
using EPiServer.UI;
using System.Web.Configuration;

namespace Di.Plugins.Plugins
{
    [GuiPlugIn(DisplayName = "FriendlyUrl Find", Description = "", Area = PlugInArea.AdminMenu, Url = "~/Plugins/FriendlyUrlPlugin.aspx")]
    public partial class FriendlyUrlPlugin : SystemPageBase
    {

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

        private string GetFriendlyUrl(PageData pd)
        {
            var url = new UrlBuilder(pd.LinkURL);
            Global.UrlRewriteProvider.ConvertToExternal(url, pd.PageLink, Encoding.UTF8);
            return txtDomain.Text + url.ToString();
        }

        public override EPiServer.Security.AccessLevel RequiredAccess()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return EPiServer.Security.AccessLevel.FullAccess;
            }
            return EPiServer.Security.AccessLevel.NoAccess;
        }

        protected void CheckPermission(string securityCode)
        {
            if (string.Compare(WebConfigurationManager.AppSettings["SecurityCode"], securityCode, true) != 0)
            {
                throw new Exception("Please input correct security code.");
            }
        }

        protected void btnGenLinks_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = "";
                foreach (string line in txtDIs.Text.Split('\n'))
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var page = DataFactory.Instance.GetPage(new PageReference(int.Parse(line.Trim())));
                        txtResult.Text += GetFriendlyUrl(page) + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }
    }
}