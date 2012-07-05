using System;

namespace DroneClient
{
	public partial class submittask : Gtk.Window
	{
		public submittask () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			//this.buttonOk.Clicked += new EventHandler(clicked_Send);
			//this.buttonCancel.Clicked += new EventHandler(clicked_Cancel);
		}

		void clicked_Send (object sender, EventArgs e)
		{
			//string formatted_msg = Chat.formatXMLChatMessage("","",entry1.Text);
            //Connection.HiveConnection.SendMessage(formatted_msg);
			this.Destroy();
		}
		
		void clicked_Cancel (object sender, EventArgs e)
		{
			this.Destroy();
		}
	}
}
