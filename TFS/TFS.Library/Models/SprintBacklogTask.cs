/*
COPYRIGHT (C) 2008 EPISERVER AB

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
using System.Data;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace TFS.Library.Models
{
    public class SprintBacklogTask : BacklogItem
    {
        public SprintBacklogTask()
        {
            State = TFS.Library.Tfs.Scrum.TaskStartState;
        }

        public const string BugTitlePrefix = "Bug:";

        public double WorkRemaining { get; set; }

        [DataType(DataType.Currency)]
        public double? EstimatedEffort { get; set; }
        public string Team { get; set; }
        public bool IsUnplanned(DateTime sprintStart)
        {
            return Created > sprintStart.AddDays(1);
        }

        public override string ProductBacklogLinkType
        {
            get { return TFS.Library.Tfs.Scrum.TaskLinkName; }
        }

        public override BacklogItemType BacklogType
        {
            get { return BacklogItemType.SprintBacklogTask; }
        }
    }
}
