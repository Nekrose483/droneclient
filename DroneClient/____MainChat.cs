// This program is fully open source, although when you see "//Leave This Here" in the code.
// Make sure to leave it.
// Code Copyright (c) 2010 xsDevelopment & sniperX
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

namespace ChatClient
{
    public partial class MainChat : Form
    {
        string adUser = "";
        string adPass = "";
        public delegate void OnRecievedMessage(string message);
        public Login m_parentForm;
        public string Host;
        public string Nickname;
        public tcpConnection m_ChildConnection;
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        static extern uint ScrollText(System.IntPtr hwnd, uint wMsg, uint wParam, uint
        lParam);
        const int WM_VSCROLL = 0x115;
        const int SB_BOTTOM = 7;
        public MainChat(Login logForm)
        {
            InitializeComponent();
            this.AcceptButton = (button1);
            m_parentForm = logForm;
            this.textBox2.KeyDown += new KeyEventHandler(textBox2_KeyDown);
            this.FormClosing += new FormClosingEventHandler(MainChat_FormClosing);
            this.textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
        }
        void textBox1_TextChanged(object sender, EventArgs e)
        {
            ScrollText(textBox1.Handle, WM_VSCROLL, SB_BOTTOM, 0);
        }
        void MainChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_ChildConnection.CloseConnection();
            m_parentForm.Close();
        }
        void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox2.Text != "")
                {
                    if (textBox2.Text.ToLower().StartsWith("/"))
                    {
                        onCommand(textBox2.Text);
                        textBox2.Text = "";
                    }
                    else
                    {
                        m_ChildConnection.SendMessage("MSG :" + textBox2.Text);
                        textBox2.Text = "";
                    }
                }
            }
        }
        private void onCommand(string message)
        {
            List<string> splitArray = new List<string>(message.Split(new char[] { '/' }));
            splitArray.RemoveAt(0);
            string midSplit = String.Join("/", splitArray.ToArray());
            splitArray = new List<string>(midSplit.Split(new char[] { ' ' }));

            string command = splitArray[0].ToUpper();
            splitArray.RemoveAt(0);
            List<string> args = splitArray;

            if (command == "KILL")
            {
                string userToKill = args[0];
                args.RemoveAt(0);
                m_ChildConnection.SendMessage("ADMIN "+adUser+" "+adPass+" :KILL " + userToKill+" "+String.Join(" ",args.ToArray()));
            }
            else if (command == "MUTE")
            {
                string userToKill = args[0];
                args.RemoveAt(0);
                m_ChildConnection.SendMessage("ADMIN " + adUser + " " + adPass + " :MUTE " + userToKill);
            }
            else if (command == "UNMUTE")
            {
                string userToKill = args[0];
                args.RemoveAt(0);
                m_ChildConnection.SendMessage("ADMIN " + adUser + " " + adPass + " :UNMUTE " + userToKill);
            }
            else if (command == "ME")
            {
                m_ChildConnection.SendMessage("ACTION :" + String.Join(" ",args.ToArray()));
            }
            else if (command == "NOTICE")
            {
                m_ChildConnection.SendMessage("NOTICE :" + String.Join(" ",args.ToArray()));
            }
            else if (command == "LOGIN")
            {
                adUser = args[0];
                adPass = args[1];
                m_ChildConnection.SendMessage("ADMIN " + adUser + " " + adPass + " :");
            }
        }
        public void StartConnection()
        {
            m_ChildConnection = new tcpConnection(this, Host, Nickname);
            m_ChildConnection.Connect();
        }
        public void Disconnected(string reason)
        {
            m_parentForm.Disconnected(reason);
        }
        public void RecievedMessage(string message)
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
        private void UpdateTextbox(string text)
        {
            textBox1.Text += "\r\n";
            textBox1.Text += text;
        }
        public delegate void Visability(bool visable);
        public void Vis(bool visable)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Visability(Vis), visable);
            }
            else
            {
                this.Visible = visable;
            }
        }
        private void MainChat_Load(object sender, EventArgs e)
        {
            this.Text = "Chat Client - " + m_ChildConnection.nick;
            // Leave this here.
            textBox1.Text = "Chat Client coded by xsDevelopment & sniperX";
        }
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please type /login <username> <password> in the textbox below");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeXsInstaChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (textBox2.Text.ToLower().StartsWith("/"))
                {
                    onCommand(textBox2.Text);
                    textBox2.Text = "";
                }
                else
                {
                    m_ChildConnection.SendMessage("MSG :" + textBox2.Text);
                    textBox2.Text = "";
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("For Admin Login. type, /login username password","1/5 Start of Commands");
            MessageBox.Show("To mute a user, you must be admin, type,  /mute nickname","2/5");
            MessageBox.Show("To unmute, you must be admin, type, /unmute nickname","3/5");
            MessageBox.Show("To disconnect a user, you must be admin, type, /kill nickname","4/5");
            MessageBox.Show("To emphasize your text, type, /me message","5/5 End Of Commands");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Leave this here.
            MessageBox.Show("Program Made by xsDevelopment & sniperX. www.youtube.com/xsDevelopment","Copyright Information");
        }
    }
}
