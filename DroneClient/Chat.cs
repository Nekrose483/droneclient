using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Xml;


namespace DroneClient
{
	public class Chat
    {   
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        static extern uint ScrollText(System.IntPtr hwnd, uint wMsg, uint wParam, uint
        lParam);
		
		public static string formatXMLChatMessage (string receivername, string channel, string message)
		{
			string xmlstr = "";
			XMLNode rootnode = new XMLNode (null, "x", "");		
			rootnode.childNodes.Add (new XMLNode (rootnode, "type", "chat"));
			rootnode.childNodes.Add (new XMLNode (rootnode, "to", receivername));
			rootnode.childNodes.Add (new XMLNode (rootnode, "channel", channel));
			rootnode.childNodes.Add (new XMLNode (rootnode, "message", message));
			xmlstr = rootnode.makeXMLString ();
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
					} 
				}
			} while (nav.MoveToNext());
			
			Console.WriteLine ("Interpret chat XML - done");
			string update = sender_username + ": " + message;
			Connection.win.UpdateChatTextbox (update);
		}
    }	
}

