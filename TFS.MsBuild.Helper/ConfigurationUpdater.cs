 using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
namespace TFS.MsBuild.Helper
{
    public class ConfigurationUpdater : IDisposable
    {
         private XmlDocument document;
        private readonly string filePath;
        private readonly TaskLoggingHelper log;
        private XmlNamespaceManager namespaceManager;
        private const string NamespacePrefix = "c";
        private readonly bool overwriteReadOnly;
        private readonly string[] ReservedAttributes = new string[] { "xpath", "value", "required", "createIfMissing", "isUnique" };
        private readonly Func<string, string> valueSelector;

        public ConfigurationUpdater(string filePath, Func<string, string> valueSelector, bool overwriteReadOnly, TaskLoggingHelper log)
        {
            this.filePath = valueSelector(filePath);
            this.valueSelector = valueSelector;
            this.overwriteReadOnly = overwriteReadOnly;
            this.log = log;
            this.Open();
        }
        
        internal void Add(string xpath, string value, bool isUnique, IDictionary<string, string> additionalAttributes)
        {
            if (isUnique && (this.SelectSingleNode(xpath) != null))
            {
                throw new InvalidOperationException(string.Format("Node '{0}' already exists.", xpath));
            }
            int length = xpath.LastIndexOf('/');
            string str = xpath.Substring(0, length);
            XmlNode node = this.SelectSingleNode(str);
            if (node == null)
            {
                throw new InvalidOperationException(string.Format("Couldn't find parent node for '{0}'.", xpath));
            }
            string name = xpath.Substring(length + 1);
            if (name.StartsWith("@"))
            {
                ((XmlElement) node).SetAttribute(name.Substring(1), value);
            }
            else
            {
                XmlElement xmlElement = this.document.CreateElement(name);
                this.UpdateElement(xmlElement, value, additionalAttributes);
                node.AppendChild(xmlElement);
            }
            this.log.LogMessage(MessageImportance.Normal, "\t\tAdded node '{0}' with value '{1}'.", new object[] { xpath, value });
        }
        
        public void ApplyChange(XmlElement change)
        {
            string localName = change.LocalName;
            string xpath = this.valueSelector(change.GetAttribute("xpath"));
            string str3 = this.valueSelector(change.HasAttribute("value") ? change.GetAttribute("value") : change.InnerXml);
            Dictionary<string, string> additionalAttributes = this.ExtractAdditionalAttributes(change);
            switch (localName)
            {
                case "add":
                {
                    bool isUnique = change.HasAttribute("isUnique") ? bool.Parse(change.GetAttribute("isUnique")) : true;
                    this.Add(xpath, str3, isUnique, additionalAttributes);
                    return;
                }
                case "delete":
                    this.Delete(xpath);
                    return;
                
                case "set":
                {
                    bool required = change.HasAttribute("required") ? bool.Parse(change.GetAttribute("required")) : false;
                    bool createIfMissing = change.HasAttribute("createIfMissing") ? bool.Parse(change.GetAttribute("createIfMissing")) : false;
                    this.Set(xpath, str3, createIfMissing, required, additionalAttributes);
                    return;
                }
            }
            throw new InvalidOperationException(string.Format("Operation '{0}' is not supported.", localName));
        }
        
        internal void Delete(string xpath)
        {
            XmlNodeList list = this.SelectNodes(xpath);
            foreach (XmlNode node in list)
            {
                if (node.NodeType == XmlNodeType.Attribute)
                {
                    XmlAttribute oldAttr = (XmlAttribute) node;
                    oldAttr.OwnerElement.RemoveAttributeNode(oldAttr);
                }
                else
                {
                    node.ParentNode.RemoveChild(node);
                }
            }
            this.log.LogMessage(MessageImportance.Normal, "\t\tDeleted {0} nodes matching '{1}'.", new object[] { list.Count, xpath });
        }
        
        public void Dispose()
        {
            this.Save();
        }
        
        private Dictionary<string, string> ExtractAdditionalAttributes(XmlNode change)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            if (change.Attributes != null)
            {
                foreach (XmlAttribute attribute in change.Attributes)
                {
                    string localName = attribute.LocalName;
                    if (!this.ReservedAttributes.Contains<string>(localName))
                    {
                        string str2 = localName.StartsWith("_") ? localName.Substring(1) : localName;
                        dictionary[str2] = this.valueSelector(attribute.Value);
                    }
                }
            }
            return dictionary;
        }
        
        private string FixXPathNamespace(string xpath)
        {
            string[] strArray = xpath.Split(new char[] { '/' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if ((strArray[i].Length > 0) && !strArray[i].StartsWith("@"))
                {
                    strArray[i] = "c:" + strArray[i];
                }
            }
            return string.Join("/", strArray);
        }
        
        internal void Open()
        {
            this.document = new XmlDocument();
            this.document.Load(this.filePath);
            this.log.LogMessage(MessageImportance.Normal, "Updating file '{0}'...", new object[] { this.filePath });
            this.namespaceManager = new XmlNamespaceManager(this.document.NameTable);
            this.namespaceManager.AddNamespace("c", this.document.DocumentElement.GetNamespaceOfPrefix(""));
        }
        
        public void Save()
        {
            if (this.overwriteReadOnly)
            {
                FileAttributes attributes = File.GetAttributes(this.filePath);
                if ((attributes & FileAttributes.ReadOnly) != 0)
                {
                    File.SetAttributes(this.filePath, attributes ^ FileAttributes.ReadOnly);
                }
            }
            this.document.Save(this.filePath);
            this.log.LogMessage(MessageImportance.Normal, "File '{0}' updated.", new object[] { this.filePath });
        }
        
        private XmlNodeList SelectNodes(string xpath)
        {
            return this.document.SelectNodes(this.FixXPathNamespace(xpath), this.namespaceManager);
        }
        
        private XmlNode SelectSingleNode(string xpath)
        {
            return this.document.SelectSingleNode(this.FixXPathNamespace(xpath), this.namespaceManager);
        }
        
        internal void Set(string xpath, string value, bool createIfMissing, bool required, IDictionary<string, string> additionalAttributes)
        {
            XmlNodeList list = this.SelectNodes(xpath);
            if ((list == null) || (list.Count == 0))
            {
                if (createIfMissing)
                {
                    this.Add(xpath, value, false, additionalAttributes);
                }
                else if (required)
                {
                    throw new InvalidOperationException(string.Format("Couldn't find node '{0}'.", xpath));
                }
            }
            else
            {
                foreach (XmlNode node in list)
                {
                    if (node.NodeType == XmlNodeType.Attribute)
                    {
                        node.Value = value;
                    }
                    else if (node.NodeType == XmlNodeType.Element)
                    {
                        this.UpdateElement((XmlElement) node, value, additionalAttributes);
                    }
                }
                this.log.LogMessage(MessageImportance.Normal, "\t\tUpdated {0} nodes matching '{1}' to value '{2}'.", new object[] { list.Count, xpath, value });
            }
        }
        
        private void UpdateElement(XmlElement xmlElement, string value, IDictionary<string, string> additionalAttributes)
        {
            xmlElement.InnerXml = value;
            foreach (KeyValuePair<string, string> pair in additionalAttributes)
            {
                xmlElement.SetAttribute(pair.Key, pair.Value);
            }
        }
    }
}
