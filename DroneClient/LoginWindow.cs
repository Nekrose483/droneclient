using System;
using Gtk;

namespace DroneClient
{
	public partial class LoginWindow : Gtk.Dialog
	{
		public LoginWindow ()
		{
			this.Build ();
			this.buttonOk.Clicked += new EventHandler(clicked_OK); //wtf
		}
		void clicked_OK (object sender, EventArgs e) //the hell is wrong with this?
		{
			//save to file config.ini then trigger connection again
		}
	}
}

