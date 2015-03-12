using System;
using WiringPiLib;


namespace libworking
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Init.wiringPiSetupGpio();
			Init.piFaceSetup (200);
			for (int i = 200; i < 208; i++) 
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
