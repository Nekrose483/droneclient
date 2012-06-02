using System;
namespace DroneClient
{
	public class Tasks
	{
		string TaskName;
		public static MainWindow win;
		
		public Tasks ()
		{
			
		}
		
		public void get_tasks ()
		{
			//get tasks
			//alert that you have new tasks
			//add the tasks 
			win.TaskComboFill(TaskName);
		}
	}
}

