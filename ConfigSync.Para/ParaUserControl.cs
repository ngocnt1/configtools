using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
namespace ConfigSync.Para
{
    public partial class ParaUserControl : UserControl
    {
        public const string NodeOthers = "Others";
        public ParaUserControl()
        {
            InitializeComponent();
        }

        private void ParaUserControl_Load(object sender, EventArgs e)
        {

        }

        internal void AddError(string msg)
        {
            try
            {
                ((Main)this.ParentForm).AddError(msg);
            }
            catch (Exception)
            {
                ;
            }
        }

        internal void AddWarning(string msg)
        {
            try
            {
                ((Main)ParentForm).AddWarning(msg);
            }
            catch (Exception)
            {
                ;
            }
        }

        [Browsable(false)]
        public string FilePath { get; set; }
        [Browsable(false)]

        public TreeView RefTree { get; set; }

        TreeNode Verify(TreeNode node, XmlNode data, TreeNode parent = null)
        {
            // node.ToolTipText = "Action:";
            try
            {
                if (parent != null && parent.Nodes.ContainsKey(node.Name))
                {
                    node.ForeColor = Color.Red;
                    node.ToolTipText = "Error: Duplication";
                    this.AddWarning(parent.Name + " got duplication key: " + node.Name);
                }
                if (string.IsNullOrWhiteSpace(data.Attributes["value"].Value))
                {
                    //node.ToolTipText += "Remove";
                    node.ForeColor = Color.Gray;
                }

                //validate by values
                if (node.Name == "SolarServer")
                {
                    node.ForeColor = (string)RefTree.Nodes[Main.NodeSolr].Nodes["Core"].Nodes["serverUrl"].Tag != data.Attributes["value"].Value ?
                         Color.Red : Color.Green;
                    RefTree.Nodes[Main.NodeSolr].Nodes["Core"].Nodes["serverUrl"].ForeColor = node.ForeColor;
                }
                else if (node.Name == "SolarID")
                {
                    node.ForeColor = (string)RefTree.Nodes[Main.NodeSolr].Nodes["Core"].Nodes["site"].Tag != data.Attributes["value"].Value ? Color.Red : Color.Green;
                    RefTree.Nodes[Main.NodeSolr].Nodes["Core"].Nodes["site"].ForeColor = node.ForeColor;
                }
                else if (node.Name == "EPiSolarServer")
                {
                    node.ForeColor = (string)RefTree.Nodes[Main.NodeSolr].Nodes["EPi"].Nodes["serverUrl"].Tag != data.Attributes["value"].Value ?
                         Color.Red : Color.Green;
                    RefTree.Nodes[Main.NodeSolr].Nodes["EPi"].Nodes["serverUrl"].ForeColor = node.ForeColor;
                }
                else
                    //SolarID
                    if (node.Name == "EPiSolarID")
                    {
                        node.ForeColor = (string)RefTree.Nodes[Main.NodeSolr].Nodes["EPi"].Nodes["site"].Tag != data.Attributes["value"].Value ? Color.Red : Color.Green;
                        RefTree.Nodes[Main.NodeSolr].Nodes["EPi"].Nodes["site"].ForeColor = node.ForeColor;
                    }
                    else
                    {
                        node.ForeColor = Color.Green;
                    }
            }
            catch (Exception)
            {
                node.ForeColor = Color.Red;
            }

            return node;
        }

        public void ReloadPara()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    lbFile.Text = Path.GetFileName(FilePath) + " at [" + DateTime.Now.ToString() + "]";
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(FilePath);
                    //sites

                    XmlNodeList _paras = xdoc.DocumentElement.ChildNodes;
                    treeViewEPiServer.Nodes[Main.NodeSites].Nodes.Clear();
                    treeViewEPiServer.Nodes[Main.NodeVpp].Nodes.Clear();
                    treeViewEPiServer.Nodes[Main.NodeOthers].Nodes.Clear();

