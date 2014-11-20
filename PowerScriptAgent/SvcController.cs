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

namespace PowerScriptAgent
{
    public class SvcController : ApiController
    {
        ILog log = LogManager.GetLogger("LOG");
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(string id)
        {
            return  RunScript(id);
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
