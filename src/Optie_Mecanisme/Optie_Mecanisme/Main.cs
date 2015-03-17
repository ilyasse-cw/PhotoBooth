using System;
using WiringPiLib;
using System.Threading;

namespace Optie_Mecanisme
{
	class MainClass
	{

		public static void Main (string[] args)
		{

			if (args.Length == 0) {
			
				Console.WriteLine ("just running");

			} else if (args [0] == "/h" || args [0] == "-help") {
				Console.WriteLine ("hey wat voor help wil je");
				Console.WriteLine ("-toggle-relay zorgt voor het aan of uit zetten van de Relay");
				Console.WriteLine ("-wait-for-click print 'hallo u bent gewonnen' als je op een knop drukt");

			} else if (args [0] == "-toggle-relay")
			{	
				Init.wiringPiSetupGpio();
				Init.piFaceSetup(200);

				if (GPIO.digitalRead(208)==1)
				{
					GPIO.digitalWrite(200,0);
				}
				else
				{
					GPIO.digitalWrite(200,1);
				}
			}
			else if (args [0] == "-wait-for-click") 
			{	
				Console.WriteLine("-wait-for-click gedrukt");
				Init.wiringPiSetupGpio();
				Init.piFaceSetup(200);
				for (int i=0;i<i+1;i++)
				{
					GPIO.pullUpDnControl(200,2);
					Thread.Sleep(500);
					if (GPIO.digitalRead(200) == 0)
					{
						Console.WriteLine("Je hebt op een knop gedrukt");
					}
				}
			}

			else
			{
				Console.WriteLine("no arguments are given");
			}
		}

		}
	}

