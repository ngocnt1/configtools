using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace CultureHelper
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        Dictionary<string, string> twoCharater = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
         
            try
            {
                string path = Path.Combine(Application.StartupPath, "cul.txt");

                foreach (var p in File.ReadAllLines(path))
                {
                    string[] names = p.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (names.Length == 2 && !dictionary.ContainsKey(names[1]))
                    {
                        dictionary.Add(names[1], names[0]);
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
            try
            {
                string path = Path.Combine(Application.StartupPath, "iso3166.txt");

                foreach (var p in File.ReadAllLines(path))
                {
                    string[] names = p.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    if (names.Length > 1 && !twoCharater.ContainsKey(names[0]))
                    {
                        twoCharater.Add(names[0], names[1]);
                    }
                }
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            try
            {
             //   CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
                var files = Directory.GetFiles(txtSrc.Text).Where(x => Path.GetFileNameWithoutExtension(x).Length == 2);
                MessageBox.Show("Found:" + files.Count());
                int done = 0;
                int ignore = 0;
                foreach (var f in files)
                {
                    try
                    {
                        var two = Path.GetFileNameWithoutExtension(f).ToUpper();
                        var three = twoCharater[two];
                        //var c = cultures.FirstOrDefault(x => x.TwoLetterISOLanguageName.ToLower() == two);
                        var des = Path.Combine(Path.GetDirectoryName(f), dictionary[three.ToUpper()] + Path.GetExtension(f));
                        if (!File.Exists(des))
                        {
                            File.Copy(f, des);
                            done++;
                        }
                    }
                    catch (Exception)
                    {
                        ignore++;
                    }
                }

                MessageBox.Show("Created:" + done + " Ignored:" + ignore);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
