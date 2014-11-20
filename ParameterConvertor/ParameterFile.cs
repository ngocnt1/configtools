using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace ParameterConvertor
{
    class ParameterFile
    {
        string path;
        public ParameterFile(string path)
        {
            this.path = path;
        }

        private XmlDocument Doc
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                return doc;
            }
        }

        public string FileName
        {
            get
            {
                return Path.GetFileName(path);
            }
        }

        public int ParameterCount
        {
            get
            {
                return Doc.SelectNodes("/parameters/parameter").OfType<XmlElement>().Count();
            }
        }

        public IEnumerable<ParameterEntity> Parameters
        {
            get
            {
                return Doc.SelectNodes("/parameters/parameter").OfType<XmlElement>().Select(x => new ParameterEntity(x));
            }
        }

        private void Sort()
        {
           
            var paras =this.Parameters;
            var parameters = new List<ParameterEntity>();
            var doc = this.Doc;
            //  XmlDocument newDoc = new XmlDocument();
            //   newDoc.ImportNode(doc.DocumentElement,false);

            foreach (var item in paras)
            {
                try
                {
                    parameters.Add(new ParameterEntity()
                           {
                               AllowEmpty = item.AllowEmpty,
                               Name = item.Name,
                               Scope = item.Scope,
                               Type = item.Type,
                               Value = item.Value,
                               XPathMatch = item.XPathMatch
                           });
                }
                catch (Exception ex)
                {                     
                    throw ex;
                }
            }
            doc.DocumentElement.RemoveAll();
            foreach (var n in parameters.OrderBy(x=>x.Scope))
            {
                CreateParameter(n, doc,false);
            }
            doc.Save(path);
        }

        public bool UpdateParameter(ParameterEntity para, XmlDocument rootDoc = null, bool autoSave = true)
        {
            XmlDocument doc = rootDoc == null ? Doc : rootDoc;
            var node = doc.SelectSingleNode(string.Format("/parameters/parameter[@name='{0}']", para.Name));
            if (node != null)
            {
                node.Attributes["value"].Value = para.Value;

                XmlNode subPara1 = node.SelectSingleNode("parameterValidation");
                if (para.AllowEmpty && subPara1 == null)
                {
                    subPara1 = doc.CreateNode(XmlNodeType.Element, "parameterValidation", "");
                    XmlAttribute kindAtt = doc.CreateAttribute("value");
                    kindAtt.Value = "AllowEmpty";
                    subPara1.Attributes.Append(kindAtt);
                    node.AppendChild(subPara1);
                }
                else if (!para.AllowEmpty && subPara1 != null)
                {
                    node.RemoveChild(subPara1);
                }

                XmlNode subPara2 = doc.CreateNode(XmlNodeType.Element, "parameterEntry", "");
                subPara2.Attributes["type"].Value = para.Type;
                subPara2.Attributes["scope"].Value = para.Scope;
                subPara2.Attributes["match"].Value = para.XPathMatch;

                if (autoSave)
                    doc.Save(path);
            }
            return true;
        }

        public bool CreateParameter(ParameterEntity para, XmlDocument rootDoc = null, bool autoSave = true)
        {
            XmlDocument doc = rootDoc == null ? Doc : rootDoc;
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "parameter", "");
            XmlAttribute nameAtt = doc.CreateAttribute("name");
            nameAtt.Value = para.Name;
            node.Attributes.Append(nameAtt);


            XmlAttribute valueAtt = doc.CreateAttribute("value");
            valueAtt.Value = para.Value;
            node.Attributes.Append(valueAtt);

            if (para.AllowEmpty)
            {
                XmlNode subPara1 = doc.CreateNode(XmlNodeType.Element, "parameterValidation", "");
                XmlAttribute kindAtt = doc.CreateAttribute("value");
                kindAtt.Value = "AllowEmpty";
                subPara1.Attributes.Append(kindAtt);
                node.AppendChild(subPara1);
            }

            XmlNode subPara2 = doc.CreateNode(XmlNodeType.Element, "parameterEntry", "");
            XmlAttribute typeAtt = doc.CreateAttribute("type");
            typeAtt.Value = para.Type;
            subPara2.Attributes.Append(typeAtt);

            XmlAttribute scopeAtt = doc.CreateAttribute("scope");
            scopeAtt.Value = para.Scope;
            subPara2.Attributes.Append(scopeAtt);

            XmlAttribute matchAtt = doc.CreateAttribute("match");
            matchAtt.Value = para.XPathMatch;
            subPara2.Attributes.Append(matchAtt);

            node.AppendChild(subPara2);


            doc.DocumentElement.AppendChild(doc.DocumentElement.OwnerDocument.ImportNode(node, true));
            //doc.DocumentElement.AppendChild(node);
            if (autoSave)
                doc.Save(path);

            return true;
        }
    }
}
