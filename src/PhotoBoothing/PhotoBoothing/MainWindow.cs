using System;
using Gtk;
using PhotoBoothing;
using System.Threading;
using System.Timers;
using WiringPiLib;

public  partial class MainWindow: Gtk.Window
{	

	private static System.Timers.Timer timer;
	public  MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		Thread resetbutton = new Thread (new ThreadStart (ResetTimer));
			resetbutton.Start();

	 timer = new System.Timers.Timer(180000);
		timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
		timer.Enabled =true;

		var photobooth = new PhotoBoothModel();

		pbm.PictureButtonPressed += photobooth.OnPictureButtonPressed;
	


	}

		
		
	public  string Prefix {

		get{ return entry1.Text;}

	}
	public string EditPic {
		get{ return entry2.Text;}

	}

	private   void OnTimedEvent (object source, ElapsedEventArgs e)
	{
		button1.Hide();
		image1.Show();


	

	}
	public void ResetTimer ()
	{
		while (true) {
			GPIO.pullUpDnControl (200, 2);
			Thread.Sleep (500);

			if (GPIO.digitalRead (200) == 0) {
				timer.Stop();
				timer.Start();
				image1.Hide();
				button1.Show ();
			}
		}
	}
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	static PhotoBoothModel pbm = new PhotoBoothModel();

	public void OnButton1Clicked (object sender, EventArgs e)
	{

		pbm.SetPictureButtonPressed ();



	}	
	
	



}

