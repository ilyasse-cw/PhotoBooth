using System;
using WiringPiLib;
using System.Threading;

namespace PollenToButton
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Init.wiringPiSetupGpio ();
			Init.piFaceSetup (200);
			for (int i=0; i<10; i++) {
				GPIO.pullUpDnControl (200, 2);
				Thread.Sleep (500);
		
				if (GPIO.digitalRead (200) == 0) {
					Console.WriteLine ("Hey je hebt op een knop gedrukt");
				}
			}
		}
	}
}
