using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Gtk;
using DroneClient;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		//label4.ForeColor = Color.Red; //how is this done
		Connection.StartConnection(); //should prolly get info first
		//this.entry1.Changed += new EventHandler(entry1_Changed);
		this.button1.Clicked += new EventHandler(button1_Click);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Connection.HiveConnection.CloseConnection();
		Application.Quit ();
		a.RetVal = true;
	}
	
/*	void entry1_Changed(object sender, EventArgs e)
        {
            if (e.KeyData == Keys.Enter) //remove this or parse for enter key...
            {
                if (entry1.Text != "")
                {
                    if (entry1.Text.ToLower().StartsWith("/"))
                    {
                        Commands.onCommand(entry1.Text);
                        entry1.Text = "";
                    }
                    else
                    {
                        Connection.HiveConnection.SendMessage("MSG :" + entry1.Text);
                        entry1.Text = "";
                    }
                }
            }
        } */
	private void button1_Click(object sender, EventArgs e)
        {
            if (entry1.Text != "")
            {
                if (entry1.Text.ToLower().StartsWith("/"))
                {
                    Commands.onCommand(entry1.Text);
                    entry1.Text = "";
                }
                else
                {
                    Connection.HiveConnection.SendMessage("MSG :" + entry1.Text);
                    entry1.Text = "";
                }
            }
        }
	public static void UpdateChatTextbox(string text)
        {
            textview1.Text += "\r\n";  //wtf is wrong here
            textview1.Text += text;
        }
	
	public static void ErrorMessage (string text)
	{
		ErrorMessageThing err = new ErrorMessageThing ();
		ErrorMessageThing.SetText(text);
		err.Show ();
	}
}
