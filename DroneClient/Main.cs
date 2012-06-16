using System;
using Gtk;

namespace DroneClient
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Config conf = new Config ();
			Application.Init ();
			MainWindow win = new MainWindow ();
			Connection.win = win;
			Tasks.win = win;
			win.Show ();
			Application.Run ();
		}
	}	
}