using System;
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
            	//create file
            }
        }
		
		public void checkcreds ()
		{
			//open up login window
			ready = true;
		}
	}
}
