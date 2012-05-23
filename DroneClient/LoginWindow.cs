using System;
namespace DroneClient
{
	public partial class LoginWindow : Gtk.Dialog
	{
		public LoginWindow ()
		{
			this.Build ();
			this.buttonOk.Clicked += new KeyEventHandler(clicked_OK);
		}
		void clicked_OK () //the hell is wrong with this?
		{
			//save to file config.ini then trigger connection again
		}
	}
}

