using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.CLIDisplay
{
	internal class TableDrawer
	{
		public static int posx = 1;
		public static int posy = 0;

		private int consoleWidth = Console.WindowWidth;
		private int artistsWidth = Console.WindowWidth/7*2;
		private int songsWidth = Console.WindowWidth / 7*3;
		private int albumsWidth = Console.WindowWidth / 7*2;
		private string artistColor = "\u001b[31m";
		private string albumColor = "\u001b[36m";
		private string songColor = "\u001b[33m";
		public TableDrawer(List<string> artists, List<string> albums, List<string> songs) {
			string welcome = " WELCOME TO DANTE ";
			int n = (new List<int>{artists.Count, albums.Count, songs.Count}).Max();

			Console.WriteLine("\u001b[32m" + new string('=', (consoleWidth - welcome.Length) / 2-1) + welcome + new string('=', (consoleWidth - welcome.Length) / 2-1)+"\n");
			Console.Write(artistColor + "|" + new string('-', (artistsWidth-9)/2-1)+" Artists " + new string('-', (artistsWidth - 9) / 2-1)+"|");
			Console.Write(albumColor + "|" + new string('-', (albumsWidth - 8) / 2 - 1) + " Albums " + new string('-', (albumsWidth - 8) / 2 - 1) + "|");
			Console.Write(songColor + "|" + new string('-', (songsWidth - 7) / 2 - 1) + " Songs " + new string('-', (songsWidth - 7) / 2 - 1) + "|\n");
			for (int i = 0; i<n; i++) {
				Console.Write(artistColor + "|");
				if (i < artists.Count) {
					if (posx == 1 && (posy == i || posy > artists.Count)) {
						if (posy > artists.Count) posy = artists.Count;
						Console.Write(artistColor + "\u001b[47m" + artists[i] + "\u001b[0m" + artistColor);
					} else Console.Write(artistColor + artists[i]);
					Console.Write(new string(' ', artistsWidth - artists[i].Length - 3) + "|");
				} else Console.Write(new string(' ', artistsWidth - 3)+"|");
				Console.Write(albumColor+"|");
				if (i < albums.Count) {
					if (posx == 2 && (posy == i || posy > albums.Count)) {
						if (posy > albums.Count) posy = albums.Count;
						Console.Write(albumColor + "\u001b[47m" + albums[i] + "\u001b[0m" + albumColor);
					} else Console.Write(albumColor + albums[i]);
					Console.Write(new string(' ', albumsWidth - albums[i].Length - 2)+"|");
				} else Console.Write(new string(' ', albumsWidth - 2)+"|");
				Console.Write(songColor + "|");
				if (i < songs.Count) {
					if (posx == 3 && (posy == i || posy > songs.Count)) {
						if (posy > songs.Count) posy = songs.Count;
						Console.Write(songColor + "\u001b[47m" + songs[i] + "\u001b[0m" + songColor);
					} else Console.Write(songColor + songs[i]);
					Console.Write(new string(' ', songsWidth - songs[i].Length - 2));
				} else Console.Write(new string(' ', songsWidth - 2));
				Console.Write("|\n");
			}
			Console.Write(artistColor + "|" + new string('-', artistsWidth - 3) + "|"+albumColor+"|" + new string('-', albumsWidth - 2) + "|"+songColor+"|" + new string('-', songsWidth - 2) + "|");
			//Console.WriteLine("WELCOME TO DANTE");
		}
	}
}
