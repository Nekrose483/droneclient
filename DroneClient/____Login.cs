// This program is fully open source, although when you see "//Leave This Here" in the code.
// Make sure to leave it.
// Code Copyright (c) 2010 xsDevelopment & sniperX
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Login : Form
    {
        public delegate void OnError(string message);
        public bool isConnected = false;
        MainChat m_ChildForm;
        public Login()
        {
            InitializeComponent();
            label1.ForeColor = Color.Red;
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
        private void Login_Load(object sender, EventArgs e)
        {
            m_ChildForm = new MainChat(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            m_ChildForm.Host = textBox1.Text;
            m_ChildForm.Nickname = textBox2.Text;
            m_ChildForm.StartConnection();
        }
        public void Disconnected(string reason)
        {
            if (InvokeRequired)
            {
                this.Invoke(new OnError(Disconnected), reason);
            }
            else
            {
                MessageBox.Show(reason, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isConnected = false;
                this.Visible = true;
                m_ChildForm.Visible = false;
            }
        }
    }
}
