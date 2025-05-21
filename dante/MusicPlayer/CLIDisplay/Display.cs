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
		private string[] options = { "[{0}] Play Music", "[{0}] Pause Music", "[{0}] Stop Music", "[{0}] Next Song", "[{0}] Previous Song", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit" };
		private List<string> artists;
		private List<string> albums;
		private List<string> songs;
		//private byte posx = 0;
		private byte posy = 0;

		public Display()
		{	
			artists = options.Take(20).ToList();
			albums = options.Take(20).ToList();
			songs = options.Take(20).ToList();
			MenuFunc();
		}

		private void MenuFunc()
		{
			Console.CursorVisible = false;
			TableDrawer tableDrawer = new TableDrawer(artists, albums, songs);
//			Console.ForegroundColor = ConsoleColor.Green;
//			Console.WriteLine(@"==============================

//      WELCOME TO DANTE

//==============================
//");
//			Menu();
			while (true) {
				//if (TableDrawer.posx == 1 && (TableDrawer.posy > 19 || 20-TableDrawer.posy>=19)) {
				//	artists = options.Skip(TableDrawer.posy-20).Take(20).ToList();
				//}
				//if (TableDrawer.posx == 2 && TableDrawer.posy > 19) {
				//	albums = options.Skip(TableDrawer.posy - 19).Take(20).ToList();
				//}
				//if (TableDrawer.posx == 3 && TableDrawer.posy > 19) {
				//	songs = options.Skip(TableDrawer.posy - 19).Take(20).ToList();
				//}

				ConsoleKeyInfo key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.UpArrow) {
					if (TableDrawer.posx == 1) artists = options.Skip(this.posy - 19).Take(20).ToList();
					else if (TableDrawer.posx == 2) albums = options.Skip(this.posy - 19).Take(20).ToList();
					else if (TableDrawer.posx == 3) songs = options.Skip(this.posy - 19).Take(20).ToList();
					if (this.posy > 0) {
						this.posy--;
						if (this.posy < 19) TableDrawer.posy = this.posy;
						else if (this.posy > 18 && this.posy != options.Length - 1) TableDrawer.posy = 18;
						else TableDrawer.posy = 19;
						Console.Clear();
						tableDrawer = new TableDrawer(artists, albums, songs);
					}
				} else if (key.Key == ConsoleKey.DownArrow) {
					if (TableDrawer.posx == 1 && this.posy + 3 <= options.Length) artists = options.Skip(this.posy - 17).Take(20).ToList();
					else if (TableDrawer.posx == 2 && this.posy + 3 <= options.Length) albums = options.Skip(this.posy - 17).Take(20).ToList();
					else if (TableDrawer.posx == 3 && this.posy + 3 <= options.Length) songs = options.Skip(this.posy - 17).Take(20).ToList();
					if (this.posy < options.Length - 1) {
						this.posy++;
						if (this.posy < 19) TableDrawer.posy=this.posy;
						else if (this.posy > 18 && this.posy != options.Length-1) TableDrawer.posy = 18;
						else TableDrawer.posy = 19;
						Console.Clear();
						tableDrawer = new TableDrawer(artists, albums, songs);
					}
				}else if (key.Key == ConsoleKey.LeftArrow) {
					if (TableDrawer.posx > 1) {
						TableDrawer.posx--;
						if (TableDrawer.posx == 1) {
							if (this.posy < options.Length - 1) artists = options.Skip(this.posy - 18).Take(20).ToList();
							else artists = options.Skip(this.posy - 19).Take(20).ToList();
						} else
						if (TableDrawer.posx == 2) {
							if (this.posy < options.Length - 1) albums = options.Skip(this.posy - 18).Take(20).ToList();
							else albums = options.Skip(this.posy - 19).Take(20).ToList();
						} else
						if (TableDrawer.posx == 3) {
							if (this.posy < options.Length - 1) songs = options.Skip(this.posy - 18).Take(20).ToList();
							else songs = options.Skip(this.posy - 19).Take(20).ToList();
						}
						//if (this.posy < 19) TableDrawer.posy = this.posy;
						//else if (this.posy > 18 && this.posy != options.Length - 1) TableDrawer.posy = 18;
						//else TableDrawer.posy = 19;
						Console.Clear();
						tableDrawer = new TableDrawer(artists, albums, songs);
					}
				} else if (key.Key == ConsoleKey.RightArrow) {
					if (TableDrawer.posx < 3) {
						TableDrawer.posx++;
						if (TableDrawer.posx == 1) {
							if (this.posy < options.Length - 1) artists = options.Skip(this.posy - 18).Take(20).ToList();
							else artists = options.Skip(this.posy - 19).Take(20).ToList();
						} else
						if (TableDrawer.posx == 2) {
							if (this.posy < options.Length - 1) albums = options.Skip(this.posy - 18).Take(20).ToList();
							else albums = options.Skip(this.posy - 19).Take(20).ToList();
						} else
						if (TableDrawer.posx == 3) {
							if (this.posy < options.Length - 1) songs = options.Skip(this.posy - 18).Take(20).ToList();
							else songs = options.Skip(this.posy - 19).Take(20).ToList();
						}
						//if (this.posy < 19) TableDrawer.posy = this.posy;
						//else if (this.posy > 18 && this.posy != options.Length - 1) TableDrawer.posy = 18;
						//if (this.posy == options.Length-1) ;
						Console.Clear();
						tableDrawer = new TableDrawer(artists, albums, songs);
					}
				} else if (key.Key == ConsoleKey.Enter) {
					Console.Clear();
					MenuSwitch();
				} else if (key.Key == ConsoleKey.Escape) {
					Console.Clear();
					Console.WriteLine("Exiting...");
					Environment.Exit(0);
				} else if (key.Key >= ConsoleKey.D1 && key.Key <= ConsoleKey.D6) {
					TableDrawer.posx = (byte)(key.Key - ConsoleKey.D1);
					Console.Clear();
					MenuSwitch();
					
				}
			}
		}

		private void MenuSwitch() {
			switch (TableDrawer.posx) {
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
				if (i == TableDrawer.posx)
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
