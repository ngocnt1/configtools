using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParameterConvertor
{
    public partial class Convertor : Form
    {
        public Convertor()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(filePS.FilePath);
                StringBuilder sb = new StringBuilder();
                foreach (XmlNode p in doc.SelectNodes("/parameters/parameter"))
                {
                    var entry = p.SelectSingleNode("parameterEntry");
                    if (entry.Attributes["scope"].Value.StartsWith(txtFile.Text, StringComparison.OrdinalIgnoreCase))
                    {
                        if (p.Attributes["value"].Value != "")
                        {
                            sb.AppendLine(string.Format(@"<set xpath=""{0}"">{1}</set>",
                                entry.Attributes["match"].Value, p.Attributes["value"].Value));
                        }
                        else
                        {
                            sb.AppendLine(string.Format(@"<delete xpath=""{0}"" />",
                               entry.Attributes["match"].Value));
                        }
                    }
                }

                txtResult.Text = sb.ToString();
                lbResult.Text = string.Format("Result: {0} line(s)", txtResult.Lines.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddResultMessage(string mes)
        {
            txtEditResult.Text = string.Format("[{0:yyyyMMdd HH:mm:ss}] {1}", DateTime.Now, mes + Environment.NewLine) + txtEditResult.Text;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResult.Text);
            MessageBox.Show("Copied result to clipboard");
        }

        private void AddNew(bool updateIfExits = false)
        {
            btnAddNew.Enabled = false;
            btnUpdateOrNew.Enabled = false;
            List<ParameterFile> files = ParameterFiles;
            var newPara = new ParameterEntity()
            {
                AllowEmpty = cbEditAllowEmpty.Checked,
                Name = txtEditName.Text,
                Scope = txtScope.Text,
                XPathMatch = txtEditXPathMatch.Text,
                Type = txtEditXMLType.Text,
                Value = txtEditValue.Text
            };

            foreach (var f in files)
            {
                if (!f.Parameters.Any(x => x.Name == newPara.Name))
                {
                    f.CreateParameter(newPara);
                }
                else if (!updateIfExits)
                {
                    AddResultMessage(string.Format("Existed {0} in {1}", txtEditName.Text, f.FileName));
                }
                else
                {
                    f.UpdateParameter(newPara);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                AddNew();
            }
            catch (Exception ex)
            {
                AddResultMessage(ex.Message);
            }
            finally
            {
                btnAddNew.Enabled = true;
                btnUpdateOrNew.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateOrNew_Click(object sender, EventArgs e)
        {
            try
            {
                AddNew(true);
            }
            catch (Exception ex)
            {
                AddResultMessage(ex.Message);
            }
        }

        #region Config Source
        public string AppSettings
        {
            get
            {
                return Path.Combine(folderSource.FolderPath, "appSettings.config");
            }
        }
        public string WebConfig
        {
            get
            {
                return Path.Combine(folderSource.FolderPath, "Web.config");
            }
        }

        public string EPiServerConfig
        {
            get
            {
                return Path.Combine(folderSource.FolderPath, "EPiServer.config");
            }
        }
        public string FHSettingsConfig
        {
            get
            {
                return Path.Combine(folderSource.FolderPath, "FhSettings.config");
            }
        }
        public string SolrConfig
        {
            get
            {
                return Path.Combine(folderSource.FolderPath, "SolrCore.config");
            }
        }
        public string EPiSolrConfig
        {
            get
            {
                return Path.Combine(folderSource.FolderPath, "EPiSolr.config");
            }
        }
        public string EPiServerLogConfig
        {
            get
            {
                return Path.Combine(folderSource.FolderPath, "EPiServerLog.config");
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddedFiles()
        {
            try
            {
                foreach (var f in lstFiles.Items.Cast<string>())
                {
                    if (File.Exists(f))
                    {
                        var para = new ParameterFile(f);
                        AddResultMessage("Found file: " + f + " with " + para.ParameterCount.ToString() + " parameter(s)");
                    }
                }
            }
            catch (Exception ex)
            {
                AddResultMessage(ex.Message);
            }
        }

        private List<ParameterFile> ParameterFiles
        {
            get
            {
                List<ParameterFile> files = new List<ParameterFile>();
                foreach (var item in lstFiles.Items.Cast<string>())
                {
                    files.Add(new ParameterFile(item));
                }
                if (files.Count == 0)
                {
                    MessageBox.Show("No selected parameter files");
                }
                return files;
            }
        }

        private void lnkAddFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var f in openFileDialog1.FileNames)
                {
                    lstFiles.Items.Add(f);
                }
                AddedFiles();
            }
        }

        private void lnlClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtEditResult.Text = string.Empty;
        }

        private void lnlClearFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lstFiles.Items.Clear();
        }

        private void lnlCompare_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (lstFiles.SelectedItems.Count >= 2)
                {
                    List<ParameterFile> files = ParameterFiles;

                    foreach (var f in files)
                    {
                        foreach (var p in f.Parameters)
                        {
                            foreach (var f1 in files.Where(x => x.FileName != f.FileName))
                            {
                                if (!f1.Parameters.Any(x => x.Name == p.Name))
                                {
                                    AddResultMessage(string.Format(@"Compared found {0}\{1} but not found {2}\{1}", f.FileName, p.Name, f1.FileName));
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                AddResultMessage(ex.Message);
            }
        }

        private void btnSearchPara_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in ParameterFiles)
                {
                    if (!item.Parameters.Any(x => x.Name == txtParaSearch.Text || x.Value == txtParaSearch.Text))
                    {
                        AddResultMessage(string.Format(@"Not found ""{0}"" in ""{1}""", txtParaSearch.Text, item.FileName));
                    }
                }
            }
            catch (Exception ex)
            {
                AddResultMessage(ex.Message);
            }
        }

        #region Generate Configuration

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outRootParam"></param>
        /// <param name="commentString"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="scopeFile"></param>
        /// <param name="matchXPath"></param>
        void CreateParameter(ref XmlElement outRootParam, string commentString, string name, string value, string scopeFile, string matchXPath)
        {
            XmlComment comment = outRootParam.OwnerDocument.CreateComment(commentString);
            //parameter
            XmlElement outParam = outRootParam.OwnerDocument.CreateElement("parameter");

            //name
            XmlAttribute outAttName = outRootParam.OwnerDocument.CreateAttribute("name");
            outAttName.Value = name;
            outParam.Attributes.Append(outAttName);

            //value
            XmlAttribute outAttValue = outRootParam.OwnerDocument.CreateAttribute("value");
            outAttValue.Value = value;
            outParam.Attributes.Append(outAttValue);

            //name
            //XmlAttribute outAttDescription = outRootParam.OwnerDocument.CreateAttribute("description");
            //outAttDescription.Value = name;
            //outParam.Attributes.Append(outAttDescription);

            //parameterEntry
            XmlElement outScopeParam = outRootParam.OwnerDocument.CreateElement("parameterEntry");
            XmlAttribute outAttType = outRootParam.OwnerDocument.CreateAttribute("type");
            outAttType.Value = "XMLFile";
            outScopeParam.Attributes.Append(outAttType);

            //scope
            XmlAttribute outAttScope = outRootParam.OwnerDocument.CreateAttribute("scope");
            outAttScope.Value = scopeFile;
            outScopeParam.Attributes.Append(outAttScope);

            //match
            XmlAttribute outAttMatch = outRootParam.OwnerDocument.CreateAttribute("match");
            outAttMatch.Value = matchXPath;
            outScopeParam.Attributes.Append(outAttMatch);

            //output
            outParam.AppendChild(outScopeParam);

            outRootParam.AppendChild(comment);
            outRootParam.AppendChild(outParam);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void GenAppSettingsParameter(ref XmlElement outRootParam)
        {
            if (!File.Exists(AppSettings))
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(AppSettings);

            var nodes = doc.DocumentElement.ChildNodes;

            foreach (XmlElement n in nodes.OfType<XmlElement>())
            {
                CreateParameter(ref outRootParam
                    , string.Format("AppSettings: {0}", n.Attributes["key"].Value)
                    , n.Attributes["key"].Value
                    , n.Attributes["value"].Value
                    , "appSettings.config$"
                    , string.Format("//*[@key='{0}']/@value", n.Attributes["key"].Value));
            }
        }

        void GenFHSettingsParameter(ref XmlElement outRootParam)
        {
            if (!File.Exists(FHSettingsConfig))
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(FHSettingsConfig);

            var nodes = doc.DocumentElement.ChildNodes;

            foreach (XmlElement n in nodes.OfType<XmlElement>())
            {
                CreateParameter(ref outRootParam
                    , string.Format("FH Settings: {0}", n.Attributes["key"].Value)
                    , "FH_" + n.Attributes["key"].Value
                    , n.Attributes["value"].Value
                    , "FhSettings.config$"
                    , string.Format("//*[@key='{0}']/@value", n.Attributes["key"].Value));
            }
        }

        void GenSolrConfigsParameter(ref XmlElement outRootParam)
        {
            //solrcore
            if (!File.Exists(SolrConfig))
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(SolrConfig);

            var node = doc.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "general");

            if (node != null)
            {
                foreach (XmlAttribute n in node.Attributes)
                {
                    CreateParameter(ref outRootParam
                        , string.Format("SolrCore: {0}", n.Name)
                        , "SolrCore_" + n.Name
                        , n.Value
                        , "SolrCore.config$"
                        , string.Format("//@{0}", n.Name));
                }
            }

            //episolr
            if (!File.Exists(EPiSolrConfig))
            {
                return;
            }

            XmlDocument docepisolr = new XmlDocument();
            docepisolr.Load(EPiSolrConfig);

            var episolr = docepisolr.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "general");

            if (episolr != null)
            {
                foreach (XmlAttribute n in episolr.Attributes)
                {
                    CreateParameter(ref outRootParam
                        , string.Format("EPiSolr: {0}", n.Name)
                        , "EPiSore_" + n.Name
                        , n.Value
                        , "EPiSolr.config$"
                        , string.Format("//@{0}", n.Name));
                }
            }
        }


        void GenWebConfigsParameter(ref XmlElement outRootParam)
        {
            //solrcore
            if (!File.Exists(WebConfig))
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(WebConfig);

            //PTB
            CreateParameter(ref outRootParam
                        , string.Format("WebConfig: {0}", "disablePageTypeUpdation")
                        , "WebConfig_PTB"
                        , "true"
                        , "Web.config$"
                        , "//@disablePageTypeUpdation");

            //combinedScripts
            var node = doc.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "combinedScripts");
            if (node != null)
            {
                foreach (XmlAttribute n in node.Attributes)
                {
                    CreateParameter(ref outRootParam
                        , string.Format("WebConfig: {0}", n.Name)
                        , "WebConfig_" + n.Name
                        , n.Value
                        , "Web.config$"
                        , string.Format("//@{0}", n.Name));
                }
            }

            //proxy
            var nodedefaultProxy = doc.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "system.net")
                .ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "defaultProxy");
            if (nodedefaultProxy != null)
            {
                CreateParameter(ref outRootParam
                       , string.Format("WebConfig remove: {0}", "Proxy")
                       , "WebConfig_remove_Proxy"
                       , ""
                       , "Web.config$"
                       , "/configuration/system.net/defaultProxy");

                CreateParameter(ref outRootParam
                       , string.Format("WebConfig: {0}", "Proxy")
                       , "WebConfig_replaceby_Proxy"
                       , nodedefaultProxy.OuterXml
                       , "Web.config$"
                       , "/configuration/system.net");
            }

            //smtp
            var mailSettings = doc.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "system.net")
                .ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "mailSettings");
            if (mailSettings != null)
            {
                CreateParameter(ref outRootParam
                       , string.Format("WebConfig Remove: {0}", "mailSettings")
                       , "WebConfig_remove_mailSettings"
                       , ""
                       , "Web.config$"
                       , "/configuration/system.net/mailSettings");

                CreateParameter(ref outRootParam
                   , string.Format("WebConfig Replace: {0}", "mailSettings")
                   , "WebConfig_replaceby_mailSettings"
                   , mailSettings.OuterXml
                   , "Web.config$"
                   , "/configuration/system.net");

            }

            var systemWeb = doc.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "system.web");
            if (systemWeb != null)
            {
                //membership defaultProvider
                var membership = systemWeb.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "membership");
                CreateParameter(ref outRootParam
                  , string.Format("WebConfig : {0}", "membership")
                  , "WebConfig_membership_provider"
                  , membership.Attributes["defaultProvider"].Value
                  , "Web.config$"
                  , "/configuration/system.web/membership/@defaultProvider");

                //customErrors
                var customError = systemWeb.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "customErrors");
                CreateParameter(ref outRootParam
                      , string.Format("WebConfig Remove Old: {0}", "customErrors")
                      , "WebConfig_remove_customErrors"
                      , ""
                      , "Web.config$"
                      , "/configuration/system.web/membership/customErrors");

                CreateParameter(ref outRootParam
                   , string.Format("WebConfig Replace By New: {0}", "customErrors")
                   , "WebConfig_replaceby_customErrors"
                   , customError.OuterXml
                   , "Web.config$"
                   , "/configuration/system.web/membership/customErrors");


                //httpModules
                var httpModules = systemWeb.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "httpModules");
                var modules = httpModules.ChildNodes.OfType<XmlElement>().ToArray();
                for (int i = modules.Length - 1; i >= 0; i--)
                {
                    CreateParameter(ref outRootParam
                           , string.Format("WebConfig Remove Old: {0}", "httpModule")
                           , "WebConfig_remove_httpModule" + modules[i].Attributes["name"].Value
                           , ""
                           , "Web.config$"
                           , "/configuration/system.web/httpModules/add[@name='" + modules[i].Attributes["name"].Value + "']");

                    CreateParameter(ref outRootParam
                       , string.Format("WebConfig Replace By New: {0}", "httpModule")
                       , "WebConfig_replaceby_httpModule" + modules[i].Attributes["name"].Value
                       , modules[i].OuterXml
                       , "Web.config$"
                       , "/configuration/system.web/httpModules");
                }
                //compilation
                CreateParameter(ref outRootParam
                  , string.Format("WebConfig: {0}", "compilation")
                  , "WebConfig_compilation"
                  , "false"
                  , "Web.config$"
                  , "//@debug");

                //authentication
                var forms = systemWeb.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "authentication")
                    .ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "forms");

                CreateParameter(ref outRootParam
                                        , string.Format("WebConfig replace: {0}", "forms")
                                        , "WebConfig_authentication_remove_forms"
                                        , ""
                                        , "Web.config$"
                                        , "/configuration/system.web/authentication/forms");

                if (forms != null)
                {
                    CreateParameter(ref outRootParam
                        , string.Format("WebConfig: {0}", "forms")
                        , "WebConfig_authentication_add_forms"
                        , forms.OuterXml
                        , "Web.config$"
                        , "/configuration/system.web/authentication");
                }
            }
            //system.webServer
            var systemwebServer = doc.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "system.webServer");
            var httpError = systemwebServer.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "httpErrors");

            CreateParameter(ref outRootParam
                      , string.Format("WebConfig system.webServer remove: {0}", "httpErrors")
                      , "WebConfig_remove_httpErrors"
                      , ""
                      , "Web.config$"
                      , "/configuration/system.webServer/httpErrors");

            if (httpError != null)
            {


                CreateParameter(ref outRootParam
                    , string.Format("WebConfig system.webServer add: {0}", "httpErrors")
                    , "WebConfig_add_httpErrors"
                    , httpError.OuterXml
                    , "Web.config$"
                    , "/configuration/system.webServer");
            }

            //system.serviceModel
            var serviceModel = doc.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "system.serviceModel")
                .ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "client");

            foreach (var item in serviceModel.ChildNodes.OfType<XmlElement>().Where(x => x.Name == "endpoint"))
            {
                CreateParameter(ref outRootParam
                , string.Format("WebConfig system.serviceModel set: {0}", item.Attributes["name"].Value)
                , "WebConfig_serviceModel_enpoint_" + item.Attributes["name"].Value
                , item.Attributes["address"].Value
                , "Web.config$"
                , string.Format("/configuration/system.serviceModel/client/endpoint[@name='{0}']/@address", item.Attributes["name"].Value));
            }

            var services = doc.DocumentElement.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "system.serviceModel")
                .ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "services")
                .ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "service" && x.Attributes["name"].Value == "EPiServer.Events.Remote.EventReplication");

            CreateParameter(ref outRootParam
                               , string.Format("WebConfig system.serviceModel remove: {0}", "EventReplication")
                               , "WebConfig_remove_EventReplication"
                               , ""
                               , "Web.config$"
                               , "/configuration/system.serviceModel/services/service[@name='EPiServer.Events.Remote.EventReplication']");

            if (services != null)
            {
                CreateParameter(ref outRootParam
                    , string.Format("WebConfig system.serviceModel add: {0}", "EventReplication")
                    , "WebConfig_add_EventReplication"
                    , services.OuterXml
                    , "Web.config$"
                    , "/configuration/system.serviceModel/services");
            }
        }

        void GenPrivateConfigsParameter(ref XmlElement outRootParam)
        {



        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void GenEPiServerParameters(ref XmlElement outRootParam)
        {
            if (!File.Exists(EPiServerConfig))
            {
                return;
            }
            XmlDocument doc = new XmlDocument();

            doc.Load(EPiServerConfig);

            var nodes = doc.DocumentElement.ChildNodes;

            //site 
            string xpath = "/";
            XmlNode node = doc.DocumentElement.ChildNodes.OfType<XmlElement>().First(x => x.Name == "sites").FirstChild;

            string _attname = "description";
            CreateParameter(ref outRootParam
                    , string.Format("EPiServer site: {0}", _attname)
                    , "Site_" + _attname
                    , node.Attributes[_attname].Value
                    , "EPiServer.config$"
                    , xpath + "/@" + _attname);

            _attname = "siteId";
            CreateParameter(ref outRootParam
                    , string.Format("EPiServer site: {0}", _attname)
                    , "Site_" + _attname
                    , node.Attributes[_attname].Value
                    , "EPiServer.config$"
                    , xpath + "/@" + _attname);

            //site settings
            node = node.FirstChild;
            xpath = "/";
            foreach (XmlAttribute att in node.Attributes)
            {
                _attname = att.Name;
                CreateParameter(ref outRootParam
                        , string.Format("EPiServer site settings: {0}", _attname)
                        , "SiteSettings_" + _attname
                        , node.Attributes[_attname].Value
                        , "EPiServer.config$"
                        , xpath + "/@" + _attname);
            }

            //VPP
            node = doc.DocumentElement.ChildNodes.OfType<XmlElement>().First(x => x.Name == "virtualPath").FirstChild;
            //node = node.FirstChild;

            foreach (XmlNode vpp in node.ChildNodes.OfType<XmlElement>().Where(x => x.Name == "add"))
            {
                if (vpp.Attributes["physicalPath"] != null)
                {
                    CreateParameter(ref outRootParam
                            , string.Format("EPiServer vpp settings: {0}", vpp.Attributes["name"].Value)
                            , "VPP_" + vpp.Attributes["name"].Value
                            , vpp.Attributes["physicalPath"].Value
                            , "EPiServer.config$"
                            , string.Format("//*[@virtualPath='{0}']/@physicalPath", vpp.Attributes["virtualPath"].Value));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outRootParam"></param>
        void GenEPiServerLogParameter(ref XmlElement outRootParam)
        {
            if (!File.Exists(EPiServerLogConfig))
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(EPiServerLogConfig);

            var nodes = doc.DocumentElement.ChildNodes;

            foreach (XmlElement n in nodes.OfType<XmlElement>().Where(x => x.Name == "appender"))
            {
                XmlElement fileTag =
                    n.ChildNodes.OfType<XmlElement>().FirstOrDefault(x => x.Name == "file");

                if (fileTag != null && fileTag.Attributes["value"] != null)
                {
                    CreateParameter(ref outRootParam
                         , string.Format("EPiServer Log: {0}", n.Attributes["name"].Value)
                         , "EPiLog" + n.Attributes["name"].Value
                         , n.ChildNodes.OfType<XmlElement>().First(x => x.Name == "file").Attributes["value"].Value
                         , "EPiServerLog.config$"
                         , string.Format("/log4net/appender[@name='{0}']/file/@value", n.Attributes["name"].Value));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenAppSettingsConfig_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument output = new XmlDocument();
                XmlElement outRootParam = output.CreateElement("parameters");
                output.AppendChild(outRootParam);

                GenSolrConfigsParameter(ref outRootParam);
                GenAppSettingsParameter(ref outRootParam);
                GenEPiServerParameters(ref outRootParam);
                GenEPiServerLogParameter(ref outRootParam);
                GenFHSettingsParameter(ref outRootParam);
                GenWebConfigsParameter(ref outRootParam);

                using (FileStream fs = File.Create(Path.Combine(folderPicker1.FolderPath, txtParamFile.Text + ".xml")))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(@"<?xml version=""1.0"" encoding=""utf-8""?>" + Environment.NewLine +
                           output.OuterXml
                            );
                        sw.Flush();
                    }
                }

                MessageBox.Show("Generated the parameters succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        private bool _resolving;

        public bool Resolving
        {
            get { return _resolving; }
            set
            {
                _resolving = value;
                btnResolveConfig.Visible = !value;
                lbResolving.Visible = value;
            }
        }


        private async void btnResolveConfig_Click(object sender, EventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                Resolving = true;
                // Start the child process.
                try
                {
                    Process p = new Process();
                    // Redirect the output stream of the child process.
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.FileName = "msdeploy";
                    p.StartInfo.Arguments = string.Format("-verb:sync -source:contentPath={0} -dest:contentPath={1} -setParamFile={2}",
                        folderTestConfig.FolderPath,
                        folderTestConfig.FolderPath,
                        filePickerParameter.FilePath);
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    // Do not wait for the child process to exit before
                    // reading to the end of its redirected stream.
                    // p.WaitForExit();
                    // Read the output stream first and then wait.
                    txtOutput.Text = string.Format("[{0:HH.mm.ss}] {1} {2}", DateTime.Now, Environment.NewLine, p.StandardOutput.ReadToEnd());
                    p.WaitForExit();
                }
                finally
                {
                    Resolving = false;
                }
            });

        }

        private void Convertor_Load(object sender, EventArgs e)
        {
            this.Text = ProductName + " " + ProductVersion;
        }

    }
}
