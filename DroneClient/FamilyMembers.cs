using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections;
using System.Xml.XPath;
using System.Xml.Serialization; //family member tree in mainwindow
using System.Xml;

namespace DroneClient
{
	public class FamilyMembers
	{
		List<FamilyMember> people;
		bool requested_from_server;
		
		public FamilyMembers ()
		{
			requested_from_server = false;
		}
		
		public void requestFamilyMembers ()
		{
			XMLNode rootnode = new XMLNode (null, "x", "");
			string xmlstr = "";
				
			rootnode.childNodes.Add (new XMLNode (rootnode, "type", "requestFamilyMembers"));	
			
			xmlstr = rootnode.makeXMLString ();
			
			Connection.HiveConnection.SendMessage (xmlstr);
			
			requested_from_server = true;
		}
		
		public static void interpretFamilyMemberXML (XPathNavigator nav)
		{
			string sender_username = "";
			string channel_name = "";
			string message = "";
			FamilyMember fm = new FamilyMember ();
			
			nav.MoveToRoot ();			
			nav.MoveToFirstChild ();
			
			do {
				if (nav.NodeType == XPathNodeType.Element) {
					if (nav.HasChildren == true) {
						nav.MoveToFirstChild ();
						do {
							
							if (nav.Name == "id") {
								fm.id = Int32.Parse(nav.Value);
							} else if (nav.Name == "username") {
								fm.username = nav.Value;
							} else if (nav.Name == "unit") {
								fm.unit = Int32.Parse(nav.Value);
							} else if (nav.Name == "number") {
								fm.number = Int32.Parse(nav.Value);
							} else if (nav.Name == "uniqueid") {
								fm.uniqueid = nav.Value;
							} else if (nav.Name == "position_id") {
								fm.position_id = Int32.Parse(nav.Value);
							} else if (nav.Name == "rank") {
								fm.rank = Int32.Parse(nav.Value);
							} else if (nav.Name == "join_date") {
								fm.join_date = nav.Value;
							} else if (nav.Name == "admin") {
								fm.admin = Int32.Parse(nav.Value);
							} else if (nav.Name == "sec_leader") {
								if (nav.Value == "1")
									fm.sec_leader = true;
								else
									fm.sec_leader = false;
							}
							
						} while (nav.MoveToNext()); 
					} else { }
				}
			} while (nav.MoveToNext());
			
			
			if ((fm.username != "undefined") && (fm.id != -1)) {
				people.Add (fm);	
			}
			
			
		}
	}
	
	public class FamilyMember
	{
		public int id;
		public string username;
		public int unit;
		public int number;
		public string uniqueid;
		public int position_id;
		public int rank;
		public string join_date;
		public int admin;
		public bool sec_leader;
		
		public bool requested_detail_from_server;
		
		public FamilyMemberDetail detail;
		
		public FamilyMember ()
		{
			id = -1;
			username = "undefined";
			unit = -1;
			number = -1;
			uniqueid = "undefined";
			position_id = -1;
			rank = -1;
			join_date = "undefined";
			admin = -1;
			sec_leader = false;
			requested_detail_from_server = false;
			detail = null;
		}
	}
	
	public class FamilyMemberDetail
	{
		int age;
		string species;
		string description;
		string fetishes;
		string contact;
		string gender;
		string orientation;
		string triggers;
		string hypnotic_nuances;
	}
}

