using System;
using System.Collections.Generic;

namespace DroneClient                  //get authpattern in server.
{                                      //done there.. can we use XML?
	public class Commands
	{
		public static string authpattern = DCConstants.authpattern;
		
		public Commands ()
		{
		}
		public static void onCommand(string message)
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
                Connection.HiveConnection.SendMessage("ADMIN "+authpattern+" :KILL " + userToKill+" "+String.Join(" ",args.ToArray()));
            }
            else if (command == "MUTE")
            {
                string userToKill = args[0];
                args.RemoveAt(0);
                Connection.HiveConnection.SendMessage("ADMIN " + authpattern + " :MUTE " + userToKill);
            }
            else if (command == "UNMUTE")
            {
                string userToKill = args[0];
                args.RemoveAt(0);
                Connection.HiveConnection.SendMessage("ADMIN " + authpattern + " :UNMUTE " + userToKill);
            }
            else if (command == "ME")
            {
                Connection.HiveConnection.SendMessage("ACTION :" + String.Join(" ",args.ToArray()));
            }
            else if (command == "NOTICE")
            {
                Connection.HiveConnection.SendMessage("NOTICE :" + String.Join(" ",args.ToArray()));
            }
        }
		
		
	}
}

