using PowerScriptAgent.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerScriptAgent
{
    class CPUMonitor
    {
        Timer timer;
        private volatile bool IsStoped;

        static CPUMonitor _instance;

        PerformanceCounter theCPUCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        // Queue<BaseItem> queues = new Queue<BaseItem>();

        public CPUMonitor()
        {
            timer = new Timer(TimerTick, null, 0, 15000);

        }

        private void TimerTick(object state)
        {
            if (!IsStoped)
            {
                  var session = RavenDbConfig.Store.OpenSession(RavenDbConfig.TableDeploymentDB);
                        session.Store(new CPU() { Value = Usage });
                        session.SaveChanges();
            }
        }

        public static CPUMonitor Instance
        {
            get
            {
                return _instance ?? (_instance = new CPUMonitor());
            }
        }

        //public Queue<BaseItem> Queues { get { return queues; } }

        public float Usage { get; private set; }

        public void Start()
        {
            Thread thread = new Thread(new ThreadStart(delegate()
            {
                try
                {
                    while (!IsStoped)
                    {
                        ////To Update The UI Thread we have to Invoke  it. 

                        //int process = cpu.Query(); //Determines the current average CPU load.
                        //proVal.Text = process.ToString() + "%";
                        //cpuUsageChart.Series[0].Points.AddY(process);//Add process to chart 

                        //if (cpuUsageChart.Series[0].Points.Count > 40)
                        //    //clear old data point after Thrad Sleep time * 40
                        //    cpuUsageChart.Series[0].Points.RemoveAt(0);


                        // Usage = 0.00F;

                        theCPUCounter.NextValue();
                        System.Threading.Thread.Sleep(1000);

                        // Thread.Sleep(450);//Thread sleep for 450 milliseconds 
                        Usage = theCPUCounter.NextValue();
                        //if (queues.Count > 600)
                        //{
                        //    queues.Dequeue();
                        //}
                      
                        // queues.Enqueue(new CPU() { Value = Usage });
                    }
                }
                catch (Exception)
                {

                }

            }));

            thread.Priority = ThreadPriority.Highest;
            thread.IsBackground = true;
            thread.Start();//Start the Thread
        }

        public void Stop()
        {
            Usage = 0.00F;
            IsStoped = true;
        }
    }
}
