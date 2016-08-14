using System;
using System.IO.Ports;

namespace AruduinoSerialPortMessaging
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("--- Arduino App: Serail Port Messaging ---");

			// --- Initialisation ---
			SerialPort portToMsg = new SerialPort ("/dev/ttyUSB0", 9600);
			portToMsg.Open ();
			portToMsg.Write ("0");

			String inputString = "";

			// Show instructions
			Console.WriteLine("Toggle on/off LED (write 'e' to exit)");

			// --- MSG Toggle Actions ---
			while(!inputString.Equals("e", StringComparison.CurrentCultureIgnoreCase))
			{		
				inputString = Console.ReadLine();

				if(inputString.Equals("on", StringComparison.CurrentCultureIgnoreCase))
					portToMsg.WriteLine("1");
				else if(inputString.Equals("off", StringComparison.CurrentCultureIgnoreCase))
					portToMsg.WriteLine("0");
			}

			// --- Clean-up & degrade ---
			portToMsg.Write ("0");
			portToMsg.Close();
		}
	}
}
