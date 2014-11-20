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
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TFS.Library.Models
{
    /// <summary>
    /// Data class for product backlogs
    /// </summary>
    public class ProductBacklogItem : Item
    {
        public ProductBacklogItem()
        {
            RelatedWorkItems = new List<int>();
        }

        public double WorkRemaining { get; set; }
        public double ConsumedPoints { get; set; }
        public int BusinessValue { get; set; }
        public string SprintName { get; set; }
        public int DeliveryOrder { get; set; }
        public string Team { get; set; }
        public List<int> RelatedWorkItems { get; set; }
        [DataType(DataType.Currency)]
        public double StoryPoints { get; set; }
        public double UnplannedStoryPoints { get; set; }
        public IList<SprintBacklogTask> SprintBacklog { get; set; }
        public IList<Impediment> Impediments { get; set; }
        public IList<AcceptanceTest> AcceptanceTests { get; set; }
       // public IList<BugItem> Bugs { get; set; }
    }
}
