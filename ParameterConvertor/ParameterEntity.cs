using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ParameterConvertor
{
    class ParameterEntity
    {
        public ParameterEntity()
        {
            Type = "XMLFile";            
        }
        public ParameterEntity(XmlNode node)
        {
            if (node==null)
            {
                return;
            }
            var entry = node.SelectSingleNode("parameterEntry");
            Scope = entry==null || entry.Attributes["scope"] == null ? "" : entry.Attributes["scope"].Value;
            Type = entry == null || entry.Attributes["type"] == null ? "" : entry.Attributes["type"].Value;
            XPathMatch = entry == null || entry.Attributes["match"] == null ? "" : entry.Attributes["match"].Value;
            Name = node.Attributes["name"] == null ? "" : node.Attributes["name"].Value;
            Value =node.Attributes["value"]==null?"": node.Attributes["value"].Value;

            AllowEmpty = node.SelectSingleNode("parameterValidation") != null 
                && node.SelectSingleNode("parameterValidation").Attributes["kind"].Value == "AllowEmpty";
        }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Scope { get; set; }
        public bool AllowEmpty { get; set; }
        public string XPathMatch { get; set; }
    }
}
