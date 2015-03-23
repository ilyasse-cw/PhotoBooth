using System;
using System.Diagnostics;
using WiringPiLib;


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
			shell.WaitForExit();

		}
	}
}


