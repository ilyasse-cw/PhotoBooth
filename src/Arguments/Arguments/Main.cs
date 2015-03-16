using System;

namespace Arguments
{
	class MainClass
	{

		public static void Main (string[] args)
		{

			if (args.Length == 0) {
			
				Console.WriteLine("just running");
			}

			else if	(args[0] == "/g")


			    {	Console.WriteLine("hey wat voor help wil je");
			}
			else
			{
				Console.WriteLine("no arguments are given");
			}
		}

		}
	}

