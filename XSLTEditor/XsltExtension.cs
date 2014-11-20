using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Xsl;

namespace XSLTEditor
{
    public static class XsltExtension
    {
        public static string AttrEncode(this string html)
        {
            return Regex.Replace(html, @"=( *)(""|')(\S+|.*?)(""|')", delegate(Match match)
            {
                return string.Format(@"=""{0}""", HttpUtility.HtmlEncode(match.Groups[3].Value));
            });
        }
        public static string ResolveIncorrectTags(this string html)
        {
            return Regex.Replace(html, @"(<img|br)(\S+|.*?)(/|)(>)", delegate(Match match)
            {
                return string.Format("{0}{1}{2}{3}", match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value == "/" ? match.Groups[3].Value : "/", match.Groups[4].Value);                
            });
        }
        public static string XsltHtmlTransform(this string html, string xsltPath, bool throwException = false)
        {
            try
            {
                string _html = html.AttrEncode();
                StringBuilder sbXslOutput = new StringBuilder();
                TextReader tr = new StringReader(File.ReadAllText(xsltPath));
                try
                {
                    using (XmlReader xsltReader = XmlReader.Create(tr))
                    {
                        using (XmlWriter xslWriter = XmlWriter.Create(sbXslOutput, new XmlWriterSettings() { ConformanceLevel = ConformanceLevel.Auto }))
                        {
                            XslCompiledTransform transformer = new XslCompiledTransform();
                            transformer.Load(xsltReader);
                            XsltArgumentList args = new XsltArgumentList();

                            XmlDocument xml = new XmlDocument();
                            xml.LoadXml(_html);
                            //XmlReader doc = XmlReader.Create(new StringReader(html));

                            transformer.Transform(xml.CreateNavigator(), args, xslWriter);
                        }
                    }
                }
                finally
                {
                    tr.Close();
                }

                return sbXslOutput.ToString();
            }
            catch (Exception ex)
            {
                if (throwException)
                    throw ex;
                else
                    return html;
            }
        }
    }
}
