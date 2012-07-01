using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Gtk;
//using Gdk; //system tray icon in v2
using DroneClient;

public partial class MainWindow: Gtk.Window
{	
	//private StatusIcon trayIcon;
	ListStore store = new ListStore(typeof (string));
	
	TreeViewColumn usernameCol;
	TreeViewColumn onlineCol;
	CellRendererText usernameCell;
	CellRendererText onlineCell;

	string activetask = "";
	bool taskstart = false;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		//label4.ForeColor = Color.Red; //how is this done in mono?
		Connection.StartConnection ();
		//this.entry1.Changed += new EventHandler(entry1_Changed); //impliment this in verson 2
		this.button1.Clicked += new EventHandler (button1_Click);
		this.ExitAction.Activated += new EventHandler (Exit_Click);
		this.MinimizeToTrayAction.Activated += new EventHandler (MinimizeToTray_Click);
		this.RefreshAction.Activated += new EventHandler (Refresh_Tasks);
		this.button18.Clicked += new EventHandler (start_stop_tasks);
		this.button17.Clicked += new EventHandler (reject_tasks);
		
		this.combobox1.Clear ();
		CellRendererText cell = new CellRendererText ();
		this.combobox1.PackStart (cell, false);
		this.combobox1.AddAttribute (cell, "text", 0);
		this.combobox1.Model = store;
		
		usernameCol = new TreeViewColumn ();
		usernameCol.Title = "Name";
		usernameCell = new CellRendererText ();
		usernameCol.PackStart (usernameCell, true);
		
		onlineCol = new TreeViewColumn ();
		onlineCol.Title = "Online";
		onlineCell = new CellRendererText ();
		usernameCol.PackStart (onlineCell, true);
				
		this.treeview2.AppendColumn(usernameCol);
		
		//trayIcon = new StatusIcon(new Pixbuf ("icon.jpg")); //get an icon
		//trayIcon.Visible = true;
		//trayIcon.Activate += delegate { this.Visible = !this.Visible; };
		//trayIcon.PopupMenu += OnTrayIconPopup;
		//trayIcon.Tooltip = "DCS v1.0";
	}
	
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Connection.HiveConnection.CloseConnection();
		Application.Quit ();
		a.RetVal = true;
	}
	
	/*static void OnTrayIconPopup (object o, EventArgs args) {
		Menu popupMenu = new Menu();
		ImageMenuItem menuItemQuit = new ImageMenuItem ("Quit");
		Gtk.Image appimg = new Gtk.Image(Stock.Quit, IconSize.Menu);
		menuItemQuit.Image = appimg;
		popupMenu.Add(menuItemQuit);
		menuItemQuit.Activated += delegate { Application.Quit(); };
		popupMenu.ShowAll();
		popupMenu.Popup();
	}*/
	
/*	void entry1_Changed(object sender, EventArgs e)       //impliment this in verson 2
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
					string formatted_msg = Chat.formatXMLChatMessage("","",entry1.Text);
                    Connection.HiveConnection.SendMessage(formatted_msg);
                    entry1.Text = "";
                }
            }
        }
	public void UpdateChatTextbox(string text)
        {
            textview1.Buffer.Text += "\r\n";
            textview1.Buffer.Text += text;
        }
	
	public static void ErrorMessage (string text)
	{
		ErrorMessageThing err = new ErrorMessageThing ();
		err.SetText(text);
		err.Show ();
	}
	
	private void Exit_Click (object sender, EventArgs e)
    {
		Application.Quit();
    }
	
	private void Refresh_Tasks (object sender, EventArgs e)
    {
		Tasks.get_tasks();
    }
	
	private void MinimizeToTray_Click (object sender, EventArgs e)
    {
		//OS Specific
    }
	
	public void TaskComboFill (string text)
	{
        store.AppendValues (text);	
	}
	
	public void addFamilyMember(FamilyMember fm) {
		
	}
	
	public void start_stop_tasks (object sender, EventArgs e)
	{
		if (taskstart == false) 
		{
			taskstart = true;
			activetask = combobox1.ActiveText;
			//take DateTime.Now
		} else if (taskstart == true)
		{
			//DateTime.now - starttime;
			//foreach (int task in Tasks.tasklist) { if (task.title == activetask) task. } //add elapsed time to datetime var in tasklist.
			//pop up message box asking if they would like to submit the task_attempt (have a text area for links and such)
		}
	}

	public void reject_tasks (object sender, EventArgs e)
	{
		//pop up window asking for information on why the rejection
		//send task_attempt to server as failed
	}
}
