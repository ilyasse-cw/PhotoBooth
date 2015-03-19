using System;
using WiringPiLib;
using System.Threading;

namespace ButtonPress
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			var buttonpress = new ButtonPress();
			var text = new TekstBericht();

			buttonpress.ButtonPressed += text.OnButtonPressed;
			buttonpress.click();
		}
	}
	public class ButtonPress
	{
		public event EventHandler<EventArgs> ButtonPressed;

		public  void click()
		{
			Init.wiringPiSetupGpio ();
			Init.piFaceSetup (200);
			for (int i=0; i<100; i++) {
				GPIO.pullUpDnControl (200, 2);
				Thread.Sleep(500);
		
				if (GPIO.digitalRead (200) == 0) {
					Console.WriteLine ("Hey je hebt op een knop gedrukt");
					OnButtonPressed();
			}

		}

			
	}
		protected virtual void OnButtonPressed()
		{
			if (ButtonPressed != null) 
			{
				ButtonPressed(this,EventArgs.Empty);
			}
		}
	}
	public class TekstBericht
	{
		public void OnButtonPressed(object source, EventArgs e)
		{
			Console.WriteLine("Hey you pressed a Button 2haha");
		}
	}
}

