using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ConfigSync.Para.Tools;
namespace ConfigSync.Para
{
    public partial class Main : Form
    {
        public const string NodeWebConfig = "Web.config";
        public const string NodeAppConfig = "appSettings";
        public const string NodePlatformConfig = "platformSettings";
        public const string NodeVpp = "VPP";
        public const string NodeSites = "Sites";
        public const string NodeOthers = "Others";
        public const string NodeServicePlus = "ServicePlus";
        public const string NodeFinancialHubSettings = "FinancialHubSettings";
        public const string NodeBurstCache = "BurstCache";
        public const string NodeSMTP = "SMTP";
        public const string NodeProxy = "Proxy";
        public const string NodeSolr = "Solr";
        public const string NodePageTypeBuilder = "PageTypeBuilder";
        public const string NodeServices = "Services";
        public const string NodeDebug = "Debug";

        public Main()
        {
            InitializeComponent();
        }

        #region Path
        private string PathEPiSolrConfig { get { return Path.Combine(folderPicker.FilePath, "EPiSolr.config"); } }
        private string PathSolrCoreConfig { get { return Path.Combine(folderPicker.FilePath, "SolrCore.config"); } }
        public string PathEPIConfig { get { return Path.Combine(folderPicker.FilePath, "Episerver.config"); } }
        public string PathWebConfig { get { return Path.Combine(folderPicker.FilePath, "Web.config"); } }
        public string PathAppConfig { get { return Path.Combine(folderPicker.FilePath, "appSettings.config"); } }
        public string PathPlatformConfig { get { return Path.Combine(folderPicker.FilePath, "platformSettings.config"); } }
        public string PathServicePlusConfig { get { return Path.Combine(folderPicker.FilePath, "ServicePlus.config"); } }        
        public string PathFinancialHubSettingsConfig { get { return Path.Combine(folderPicker.FilePath, "FhSettings.config"); } }
        #endregion

        internal void AddError(string msg)
        {
            try
            {
                errors.DropDownItems.Add(string.Format("{0}.{1}", errors.DropDownItems.Count + 1, msg)).ForeColor = Color.Red;
                errors.Text = string.Format("Errors ({0})!", warnings.DropDownItems.Count);
                errors.DropDownItems.Insert(0, new ToolStripSeparator());
                ToolStripMenuItem _mi = new ToolStripMenuItem() { Text = "Clear" };
                _mi.Click += _mi_Click;
                errors.DropDownItems.Insert(0, _mi);
            }
            catch (Exception)
            {
                ;
            }
        }

        void _mi_Click(object sender, EventArgs e)
        {
            ClearError();
        }
        TreeNode SetTagForDbClkEdit(TreeNode node, XmlNode xnode, string configFile, string xpath, string attrname, string onValue = "true")
        {
            node.ForeColor = xnode.Attributes[attrname] != null && xnode.Attributes[attrname].Value.ToLower() == onValue ? Color.Green : Color.Gray;
            node.ToolTipText = node.ForeColor == Color.Gray ? "Off" : "On";
            node.Tag = string.Format("DBCLK|{0}|{1}|{2}", configFile, xpath, attrname);
            return node;
        }
        internal void AddWarning(string msg)
        {
            try
            {
                warnings.DropDownItems.Add(string.Format("{0}.{1}", warnings.DropDownItems.Count + 1, msg)).ForeColor = Color.Red;
                warnings.Text = string.Format("Wrong configurations ({0})!", warnings.DropDownItems.Count);
            }
            catch (Exception)
            {
                ;
            }
        }

