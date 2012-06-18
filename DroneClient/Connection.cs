using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace DroneClient
{
	public class Connection
    {
		public static bool isConnected = false;
		public delegate void OnError(string message);
		public delegate void OnRecievedMessage(string message);
		public static tcpConnection HiveConnection;
		public static MainWindow win;
		
		public static void StartConnection()
        {
            HiveConnection = new tcpConnection();
            HiveConnection.Connect();
        }
	
		public static void Disconnected(string reason)
        {
                MainWindow.ErrorMessage("*le connection has failed*");
                isConnected = false;
        }
		
		public static void RecievedMessage (string message)
		{
			byte[] byteArray = Encoding.UTF8.GetBytes (message);
			MemoryStream stream = new MemoryStream (byteArray);
			
			XPathDocument xmldoc;
			
			try {
				xmldoc = new XPathDocument (stream);
			} catch (Exception ex) {
				Console.WriteLine ("{0} Exception in xml: ", ex);
				return;
			}
			XPathNavigator nav = xmldoc.CreateNavigator ();
			nav.MoveToRoot ();
			nav.MoveToFirstChild ();
			do {
				if (nav.NodeType == XPathNodeType.Element) {
					if (nav.HasChildren == true) {
						nav.MoveToFirstChild ();
						do {

							if (nav.Name == "type") {
								
								if (nav.Value == "chat") {
								
									Chat.interpretChatXML (nav);
									return;
								}
								
								if (nav.Value == "task") {								
									Tasks.interpretTaskXML (nav);
									return;
								}
							}
							
						} while (nav.MoveToNext()); 
					} 
				}
			} while (nav.MoveToNext());
			
			return;
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
        public tcpConnection()
        {
			
        }
        public void Connect ()
		{
			Config conf = new Config ();
			
			try {
				Console.WriteLine ("Attempting to connect to " + DCConstants.Host);
				
				IP = IPAddress.Parse (DCConstants.Host);
				Connection1 = new TcpClient ();
				Connection1.Connect (IP, DCConstants.Port);
				Outgoing = new StreamWriter (Connection1.GetStream ());
				Outgoing.WriteLine (DCConstants.Username + ":" + DCConstants.Password + ":" + DCConstants.authpattern);
				Outgoing.Flush ();
				Messages = new Thread (new ThreadStart (this.Communication));
				Messages.Start ();
			} catch (Exception e) { 
				Console.WriteLine ("Failed connection: " + e.Message); //try to get the conf file and then connect again
				while (conf.ready == false) {conf.checkcreds();}
				Connection.Disconnected(e.Message);
				
			}
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

