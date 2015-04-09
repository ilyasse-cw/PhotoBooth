using System;
using Gtk;
using WiringPiLib;
using System.Threading;
using System.Diagnostics;


namespace PhotoBoothV3_Events
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			WiringPiLib.Init.wiringPiSetupGpio();
			WiringPiLib.Init.piFaceSetup(200);
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
			var buttonpress = new ButtonPress();


		
		}
	}
	public class ButtonPress
	{
		public event EventHandler ButtonPressed;


		public void SetButtonPressed ()
		{
			ButtonPressed(this, EventArgs.Empty);
		}

		public  void Click ()
		{
			if (GPIO.digitalRead (200) == 0) {
				OnButtonPressed();
			}
			}
		protected virtual void OnButtonPressed ()
		{
			Console.WriteLine("ik werk");
			GPIO.digitalWrite(202,1);
			Thread.Sleep(1000);
			//1sec
			GPIO.digitalWrite(203,1);
			Thread.Sleep (1000);
			//2sec
			GPIO.digitalWrite(204,1);
			Thread.Sleep(1000);
			//3sec
			GPIO.digitalWrite(200,1);
			//take pic
			Process Getpic = new Process();
			Getpic.EnableRaisingEvents =false;
			Getpic.StartInfo.FileName = "gphoto2";
			Getpic.StartInfo.Arguments ="--capture-image-and-download";
			Getpic.Start();
			Getpic.WaitForExit(5000);

			//reset everything
			GPIO.digitalWrite(200,0);
			GPIO.digitalWrite(202,0);
			GPIO.digitalWrite(203,0);
			GPIO.digitalWrite(204,0);
			}
		}
		}
	
	
	

