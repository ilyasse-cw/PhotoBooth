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
			Init.piFaceSetup (201);


			Thread Button = new Thread (new ThreadStart (PolButton));
			Button.Start();
			Thread Led = new Thread (new ThreadStart (LedOn));
			Led.Start();

		}
		
		public static void PolButton ()
		{

			while (true) {
				GPIO.pullUpDnControl (201, 2);
				Thread.Sleep (500);
		
				if (GPIO.digitalRead (201) == 0) {
					Console.WriteLine ("Hey je hebt op een knop gedrukt");
				}

			}
		
		}
			public static void LedOn ()
		{
				for (int i = 200; i < 230; i++) 
			{

			
				GPIO.digitalWrite(i,1);
				Timing.delay( 500);
				GPIO.digitalWrite(i,0);
				Timing.delay( 500);
				Console.WriteLine(i);
			}
		}

	}
}
