
using MusicControl;
using NAudio.Wave;

namespace MusicPlayer
{
    internal class Program
    {
        static void Main(string[] args) {
			//Примерен код

			Controls.PlaySong("06 Runaway.flac");
			while (true) {
				var key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.LeftArrow) {
					Controls.SeekBackward(5);
				} else if (key.Key == ConsoleKey.RightArrow) {
					Controls.SeekForward(5);
				} else if (key.Key == ConsoleKey.UpArrow) {
					Controls.VolumeUp(0.01f);
				} else if (key.Key == ConsoleKey.DownArrow) {
					Controls.VolumeDown(0.01f);
				} else if (key.Key == ConsoleKey.Spacebar && Controls.GetPlaybackState()==PlaybackState.Playing) {
					Controls.PauseSong();
				} else if (key.Key == ConsoleKey.Spacebar && Controls.GetPlaybackState() == PlaybackState.Paused) {
					Controls.ResumeSong();
				}
			}

			Console.ReadKey();
        }
    }
}
