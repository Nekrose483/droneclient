using System;
namespace DroneClient
{
	
	public class DCConstants
	{
		public static string Host = "127.0.0.1"; //Hypnoflow.org = 208.115.203.104
		public static int Port = 1986; //4256
        public static string Username = "enzo";
		public static string Password = "password";
		public static string ConfigFile = "Config.ini";
		public static string authpattern = Username + Password; //not sure if we really need this.
	}
}

