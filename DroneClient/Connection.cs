using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace DroneClient
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
        bool isConnected;
        public tcpConnection(string Host, string Username, string Password) //already in DCConstants.. remove this
        {
            host = Host;
            nick = Nickname;
        }
        public void Connect()
        {
            try
            {
                IP = IPAddress.Parse(host); //fix this stuff
                Connection = new TcpClient();
                Connection.Connect(IP, 1986);
                Outgoing = new StreamWriter(Connection.GetStream());
                Outgoing.WriteLine(nick);
                Outgoing.Flush();
                Messages = new Thread(new ThreadStart(this.Communication));
                Messages.Start();
            }
            catch (Exception e) { m_ParentForm.Disconnected(e.Message); } //why the form?
        }
        private void Communication()
        {
            Incoming = new StreamReader(Connection.GetStream());
            string check = Incoming.ReadLine();
            if (check[0] == '1')
            {
                isConnected = true;
            }
            else
            {
                string Reason = "Disconnected: ";
                Reason += check.Substring(2, check.Length - 2);
                MainWindow.Disconnected(Reason);
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
                        MainWindow.Disconnected("Connection to server lost");
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
                MainWindow.RecievedMessage(message); //put recievedMessage in Connection.cs in class Connection.
            }                                          //and then call it from there
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

