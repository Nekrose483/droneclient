using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace DroneClient
{
	public class XMLNode
	{
		public XMLNode parent;
		public List<XMLNode> childNodes = new List<XMLNode> ();
		public string tag;
		public string value;
		
		public XMLNode (XMLNode parent_, string tag_, string value_)
		{
			parent = parent_;
			tag = tag_;
			value = value_;
		}	
		
		
		public XMLNode lastChild ()
		{
			if (childNodes.Count > 0) {
				return childNodes [childNodes.Count - 1];
			} else {
				return null;
			}
				
		}
		
		public string makeXMLString ()
		{			
			string ret = "<" + tag + ">";
			
			if (childNodes.Count > 0) {
				foreach (XMLNode node in childNodes) {
					ret += node.makeXMLString ();
				}
			} else {
				ret += value;
			}
			ret += "</"+tag+">";
			
			return ret;
		}		
	}
}

