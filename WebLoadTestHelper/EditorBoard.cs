using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace WebLoadTestHelper
{
    public partial class EditorBoard : Form
    {
        public EditorBoard()
        {
            InitializeComponent();
        }

        private void GenVs2012WebTest()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
                sb.AppendLine(string.Format(@"<WebTest Name=""{0}"" Id=""{1}"" Owner=""{2}"" Priority=""{3}"" Enabled=""{4}"" CssProjectStructure="""" CssIteration="""" Timeout=""0"" WorkItemIds="""" xmlns=""http://microsoft.com/schemas/VisualStudio/TeamTest/2010"" Description="""" CredentialUserName="""" CredentialPassword="""" PreAuthenticate=""True"" Proxy="""" StopOnError=""False"" RecordedResultFile="""" ResultsLocale="""">",
                   string.Format("URL_{0}", txtLinks.Lines.Length), Guid.NewGuid(), "", new Random(int.MaxValue / 2).Next(int.MaxValue / 2),
                    true));
                sb.AppendLine("     <Items>");

                foreach (var link in txtLinks.Lines)
                {
                    sb.AppendLine(
                        string.Format(@"<Request Method=""{0}"" Guid=""{1}"" Version=""1.1"" Url=""{2}"" ThinkTime=""{3}"" Timeout=""{4}"" ParseDependentRequests=""{5}"" FollowRedirects=""False"" RecordResult=""True"" Cache=""False"" ResponseTimeGoal=""{6}"" Encoding=""utf-8"" ExpectedHttpStatusCode=""0"" ExpectedResponseUrl="""" ReportingName="""" IgnoreHttpStatusCode=""False"" />",
                    "GET",
                    Guid.NewGuid(),
                    link,
                    txtThinkTimes.Text,
                    300,
                    false,
                      txtTimeGoal.Text));
                }
                sb.AppendLine(@"</Items>");
                sb.AppendLine(@"</WebTest>");
                txtWebTest.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            try
            {
                this.GenVs2012WebTest();
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            try
            {
                wb.Navigate(tbUrl.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public string BaseUrl
        {
            get
            {
                return tbUrl.Text.Replace("//", "##").Split('/')[0].Replace("##", "//").TrimEnd('/');
            }
        }

        public string DeviceUrl
        {
            get
            {
                return tbDeviceUrl.Text.Replace("//", "##").Split('/')[0].Replace("##", "//").TrimEnd('/');
            }
        }

        private string BuildLink(string absolutePath, string baseUrl)
        {
            return baseUrl + HttpUtility.HtmlEncode(absolutePath);
        }

        private void ValidateMaxLinks(int len)
        {
            int max = int.Parse(tbMaxLinks.Text);
            if (len >= max)
            {
                throw new Exception(string.Format("You got {0} links already.", max));
            }
        }

        void GatherLinks(string html)
        {
            try
            {
                Regex rex = new Regex(@"href=\""(\S+)\""");
                var hrefs = rex.Matches(html);

                this.ValidateMaxLinks(txtLinks.Lines.Length);
                List<string> _links = new List<string>(txtLinks.Lines);
                string baseUrl = BaseUrl;
                foreach (Match h in hrefs)
                {
                    if (h.Groups[1].Value.StartsWith("/"))
                    {
                        string lnk = this.BuildLink(h.Groups[1].Value, baseUrl);
                        if (!_links.Contains(lnk))
                        {
                            _links.Add(lnk);
                        }
                    }
                }

                txtLinks.Lines = _links.ToArray();
                //for (int i = 0; i < hrefs.Count; i++)
                //{

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                GatherLinks(wb.Document.Body.InnerHtml);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLinks_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbLinks.Text = lbTotalLines.Text = string.Format("{0} line(s)", txtLinks.Lines.Length);
                btnGen.Enabled = txtLinks.Lines.Length > 0;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnGen_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.GenVs2012WebTest();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtWebTest.Text);
            MessageBox.Show("Copied to clipboard.");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Want to clear all found Urls?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    txtLinks.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGather_Click(object sender, EventArgs e)
        {
            toolStripButton1.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " " + Application.ProductVersion;
        }

        private void btnImportUrlsFromIISLog_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Want to clear all found Urls before importing ?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (fileOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        List<string> _links = new List<string>(txtLinks.Lines);
                        txtLinks.Text = "";
                        using (var stream = File.OpenText(fileOpen.FileName))
                        {
                            var line = "temp";
                            string baseUrl = BaseUrl;
                            string deviceUrl = DeviceUrl;
                            while (!stream.EndOfStream && !string.IsNullOrEmpty(line))
                            {
                                line = stream.ReadLine();
                                var i = line.IndexOf(" GET ");
                                if (i <= 0)
                                {
                                    continue;
                                }

                                var port = line.IndexOf(" 80 -");

                                if (port <= 0)
                                {
                                    continue;
                                }

                                var urlNquery = line.Substring(i + 5, port - i - 5);
                                var tmpLine = line.ToLower();
                                string url = tmpLine.Contains("iphone") || tmpLine.Contains("android") || tmpLine.Contains("iemobile") || tmpLine.Contains("ipad") ? deviceUrl : baseUrl;

                                if (urlNquery.EndsWith(" -"))
                                    urlNquery = urlNquery.Substring(0, urlNquery.Length - 2);

                                if (urlNquery.IndexOf(" ") > 0)
                                {
                                    var a = urlNquery.Split(new char[] { ' ' });
                                    url = this.BuildLink(a[0] + "&" + a[1], url);
                                }
                                else
                                {
                                    url = this.BuildLink(urlNquery, url);
                                }

                                if (!_links.Contains(url))
                                {
                                    try
                                    {
                                        this.ValidateMaxLinks(_links.Count);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        break;
                                    }
                                    _links.Add(url);
                                }
                            }
                            txtLinks.Lines = _links.ToArray();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "URL_" + txtLinks.Lines.Length;
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (Stream stream = saveFileDialog1.OpenFile())
                    {
                        StreamWriter sw = new StreamWriter(stream);
                        sw.Write(txtWebTest.Text);
                        sw.Flush();
                        stream.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void wb_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Maximum = (int)e.MaximumProgress;
                progressBar1.Value = (int)e.CurrentProgress;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                progressBar1.Visible = false;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnGetSrcs_Click(object sender, EventArgs e)
        {
            try
            {
                Regex rex = new Regex(@"src=\""(\S+)\""");
                var hrefs = rex.Matches(wb.Document.Body.InnerHtml);

                this.ValidateMaxLinks(txtLinks.Lines.Length);
                List<string> _links = new List<string>(txtLinks.Lines);
                string baseUrl = BaseUrl;
                foreach (Match h in hrefs)
                {
                    if (h.Groups[1].Value.StartsWith("/"))
                    {
                        string lnk = this.BuildLink(h.Groups[1].Value, baseUrl);
                        if (!_links.Contains(lnk))
                        {
                            _links.Add(lnk);
                        }
                    }
                }

                txtLinks.Lines = _links.ToArray();
                //for (int i = 0; i < hrefs.Count; i++)
                //{

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtHTML_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGatherLinkFromHTML_Click(object sender, EventArgs e)
        {
            try
            {
                GatherLinks(txtHTML.Text.Replace("\r", "").Replace("\n", ""));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
