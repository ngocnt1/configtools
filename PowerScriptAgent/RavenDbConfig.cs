using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Document;

namespace PowerScriptAgent
{
    class RavenDbConfig
    {
        public const string TableDeploymentDB = "DeploymentDB";
        static IDocumentStore docStore;
        private static readonly Lazy<IDocumentStore> LazyDocStore = new Lazy<IDocumentStore>(() =>
        {
            if (docStore!=null && !docStore.WasDisposed)
            {
                return docStore;
            }
            docStore = new DocumentStore
            {
                Url = "http://localhost:8083"
            };

            docStore.Initialize();
            return docStore;
        });

        public static IDocumentStore Store
        {
            get
            {
                if (LazyDocStore == null)
                    throw new InvalidOperationException(
                    "IDocumentStore has not been initialized.");
                return LazyDocStore.Value;
            }
        }
    }
}
