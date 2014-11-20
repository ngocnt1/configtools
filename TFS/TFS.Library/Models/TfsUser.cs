/*
COPYRIGHT (C) 2010 EPISERVER AB

THIS FILE IS PART OF SCRUM DASHBOARD.

SCRUM DASHBOARD IS FREE SOFTWARE: YOU CAN REDISTRIBUTE IT AND/OR MODIFY IT UNDER THE TERMS OF 
THE GNU LESSER GENERAL PUBLIC LICENSE VERSION v2.1 AS PUBLISHED BY THE FREE SOFTWARE FOUNDATION.

SCRUM DASHBOARD IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, BUT WITHOUT ANY WARRANTY; WITHOUT
EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU LESSER
GENERAL PUBLIC LICENSE FOR MORE DETAILS.

YOU SHOULD HAVE RECEIVED A COPY OF THE GNU LESSER GENERAL PUBLIC LICENSE ALONG WITH SCRUM DASHBOARD. 
IF NOT, SEE <HTTP://WWW.GNU.ORG/LICENSES/>.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace TFS.Library.Models
{
    /// <summary>
    /// A user in TFS
    /// </summary>
    public class User
    {
        public User(string displayName, string accountName, string domain)
        {
            DisplayName = displayName;
            AccountName = accountName;
            Domain = domain;
            Initials = String.Empty;

            SetInitials();
        }

        public string DisplayName { get; private set; }
        public string AccountName { get; private set; }
        public string Domain { get; private set; }
        public string Initials { get; private set; }

        public static User Empty = new User("","","");

        public override string ToString()
        {
            return DisplayName.ToString();
        }

        private void SetInitials()
        {
            switch (ConfigurationManager.AppSettings["tfsUserInitials"])
            {
                case "AccountName":
                    Initials = AccountName;
                    break;
                
                default:
                    if (String.IsNullOrEmpty(DisplayName))
                        break;

                    if (DisplayName.Contains(" "))
                    {
                        string[] parts = DisplayName.Split(' ');
                        foreach (string part in parts)
                        {
                            Initials += part.Length == 0 ? String.Empty : part.Substring(0, 1);
                        }
                    }
                    else
                    {
                        Initials = DisplayName.Substring(0, 2);
                    }
                    break;
            }
        }
    }
}
