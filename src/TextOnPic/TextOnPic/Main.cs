using System;
using System.Diagnostics;
using WiringPiLib;
using System.Threading;


namespace TextOnPic
{
	class MainClass
	{


		public static void Main (string[] args)
		{


			Process shell =new Process();
			shell.EnableRaisingEvents=false;
			shell.StartInfo.FileName="gphoto2";
			shell.StartInfo.Arguments="-v";
			shell.Start();


			TakePic();

		}
		public static void TakePic ()
		{
			Init.wiringPiSetupGpio ();
			Init.piFaceSetup (200);
			GPIO.pullUpDnControl (200, 2);
			Thread.Sleep(500);
			if (GPIO.digitalRead (200) == 0) 
			{
				Process takePic = new Process ();
				takePic.EnableRaisingEvents = false;
				takePic.StartInfo.FileName = "gphoto2";
				takePic.StartInfo.Arguments = "--capture-image-and-download";
				takePic.Start ();
				takePic.WaitForExit ();

				EditText();
			}
		}
		public static void EditText()
		{
			string tekst;
			Console.WriteLine ("Geef uw tekst op!");
			tekst = Console.ReadLine();
			Process Text =new Process();
			Text.EnableRaisingEvents=false;
			Text.StartInfo.FileName="convert.im6";
			Text.StartInfo.Arguments=" convert capt0000.jpg -pointsize 150 -draw \"text 2500,3500'"+tekst+"'\" cv2.jpg";
			Text.Start(); 
		}
	}
}


