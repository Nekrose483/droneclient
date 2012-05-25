using System;
using Gtk;

namespace DroneClient
{
	public partial class LoginWindow : Gtk.Dialog
	{
		public LoginWindow ()
		{
			this.Build ();
			this.buttonOk.Clicked += new EventHandler(clicked_OK);
		}
		void clicked_OK (object sender, EventArgs e)
		{
			//save to file config.ini then trigger connection again
		}
	}
}

