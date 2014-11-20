using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Library.Models
{
    public class GenericWorkItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool LinkedToActiveSprint { get; set; }
        public string WorkItemType { get; set; }
    }
}
