using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.CLIDisplay
{
	internal class Display
	{
		string[] UNDERLINE = ["\x1B[4m", "\x1B[0m"];
		private string[] colors = ["\u001b[36m", "\u001b[0m"];
		private string[] options = { "[{0}] Play Music", "[{0}] Pause Music", "[{0}] Stop Music", "[{0}] Next Song", "[{0}] Previous Song", "[{0}] Exit" };
		private byte posx = 0;
		private byte posy = 0;

		public Display()
		{
			MenuFunc();
		}

		private void MenuFunc()
		{
			Console.CursorVisible = false;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(@"==============================

      WELCOME TO DANTE

==============================
");
			Menu();
			while (true) {
				ConsoleKeyInfo key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.UpArrow) {
					if (posx > 0) {
						posx--;
						Console.Clear();
						Menu();
					}
				} else if (key.Key == ConsoleKey.DownArrow) {
					if (posx < options.Length - 1) {
						posx++;
						Console.Clear();
						Menu();
					}
				} else if (key.Key == ConsoleKey.Enter) {
					Console.Clear();
					MenuSwitch();
				} else if (key.Key == ConsoleKey.Escape) {
					Console.Clear();
					Console.WriteLine("Exiting...");
					Environment.Exit(0);
				} else if (key.Key >= ConsoleKey.D1 && key.Key <= ConsoleKey.D6) {
					posx = (byte)(key.Key - ConsoleKey.D1);
					Console.Clear();
					MenuSwitch();
					
				}
			}
		}

		private void MenuSwitch() {
			switch (posx) {
				case 1:
					//PlayMusic();
					break;
				case 2:
					//PauseMusic();
					break;
				case 3:
					//StopMusic();
					break;
				case 4:
					//NextSong();
					break;
				case 5:
					//PreviousSong();
					break;
				case 6:
					//Exit();
					break;
			}
		}

		private void Menu()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Use the arrows to select an option!");
			Console.ResetColor();

			for (int i = 0; i < options.Count(); i++)
			{
				if (i == posx)
				{
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine($"{colors[0] + options[i] + colors[1]}", String.Join((i+1).ToString(), [UNDERLINE[0], UNDERLINE[1]+colors[0]]));
				} else
				{
					Console.WriteLine(options[i], String.Join((i+1).ToString(), UNDERLINE));
				}

			}
		}
	}
}
