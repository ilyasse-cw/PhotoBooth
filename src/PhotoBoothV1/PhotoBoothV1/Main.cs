using System;
using System.Threading;
using System.Diagnostics;
using WiringPiLib;


namespace PhotoBoothV1
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			Init.wiringPiSetupGpio();
			Init.piFaceSetup(200);

			Thread InstantPic = new Thread (new ThreadStart (TakePic));


			Thread waitlisten = new Thread (new ThreadStart (WaitForPic));


			if (args.Length == 0)
			{
				Console.WriteLine ("please give a parameter, Press /h for help");
			}
			else if (args [0] == "--help" || args [0] == "-h") 
			{
				Console.WriteLine ("JE hebt de volgende settings");
			} 
			else if (args [0] == "--take-picture") 
			{


				InstantPic.Start ();
				TakePic();
			} 
			else if (args [0] == "--wait-for-pic") 
			{

				waitlisten.Start ();
				WaitForPic();
			}
			else 
			{
				Console.WriteLine("wrong parameter");
			}

		}
	

		public static void TakePic ()
		{

			Process GetPic = new Process();
			GetPic.EnableRaisingEvents = false;
			GetPic.StartInfo.FileName ="gphoto2";
			GetPic.StartInfo.Arguments = "--capture-image-and-download";
			GetPic.Start();
			GetPic.WaitForExit();
			GetPic.Kill();
	
		}
	
		public static void WaitForPic ()
		{



			/*do (1 ==1) 
			{*/
			while (true) {
				GPIO.pullUpDnControl (200, 2);
				Thread.Sleep (1000);
				if (GPIO.digitalRead (200) == 0) {

					GPIO.digitalWrite (202, 1);
					Thread.Sleep (1000);
					//1sec
					GPIO.digitalWrite (203, 1);
					Thread.Sleep (1000);
					//2sec
					GPIO.digitalWrite (204, 1);
					Thread.Sleep (1000);
					//3sec
					GPIO.digitalWrite (200, 1);
					//take pic
					Process GetPic = new Process ();
					GetPic.EnableRaisingEvents = false;
					GetPic.StartInfo.FileName = "gphoto2";
					GetPic.StartInfo.Arguments = "--capture-image-and-download";
					GetPic.Start ();
					Console.WriteLine ("hjkke");
					GetPic.WaitForExit ();





					//reset evrything
					GPIO.digitalWrite (200, 0);
					GPIO.digitalWrite (202, 0);
					GPIO.digitalWrite (203, 0);
					GPIO.digitalWrite (204, 0);


				}

			}
			}
		}

	}

