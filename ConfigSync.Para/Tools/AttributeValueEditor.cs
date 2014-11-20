using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ConfigSync.Para.Tools
{
    public partial class AttributeValueEditor : Form
    {
        string configFile;
        string xpath;
        string attr;
        public AttributeValueEditor(params string[] paras)
        {
            InitializeComponent();
            this.configFile = paras[1];
            this.xpath = paras[2];
            this.attr = paras[3];
        }

        XmlAttribute Attr
        {
            get
            {
                try
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(configFile);
                    return xdoc.DocumentElement.SelectSingleNode(xpath).Attributes[attr];
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }


        private void AttributeValueEditor_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text =  Path.GetFileName(configFile);
                int minus =  (int)this.CreateGraphics().MeasureString(Attr.Value, this.Font).Width - tbVal.Width+5;
                this.Width += minus;
                lbName.Text = attr;
                tbVal.Text = Attr.Value;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(configFile);
                xdoc.DocumentElement.SelectSingleNode(xpath).Attributes[attr].Value = tbVal.Text;

                xdoc.Save(configFile);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
