using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimeZoneUtil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                zoneList.DataSource = TimeZoneInfo.GetSystemTimeZones();
                zoneList.DisplayMember = "DisplayName";
                zoneList.ValueMember = "StandardName";
                zoneList.SelectedIndexChanged += zoneList_SelectedIndexChanged;
                //List<TimeZoneInfo> zones;
                //foreach (var z in TimeZoneInfo.GetSystemTimeZones())
                //{
                //    z.DisplayName
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DateTime ConvertToLocalServer(string zoneId)
        {
            DateTime localTime = DateTime.Now;
            //  GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);            
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
            //  var timeZone2 = timeZone.IsDaylightSavingTime(screen9DateTime) ? timeZone.DaylightName : timeZone.StandardName;
            var convertedTime = TimeZoneInfo.ConvertTime(
                ApplyAdjustment(localTime, TimeZoneInfo.Local.GetAdjustmentRules()),
                TimeZoneInfo.Local,
                timeZone
                );

            //var adjustmentRules = timeZone.GetAdjustmentRules();
            //if (adjustmentRules.Any())
            //{
            //    convertedTime = adjustmentRules[0].DaylightTransitionStart.TimeOfDay;
            //}
            return convertedTime;
        }

        public DateTime ApplyAdjustment(DateTime datetime, TimeZoneInfo.AdjustmentRule[] rules)
        {
            var _datetime = datetime;
            if (rules == null || !rules.Any())
                return _datetime;
            foreach (var adj in rules)
            {
                if (datetime >= adj.DateStart && datetime <= adj.DateEnd)
                {
                    _datetime = _datetime.Add(adj.DaylightDelta);
                }
            }
            return _datetime;
        }

        void zoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TimeZoneInfo z = zoneList.SelectedItem as TimeZoneInfo;

            lbStandardName.Text = z != null ? z.StandardName : "";
            if (z != null && z.GetAdjustmentRules().Any())
            {

                foreach (var adj in z.GetAdjustmentRules())
                {
                    var from = adj.DateStart;

                    var end = adj.DateEnd;

                    lbAdjustment.Text = string.Format("Daylight: {0}, From: {1:dd'-'MM'-'yyyy' 'HH':'mm':'ss} - To: {2:dd'-'MM'-'yyyy' 'HH':'mm':'ss}" + Environment.NewLine, adj.DaylightDelta
                        , from, end);
                }
            }
            else
                lbAdjustment.Text = "";
        }

        private void lbCopy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string label = ((LinkLabel)sender).Tag.ToString();
                TimeZoneInfo z = zoneList.SelectedItem as TimeZoneInfo;
                if (z!=null)
                {
                    Clipboard.SetText(z.StandardName);
                    MessageBox.Show("Copied");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeZoneInfo z = zoneList.SelectedItem as TimeZoneInfo;

                lbTime.Text = z == null ? "" : ConvertToLocalServer(z.StandardName).ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}