        void FeedSitesNode(XmlDocument xdoc)
        {
            try
            {
                #region Sites node
                XmlNodeList _sites = xdoc.DocumentElement.ChildNodes.Cast<XmlNode>().FirstOrDefault(x => x.Name == "sites").ChildNodes;
                treeView.Nodes["Sites"].Nodes.Clear();
                foreach (XmlNode site in _sites)
                {
                    TreeNode _nSite = new TreeNode();
                    _nSite.Text = site.Attributes["siteId"].Value;
                    _nSite.ToolTipText = site.Attributes["description"].Value;
                    _nSite.Name = site.Attributes["siteId"].Value;


                    XmlNode _sitesettings = site.FirstChild;

                    foreach (XmlAttribute setting in _sitesettings.Attributes)
                    {
                        _nSite.Nodes.Add(new TreeNode() { Name = setting.Name, Text = string.Format(setting.Name + "= {0}", setting.Value) });
                    }

                    treeView.Nodes["Sites"].Nodes.Add(_nSite);
                }

                treeView.Nodes[NodeSites].Text = string.Format("{0} ({1})", NodeSites, treeView.Nodes[NodeSites].FirstNode.Nodes.Count);
                #endregion
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
            }
        }

        void FeedVPPNode(XmlDocument xdoc)
        {
            try
            {
                int _errorCount = 0;
                #region VPP node
                XmlNodeList _vpp = xdoc.DocumentElement.ChildNodes.Cast<XmlNode>().FirstOrDefault(x => x.Name == "virtualPath").ChildNodes
                    .Cast<XmlNode>().FirstOrDefault(x => x.Name == "providers").ChildNodes;
                treeView.Nodes[NodeVpp].Nodes.Clear();

                foreach (XmlNode site in _vpp.Cast<XmlNode>().Where(x => x.Name == "add").OrderBy(x => x.Attributes["name"].Value))
                {
                    try
                    {
                        TreeNode _node = new TreeNode();
                        // _vppNode.Text = site.Attributes["name"].Value;
                        string _physicalPath = site.Attributes["physicalPath"] != null ? site.Attributes["physicalPath"].Value : "(none)";
                        _node.Text = string.Format("{0}. {1}= {2}", treeView.Nodes["VPP"].Nodes.Count + 1, site.Attributes["name"].Value,
                                           _physicalPath);
                        _node.ToolTipText = site.Attributes["virtualPath"].Value;
                        _node.Name = site.Attributes["name"].Value;

                        if (VerifyDuplication(treeView.Nodes[NodeVpp], _node) == 1)
                        {
                            this.AddWarning("VPP got duplication key: " + _node.Name);
                            _errorCount++;
                        }
                        else
                        {
                            string _parentOfWebroot = Directory.GetParent(folderPicker.FilePath.TrimEnd('\\')).FullName;
                            if (_physicalPath.StartsWith(@"..\") && !Directory.Exists(Path.Combine(_parentOfWebroot, _physicalPath.Replace(@"..\", ""))))
                            {
                                _node.ForeColor = Color.Red;
                                _node.ToolTipText = "Physical path is not exists";
                                this.AddWarning("VPP Physical path is not exists: " + _physicalPath);
                                _errorCount++;
                            }
                            else
                            {
                                _node.ForeColor = Color.Green;
                            }
                        }


                        treeView.Nodes[NodeVpp].Nodes.Add(_node);
                    }
                    catch (Exception)
                    {
                        this.AddError("VPP:" + site.Attributes["name"].Value);
                    }
                }

                treeView.Nodes[NodeVpp].Text = string.Format("{0} ({1}) - errors: {2}", NodeVpp, treeView.Nodes[NodeVpp].Nodes.Count,
                    _errorCount);

                treeView.Nodes[NodeVpp].ForeColor = _errorCount > 0 ? Color.Red : Color.Black;
                #endregion
            }
            catch (Exception ex)
            {
                this.AddError("VPP:" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void FeedSolr()
        {
            try
            {
                TreeNode _nodeSolr = treeView.Nodes[NodeSolr];
                _nodeSolr.Nodes.Clear();

                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(PathSolrCoreConfig);

                #region SolrCore
                XmlNode _solrCore = xdoc.DocumentElement.SelectNodes("general")[0];
                TreeNode _treeNodeSolr = new TreeNode() { Text = "Core", Name = "Core" };
                foreach (XmlAttribute at in _solrCore.Attributes)
                {
                    _treeNodeSolr.Nodes.Add(new TreeNode() { Name = at.Name, Tag = at.Value, Text = string.Format("{0}: {1}", at.Name, at.Value) });
                }

                _nodeSolr.Nodes.Add(_treeNodeSolr);
                #endregion

                xdoc = new XmlDocument();
                xdoc.Load(PathEPiSolrConfig);

                #region EPiCore
                XmlNode _solrEpi = xdoc.DocumentElement.SelectNodes("general")[0];
                TreeNode _treeNodeEPiSolr = new TreeNode() { Text = "EPi", Name = "EPi" };
                foreach (XmlAttribute at in _solrEpi.Attributes)
                {
                    _treeNodeEPiSolr.Nodes.Add(new TreeNode() { Name = at.Name, Tag = at.Value, Text = string.Format("{0}: {1}", at.Name, at.Value) });
                }

                _nodeSolr.Nodes.Add(_treeNodeEPiSolr);
                #endregion
            }
            catch (Exception ex)
            {
                this.AddError("Solr:" + ex.Message);
            }
        }
        /// <summary>
        /// FeedWebConfig
        /// </summary>
        void FeedWebConfig()
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(PathWebConfig);
                XmlNodeList _node1 = xdoc.DocumentElement.SelectNodes("system.web/httpModules/add[@name='BurstCacheModule']");
                XmlNodeList _node2 = xdoc.DocumentElement.SelectNodes("system.webServer/modules/add[@name='BurstCacheModule']");

                TreeNode _node = treeView.Nodes[NodeWebConfig].Nodes[NodeBurstCache];
                _node.Nodes.Clear();
                //XmlNode _burst = xdoc.CreateNode(XmlNodeType.Element, "add", "");
                //  _burst.Attributes.Append(new XmlAttribute(){ Value="", });
                #region BurstCache
                try
                {
                    if (_node1.Count == 1)
                    {
                        _node.Nodes.Add(new TreeNode()
                        {
                            Name = NodeBurstCache + "OnSystemWeb",
                            Text = NodeBurstCache + " On system.web",
                        });
                    }

                    if (_node2.Count == 1)
                    {
                        _node.Nodes.Add(new TreeNode()
                        {
                            Name = NodeBurstCache + "OnSystemwebServer",
                            Text = NodeBurstCache + " On system.webServer",
                        });
                    }

                    _node.ForeColor = _node.Nodes.Count == 0 ? Color.Gray : Color.Green;
                    _node.ToolTipText = _node.Nodes.Count == 0 ? "Off" : "On";

                    _node.Tag = @"<add name=""BurstCacheModule"" type=""Bonnier.BurstCache.CacheModule, Bonnier.BurstCache""/>";
                }
                catch (Exception ex)
                {
                    this.AddError(NodeProxy + ex.Message);
                    _node.ForeColor = Color.Red;
                }
                #endregion

                TreeNode _nodeDebug = treeView.Nodes[NodeWebConfig].Nodes[NodeDebug];
                _nodeDebug.Nodes.Clear();
                XmlNode _xdebug = xdoc.DocumentElement.SelectSingleNode("system.web/compilation");
                #region DEBUG
                try
                {

                    _nodeDebug.ForeColor = _xdebug.Attributes["debug"].Value == "false" ? Color.Gray : Color.Green;
                    _nodeDebug.ToolTipText = _xdebug.Attributes["debug"].Value == "false" ? "Off" : "On";

                    _nodeDebug.Tag = string.Format("DBCLK|{0}|system.web/compilation|debug", PathWebConfig);
                }
                catch (Exception ex)
                {
                    this.AddError(NodeProxy + ex.Message);
                    _node.ForeColor = Color.Red;
                }
                #endregion

                TreeNode _nodeSmtp = treeView.Nodes[NodeWebConfig].Nodes[NodeSMTP];
                _nodeSmtp.Nodes.Clear();

                #region SMTP
                XmlNodeList _smtp = xdoc.DocumentElement.SelectNodes("system.net/mailSettings/smtp");
                try
                {
                    foreach (XmlNode item in _smtp)
                    {
                        foreach (XmlAttribute a in item.Attributes)
                        {
                            _nodeSmtp.Nodes.Add(
                                new TreeNode()
                                {
                                    Name = a.Name,
                                    Text = string.Format("{0}: {1}", a.Name, a.Value)
                                }
                                );
                        }
                        foreach (XmlNode subitem in item.ChildNodes)
                        {
                            TreeNode _subNode = new TreeNode()
                                 {
                                     Name = subitem.Name,
                                     Text = subitem.Name
                                 };
                            _nodeSmtp.Nodes.Add(_subNode);
                            foreach (XmlAttribute a in subitem.Attributes)
                            {
                                _subNode.Nodes.Add(
                                    new TreeNode()
                                    {
                                        Name = a.Name,
                                        Text = string.Format("{0}: {1}", a.Name, a.Value)
                                    }
                                    );
                            }
                        }
                    }

                    _nodeSmtp.ForeColor = _nodeSmtp.Nodes.Count == 0 ? Color.Gray : Color.Green;
                    _nodeSmtp.ToolTipText = _nodeSmtp.Nodes.Count == 0 ? "Off" : "On";
                }
                catch (Exception ex)
                {
                    this.AddError(NodeProxy + ex.Message);
                    _nodeSmtp.ForeColor = Color.Red;
                }
                #endregion

                TreeNode _nodeProxy = treeView.Nodes[NodeWebConfig].Nodes[NodeProxy];
                _nodeProxy.Nodes.Clear();

                #region Proxy
                XmlNodeList _proxies = xdoc.DocumentElement.SelectNodes("system.net/defaultProxy");
                try
                {
                    if (_proxies.Count == 1)
                    {
                        foreach (XmlNode subProxy in _proxies[0].ChildNodes.Cast<XmlNode>().Where(x => x.NodeType == XmlNodeType.Element))
                        {
                            TreeNode _subNode = new TreeNode()
                                {
                                    Name = subProxy.Name,
                                    Text = subProxy.Name
                                };
                            _nodeProxy.Nodes.Add(_subNode);
                            if (_subNode.Name == "proxy")
                            {
                                foreach (XmlAttribute a in subProxy.Attributes)
                                {
                                    _subNode.Nodes.Add(
                                        new TreeNode()
                                        {
                                            Name = a.Name,
                                            Text = string.Format("{0}: {1}", a.Name, a.Value)
                                        });
                                }
                            }
                            else if (_subNode.Name == "bypasslist")
                            {
                                foreach (XmlNode byPass in subProxy.ChildNodes)
                                {
                                    _subNode.Nodes.Add(new TreeNode()
                                    {
                                        Name = byPass.Attributes["address"].Value,
                                        Text = string.Format("address: {0}", byPass.Attributes["address"].Value)
                                    });
                                }
                            }
                        }
                    }

                    _nodeProxy.ForeColor = _nodeProxy.Nodes.Count == 0 ? Color.Gray : Color.Green;
                    _nodeProxy.ToolTipText = _nodeProxy.Nodes.Count == 0 ? "Off" : "On";
                }
                catch (Exception ex)
                {
                    this.AddError(NodeProxy + ex.Message);
                    _nodeProxy.ForeColor = Color.Red;
                }
                #endregion

                #region PageTyeBuilder
                try
                {
                    TreeNode _nodePTB = treeView.Nodes[NodeWebConfig].Nodes[NodePageTypeBuilder];
                    XmlNode _xmlPtb = xdoc.DocumentElement.SelectNodes("pageTypeBuilder")[0];
                    SetTagForDbClkEdit(_nodePTB, _xmlPtb, PathWebConfig, "pageTypeBuilder", "disablePageTypeUpdation", "false");
                }
                catch (Exception ex)
                {
                    this.AddError(NodePageTypeBuilder + ex.Message);
                    _nodeSmtp.ForeColor = Color.Red;
                }
                #endregion

                #region Services
                TreeNode _nodeSvr = treeView.Nodes[NodeWebConfig].Nodes[NodeServices];
                _nodeSvr.Nodes.Clear();
                XmlNodeList _clientEnpoints = xdoc.DocumentElement.SelectNodes("system.serviceModel/client/endpoint");
                XmlNodeList _serviceEnpoints = xdoc.DocumentElement.SelectNodes("system.serviceModel/services/service");
                try
                {
                    foreach (XmlNode client in _clientEnpoints.Cast<XmlNode>().Union(_serviceEnpoints.Cast<XmlNode>()))
                    {
                        TreeNode _xclient = new TreeNode() { Text = client.Name };
                        _nodeSvr.Nodes.Add(_xclient);

                        foreach (XmlAttribute a in client.Attributes)
                        {
                            if (a.Name == "address")
                            {
                                _xclient.Nodes.Add(SetTagForDbClkEdit(
                                   new TreeNode()
                                   {
                                       Name = a.Name,
                                       Text = string.Format("{0}: {1}", a.Name, a.Value)
                                   }, client, PathWebConfig, "system.serviceModel/client/endpoint[@name='" + client.Attributes["name"].Value + "']", "address", a.Value));
                            }
                            else
                            {
                                _xclient.Nodes.Add(
                                    new TreeNode()
                                    {
                                        Name = a.Name,
                                        Text = string.Format("{0}: {1}", a.Name, a.Value)
                                    });
                            }
                        }

                        if (client.HasChildNodes)
                        {
                            foreach (XmlNode ep in client.ChildNodes.Cast<XmlNode>().Where(x => x.NodeType == XmlNodeType.Element))
                            {
                                TreeNode _child = new TreeNode() { Text = ep.Name };
                                _xclient.Nodes.Add(_child);

                                foreach (XmlAttribute a in ep.Attributes)
                                {
                                    //_child.Nodes.Add(
                                    //    new TreeNode()
                                    //    {
                                    //        Name = a.Name,
                                    //        Text = string.Format("{0}: {1}", a.Name, a.Value)
                                    //    });

                                    if (a.Name == "address")
                                    {
                                        _child.Nodes.Add(SetTagForDbClkEdit(
                                           new TreeNode()
                                           {
                                               Name = a.Name,
                                               Text = string.Format("{0}: {1}", a.Name, a.Value)
                                           }, client, PathWebConfig, "system.serviceModel/services/service[@name='" + client.Attributes["name"].Value + "']/endpoint", "address", a.Value));
                                    }
                                    else
                                    {
                                        _child.Nodes.Add(
                                            new TreeNode()
                                            {
                                                Name = a.Name,
                                                Text = string.Format("{0}: {1}", a.Name, a.Value)
                                            });
                                    }
                                }
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    this.AddError(NodeServices + ex.Message);
                    _nodeSvr.ForeColor = Color.Red;
                }
                #endregion


            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        void FeedServicePlusConfig()
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(PathServicePlusConfig);

                #region Service Plus
                TreeNode _nodeServicePlus = treeView.Nodes[NodeServicePlus];
                _nodeServicePlus.Nodes.Clear();

                XmlNodeList _sites = xdoc.DocumentElement.SelectNodes("sites/site");
                foreach (XmlNode site in _sites)
                {
                    TreeNode _nSite = new TreeNode();
                    _nSite.Text = site.Attributes["id"].Value;
                    _nSite.Name = _nSite.Text;
                    XmlNode _sitesettings = site.FirstChild;

                    foreach (XmlAttribute setting in site.Attributes)
                    {
                        switch (setting.Name.ToLower())
                        {
                            case "ispremium":
                                _nSite.Nodes.Add(SetTagForDbClkEdit(new TreeNode()
                                {
                                    Name = setting.Name,
                                    Text = string.Format(setting.Name + "= {0}", setting.Value)
                                }, site, PathServicePlusConfig, "sites/site[@id='" + site.Attributes["id"].Value + "']", "isPremium", "true"));
                                break;
                            case "domain":
                                _nSite.Nodes.Add(SetTagForDbClkEdit(new TreeNode()
                                {
                                    Name = setting.Name,
                                    Text = string.Format(setting.Name + "= {0}", setting.Value)
                                }, site, PathServicePlusConfig, "sites/site[@id='" + site.Attributes["id"].Value + "']", "domain", treeView.Nodes[NodeSites].Nodes[site.Attributes["id"].Value].Nodes["siteUrl"].Text.Replace("siteUrl=", "").Trim()));
                                if (_nSite.Nodes[setting.Name].ForeColor == Color.Gray)
                                {
                                    this.AddError(NodeServicePlus + " wrong 'domain' with EPiServer siteUrl");
                                }
                                break;
                            default:
                                _nSite.Nodes.Add(new TreeNode()
                               {
                                   Name = setting.Name,
                                   Text = string.Format(setting.Name + "= {0}", setting.Value)
                               });
                                break;
                        }
                    }

                    //authentication info
                    XmlNode _aut = site.SelectSingleNode("authentication");
                    var _nAut = new TreeNode()
                    {
                        Name = _aut.Name,
                        Text = _aut.Name
                    };

                    foreach (XmlAttribute autSetting in _aut.Attributes)
                    {
                        _nAut.Nodes.Add(new TreeNode()
                        {
                            Name = autSetting.Name,
                            Text = string.Format(autSetting.Name + "= {0}", autSetting.Value)
                        });
                    }

                    string _callbackAfterRegisterAndPay = _aut.SelectSingleNode("actions/action[@name='registerAndPay']/parameters/add[@name='callback']").Attributes["value"].Value;

                    TreeNode _xcallbackAfterRegisterAndPay = new TreeNode()
                    {
                        Name = _callbackAfterRegisterAndPay,
                        Text = string.Format("registerAndPay.callback = {0}", _callbackAfterRegisterAndPay
                        )
                    };
                    _xcallbackAfterRegisterAndPay.ForeColor = (_callbackAfterRegisterAndPay == site.Attributes["domain"].Value ? Color.Green : Color.Red);
                    _nAut.Nodes.Add(_xcallbackAfterRegisterAndPay);
                    if (_xcallbackAfterRegisterAndPay.ForeColor == Color.Red)
                    {
                        this.AddError(NodeServicePlus + " wrong 'callback' for registerAndPay");
                    }

                    _callbackAfterRegisterAndPay = _aut.SelectSingleNode("actions/action[@name='pay']/parameters/add[@name='callback']").Attributes["value"].Value;

                    TreeNode _xPay = new TreeNode()
                    {
                        Name = _callbackAfterRegisterAndPay,
                        Text = string.Format("pay.callback = {0}", _callbackAfterRegisterAndPay
                        )
                    };
                    _xPay.ForeColor = (_callbackAfterRegisterAndPay == site.Attributes["domain"].Value ? Color.Green : Color.Red);
                    _nAut.Nodes.Add(_xPay);
                    if (_xPay.ForeColor == Color.Red)
                    {
                        this.AddError(NodeServicePlus + " wrong 'callback' for pay");
                    }

                    _nSite.Nodes.Add(_nAut);

                    //_nSite.Nodes.Add(, site, PathServicePlusConfig, "sites/site[@id='" + site.Attributes["id"].Value + "']", "isPremium"));

                    _nodeServicePlus.Nodes.Add(_nSite);
                }

                _nodeServicePlus.Text = string.Format("{0} ({1})", NodeServicePlus, _nodeServicePlus.Nodes.Count);
                #endregion
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
            }
        }

        /// <summary>
        /// Reload 
        /// </summary>
        void FeedAppSettingsConfig()
        {
            try
            {
                int _errorCount = 0;
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(PathAppConfig);

                XmlNodeList _appsettings = xdoc.DocumentElement.ChildNodes;

                treeView.Nodes[NodeAppConfig].Nodes.Clear();
                foreach (XmlNode app in _appsettings.Cast<XmlNode>().Where(x => x.NodeType == XmlNodeType.Element))//.Cast<XmlNode>().OrderBy(x=>x.Attributes["name"].Value))
                {
                    try
                    {
                        TreeNode _node = new TreeNode();

                        _node.Text = string.Format("{0}. {1}= {2}", treeView.Nodes[NodeAppConfig].Nodes.Count + 1, app.Attributes["key"].Value,
                                           app.Attributes["value"].Value);
                        _node.Name = app.Attributes["key"].Value;
                        _node.ToolTipText = app.Attributes["value"].Value;
                        if (VerifyDuplication(treeView.Nodes[NodeAppConfig], _node) == 1)
                        {
                            this.AddWarning(NodeAppConfig + " got duplication key: " + _node.Name);
                            _errorCount++;
                        }
                        SetTagForDbClkEdit(_node, app, PathAppConfig, "add[@key='" + app.Attributes["key"].Value + "']", "value", app.Attributes["value"].Value);
                        treeView.Nodes[NodeAppConfig].Nodes.Add(_node);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                }

                treeView.Nodes[NodeAppConfig].Text = string.Format("{0} ({1}) - errors: {2}", NodeAppConfig, treeView.Nodes[NodeAppConfig].Nodes.Count,
                    _errorCount);

                treeView.Nodes[NodeAppConfig].ForeColor = _errorCount > 0 ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
            }
        }

        void FeedPlatformSettingsConfig()
        {
            try
            {
                int _errorCount = 0;
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(PathPlatformConfig);

                XmlNodeList _appsettings = xdoc.DocumentElement.ChildNodes;

                treeView.Nodes[NodePlatformConfig].Nodes.Clear();
                foreach (XmlNode app in _appsettings.Cast<XmlNode>().Where(x => x.NodeType == XmlNodeType.Element))//.Cast<XmlNode>().OrderBy(x=>x.Attributes["name"].Value))
                {
                    try
                    {
                        TreeNode _node = new TreeNode();

                        _node.Text = string.Format("{0}. {1}= {2}", treeView.Nodes[NodePlatformConfig].Nodes.Count + 1, app.Attributes["key"].Value,
                                           app.Attributes["value"].Value);
                        _node.Name = app.Attributes["key"].Value;
                        _node.ToolTipText = app.Attributes["value"].Value;
                        if (VerifyDuplication(treeView.Nodes[NodePlatformConfig], _node) == 1)
                        {
                            this.AddWarning(NodePlatformConfig + " got duplication key: " + _node.Name);
                            _errorCount++;
                        }
                        SetTagForDbClkEdit(_node, app, NodePlatformConfig, "add[@key='" + app.Attributes["key"].Value + "']", "value", app.Attributes["value"].Value);
                        treeView.Nodes[NodePlatformConfig].Nodes.Add(_node);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                }

                treeView.Nodes[NodePlatformConfig].Text = string.Format("{0} ({1}) - errors: {2}", NodePlatformConfig, treeView.Nodes[NodePlatformConfig].Nodes.Count,
                    _errorCount);

                treeView.Nodes[NodePlatformConfig].ForeColor = _errorCount > 0 ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
            }
        }

        void FeedFhSettingsConfig()
        {
            try
            {
                int _errorCount = 0;
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(PathFinancialHubSettingsConfig);

                XmlNodeList _fhsettings = xdoc.DocumentElement.ChildNodes;

                treeView.Nodes[NodeFinancialHubSettings].Nodes.Clear();
                foreach (XmlNode app in _fhsettings.Cast<XmlNode>().Where(x => x.NodeType == XmlNodeType.Element))//.Cast<XmlNode>().OrderBy(x=>x.Attributes["name"].Value))
                {
                    try
                    {
                        TreeNode _node = new TreeNode();

                        _node.Text = string.Format("{0}. {1}= {2}", treeView.Nodes[NodeFinancialHubSettings].Nodes.Count + 1, app.Attributes["key"].Value,
                                           app.Attributes["value"].Value);
                        _node.Name = app.Attributes["key"].Value;
                        _node.ToolTipText = app.Attributes["value"].Value;
                        if (VerifyDuplication(treeView.Nodes[NodeFinancialHubSettings], _node) == 1)
                        {
                            this.AddWarning(NodeFinancialHubSettings + " got duplication key: " + _node.Name);
                            _errorCount++;
                        }
                        SetTagForDbClkEdit(_node, app, PathFinancialHubSettingsConfig, "add[@key='" + app.Attributes["key"].Value + "']", "value", app.Attributes["value"].Value);
                        treeView.Nodes[NodeFinancialHubSettings].Nodes.Add(_node);
                    }
                    catch (Exception)
                    {
                        ;
                    }
                }

                treeView.Nodes[NodeFinancialHubSettings].Text = string.Format("{0} ({1}) - errors: {2}", NodeFinancialHubSettings, treeView.Nodes[NodeFinancialHubSettings].Nodes.Count,
                    _errorCount);

                treeView.Nodes[NodeFinancialHubSettings].ForeColor = _errorCount > 0 ? Color.Red : Color.Black;
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        internal static int VerifyDuplication(TreeNode parent, TreeNode node)
        {
            if (parent.Nodes.ContainsKey(node.Name))
            {
                bool _sameText = parent.Nodes[node.Name].ToolTipText == node.ToolTipText;
                node.ForeColor = _sameText ? Color.Red : Color.Orange;
                node.ToolTipText = _sameText ? "Error: Duplication" : "Error: Duplicated but not same value";
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// ReloadEPi
        /// </summary>
        void ReloadEPi()
        {
            try
            {
                folderPicker.SavePath();
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(PathEPIConfig);
                //sites
                this.FeedSitesNode(xdoc);
                this.FeedVPPNode(xdoc);
                this.FeedWebConfig();
                this.FeedAppSettingsConfig();
                this.FeedPlatformSettingsConfig();
                this.FeedWebConfig();
                this.FeedSolr();
                this.FeedServicePlusConfig();
                this.FeedFhSettingsConfig();
                treeView.Nodes[Main.NodeOthers].Text = string.Format("{0} ({1})", Main.NodeOthers, treeView.Nodes[Main.NodeOthers].Nodes.Count);

                
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                //if (!File.Exists(filePickerEpi.FilePath))
                //{
                //    throw new FileNotFoundException(filePickerEpi.FilePath);
                //}
                ClearWarning();
                ClearError();

               

                if (!File.Exists(filePickerCms.FilePath))
                {
                    throw new FileNotFoundException(filePickerCms.FilePath);
                }

                ReloadEPi();
                ReloadPara();
            }
            catch (FileNotFoundException fex)
            {
                MessageBox.Show("FileNotFoundException:" + fex.Message);
            }
            catch (Exception ex)
            {
                this.AddError(ex.Message);
            }
        }

        internal void ClearWarning()
        {
            warnings.Text = "";
            warnings.DropDownItems.Clear();
        }

        internal void ClearError()
        {
            errors.Text = "";
            errors.DropDownItems.Clear();
        }

        void ReloadPara()
        {
            filePickerCms.SavePath();
            filePickerWWW.SavePath();

            paraCms.FilePath = filePickerCms.FilePath;
            paraCms.RefTree = treeView;
            paraCms.ReloadPara();
           

            paraWWW.FilePath = filePickerWWW.FilePath;
            paraWWW.RefTree = treeView;
            paraWWW.ReloadPara();

           
        }
        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " - " + Application.ProductVersion;

            try
            {
                filePickerCms.SavePath();
                filePickerWWW.SavePath();
                folderPicker.SavePath();
            }
            catch (Exception)
            {
                ;
            }
#if DEBUG
            folderPicker.FilePath = @"D:\Projects\Bonnier\Dagensnyheter\Main\DagensNyheter.Web";
            filePickerCms.FilePath = @"D:\Projects\Bonnier\Dagensnyheter\Package\Parameters\cms_parameters.xml";
            filePickerWWW.FilePath = @"D:\Projects\Bonnier\Dagensnyheter\Package\Parameters\www_parameters.xml";
#endif
        }

        private void btnReloadEPi_Click(object sender, EventArgs e)
        {
            try
            {
                ClearError();
                ReloadEPi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }
        }

        private void btnReloadPara_Click(object sender, EventArgs e)
        {
            try
            {
                ReloadPara();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    Clipboard.SetText(e.Node.Name);
                    MessageBox.Show("Copied the Node name to clipboard");
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        private void treeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    string _tag = e.Node.Tag.ToString();
                    if (e.Node.Tag is string && _tag.StartsWith("DBCLK"))
                    {
                        if ((new AttributeValueEditor(_tag.Split('|'))).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            btnReloadEPi.PerformClick();
                        }
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
        }


    }
}
