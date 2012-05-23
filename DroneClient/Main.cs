using System;
using Gtk;

namespace DroneClient
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			//put stuff here from MainWindow that can be put here. like call a check for Config.ini here
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
