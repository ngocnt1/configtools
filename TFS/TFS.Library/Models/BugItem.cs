using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Library.Models
{
    public class BugItem : BacklogItem
    {
        public BugItem()
        {
            State = "Active";
            DevState = "Open";
        }
        public override string ProductBacklogLinkType
        {
            get { return TFS.Library.Tfs.Scrum.TaskLinkName; }
        }

        public override BacklogItemType BacklogType
        {
            get { return BacklogItemType.Bug; }
        }
        public string DevState { get; set; }
    }
}
