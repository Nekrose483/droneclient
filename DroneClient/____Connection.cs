// This program is fully open source, although when you see "//Leave This Here" in the code.
// Make sure to leave it.
// Code Copyright (c) 2010 xsDevelopment & sniperX
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ChatClient
{
    public class tcpConnection
    {
        public StreamWriter Outgoing;
        private StreamReader Incoming;
        private TcpClient Connection;
        private Thread Messages;
        private IPAddress IP;
        public string host;
        public string nick;
        MainChat m_ParentForm;
        bool isConnected;
        public tcpConnection(MainChat main, string Host, string Nickname)
        {
            m_ParentForm = main;
            host = Host;
            nick = Nickname;
        }
        public void Connect()
        {
            try
            {
                IP = IPAddress.Parse(host);
                Connection = new TcpClient();
                Connection.Connect(IP, 1986);
                Outgoing = new StreamWriter(Connection.GetStream());
                Outgoing.WriteLine(nick);
                Outgoing.Flush();
                m_ParentForm.Vis(true);
                Messages = new Thread(new ThreadStart(this.Communication));
                Messages.Start();
            }
            catch (Exception e) { m_ParentForm.Disconnected(e.Message); }
        }
        private void Communication()
        {
            Incoming = new StreamReader(Connection.GetStream());
            string check = Incoming.ReadLine();
            if (check[0] == '1')
            {
                m_ParentForm.m_parentForm.Vis(false);
                m_ParentForm.Vis(true);
                isConnected = true;
            }
            else
            {
                string Reason = "Disconnected: ";
                Reason += check.Substring(2, check.Length - 2);
                m_ParentForm.Disconnected(Reason);
                return;
            }
            while (isConnected == true)
            {
                try
                {
                    ServerMessage(Incoming.ReadLine());
                }
                catch (Exception e)
                {
                    if (isConnected == true)
                    {
                        m_ParentForm.Disconnected("Connection to server lost");
                        Console.WriteLine("Connection Lost: " + e.ToString());
                    }
                    break;
                }
            }
        }
        private void ServerMessage(string message)
        {
            try
            {
                m_ParentForm.RecievedMessage(message);
            }
            catch { }
        }
        public void CloseConnection()
        {
            isConnected = false;
            Incoming.Close();
            Outgoing.Close();
            Connection.Close();
            Messages.Abort();
        }
        public void SendMessage(string message)
        {
            Outgoing.WriteLine(message);
            Outgoing.Flush();
        }
    }
}
