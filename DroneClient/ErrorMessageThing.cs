using System;
namespace DroneClient
{
	public partial class ErrorMessageThing : Gtk.Dialog
	{
		public ErrorMessageThing ()
		{
			this.Build ();
			this.buttonOk.Clicked += new EventHandler(clicked_OK); //wtf
		}
		
		void clicked_OK (object sender, EventArgs e) //the hell is wrong with this?
		{
			this.Close();
		}
		
		public static void SetText (string text)
		{
			label2.Text = text;
		}
	}
}

