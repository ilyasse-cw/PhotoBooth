using System;
using Gtk;
using System.Threading;
using System.Diagnostics;
using WiringPiLib;


namespace PhotoBoothing
{
	public class MainClass
	{
		public static string editText;
		public static string prefix;
		public static void Main (string[] args)
		{
			Thread RpiButton = new Thread (new ThreadStart (RPIButton));
			RpiButton.Start();
			WiringPiLib.Init.wiringPiSetupGpio();
			WiringPiLib.Init.piFaceSetup(200);
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			editText = win.EditPic;
			 prefix=win.Prefix;
			var photo = new PhotoBoothModel();
			photob.PictureButtonPressed += photo.OnPictureButtonPressed;


			Application.Run ();
		 	

		}

		static PhotoBoothModel photob = new PhotoBoothModel();
		public static void RPIButton ()
		{


			while (true) {
				GPIO.pullUpDnControl (200, 2);
				Thread.Sleep (500);


				if (GPIO.digitalRead (200) == 0) {


					photob.SetPictureButtonPressed();


							
						
					
				}
			}
		}

	}
	public class PhotoBoothModel
	{
		public static string test1;
		public static string test2;
		public  void Nec()
		{
		MainWindow nieuw = new MainWindow();
			test1 = nieuw.Prefix;
			test2 = nieuw.EditPic;

		}

		public int photoCounter =0;
		public string newphotoCounter;
		public event EventHandler PictureButtonPressed;

		public void SetPictureButtonPressed()
		{
			PictureButtonPressed(this, EventArgs.Empty);
		}
		public void OnPictureButtonPressed(object sender, EventArgs e)
		{
			Console.WriteLine(test1+"lol");
			Console.WriteLine(test2+"lol");

			photoCounter++;
			newphotoCounter = photoCounter.ToString("D4");

			GPIO.digitalWrite(202,1);
			Console.WriteLine(" 3 ");
			Thread.Sleep(1000);
			//1sec
			GPIO.digitalWrite(203,1);
			Console.WriteLine(" 2 ");
			Thread.Sleep (1000);
			//2sec
			GPIO.digitalWrite(204,1);
			Console.WriteLine(" 1 ");
			Thread.Sleep(1000);
			//3sec
			GPIO.digitalWrite(200,1);
			//take pic
			Process Getpic = new Process();
			Getpic.EnableRaisingEvents =false;
			Getpic.StartInfo.FileName = "gphoto2";
			Getpic.StartInfo.Arguments ="--filename="+MainClass.prefix+"_"+newphotoCounter+" --capture-image-and-download";
			Getpic.Start();
			Getpic.WaitForExit(5000);

			//reset everything
			GPIO.digitalWrite(200,0);
			GPIO.digitalWrite(202,0);
			GPIO.digitalWrite(203,0);
			GPIO.digitalWrite(204,0);
			Console.WriteLine(newphotoCounter);
			Console.WriteLine(MainClass.prefix);
			Console.WriteLine(MainClass.editText);

			EditPicture();
		}
		public  void EditPicture ()
		{

			Process EditPic = new Process ();
					EditPic.EnableRaisingEvents = false;
					EditPic.StartInfo.FileName = "convert.im6";
					EditPic.StartInfo.Arguments = " convert "+MainClass.prefix+"_"+newphotoCounter+".jpg -pointsize 150 -draw \"text 2500,3500'"+MainClass.editText+"'\" edited_"+MainClass.prefix+"_"+newphotoCounter+".jpg";
					EditPic.Start ();
					Console.WriteLine(newphotoCounter);
			Console.WriteLine(MainClass.prefix);
			Console.WriteLine(MainClass.editText);
		}
	}

}
