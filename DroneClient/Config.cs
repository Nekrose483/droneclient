using System;
using System.IO;

namespace DroneClient
{
	public class Config
	{
		public bool ready = false;
		
		public Config ()
		{
			if (File.Exists (DCConstants.ConfigFile)) {
				string[] lines;

				try {
					lines = File.ReadAllLines (DCConstants.ConfigFile);
					if (lines != null) {
						foreach (string line in lines) {
							string[] data = line.Split (':');
							if (data.Length >= 2) {
								if (data [0].Equals ("username")) DCConstants.Username = data [1];
								else if (data [0].Equals ("password")) DCConstants.Password = data [1];
							}
						}
					}
				} catch {
				}


			} else {
				try {
					//File.Create(DCConstants.ConfigFile);
					StreamWriter writer = new StreamWriter(DCConstants.ConfigFile);
					writer.WriteLine("username:");
					writer.WriteLine("password:");
					writer.Close();
				} catch {
				}
			}
            
        }
		
		public static void checkcreds ()
		{
			LoginWindow login = new LoginWindow ();
		}
	}
}

