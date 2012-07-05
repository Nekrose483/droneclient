using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;

namespace DroneClient
{
	public class Tasks
	{
		public static List<TaskData> tasklist;
		public static MainWindow win;
		
		public Tasks ()
		{
			
		}
		
		public static void get_tasks ()
		{
			XMLNode rootnode = new XMLNode (null, "x", "");
				
			rootnode.childNodes.Add (new XMLNode (rootnode, "type", "gettask"));
			string xmlstr = rootnode.makeXMLString ();

          	Connection.HiveConnection.SendMessage(xmlstr);
			
			tasklist.Clear();
		}

		private static bool truefalse (string stuff)
		{
			int lol;
			try {lol = Int32.Parse(stuff);} catch {lol = 0;}
			if (lol == 1) return true; else return false;
		}
		
		public static void interpretTaskXML (XPathNavigator nav)
		{
			Console.WriteLine ("Interpret task XML");
			
		 string title = ""; 
		 int taskid = 0;
		 int from_unit = 0;
		 int from_number = 0;
		 int to_unit = 0;
		 int to_number = 0;
		 string task = "";
		 DateTime creation_date = DateTime.Now; 
		 int type = 0;
		 bool requires_review = false;
		 bool completed = false;
		 bool denied = false;
		 bool failed = false;
		 DateTime end_date = DateTime.Now;
			
			nav.MoveToRoot ();			
			nav.MoveToFirstChild ();
			
			do {
				if (nav.NodeType == XPathNodeType.Element) {
					if (nav.HasChildren == true) {
						nav.MoveToFirstChild ();
						do {
							
							if (nav.Name == "title") {
								title = nav.Value;
							} else if (nav.Name == "taskid") {
								taskid = Int32.Parse(nav.Value);
							} else if (nav.Name == "from_unit") {
								from_unit = Int32.Parse(nav.Value);
							} else if (nav.Name == "from_number") {
								from_number = Int32.Parse(nav.Value);
							} else if (nav.Name == "to_unit") {
								to_unit = Int32.Parse(nav.Value);
							} else if (nav.Name == "to_number") {
								to_number = Int32.Parse(nav.Value);
							} else if (nav.Name == "task") {
								task = nav.Value;
							} else if (nav.Name == "creation_date") {
								creation_date = System.Convert.ToDateTime(nav.Value);
							} else if (nav.Name == "type") {
								type = Int32.Parse(nav.Value);
							} else if (nav.Name == "requires_review") {
								requires_review = truefalse(nav.Value);
							} else if (nav.Name == "completed") {
								completed = truefalse(nav.Value);
							} else if (nav.Name == "denied") {
								denied = truefalse(nav.Value);
							} else if (nav.Name == "failed") {
								failed = truefalse(nav.Value);
							} else if (nav.Name == "end_date") {
								end_date = System.Convert.ToDateTime(nav.Value);
							} 
							
						} while (nav.MoveToNext()); 
					}
				}
			} while (nav.MoveToNext());
			
			Console.WriteLine ("Interpret task XML - done");
			
							NewTask (title,
			         					taskid,
			                            from_unit,
 						 				from_number,
						 				to_unit,
						 				to_number,
						 				task,
        				 				creation_date,
						 				type,
										requires_review,
						 				completed,
        				 				denied,
						 				failed,
						 				end_date);
		}
		
		private static void NewTask (string title_,
		                             int taskid_,
		                 			int from_unit_,
 						 			int from_number_,
						 			int to_unit_,
						 			int to_number_,
						 			string task_,
        				 			DateTime creation_date_,
									int type_,
									bool requires_review_,
									bool completed_,
        							bool denied_,
									bool failed_,
									DateTime end_date_)
		{
			TaskData td = new TaskData (title_,
			                            taskid_,
			                            from_unit_,
 						 				from_number_,
						 				to_unit_,
						 				to_number_,
						 				task_,
        				 				creation_date_,
						 				type_,
										requires_review_,
						 				completed_,
        				 				denied_,
						 				failed_,
						 				end_date_);
			if ((failed_ == false) && (denied_ = false) && (completed_ == false)) {
				TaskDialog task = new TaskDialog (title_, task_);
				task.Show ();
				tasklist.Add(td);
				win.TaskComboFill(title_);
			}
		}
	}
}
