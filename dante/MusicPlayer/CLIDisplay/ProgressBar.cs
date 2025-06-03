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
		private static int barLenght = Console.WindowWidth - 15;
		private static int posx;
		private static double secLenght;

		public ProgressBar() {
			string song = Display.songsData.First(x => x.Id == Controls.SongID).Title;
			string artist = Display.artistsData.First(x => x.Songs.Contains(Controls.SongID)).Name;
			Console.SetCursorPosition((Console.WindowWidth - (song.Length + artist.Length + 3)) / 2, Console.WindowTop + 25);
			Console.WriteLine($"{song} - {artist}");
			secLenght = Convert.ToDouble(barLenght) / Controls.GetTotalTime.TotalSeconds;
			posx = Convert.ToInt32(secLenght * Controls.GetCurrentTime.TotalSeconds);
			Console.Write($" {Convert.ToDateTime(Controls.GetCurrentTime.ToString()):m:ss}" + " \u001b[32m├" + new string('─', posx) + "\u001b[0m" + new string('─', Convert.ToInt32(secLenght * (Controls.GetTotalTime.TotalSeconds - Controls.GetCurrentTime.TotalSeconds))) + "┤ " + $"{Convert.ToDateTime(Controls.GetTotalTime.ToString()):m:ss}");
			//Tick();
		}

		internal static void Tick() {
			Thread thread = new Thread(() => {
				Thread.Sleep(2000);
				while (Controls.GetPlaybackState == NAudio.Wave.PlaybackState.Playing || Controls.GetPlaybackState == NAudio.Wave.PlaybackState.Paused) {
					Console.SetCursorPosition(barLenght-5, Console.WindowTop + 26);
					Console.Write(new string('\b', barLenght-5) + $" {Convert.ToDateTime(Controls.GetCurrentTime.ToString()):m:ss}" + " \u001b[32m├" + new string('─', posx) + "\u001b[0m" + new string('─', Convert.ToInt32(secLenght * (Controls.GetTotalTime.TotalSeconds - Controls.GetCurrentTime.TotalSeconds))) + "┤ ");
					Thread.Sleep(500);
					posx = Convert.ToInt32(secLenght * Controls.GetCurrentTime.TotalSeconds);
				}
			});
			thread.Start();
		}
	}
}
