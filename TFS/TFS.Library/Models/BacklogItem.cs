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
using System.ComponentModel.DataAnnotations;

namespace TFS.Library.Models
{
    public abstract class BacklogItem : Item
    {
        [Required]
        public int ProductBacklogId { get; set; }
        public abstract string ProductBacklogLinkType { get; }

        public abstract BacklogItemType BacklogType
        {
            get;
        }


        public static BacklogItem CreateType(string type)
        {
            return CreateType((BacklogItemType)Enum.Parse(typeof(BacklogItemType), type));
        }

        public static BacklogItem CreateType(BacklogItemType type)
        {
            switch (type)
            {
                case BacklogItemType.AcceptanceTest:
                    return new AcceptanceTest();
                case BacklogItemType.Impediment:
                    return new Impediment();
                case BacklogItemType.SprintBacklogTask:
                    return new SprintBacklogTask();
                case BacklogItemType.Bug:
                    return new BugItem();
            }
            return null;
        }
    }

    public enum BacklogItemType
    {
        SprintBacklogTask,
        Impediment,
        AcceptanceTest,
        Bug
    }
}
