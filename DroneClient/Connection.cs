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
	public class Connection
    {
		public static bool isConnected = false;
		public delegate void OnError(string message);
		public delegate void OnRecievedMessage(string message);
		public static tcpConnection HiveConnection;
		
		public static void StartConnection()
        {
            HiveConnection = new tcpConnection(DCConstants.Host, DCConstants.Username, DCConstants.Password);
            HiveConnection.Connect();
        }
	
		public static void Disconnected(string reason)
        {
                MainWindow.ErrorMessageThing("*le connection has failed*");
                isConnected = false;
        }
		
		public static void RecievedMessage(string message)
        {
                MainWindow.UpdateChatTextbox(message);
        }
	}
	
	public class tcpConnection
    {
        public StreamWriter Outgoing;
        private StreamReader Incoming;
        private TcpClient Connection1;
        private Thread Messages;
        private IPAddress IP;
        public string host;
        public string nick;
		public string pass;
        bool isConnected;
        public tcpConnection(string Host, string Username, string Password) //already in DCConstants.. remove this
        {
            host = Host;
            nick = Username;
			pass = Password;
        }
        public void Connect()
        {
            try
            {
                IP = IPAddress.Parse(host); //fix this stuff
                Connection1 = new TcpClient();
                Connection1.Connect(IP, 1986);
                Outgoing = new StreamWriter(Connection1.GetStream());
				Outgoing.WriteLine(nick + ";" + pass); //make the server accept this
                Outgoing.Flush();
                Messages = new Thread(new ThreadStart(this.Communication));
                Messages.Start();
            }
            catch (Exception e) { Connection.Disconnected(e.Message); }
        }
        private void Communication()
        {
            Incoming = new StreamReader(Connection1.GetStream());
            string check = Incoming.ReadLine();
            if (check[0] == '1')
            {
                isConnected = true;
            }
            else
            {
                string Reason = "Disconnected: ";
                Reason += check.Substring(2, check.Length - 2);
                Connection.Disconnected(Reason);
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
                        Connection.Disconnected("Connection to server lost");
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
                Connection.RecievedMessage(message);
            }                                        
            catch { }
        }
        public void CloseConnection()
        {
            isConnected = false;
            Incoming.Close();
            Outgoing.Close();
            Connection1.Close();
            Messages.Abort();
        }
        public void SendMessage(string message)
        {
            Outgoing.WriteLine(message);
            Outgoing.Flush();
        }
    }
}

