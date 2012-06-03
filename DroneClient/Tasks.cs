using System;
using System.Text.RegularExpressions; //regular expressions, duh
using System.Web; //needs to be added as a reference
using System.Xml.XPath;
//using System.Xml.XmlReader;
using System.Xml.Serialization;
using System.Xml;

namespace DroneClient
{
	public class Tasks
	{
		//string TaskName;
		public static MainWindow win;
		
		public Tasks ()
		{
			
		}
		
		public void get_tasks ()
		{
			//tell server to send tasks for specific drone ID
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
							} else if (nav.Name == "body") {
								task_body = nav.Value;
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
			
			Console.WriteLine ("Interpret task XML - done");
			
			NewTask (task_title, task_body);
		}
		
		private static void NewTask (string title, string body)
		{
			TaskDialog task = new TaskDialog (title, body);
			task.Show ();
			//add the tasks to some kind of array
			win.TaskComboFill(title);
		}
	}
}

