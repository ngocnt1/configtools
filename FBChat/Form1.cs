﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBChat
{
    public partial class Form1 : Form
    {
      
         private FacebookChatClient client;

         public Form1()
        {
            InitializeComponent();
            
            client = new FacebookChatClient();
            client.OnLoginResult = success => appendLog("Connection to Facebook established " + (success ? "" : "un") + "successfully");           
            client.OnLogout = () => appendLog("Client logged out");            
            client.OnMessageReceived = (msg, user) => appendLog(user.name + ":" + msg.Body);          
            client.OnUserIsTyping = user => appendLog("The user " + user.name + " " + (user.isTyping ? "started typing" : "stopped typing"));           
            client.OnUserAdded = user =>
            {
                appendLog("User " + user.name + " is now available for chat");
                changeContactList(user.name, true);
            };
            client.OnUserRemoved = user =>
            {
                appendLog("User " + user.name + " is not longer available for chat");
                changeContactList(user.name, false);
            };
            tbxInput.KeyPress += new KeyPressEventHandler(tbxInput_KeyPress);
        }

         void tbxInput_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (e.KeyChar == '\r' && !string.IsNullOrEmpty(tbxInput.Text) && lbxContacts.SelectedItem != null)
             {
                 client.SendMessage(tbxInput.Text, (string)lbxContacts.Items[lbxContacts.SelectedIndex]);
                 appendLog("You to " + (string)lbxContacts.Items[lbxContacts.SelectedIndex] + ": " + tbxInput.Text);
                 tbxInput.ResetText();
             }
         }
         private void btnConnect_Click(object sender, EventArgs e)
         {
             if (!string.IsNullOrEmpty(tbxNick.Text) && !string.IsNullOrEmpty(tbxNick.Text))
                 client.Login(tbxNick.Text, tbxPass.Text);
         }

        private void changeContactList(string userName, bool add)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate { this.changeContactList(userName, add); }));
            else if (add)
                lbxContacts.Items.Add(userName);
            else if (!add)
                for (int i = 0; i <= lbxContacts.Items.Count; i++)
                    if (lbxContacts.Items[i].ToString() == userName)
                    {
                        lbxContacts.Items.RemoveAt(i);
                        break;
                    }
        }
        private void appendLog(string msg)
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate { this.appendLog(msg); }));
            else
            {
                tbxLog.AppendText(msg + Environment.NewLine);
                tbxLog.SelectionStart = tbxLog.Text.Length;
                tbxLog.ScrollToCaret();
            }
        }
    }
}
