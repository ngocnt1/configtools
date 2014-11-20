using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rates
{
    public partial class Main : Form
    {
        Pairs[] pairs = new Pairs[] { Pairs.EURNZD };
        public Main()
        {
            InitializeComponent();
        }


        private void UpdateRate(Pairs pair)
        {
            try
            {
                WebClient w = new WebClient();
                w.DownloadStringCompleted += w_DownloadStringCompleted;
                w.DownloadStringAsync(new Uri(string.Format("http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1ba&e=.csv", pair.ToString())),"");
            }
            catch (Exception)
            {
                ;
            }
        }

        void w_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                label1.Text = e.Result;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label2.Text = DateTime.Now.ToString();
                foreach (var p in pairs)
                {
                    UpdateRate(p);
                }
            }
            catch (Exception)
            {
                ;
            }
        }
    }
}
