using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Xml;

namespace DroneClient
{
	public class Tasks
	{
		public static MainWindow win;
		
		public Tasks ()
		{
			
		}
		
		public static void get_tasks ()
		{
			XMLNode rootnode = new XMLNode (null, "x", "");
				
			rootnode.childNodes.Add (new XMLNode (rootnode, "type", "asktask"));;
			string xmlstr = rootnode.makeXMLString ();

          	Connection.HiveConnection.SendMessage(xmlstr);
			
			//clear tasks before you recieve them
		}
		
		public static void interpretTaskXML (XPathNavigator nav)
		{
			Console.WriteLine ("Interpret task XML");
			
			string task_title = "";
			string task_body = "";
			
			nav.MoveToRoot ();			
			nav.MoveToFirstChild ();
			
			do {
				if (nav.NodeType == XPathNodeType.Element) {
					if (nav.HasChildren == true) {
						nav.MoveToFirstChild ();
						do {
							
							if (nav.Name == "title") {
								task_title = nav.Value;
							} else if (nav.Name == "body") { //add to,from,start/end dates...
								task_body = nav.Value;
							} 
							
						} while (nav.MoveToNext()); 
					}
				}
			} while (nav.MoveToNext());
			
			Console.WriteLine ("Interpret task XML - done");
			
			NewTask (task_title, task_body);
		}
		
		private static void NewTask (string title, string body)
		{
			TaskDialog task = new TaskDialog (title, body);
			task.Show ();
			//add the tasks to some kind of array like a LIST in the server
			win.TaskComboFill(title);
		}
	}
}

