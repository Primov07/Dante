using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MusicControl;

namespace MusicPlayer.CLIDisplay
{
	internal class ProgressBar
	{
		private int posx;

		public ProgressBar(string song, string artist) {
			posx = 0;
			Console.SetCursorPosition((Console.WindowWidth-(song.Length+artist.Length+3))/2, Console.WindowTop+25);
			Console.WriteLine($"{song} - {artist}");
			Console.Write($"{Convert.ToDateTime(new TimeSpan(0, 3, 5).ToString()):m:ss}"+" ├"+new string('─', Console.WindowWidth-15)+ "┤ "+ $"{Convert.ToDateTime(new TimeSpan(0, 3, 5).ToString()):m:ss}");
		}
	}
}
