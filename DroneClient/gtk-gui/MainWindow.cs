
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action FileAction;
	private global::Gtk.Action ExitAction;
	private global::Gtk.Action LoginAction;
	private global::Gtk.Action LoginAction1;
	private global::Gtk.Action LogoutAction;
	private global::Gtk.Action MinimizeToTrayAction;
	private global::Gtk.Action TasksAction;
	private global::Gtk.Action RefreshAction;
	private global::Gtk.VBox vbox1;
	private global::Gtk.MenuBar menubar1;
	private global::Gtk.Notebook notebook1;
	private global::Gtk.VBox vbox3;
	private global::Gtk.Label label6;
	private global::Gtk.ScrolledWindow GtkScrolledWindow1;
	private global::Gtk.TextView textview2;
	private global::Gtk.HBox hbox2;
	private global::Gtk.ComboBox combobox1;
	private global::Gtk.Button button18;
	private global::Gtk.Button button17;
	private global::Gtk.Label label1;
	private global::Gtk.VBox vbox2;
	private global::Gtk.Label label3;
	private global::Gtk.ScrolledWindow GtkScrolledWindow;
	private global::Gtk.TextView textview1;
	private global::Gtk.HBox hbox1;
	private global::Gtk.Entry entry1;
	private global::Gtk.Button button1;
	private global::Gtk.Label label2;
	private global::Gtk.ScrolledWindow GtkScrolledWindow2;
	private global::Gtk.TreeView treeview2;
	private global::Gtk.Label label4;
	private global::Gtk.Statusbar statusbar1;
	private global::Gtk.Label label5;
	
	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.ExitAction = new global::Gtk.Action ("ExitAction", global::Mono.Unix.Catalog.GetString ("Exit"), null, null);
		this.ExitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Exit");
		w1.Add (this.ExitAction, null);
		this.LoginAction = new global::Gtk.Action ("LoginAction", global::Mono.Unix.Catalog.GetString ("Login"), null, null);
		this.LoginAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Login");
		w1.Add (this.LoginAction, null);
		this.LoginAction1 = new global::Gtk.Action ("LoginAction1", global::Mono.Unix.Catalog.GetString ("Login"), null, null);
		this.LoginAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Login");
		w1.Add (this.LoginAction1, null);
		this.LogoutAction = new global::Gtk.Action ("LogoutAction", global::Mono.Unix.Catalog.GetString ("Logout"), null, null);
		this.LogoutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Logout");
		w1.Add (this.LogoutAction, null);
		this.MinimizeToTrayAction = new global::Gtk.Action ("MinimizeToTrayAction", global::Mono.Unix.Catalog.GetString ("Minimize to Tray"), null, null);
		this.MinimizeToTrayAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Minimize to Tray");
		w1.Add (this.MinimizeToTrayAction, null);
		this.TasksAction = new global::Gtk.Action ("TasksAction", global::Mono.Unix.Catalog.GetString ("Tasks"), null, null);
		this.TasksAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Tasks");
		w1.Add (this.TasksAction, null);
		this.RefreshAction = new global::Gtk.Action ("RefreshAction", global::Mono.Unix.Catalog.GetString ("Refresh"), null, null);
		this.RefreshAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Refresh");
		w1.Add (this.RefreshAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Imperius Chat Network");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox1 = new global::Gtk.VBox ();
		this.vbox1.Name = "vbox1";
		this.vbox1.Spacing = 6;
		// Container child vbox1.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString (@"<ui><menubar name='menubar1'><menu name='FileAction' action='FileAction'><menuitem name='ExitAction' action='ExitAction'/><menuitem name='MinimizeToTrayAction' action='MinimizeToTrayAction'/></menu><menu name='LoginAction' action='LoginAction'><menuitem name='LoginAction1' action='LoginAction1'/><menuitem name='LogoutAction' action='LogoutAction'/></menu><menu name='TasksAction' action='TasksAction'><menuitem name='RefreshAction' action='RefreshAction'/></menu></menubar></ui>");
		this.menubar1 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar1")));
		this.menubar1.Name = "menubar1";
		this.vbox1.Add (this.menubar1);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.menubar1]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox1.Gtk.Box+BoxChild
		this.notebook1 = new global::Gtk.Notebook ();
		this.notebook1.CanFocus = true;
		this.notebook1.Name = "notebook1";
		this.notebook1.CurrentPage = 0;
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox3 = new global::Gtk.VBox ();
		this.vbox3.Name = "vbox3";
		this.vbox3.Spacing = 6;
		// Container child vbox3.Gtk.Box+BoxChild
		this.label6 = new global::Gtk.Label ();
		this.label6.Name = "label6";
		this.label6.LabelProp = global::Mono.Unix.Catalog.GetString ("label2");
		this.vbox3.Add (this.label6);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.label6]));
		w3.Position = 0;
		w3.Expand = false;
		w3.Fill = false;
		// Container child vbox3.Gtk.Box+BoxChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.textview2 = new global::Gtk.TextView ();
		this.textview2.CanFocus = true;
		this.textview2.Name = "textview2";
		this.textview2.Editable = false;
		this.GtkScrolledWindow1.Add (this.textview2);
		this.vbox3.Add (this.GtkScrolledWindow1);
		global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow1]));
		w5.Position = 1;
		// Container child vbox3.Gtk.Box+BoxChild
		this.hbox2 = new global::Gtk.HBox ();
		this.hbox2.Name = "hbox2";
		this.hbox2.Spacing = 6;
		// Container child hbox2.Gtk.Box+BoxChild
		this.combobox1 = global::Gtk.ComboBox.NewText ();
		this.combobox1.AppendText (global::Mono.Unix.Catalog.GetString ("NO TASKS YET                                                     "));
		this.combobox1.Name = "combobox1";
		this.combobox1.Active = 0;
		this.hbox2.Add (this.combobox1);
		global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.combobox1]));
		w6.Position = 0;
		w6.Expand = false;
		w6.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button18 = new global::Gtk.Button ();
		this.button18.CanFocus = true;
		this.button18.Name = "button18";
		this.button18.UseUnderline = true;
		this.button18.Label = global::Mono.Unix.Catalog.GetString ("Start/Stop");
		this.hbox2.Add (this.button18);
		global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.button18]));
		w7.Position = 1;
		w7.Expand = false;
		w7.Fill = false;
		// Container child hbox2.Gtk.Box+BoxChild
		this.button17 = new global::Gtk.Button ();
		this.button17.CanFocus = true;
		this.button17.Name = "button17";
		this.button17.UseUnderline = true;
		this.button17.Label = global::Mono.Unix.Catalog.GetString ("Reject");
		this.hbox2.Add (this.button17);
		global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.button17]));
		w8.Position = 2;
		w8.Expand = false;
		w8.Fill = false;
		this.vbox3.Add (this.hbox2);
		global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.hbox2]));
		w9.Position = 2;
		w9.Expand = false;
		w9.Fill = false;
		this.notebook1.Add (this.vbox3);
		// Notebook tab
		this.label1 = new global::Gtk.Label ();
		this.label1.Name = "label1";
		this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("My Tasks");
		this.notebook1.SetTabLabel (this.vbox3, this.label1);
		this.label1.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.label3 = new global::Gtk.Label ();
		this.label3.Name = "label3";
		this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Chat with Master, Mistress, and other drones");
		this.vbox2.Add (this.label3);
		global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.label3]));
		w11.Position = 0;
		w11.Expand = false;
		w11.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.textview1 = new global::Gtk.TextView ();
		this.textview1.CanFocus = true;
		this.textview1.Name = "textview1";
		this.textview1.Editable = false;
		this.GtkScrolledWindow.Add (this.textview1);
		this.vbox2.Add (this.GtkScrolledWindow);
		global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
		w13.Position = 1;
		// Container child vbox2.Gtk.Box+BoxChild
		this.hbox1 = new global::Gtk.HBox ();
		this.hbox1.Name = "hbox1";
		this.hbox1.Spacing = 6;
		// Container child hbox1.Gtk.Box+BoxChild
		this.entry1 = new global::Gtk.Entry ();
		this.entry1.CanFocus = true;
		this.entry1.Name = "entry1";
		this.entry1.IsEditable = true;
		this.entry1.InvisibleChar = '●';
		this.hbox1.Add (this.entry1);
		global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entry1]));
		w14.Position = 0;
		// Container child hbox1.Gtk.Box+BoxChild
		this.button1 = new global::Gtk.Button ();
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString ("GtkButton");
		this.hbox1.Add (this.button1);
		global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.button1]));
		w15.Position = 1;
		w15.Expand = false;
		w15.Fill = false;
		this.vbox2.Add (this.hbox1);
		global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox1]));
		w16.Position = 2;
		w16.Expand = false;
		w16.Fill = false;
		this.notebook1.Add (this.vbox2);
		global::Gtk.Notebook.NotebookChild w17 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.vbox2]));
		w17.Position = 1;
		// Notebook tab
		this.label2 = new global::Gtk.Label ();
		this.label2.Name = "label2";
		this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Chat");
		this.notebook1.SetTabLabel (this.vbox2, this.label2);
		this.label2.ShowAll ();
		// Container child notebook1.Gtk.Notebook+NotebookChild
		this.GtkScrolledWindow2 = new global::Gtk.ScrolledWindow ();
		this.GtkScrolledWindow2.Name = "GtkScrolledWindow2";
		this.GtkScrolledWindow2.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow2.Gtk.Container+ContainerChild
		this.treeview2 = new global::Gtk.TreeView ();
		this.treeview2.CanFocus = true;
		this.treeview2.Name = "treeview2";
		this.GtkScrolledWindow2.Add (this.treeview2);
		this.notebook1.Add (this.GtkScrolledWindow2);
		global::Gtk.Notebook.NotebookChild w19 = ((global::Gtk.Notebook.NotebookChild)(this.notebook1 [this.GtkScrolledWindow2]));
		w19.Position = 2;
		// Notebook tab
		this.label4 = new global::Gtk.Label ();
		this.label4.Name = "label4";
		this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Family Members");
		this.notebook1.SetTabLabel (this.GtkScrolledWindow2, this.label4);
		this.label4.ShowAll ();
		this.vbox1.Add (this.notebook1);
		global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.notebook1]));
		w20.Position = 1;
		// Container child vbox1.Gtk.Box+BoxChild
		this.statusbar1 = new global::Gtk.Statusbar ();
		this.statusbar1.Name = "statusbar1";
		this.statusbar1.Spacing = 6;
		// Container child statusbar1.Gtk.Box+BoxChild
		this.label5 = new global::Gtk.Label ();
		this.label5.Name = "label5";
		this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Status: Offline");
		this.statusbar1.Add (this.label5);
		global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.statusbar1 [this.label5]));
		w21.Position = 1;
		w21.Expand = false;
		w21.Fill = false;
		this.vbox1.Add (this.statusbar1);
		global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar1]));
		w22.Position = 2;
		w22.Expand = false;
		w22.Fill = false;
		this.Add (this.vbox1);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 467;
		this.DefaultHeight = 531;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
