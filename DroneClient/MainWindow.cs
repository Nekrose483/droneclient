using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Gtk;
using DroneClient;

public partial class MainWindow: Gtk.Window
{	
	public tcpConnection HiveConnection;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		this.entry1.KeyDown += new KeyEventHandler(entry1_KeyDown);
		this.button1_Click.Clicked += new KeyEventHandler(button1_Click);
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		HiveConnection.CloseConnection();
		Application.Quit ();
		a.RetVal = true;
	}
	
	public void StartConnection() //this can be moved to Connection.cs class Connection
        {
            HiveConnection = new tcpConnection(this, Host, Nickname); //fix 'this' and put it in class connection
            HiveConnection.Connect();
        }
	
	public void Disconnected(string reason) //to connection.cs
        {
            MainWindow.Disconnected(reason);
        }
	
	void entry1_KeyDown(object sender, EventArgs e)
        {
            if (e.KeyData == Keys.Enter)
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
                        HiveConnection.SendMessage("MSG :" + entry1.Text);
                        entry1.Text = "";
                    }
                }
            }
        }
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
                    HiveConnection.SendMessage("MSG :" + entry1.Text);
                    entry1.Text = "";
                }
            }
        }
}