                    IEnumerable<XmlNode> _nodes = _paras.Cast<XmlNode>().Where(x => x.NodeType == XmlNodeType.Element).OrderBy(x => x.Attributes["name"].Value);
                    int _errorVppCount = 0;
                    int _errorSitesCount = 0;
                    foreach (XmlNode n in _nodes)
                    {
                        string _name = n.Attributes["name"].Value;
                        string _rootNode = "";
                        try
                        {
                            _rootNode = "Sites";
                            if (RefTree.Nodes.ContainsKey(_rootNode) && RefTree.Nodes[_rootNode].FirstNode.Nodes.ContainsKey(_name))
                            {
                                treeViewEPiServer.Nodes[_rootNode].Nodes.Add(this.Verify(new TreeNode()
                                {
                                    Name = _name,
                                    Text = string.Format("{0}. {1}= {2}", treeViewEPiServer.Nodes[_rootNode].Nodes.Count + 1, _name,
                                        n.Attributes["value"].Value)
                                }, n));
                                continue;
                            }


                            if (RefTree.Nodes.ContainsKey(Main.NodeVpp) && RefTree.Nodes[Main.NodeVpp].Nodes.ContainsKey(_name))
                            {
                                TreeNode _nodeVpp = new TreeNode()
                                 {
                                     Name = _name,
                                     Text = string.Format("{0}. {1}= {2}", treeViewEPiServer.Nodes[Main.NodeVpp].Nodes.Count + 1, _name,
                                         n.Attributes["value"].Value)
                                 };

                                _nodeVpp = this.Verify(_nodeVpp, n, treeViewEPiServer.Nodes[Main.NodeVpp]);
                                if (_nodeVpp.ForeColor == Color.Red)
                                {
                                    ++_errorVppCount;
                                }
                                treeViewEPiServer.Nodes[Main.NodeVpp].Nodes.Add(_nodeVpp);
                                continue;
                            }


                            //other green
                            treeViewEPiServer.Nodes[NodeOthers].Nodes.Add(Verify(new TreeNode()
                            {
                                Name = _name,
                                Text = string.Format(_name + "= {0}", n.Attributes["value"].Value)
                            }, n));

                        }
                        catch (Exception ex)
                        {
                            treeViewEPiServer.Nodes[NodeOthers].Nodes.Add(new TreeNode()
                            {
                                ForeColor = Color.Red,
                                Name = _name,
                                Text = string.Format(_name + "= {0}",
                                    n.Attributes["value"].Value),
                                ToolTipText = ex.Message
                            });
                        }
                    }


                    //  treeViewEPiServer.Nodes[Main.NodeAppConfig].Text = string.Format("{0} ({1})", Main.NodeAppConfig, treeViewEPiServer.Nodes[Main.NodeAppConfig].Nodes.Count);

                    treeViewEPiServer.Nodes[Main.NodeVpp].Text = string.Format("{0} ({1}) - errors: {2}", Main.NodeVpp, treeViewEPiServer.Nodes[Main.NodeVpp].Nodes.Count, _errorVppCount);
                    treeViewEPiServer.Nodes[Main.NodeVpp].ForeColor = _errorVppCount > 0 ? Color.Red : Color.Black;

                    //  treeViewEPiServer.Nodes[Main.NodeWebConfig].Text = string.Format("{0} ({1})", Main.NodeWebConfig, treeViewEPiServer.Nodes[Main.NodeWebConfig].Nodes.Count);
                    treeViewEPiServer.Nodes[Main.NodeSites].Text = string.Format("{0} ({1}) - errors: {2}", Main.NodeSites, treeViewEPiServer.Nodes[Main.NodeSites].Nodes.Count, _errorSitesCount);
                    treeViewEPiServer.Nodes[Main.NodeSites].ForeColor = _errorSitesCount > 0 ? Color.Red : Color.Black;

                    treeViewEPiServer.Nodes[Main.NodeOthers].Text = string.Format("{0} ({1})", Main.NodeOthers, treeViewEPiServer.Nodes[Main.NodeOthers].Nodes.Count);
                }
            }
            catch (Exception ex)
            {
                AddError(ex.Message);
            }
            //treeViewEPiServer.ExpandAll();
        }

        private void treeViewEPiServer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
    }
}
