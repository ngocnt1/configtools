using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using log4net;
using System.Management;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace PowerScriptAgent
{
    public partial class ServiceCore : ServiceBase
    {
        ILog log = LogManager.GetLogger("LOG");
        IDisposable app;
        public ServiceCore()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {
            try
            {
                CPUMonitor.Instance.Start();

                log.Info("On Start: http://localhost:9096");
                //log.Info(RunScript(@"""ABC"" | Out-File -FilePath Date.txt"));
                // string baseAddress = "http://localhost:9000/";

                StartOptions options = new StartOptions();
                options.Urls.Add("http://localhost:9096");
                options.Urls.Add("http://127.0.0.1:9096");
                options.Urls.Add(string.Format("http://{0}:9096", Environment.MachineName));

                // Start OWIN host 
                app = WebApp.Start<SvcStartup>(options);
                //using ()
                //{
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync("http://127.0.0.1:9096/" + "api/svc/GET-SERVICE").Result;

                log.Info(response);

                string res = response.Content.ReadAsStringAsync().Result;

                foreach (var l in res.Split('\n'))
                {
                    log.Info(l);
                }

                //}
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        protected override void OnStop()
        {
            app.Dispose();
            CPUMonitor.Instance.Stop();
            log.Info("On Stop");
            base.OnStop();
        }
    }
}
