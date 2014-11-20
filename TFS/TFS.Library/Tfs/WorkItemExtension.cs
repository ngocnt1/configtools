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
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace TFS.Library.Tfs
{
    /// <summary>
    /// Helper methods on WorkItem
    /// </summary>
    public static class WorkItemExtension
    {
        public static string GetTeamProject(this WorkItem wi)
        {
            return wi.Fields["System.TeamProject"].Value as string;
        }

        public static string GetWorkItemType(this WorkItem wi)
        {
            return wi.Fields["System.WorkItemType"].Value as string;
        }

        public static double Effort(this WorkItem wi)
        {
            return wi.Fields["Microsoft.VSTS.Scheduling.Effort"].Value != null ? (double)wi.Fields["Microsoft.VSTS.Scheduling.Effort"].Value : 0;
        }
        public static double Effort(this Revision wi)
        {
            return wi.Fields["Microsoft.VSTS.Scheduling.Effort"].Value != null ? (double)wi.Fields["Microsoft.VSTS.Scheduling.Effort"].Value : 0;
        }
        public static double RemainingWork(this WorkItem wi)
        {
            return wi.Fields["Microsoft.VSTS.Scheduling.RemainingWork"] != null && wi.Fields["Microsoft.VSTS.Scheduling.RemainingWork"].Value != null ?
                (double)wi.Fields["Microsoft.VSTS.Scheduling.RemainingWork"].Value :
                0;
        }

        public static double RemainingWork(this Revision wi)
        {
            return wi.Fields["Microsoft.VSTS.Scheduling.RemainingWork"] != null && wi.Fields["Microsoft.VSTS.Scheduling.RemainingWork"].Value != null ?
                (double)wi.Fields["Microsoft.VSTS.Scheduling.RemainingWork"].Value :
                0;
        }

        public static bool ContainsValueFor(this FieldCollection fields, string key)
        {
            return fields.Contains(key) && fields[key].Value != null;
        }


    }
}
