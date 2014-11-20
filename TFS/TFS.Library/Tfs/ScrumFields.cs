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
using System.Collections.Generic;
using System.Text;

namespace TFS.Library.Tfs
{
    public static class Scrum
    {       
        //sprint
        public const string SprintStart = "Scrum.v3.SprintStart";
        public const string SprintEnd = "Scrum.v3.SprintEnd";

        //sprint backlog task
        public const string EstimatedEffort = "Scrum.v3.EstimatedEffort";
        public const string StoryPoints = "Microsoft.VSTS.Scheduling.StoryPoints";
        public const string UnplannedStoryPoints = "Niteco.Scheduling.UnplannedPoints";
        public const string WorkRemaining = "Scrum.v3.WorkRemaining";
        public const string TaskPriority = "Scrum.v3.TaskPriority";

        public const string TaskLinkName = "Scrum.ImplementedBy-Reverse";
        public const string TaskStartState = "Not Started";
        public const string AcceptanceTestLinkName = "Microsoft.VSTS.Common.TestedBy-Reverse";
        public const string AcceptanceTestStartState = "Not Implemented";
        public const string ImpedimentLinkName = "Scrum.ImpededBy-Reverse";
        public const string ImpedimentStartState = "Open";

        //product backlog item
        public const string DeliveryOrder = "Scrum.v3.DeliveryOrder";
        public const string BusinessValue = "Scrum.v3.BusinessValue";
        public const string RemainStoryPoints = "Niteco.Scheduling.StoryPoints";

        public const string ConsumedPoints = "Niteco.Scheduling.ConsumedPoints";


        public class WorkItemTypes
        {
            public const string SprintBacklogTask = "Sprint Backlog Task";
            public const string Impediment = "Impediment";
            public const string Bug = "Bug";
            public const string AcceptanceTest = "Acceptance Test";
            public const string ProductBacklogItem = "Product Backlog Item";
        }
    }
}
