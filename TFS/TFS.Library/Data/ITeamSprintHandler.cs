﻿/*
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
namespace TFS.Library.Data
{
    public interface ITeamSprintHandler
    {
        TFS.Library.Models.TeamSprint GetTeamSprint(int teamSprintNumber);
        System.Collections.Generic.IList<TFS.Library.Models.TeamSprint> GetTeamSprints(string tfsProject, int sprintNumber);
        Models.TeamSprint GetTeamSprintByIteration(int iterationId);

    }
}
