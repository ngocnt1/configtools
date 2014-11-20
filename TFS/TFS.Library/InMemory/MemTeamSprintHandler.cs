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
using TFS.Library.Data;
using TFS.Library.Models;

namespace TFS.Library.InMemory
{
    class MemTeamSprintHandler : ITeamSprintHandler
    {
        private IList<TeamSprint> _sprints = new List<TeamSprint>();

        public MemTeamSprintHandler()
        {
            _sprints.Add(new TeamSprint() { Id = 1, Title="InMemoryTeam1", SprintStart = DateTime.Now, SprintEnd = DateTime.Now.AddDays(14), Project="InMemory" });
        }

        public Models.TeamSprint GetTeamSprint(int id)
        {
            return (from s in _sprints where s.Id==id select s).FirstOrDefault();
        }

        public IList<Models.TeamSprint> GetTeamSprints(string tfsProject, int sprintNumber)
        {
            return _sprints;
        }


        public TeamSprint GetTeamSprintByIteration(int iterationId)
        {
            return GetTeamSprint(1);
        }
    }
}
