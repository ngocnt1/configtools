using log4net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Diagnostics;
using PowerScriptAgent.Entities;
using Newtonsoft.Json;

namespace PowerScriptAgent
{
    //[HMACAuthentication]
    public class SvcController : ApiController
    {
        ILog log = LogManager.GetLogger("LOG");
      //  PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter theMemCounter = new PerformanceCounter("Memory", "Available MBytes");
        // GET api/values 
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
       

        public string Get()
        {
           
            //float cpuUsage = 0.00F;

            //theCPUCounter.NextValue();
            //System.Threading.Thread.Sleep(1000);
            //cpuUsage = theCPUCounter.NextValue();

           // return new string[] { "CPU:" + CPUMonitor.Instance.Usage, "RAM:" + theMemCounter.NextValue() };

            return JsonConvert.SerializeObject(CPUMonitor.Instance.Queues.Select(x => x).ToList());
        }

        // GET api/values/5 
        public string Get(string id)
        {
            return RunScript(id);
        }

        private string RunScript(string scriptText)
        {
            try
            {
                // create Powershell runspace

                Runspace runspace = RunspaceFactory.CreateRunspace();

                // open it

                runspace.Open();

                // create a pipeline and feed it the script text

                Pipeline pipeline = runspace.CreatePipeline();

                //                pipeline.Commands.AddScript(@"
                //function Get-ComputerStats($ServerName) { 
                //
                //  process {
                //        $avg = Get-WmiObject win32_processor -computername $ServerName | 
                //                   Measure-Object -property LoadPercentage -Average | 
                //                   Foreach {$_.Average}
                //        $mem = Get-WmiObject win32_operatingsystem -ComputerName $ServerName |
                //                   Foreach {""{0:N2}"" -f ((($_.TotalVisibleMemorySize - $_.FreePhysicalMemory)*100)/ $_.TotalVisibleMemorySize)}
                //        $free = Get-WmiObject Win32_Volume -ComputerName $ServerName -Filter ""DriveLetter = 'C:'"" |
                //                    Foreach {""{0:N2}"" -f (($_.FreeSpace / $_.Capacity)*100)}
                //					
                //					Write-Host ""CPU usage: $avg %"" -ForegroundColor Green
                //					Write-Host ""Memory usage: $mem %"" -ForegroundColor Green
                //					Write-Host ""OS Disk free: $free %"" -ForegroundColor Green    
                //  }
                //}
                //
                //");
                pipeline.Commands.AddScript(scriptText);

                // add an extra command to transform the script
                // output objects into nicely formatted strings

                // remove this line to get the actual objects
                // that the script returns. For example, the script

                // "Get-Process" returns a collection
                // of System.Diagnostics.Process instances.

                pipeline.Commands.Add("Out-String");

                // execute the script

                Collection<PSObject> results = pipeline.Invoke();

                // close the runspace

                runspace.Close();

                // convert the script result into a single string

                StringBuilder stringBuilder = new StringBuilder();
                foreach (PSObject obj in results)
                {
                    stringBuilder.AppendLine(obj.ToString());
                }

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return ex.Message;
            }
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
