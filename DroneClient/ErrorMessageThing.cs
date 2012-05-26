using System;
namespace DroneClient
{
	public partial class ErrorMessageThing : Gtk.Dialog
	{
		public ErrorMessageThing ()
		{
			this.Build ();
			this.buttonOk.Clicked += new EventHandler(clicked_OK);
		}
		
		void clicked_OK (object sender, EventArgs e)
		{
			this.Close();
		}
		
		public void SetText (string text)
		{
			label2.Text = text;
		}
	}
}

