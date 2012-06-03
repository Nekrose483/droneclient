using System;
namespace DroneClient
{
	public partial class TaskDialog : Gtk.Dialog
	{
		public TaskDialog (string title, string body)
		{
			this.Build ();
			label1.Text = title;
			textview1.Buffer.Text = body;
			//read it out loud here
		}
	}
}

