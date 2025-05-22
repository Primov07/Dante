using System;
using NAudio.Wave;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace MusicControl
{
	public static class Controls
	{
		public static string BaseURL = "/Song/";//Примерен път "D:\\Music\\Linkin Park- Hybrid Theory [FLAC]\\";
		private static string SongURL;
		private static Thread songThread;
		private static bool ManualStop = false;
		private static List<string> NextQueue = new List<string>();
		private static List<string> PrevQueue = new List<string>();
		private static AudioFileReader audioFile;
		private static WaveOutEvent output = new WaveOutEvent();
		public static PlaybackState GetPlaybackState { get { return output.PlaybackState; } }
		public static float GetVolume { get { return output.Volume; } }
		public static TimeSpan GetCurrentTime { get { return audioFile.CurrentTime; } }
		public static TimeSpan GetTotalTime { get { return audioFile.TotalTime; } }

		static public void PlaySong(string SongID) {
			/// Пуска дадената песен, ако друга песен е пусната я спира и пуска новата
			ManualStop = false;
			if (output.PlaybackState == PlaybackState.Playing) {
				output.Stop();
			}
			
			SongURL = BaseURL + SongID;
			audioFile = new AudioFileReader(SongURL);
			output.Init(audioFile);
			output.Play();

			songThread = new Thread(() => {
				while (output.PlaybackState != PlaybackState.Stopped)
				{
					//Console.WriteLine(output.PlaybackState);
					//Console.WriteLine(TimeSpan.FromSeconds(audioFile.CurrentTime.TotalSeconds));
					//Console.WriteLine(output.Volume);
					Thread.Sleep(1500);
				}
				if (!ManualStop) NextSong();
			});
			songThread.Start();
		}

		static public void PauseSong() {
			/// Пауза на песента
			if (output.PlaybackState == PlaybackState.Playing) {
				output.Pause();
			}
		}

		static public void StopSong() {
			/// Спира песента
			if (output.PlaybackState == PlaybackState.Playing) {
				//songThread.Abort();
				//songThread.Suspend();
				ManualStop = true;
				PrevQueue.Add(SongURL.Replace(BaseURL, ""));
				output.Stop();
			}
		}

		static public void QueueSong(string SongID) {
			/// Добавя песен в опашката
			if (output.PlaybackState == PlaybackState.Stopped || output.PlaybackState == PlaybackState.Paused) {
				PlaySong(SongID);
			} else {
				NextQueue.Add(SongID);
			}
		}

		static public void NextSong() {
			/// Пуска следващата песен от опашката
			PrevQueue.Add(SongURL.Replace(BaseURL, ""));
			if (NextQueue.Count > 0) {
				string nextSong = NextQueue[0];
				NextQueue.RemoveAt(0);
				PlaySong(nextSong);
			} else {
				Console.WriteLine("No more songs in the queue.");
			}
		}

		static public void PreviousSong() {
			/// Пуска предишната песен от опашката
			if (PrevQueue.Count > 0) {
				NextQueue.Insert(0, SongURL.Replace(BaseURL, ""));
				string prevSong = PrevQueue[PrevQueue.Count - 1];
				PrevQueue.RemoveAt(PrevQueue.Count - 1);
				PlaySong(prevSong);
			} else {
				Console.WriteLine("No previous song in the queue.");
			}
		}

		static public void ResumeSong() {
			/// Възобновява песента
			if (output.PlaybackState == PlaybackState.Paused) {
				output.Play();
			}
		}

		static public void VolumeUp(float amount) {
			/// Увеличава звука, amount е между 0.0 и 1.0
			if (output.Volume < 1.0f) {
				output.Volume += amount;
			}
		}

		static public void VolumeDown(float amount) {
			/// Намалява звука, amount е между 0.0 и 1.0
			if (output.Volume > 0.0f) {
				output.Volume -= amount;
			}
		}

		static public void SeekBackward(double durationInSeconds) {
			/// Превърта назад песента с определено време
			audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.CurrentTime.TotalSeconds - durationInSeconds);
		}

		static public void SeekForward(double durationInSeconds) {
			/// Превърта напред песента с определено време
			audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.CurrentTime.TotalSeconds + durationInSeconds);
		}
	}
}