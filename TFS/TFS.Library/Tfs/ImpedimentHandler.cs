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
using TFS.Library.Models;
using System.Collections;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using TFS.Library.Data;

namespace TFS.Library.Tfs
{
    public class ImpedimentHandler
    {
        private ITfsServices _tfs;

        public ImpedimentHandler(ITfsServices tfs)
        {
            _tfs = tfs;
        }

        public Impediment GetImpediment(int workItemId)
        {
            return WorkItemToImpediment(_tfs.GetWorkItem(workItemId));
        }

        public Impediment WorkItemToImpediment(WorkItem wi)
        {
            return WorkItemToImpediment( wi, null);
        }
        public Impediment WorkItemToImpediment(WorkItem wi, int? productBacklogId)
        {
            Impediment imp = _tfs.CreateItem<Impediment>(wi);

            if (productBacklogId.HasValue)
            {
                imp.ProductBacklogId = productBacklogId.Value;
            }
            else
            {
                _tfs.ResolveProductBacklogId(imp, wi);
            }

            return imp;
        }
    }
}
