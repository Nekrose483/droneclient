using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions; //regular expressions, duh
using System.Web; //needs to be added as a reference
using System.Xml.XPath;
//using System.Xml.XmlReader;
using System.Xml.Serialization;
using System.Xml;


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
		
		public static string formatXMLChatMessage (string receivername, string channel, string message)
		{
			//this function only constructs the XML chat message
			//from server to clients
			
			string xmlstr = "";
			
			//I actually don't know how to get the name of the root node
			//so I'll just name it . to keep it small
			// here's what this should look like
			// <x>
			//		<type>chat</type>
			//		<to>recipient_name</to>
			//		<channel>channel_name</channel>
			//		<message>message_text</message>
			// </x>
			
			XMLNode rootnode = new XMLNode (null, "x", "");
			
				
			rootnode.childNodes.Add (new XMLNode (rootnode, "type", "chat"));
			rootnode.childNodes.Add (new XMLNode (rootnode, "to", receivername));
			rootnode.childNodes.Add (new XMLNode (rootnode, "channel", channel));
			rootnode.childNodes.Add (new XMLNode (rootnode, "message", message));
				
			
			xmlstr = rootnode.makeXMLString ();
			//rootnode.parseXML (xmlstr);	
			
			return xmlstr;
		}
		
		public static void interpretChatXML (XPathNavigator nav)
		{
			Console.WriteLine ("Interpret chat XML");
			
			string sender_username = "";
			string channel_name = "";
			string message = "";
			
			nav.MoveToRoot ();			
			nav.MoveToFirstChild ();
			
			do {
				if (nav.NodeType == XPathNodeType.Element) {
					if (nav.HasChildren == true) {
						nav.MoveToFirstChild ();
						do {
							
							if (nav.Name == "from") {
								sender_username = nav.Value;
							} else if (nav.Name == "channel") {
								channel_name = nav.Value;
							} else if (nav.Name == "message") {
								message = nav.Value;
							}
							
						} while (nav.MoveToNext()); 
					} else {
						/*
						Console.Write ("The XML string for this PARENT ");
						Console.Write ("  " + nav.Name + " ");
						Console.WriteLine ("is '{0}'", nav.Value);
						*/
					}
				}
			} while (nav.MoveToNext());
			
			Console.WriteLine ("Interpret chat XML - done");
			
			//Hopefully, we don't get stuck in an infinate loop
			//SendChatMessage (fromuser, message);
			string update = sender_username + ": " + message;
			Connection.win.UpdateChatTextbox (update);
		}
    }	
}

