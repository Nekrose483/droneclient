using System;
namespace DroneClient
{
	public partial class ErrorMessageThing : Gtk.Dialog
	{
		public ErrorMessageThing ()
		{
			this.Build ();
			this.button70.Clicked += new EventHandler(clicked_OK);
		}
		
		void clicked_OK (object sender, EventArgs e)
		{
			this.Destroy();
		}
		
		public void SetText (string text)
		{
			label1.Text = text;
		}
	}
}

