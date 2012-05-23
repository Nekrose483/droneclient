using System;
namespace DroneClient                  //fix adUser and adPass from DCConstants.. look at server and see how it's
{                                      //done there.. can we use XML?
	public class Commands
	{
		public Commands ()
		{
		}
		public void onCommand(string message)
        {
            List<string> splitArray = new List<string>(message.Split(new char[] { '/' }));
            splitArray.RemoveAt(0);
            string midSplit = String.Join("/", splitArray.ToArray());
            splitArray = new List<string>(midSplit.Split(new char[] { ' ' }));

            string command = splitArray[0].ToUpper();
            splitArray.RemoveAt(0);
            List<string> args = splitArray;

            if (command == "KILL")
            {
                string userToKill = args[0];
                args.RemoveAt(0);
                HiveConnection.SendMessage("ADMIN "+adUser+" "+adPass+" :KILL " + userToKill+" "+String.Join(" ",args.ToArray()));
            }
            else if (command == "MUTE")
            {
                string userToKill = args[0];
                args.RemoveAt(0);
                HiveConnection.SendMessage("ADMIN " + adUser + " " + adPass + " :MUTE " + userToKill);
            }
            else if (command == "UNMUTE")
            {
                string userToKill = args[0];
                args.RemoveAt(0);
                HiveConnection.SendMessage("ADMIN " + adUser + " " + adPass + " :UNMUTE " + userToKill);
            }
            else if (command == "ME")
            {
                HiveConnection.SendMessage("ACTION :" + String.Join(" ",args.ToArray()));
            }
            else if (command == "NOTICE")
            {
                HiveConnection.SendMessage("NOTICE :" + String.Join(" ",args.ToArray()));
            }
            else if (command == "LOGIN")
            {
                adUser = args[0];
                adPass = args[1];
                HiveConnection.SendMessage("ADMIN " + adUser + " " + adPass + " :");
            }
        }
		
		
	}
}

