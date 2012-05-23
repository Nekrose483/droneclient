using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace DroneClient
{
	public class Chat
    {
        public delegate void OnRecievedMessage(string message); //goes in connection.cs
        
        [DllImport("user32.dll", EntryPoint = "SendMessageA")] //dunno what this does
        static extern uint ScrollText(System.IntPtr hwnd, uint wMsg, uint wParam, uint
        lParam);
		
		
		
		
        
		
		
	
        public void RecievedMessage(string message) //don't know where to put this... where is OnRecievedMessage?
        {
            if (InvokeRequired)
            {
                this.Invoke(new OnRecievedMessage(RecievedMessage), message);
            }
            else
            {
                UpdateTextbox(message);
            }
        }
        private void UpdateTextbox(string text) //stays here
        {
            MainWindow.textview1.Text += "\r\n";
            MainWindow.textview1.Text += text;
        }

        private void closeXsInstaChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //take this into MainWindow
        {
            MessageBox.Show("For Admin Login. type, /login username password","1/5 Start of Commands");
            MessageBox.Show("To mute a user, you must be admin, type,  /mute nickname","2/5");
            MessageBox.Show("To unmute, you must be admin, type, /unmute nickname","3/5");
            MessageBox.Show("To disconnect a user, you must be admin, type, /kill nickname","4/5");
            MessageBox.Show("To emphasize your text, type, /me message","5/5 End Of Commands");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e) //take this into MainWindow
        {
            // Leave this here.
            MessageBox.Show("Program Made by xsDevelopment & sniperX. www.youtube.com/xsDevelopment","Copyright Information");
        }
    }	
}

