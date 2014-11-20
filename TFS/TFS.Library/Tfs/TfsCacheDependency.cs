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
using System.Web.Caching;

namespace TFS.Library.Tfs
{
    public delegate void TfsCacheDependencyEventHandler(object sender, TfsCacheDependencyEventArgs args);

    public class TfsCacheDependency : CacheDependency
    {
        private string _project;
        private bool _disposedEvent;
        private TfsCacheDependencyEventHandler _localHandler;
        private static event TfsCacheDependencyEventHandler _tfsChanged;

        public TfsCacheDependency(string project)
        {
            _project = project;
            _localHandler = new TfsCacheDependencyEventHandler(TfsCacheDependency__tfsChanged);
            _tfsChanged += _localHandler;
        }

        void TfsCacheDependency__tfsChanged(object sender, TfsCacheDependencyEventArgs e)
        {
            if(_project==e.TfsProject)
                NotifyDependencyChanged(this, EventArgs.Empty);
        }

        public static void FireTfsChanged(string tfsProject)
        {
            if (_tfsChanged != null)
                _tfsChanged(null, new TfsCacheDependencyEventArgs(tfsProject));
        }

        protected override void DependencyDispose()
        {
            if (!_disposedEvent)
            {
                _tfsChanged -= _localHandler;
                _disposedEvent = true;
            }
            base.DependencyDispose();
        }
    }
}
