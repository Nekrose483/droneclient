using System;
namespace DroneClient
{
	public partial class TaskDialog : Gtk.Dialog
	{
		public TaskDialog (string title, string body)
		{
			this.Build ();
			this.button17.Clicked += new EventHandler(clicked_Accept);
			label1.Text = title;
			textview1.Buffer.Text = body;
			//read it out loud here
		}
		
		void clicked_Accept (object sender, EventArgs e)
		{
			this.Destroy();
		}
	}
}

