using System;
using System.Net.Sockets;
using Hypnoflow.Net;

namespace DroneClient
{
	public class Connection
	{
		ClientInfo client;
		
		public Connection ()
		{
		 Socket sock = Sockets.CreateTCPSocket(DCConstants.Host, DCConstants.Port);
       	 client = new ClientInfo(sock, false); // Don't start receiving yet
   		 client.OnRead += new ConnectionRead(ReadData);
   		 client.Delimiter = "\n";  // this is the default, shown for illustration
   		 client.BeginReceive();
		}
		
		  void ReadData(ClientInfo ci, String text)
		{ //var ci keeps track of what connection it is
    	  Console.WriteLine("Received text message: "+text);
  		}
	}
}

