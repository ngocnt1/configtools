using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoRefreshTool
{
    public partial class Form1 : Form
    {
        DateTime start = DateTime.Now;
        DateTime startRF = DateTime.Now;
        int _interval = 1;
        int _hits = 0;
        int _fresh = 0;
        public Form1()
        {
            InitializeComponent();
            this.Text = Application.ProductName + " " + Application.ProductVersion;
        }

        DateTime? TimerOff
        {
            get
            {
                try
                {
                    return DateTime.Parse(tbTimer.Text);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate(tbUrl.Text);
            }
            catch (Exception)
            {
                ;
            }
        }
        void SetNewInternal()
        {
            _interval = GetRandomInterval;
            timer1.Interval = _interval * 1000 * 60;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                startRF = DateTime.Now;
                if (btnAutoRefresh.Checked)
                {
                    SetNewInternal();
                    if (webBrowser1.Url != null && cbRefreshCompletly.Checked)
                    {
                        webBrowser1.Refresh(WebBrowserRefreshOption.Completely);
                        ++_fresh;
                    }
                    else
                    {
                        btnGo.PerformClick();
                    }
                    lbHits.Text = string.Format("{0} fresh / {1} hit", _fresh, ++_hits);
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        public int GetRandomInterval
        {
            get
            {
                var _result = new Random().Next(int.Parse(ddlMaxInterval.Text));
                return _result == 0 ? 1 : _result;
            }
        }

        private void timer_Clock_Tick(object sender, EventArgs e)
        {
            try
            {

                if (btnAutoRefresh.Checked)
                {
                    if (cbTimer.Checked && TimerOff.HasValue && TimerOff.Value <= DateTime.Now)
                    {
                        btnAutoRefresh.PerformClick();
                        return;
                    }
                    TimeSpan _eslaped = DateTime.Now.Subtract(start);
                    lbTime.Text = string.Format("{0}:{1}:{2}", _eslaped.Hours, _eslaped.Minutes, _eslaped.Seconds);

                    TimeSpan _eslapedRF = DateTime.Now.Subtract(startRF);
                    btnAutoRefresh.Image = Properties.Resources.ResourceManager.GetObject("orderedList" + (_interval - _eslapedRF.Minutes).ToString()) as Image;
                }
                notifyIcon1.Text = string.Format("Hit: {0}\r\nEslapsed:{1}", _hits, lbTime.Text);
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnAutoRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lbTime.Visible = true;
                if (cbTimer.Enabled = btnAutoRefresh.Checked)
                {
                    start = DateTime.Now;
                }
                else
                {
                    btnAutoRefresh.Image = Properties.Resources.method;
                    cbTimer.Checked = false;
                    tbTimer.Enabled = true;
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        private void cbTimer_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                tbTimer.Enabled = !cbTimer.Checked;
                SetNewInternal();
            }
            catch (Exception)
            {
                ;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ddlMaxInterval.SelectedIndex = 0;
                tbTimer.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                SetNewInternal();

            }
            catch (Exception)
            {
                ;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            try
            {
                progressBar1.Visible = true;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                progressBar1.Maximum = (int)e.MaximumProgress;
                progressBar1.Value = (int)e.CurrentProgress;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                progressBar1.Visible = false;
            }
            catch (Exception)
            {
                ;
            }
        }
    }
}
