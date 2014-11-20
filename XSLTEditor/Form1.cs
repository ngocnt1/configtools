using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
namespace XSLTEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sbXslOutput = new StringBuilder();
                //XmlDocument xslt =new XmlDocument();
                //xslt.LoadXml(tbXSLT.Text);
                TextReader tr = new StringReader(string.IsNullOrWhiteSpace(tbXsltPath.Text) ? tbXSLT.Text :
                    File.ReadAllText(tbXsltPath.Text));
                using (XmlReader xsltReader = XmlReader.Create(tr))
                {
                    using (XmlWriter xslWriter = XmlWriter.Create(sbXslOutput, new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Auto }))
                    {

                        XslCompiledTransform transformer = new XslCompiledTransform();

                        transformer.Load(xsltReader);

                        XsltArgumentList args = new XsltArgumentList();

                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

                        //XmlDocument doc = new XmlDocument();

                        doc.LoadHtml(tbXML.Text);

                        transformer.Transform(doc.CreateNavigator(), args, xslWriter);
                    }
                }

                tbResult.Text = sbXslOutput.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string Html(string url, string xpath, bool onlyInnerText = false, string xslt = null, int httpCacheDuration = 600, string regexPatternRemoval = @"(<br>)|(<script[\d\D]*?>[\d\D]*?</script>)")
        {
            try
            {
                HtmlNode _content = null;

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                var wr = WebRequest.CreateHttp(url);
                wr.Method = "GET";
                wr.UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/534.30 (KHTML, like Gecko) Chrome/12.0.742.122 Safari/534.30";
                wr.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                wr.KeepAlive = true;

                var tpWebReponse = (HttpWebResponse)wr.GetResponse();
                var responseReader = new StreamReader(tpWebReponse.GetResponseStream());

                doc.Load(responseReader);


                _content = doc.DocumentNode.SelectSingleNode(xpath);

                return _content.OuterHtml.AttrEncode().ResolveIncorrectTags();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(tbXML.Text);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(tbXSLT.Text);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(tbResult.Text);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            try
            {
                tbXML.Text = this.Html(tbUrl.Text, tbXpath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
