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
using System.Web;
using System.Web.Caching;

namespace TFS.Library.Tfs
{
    /// <summary>
    /// Helper class for handling caching of objects with TFS dependency
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TfsCache<T> where T: class
    {
        private readonly string _cacheKey;
        private readonly string _tfsProject;

        public TfsCache(string tfsProject, params object[] keys)
        {
            _tfsProject = tfsProject;
            _cacheKey = tfsProject;
            foreach (object o in keys)
            {
                if (o == null)
                {
                    continue;
                }
                _cacheKey += "-" + o.ToString();
            }
        }

        public T Get()
        {
            return HttpRuntime.Cache[_cacheKey] as T;
        }

        public void Put(T val)
        {
#if RELEASE
            HttpRuntime.Cache.Add(_cacheKey, val, new TfsCacheDependency(_tfsProject), DateTime.Now.AddHours(1), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
#endif
        }
    }
}
