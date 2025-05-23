﻿using HttpRequest;
using MusicControl;
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
		private List<List<string>> Info = new List<List<string>>();
		private string[] options = { "[{0}] Play Music", "[{0}] Pause Music", "[{0}] Stop Music", "[{0}] Next Song", "[{0}] Previous Song", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit", "[{0}] Exit" };
		private List<string> artists;
		private List<string> albums;
		private List<string> songs;
		private int consoleHeight = Console.WindowHeight;
		//private byte posx = 0;
		private byte posy = 0;

		public Display() {
			Controls.BaseURL = "D:\\Music\\Linkin Park- Hybrid Theory [FLAC]\\";
											 //try {
			Info.Add([ "Linkin Park", "NEFFEX", "Three Days Grace"]);//Getter.GetArtists().Result.Select(x => x.Name).ToList());
			Info.Add(["From Zero", "Allienation", "Brawl", "One-X"]);//Getter.GetAlbums().Result.Select(x => x.Title).ToList());
			Info.Add(["Apologies", "Brawl", "The Emptiness Machine", "Mayday", "Up From The Bottom", "03 With You.flac"]);// Getter.GetSongs().Result.Select(x => x.Title).ToList());
			artists = Info[0].Take(consoleHeight-11).ToList();
			albums = Info[1].Take(consoleHeight-11).ToList();
			songs = Info[2].Take(consoleHeight-11).ToList();
			MenuFunc();
			//} catch (ArgumentException e) {
			//	foreach (var item in e.Data) {
			//		Console.WriteLine(item);
			//	}
			//	//Console.WriteLine(e.Data.ToString());
			//	Console.WriteLine("Error: " + e.Message);
			//}
		}

		private void MenuFunc()
		{
			Console.CursorVisible = false;
			TableDrawer tableDrawer = new TableDrawer(artists, albums, songs);

			while (true) {

				ConsoleKeyInfo key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.UpArrow) {
					if (TableDrawer.posx == 1) artists = Info[0].Skip(this.posy - (consoleHeight - 12)).Take(consoleHeight - 11).ToList();
					else if (TableDrawer.posx == 2) albums = Info[1].Skip(this.posy - (consoleHeight - 12)).Take(consoleHeight - 11).ToList();
					else if (TableDrawer.posx == 3) songs = Info[2].Skip(this.posy - (consoleHeight - 12)).Take(consoleHeight - 11).ToList();
					if (this.posy > 0) {
						this.posy--;
						if (this.posy < (consoleHeight - 12)) TableDrawer.posy = this.posy;
						else if (this.posy > (consoleHeight - 13) && this.posy != Info[TableDrawer.posx - 1].Count - 1) TableDrawer.posy = (consoleHeight - 13);
						else TableDrawer.posy = (consoleHeight - 12);
						Console.Clear();
						tableDrawer = new TableDrawer(artists, albums, songs);
					}
				} else
				if (key.Key == ConsoleKey.DownArrow) {
					if (TableDrawer.posx == 1 && this.posy + 3 <= Info[0].Count) artists = Info[0].Skip(this.posy - 17).Take(consoleHeight - 11).ToList();
					else if (TableDrawer.posx == 2 && this.posy + 3 <= Info[1].Count) albums = Info[1].Skip(this.posy - 17).Take(consoleHeight - 11).ToList();
					else if (TableDrawer.posx == 3 && this.posy + 3 <= Info[2].Count) songs = Info[2].Skip(this.posy - 17).Take(consoleHeight - 11).ToList();
					if (this.posy < Info[TableDrawer.posx - 1].Count - 1) {
						this.posy++;
						if (this.posy < (consoleHeight - 12)) TableDrawer.posy = this.posy;
						else if (this.posy > (consoleHeight - 13) && this.posy != Info[TableDrawer.posx - 1].Count - 1) TableDrawer.posy = (consoleHeight - 13);
						else TableDrawer.posy = (consoleHeight - 12);
						Console.Clear();
						tableDrawer = new TableDrawer(artists, albums, songs);
					}
				} else
				if (key.Key == ConsoleKey.Backspace) {
					if (TableDrawer.posx > 1) {
						TableDrawer.posx--;
						if (TableDrawer.posx == 1) {
							if (TableDrawer.posy > Info[0].Count - 1) TableDrawer.posy = Info[0].Count - 1;
							if (this.posy < Info[0].Count - 1) artists = Info[0].Skip(this.posy - (consoleHeight - 13)).Take(consoleHeight - 11).ToList();
							else artists = Info[0].Skip(this.posy - (consoleHeight - 12)).Take(consoleHeight - 11).ToList();
						} else
						if (TableDrawer.posx == 2) {
							if (TableDrawer.posy > Info[1].Count - 1) TableDrawer.posy = Info[1].Count - 1;
							if (this.posy < Info[1].Count - 1) albums = Info[1].Skip(this.posy - (consoleHeight - 13)).Take(consoleHeight - 11).ToList();
							else albums = Info[1].Skip(this.posy - (consoleHeight - 12)).Take(consoleHeight - 11).ToList();
						} else
						if (TableDrawer.posx == 3) {
							if (TableDrawer.posy > Info[2].Count - 1) TableDrawer.posy = Info[2].Count - 1;
							if (this.posy < Info[2].Count - 1) songs = Info[2].Skip(this.posy - (consoleHeight - 13)).Take(consoleHeight - 11).ToList();
							else songs = Info[2].Skip(this.posy - (consoleHeight - 12)).Take(consoleHeight - 11).ToList();
						}
						Console.Clear();
						tableDrawer = new TableDrawer(artists, albums, songs);
					}
				} else
				if (key.Key == ConsoleKey.Enter && key.Modifiers != ConsoleModifiers.Shift) {
					if (TableDrawer.posx < 3) {
						TableDrawer.posx = 3;
						//if (TableDrawer.posx == 1) {
						//	if (TableDrawer.posy > Info[0].Count - 1) TableDrawer.posy = Info[0].Count - 1;
						//	if (this.posy < Info[0].Count - 1) artists = Info[0].Skip(this.posy - (consoleHeight-13)).Take(consoleHeight-11).ToList();
						//	else artists = Info[0].Skip(this.posy - (consoleHeight-12)).Take(consoleHeight-11).ToList();
						//} else
						//if (TableDrawer.posx == 2) {
						//	if (TableDrawer.posy > Info[1].Count - 1) TableDrawer.posy = Info[1].Count - 1;
						//	if (this.posy < Info[1].Count - 1) albums = Info[1].Skip(this.posy - (consoleHeight-13)).Take(consoleHeight-11).ToList();
						//	else albums = Info[1].Skip(this.posy - (consoleHeight-12)).Take(consoleHeight-11).ToList();
						//} else
						if (TableDrawer.posx == 3) {
							if (TableDrawer.posy > Info[2].Count - 1) TableDrawer.posy = Info[2].Count - 1;
							if (this.posy < Info[2].Count - 1) songs = Info[2].Skip(this.posy - (consoleHeight - 13)).Take(consoleHeight - 11).ToList();
							else songs = Info[2].Skip(this.posy - (consoleHeight - 12)).Take(consoleHeight - 11).ToList();
						}
						Console.Clear();
						tableDrawer = new TableDrawer(artists, albums, songs);
					} else
					if (TableDrawer.posx == 3) {
						Controls.PlaySong(Info[2][TableDrawer.posy]);
					}
				} else
				if (key.Key == ConsoleKey.Enter && key.Modifiers == ConsoleModifiers.Shift) {
					if (TableDrawer.posx < 3) {
						if (Controls.GetPlaybackState.ToString() == "Playing") Controls.QueueSong(Info[2][0]);
						else Controls.PlaySong(Info[2][0]);
					} else {
						if (Controls.GetPlaybackState.ToString() == "Playing") Controls.QueueSong(Info[2][TableDrawer.posy]);
						else Controls.PlaySong(Info[2][TableDrawer.posy]);
					}
				} else
				if (key.Key == ConsoleKey.Spacebar) {
					if (Controls.GetPlaybackState.ToString() == "Playing") Controls.PauseSong();
					else Controls.ResumeSong();
				} else
				if (key.Key == ConsoleKey.LeftArrow) {
					Controls.SeekBackward(5);
				} else
				if (key.Key == ConsoleKey.RightArrow) {
					Controls.SeekForward(5);
				} else
				if (key.Key == ConsoleKey.Tab && key.Modifiers != ConsoleModifiers.Shift) {
					Controls.NextSong();
				} else
				if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.Tab) {
					Controls.PreviousSong();
				} else
				if (key.Key == ConsoleKey.Escape) {
					Console.Clear();
					Console.WriteLine("Exiting...");
					Environment.Exit(0);
				} //else
				//if (key.Key >= ConsoleKey.D1 && key.Key <= ConsoleKey.D6) {
				//	TableDrawer.posx = (byte)(key.Key - ConsoleKey.D1);
				//	Console.Clear();
				//	MenuSwitch();

				//}
			}
		}

		//private void MenuSwitch() {
		//	switch (TableDrawer.posx) {
		//		case 1:
		//			//PlayMusic();
		//			break;
		//		case 2:
		//			//PauseMusic();
		//			break;
		//		case 3:
		//			//StopMusic();
		//			break;
		//		case 4:
		//			//NextSong();
		//			break;
		//		case 5:
		//			//PreviousSong();
		//			break;
		//		case 6:
		//			//Exit();
		//			break;
		//	}
		//}

		//private void Menu()
		//{
		//	Console.ForegroundColor = ConsoleColor.Green;
		//	Console.WriteLine("Use the arrows to select an option!");
		//	Console.ResetColor();

		//	for (int i = 0; i < Info[TableDrawer.posx-1].Count(); i++)
		//	{
		//		if (i == TableDrawer.posx)
		//		{
		//			Console.ForegroundColor = ConsoleColor.Cyan;
		//			Console.WriteLine($"{colors[0] + Info[i] + colors[1]}", String.Join((i+1).ToString(), [UNDERLINE[0], UNDERLINE[1]+colors[0]]));
		//		} else
		//		{
		//			Console.WriteLine(Info[i], String.Join((i+1).ToString(), UNDERLINE));
		//		}

		//	}
		//}
	}
}
