using System;
using System.IO;
using Gtk;

namespace DroneClient
{
	public partial class LoginWindow : Gtk.Dialog
	{
		public LoginWindow ()
		{
			this.Build ();
			this.buttonOk.Clicked += new EventHandler(clicked_OK);
			this.buttonCancel.Clicked += new EventHandler(clicked_Cancel);
		}
		void clicked_OK (object sender, EventArgs e)
		{
			StreamWriter writer = new StreamWriter(DCConstants.ConfigFile);
				writer.WriteLine("username:" + entry1.Text);
				writer.WriteLine("password:" + entry2.Text);
				writer.Close();
			Connection.HiveConnection.Connect();
			this.Destroy();
		}
		
		void clicked_Cancel (object sender, EventArgs e)
		{
			this.Destroy();
		}
	}
}

