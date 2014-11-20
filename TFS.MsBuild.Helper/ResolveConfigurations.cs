using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace TFS.MsBuild.Helper
{
    public class ResolveConfigurations : Task
    {
        private const string ChangesXPath = "/configuration/changes";
        private static readonly Regex VariableRegex = new Regex(@"\$\((?<name>\w+)\)");
        private readonly Dictionary<string, string> variables = new Dictionary<string, string>();
        private const string VariablesXPath = "/configuration/variables";

        public override bool Execute()
        {
            if (string.IsNullOrEmpty(this.Environment))
            {
                base.Log.LogWarning("'Environment' is empty. Skipping configuration updates.", new object[0]);
                return true;
            }
            this.ValidateArguments();
            this.variables["Environment"] = this.Environment;
            XmlDocument document = new XmlDocument();
            document.Load(this.Settings);
            base.Log.LogMessage(MessageImportance.Normal, "Using configuration file '{0}'.", new object[] { this.Settings });
            this.ReadVariables(document);
            this.PrintVariables();
            this.ProcessFiles(document);
            return true;
        }

        private void IterateNodes(XmlNode parent, Action<XmlNode> action)
        {
            foreach (XmlElement element in parent.ChildNodes.OfType<XmlElement>())
            {
                if (this.ShouldBeProcessed(element.GetAttribute("name")))
                {
                    action(element);
                }
            }
        }

        private void PrintVariables()
        {
            base.Log.LogMessage(MessageImportance.Low, "Defined variables:", new object[0]);
            foreach (KeyValuePair<string, string> pair in this.variables)
            {
                base.Log.LogMessage(MessageImportance.Low, "\t\t{0}:\t\t{1}", new object[] { pair.Key, pair.Value });
            }
        }

        private void ProcessChanges(XmlNode parent)
        {
            foreach (XmlElement element in parent.SelectNodes("file").OfType<XmlElement>())
            {
                using (ConfigurationUpdater updater = new ConfigurationUpdater(Path.Combine(this.RootFolder, element.GetAttribute("name")), new Func<string, string>(this.ReplaceVariables), this.Force, base.Log))
                {
                    foreach (XmlElement element2 in element.ChildNodes.OfType<XmlElement>())
                    {
                        updater.ApplyChange(element2);
                    }
                }
            }
        }

        private void ProcessFiles(XmlDocument document)
        {
            this.IterateNodes(document.SelectSingleNode("/configuration/changes"), new Action<XmlNode>(this.ProcessChanges));
        }

        private void ReadVariables(XmlDocument document)
        {
            this.IterateNodes(document.SelectSingleNode("/configuration/variables"), new Action<XmlNode>(this.ReadVariablesNode));
        }

        private void ReadVariablesNode(XmlNode parent)
        {
            foreach (XmlElement element in parent.ChildNodes.OfType<XmlElement>())
            {
                string localName = element.LocalName;
                string str2 = this.ReplaceVariables(element.InnerXml);
                this.variables[localName] = str2;
            }
        }

        private string ReplaceVariables(string s)
        {
            return VariableRegex.Replace(s, delegate(Match match)
            {
                string key = match.Groups["name"].Value;
                if (!this.variables.ContainsKey(key))
                {
                    base.Log.LogWarning("Variable '{0}' is not defined. Replacing with empty string.", new object[] { key });
                    return string.Empty;
                }
                return this.variables[key];
            });
        }

        private bool ShouldBeProcessed(string environment)
        {
            foreach (string str in environment.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Regex regex = new Regex("^" + str.Replace("*", ".*") + "$");
                if (regex.Match(this.Environment).Success)
                {
                    return true;
                }
            }
            return false;
        }

        private void ValidateArguments()
        {
            if (string.IsNullOrEmpty(this.RootFolder))
            {
                throw new ArgumentNullException("RootFolder");
            }
            if (string.IsNullOrEmpty(this.Settings))
            {
                throw new ArgumentNullException("Settings");
            }
        }

        public string Environment { get; set; }

        public bool Force { get; set; }

        public string RootFolder { get; set; }

        public string Settings { get; set; }
    }
}
