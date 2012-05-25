using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

namespace DroneClient
{
	public class Chat
    {   
        [DllImport("user32.dll", EntryPoint = "SendMessageA")] //dunno what this does
        static extern uint ScrollText(System.IntPtr hwnd, uint wMsg, uint wParam, uint
        lParam);

        private void closeXsInstaChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // this.Close();
        }
    }	
}

