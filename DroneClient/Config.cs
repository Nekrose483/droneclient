using System;
using System.IO;

namespace DroneClient
{
	public class Config
	{
		public bool ready = false;
		
		public Config ()
		{
            try {
                string[] lines = File.ReadAllLines(DCConstants.ConfigFile);
                foreach (string line in lines) {
                string[] data = line.Split(':');
                if (data[0].Equals("username")) DCConstants.Username = data[1];
                else if (data[0].Equals("password")) DCConstants.Password = data[1];
                }
            }
            catch {
				File.Create(DCConstants.ConfigFile);
				StreamWriter writer = new StreamWriter(DCConstants.ConfigFile);
				writer.WriteLine("username:");
				writer.WriteLine("password:");
				writer.Close();
            }
        }
		
		public static void checkcreds ()
		{
			LoginWindow login = new LoginWindow ();
		}
	}
}

