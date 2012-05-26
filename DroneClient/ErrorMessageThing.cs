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
			//this.Quit(); //make sure this doesnt quit the whole thing.
		}
		
		public void SetText (string text)
		{
			label2.Text = text;
		}
	}
}

