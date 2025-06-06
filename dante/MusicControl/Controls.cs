using NAudio.Wave;
using HttpRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace MusicControl
{
	public static class Controls
	{
		public static long SongID { get; private set; }
		public static PlaybackState GetPlaybackState { get { return output.PlaybackState; } }
		public static float GetVolume { get { return output.Volume; } }
		public static TimeSpan GetCurrentTime { get { return audioFile.CurrentTime; } }
		public static TimeSpan GetTotalTime { get { return audioFile.TotalTime; } }

		private static Thread songThread;
		private static bool ManualStop = false;
		private static List<long> NextQueue = new List<long>();
		private static List<long> PrevQueue = new List<long>();
		private static Mp3FileReader audioFile;
		private static WaveOutEvent output = new WaveOutEvent();

		static public void PlaySong(long SongId) {
			output.Stop();
			ManualStop = false;

			SongID = SongId;
			audioFile = Getter.GetSong(SongId).Result;
			output.Init(audioFile);
			output.Play();
			Thread.Sleep(1000);
			songThread = new Thread(() => {
				while (output.PlaybackState != PlaybackState.Stopped) { }
				if (!ManualStop) NextSong();
			});
			songThread.Start();
		}

		static public void PauseSong() {
			if (output.PlaybackState == PlaybackState.Playing) output.Pause();
		}

		static public void StopSong() {
			if (output.PlaybackState == PlaybackState.Playing || output.PlaybackState == PlaybackState.Paused) {
				ManualStop = true;
				PrevQueue.Add(SongID);
				output.Stop();
			}
		}

		static public void QueueSong(long SongId) {
			if (output.PlaybackState == PlaybackState.Stopped || output.PlaybackState == PlaybackState.Paused) PlaySong(SongId);
			else NextQueue.Add(SongId);
		}

		static public void NextSong() {
			if (SongID != 0L) PrevQueue.Add(SongID);
			if (NextQueue.Count > 0) {
				long nextSong = NextQueue[0];
				NextQueue.RemoveAt(0);
				StopSong();
				PlaySong(nextSong);
			}
		}

		static public void PreviousSong() {
			if (PrevQueue.Count > 0) {
				if (SongID != 0L) NextQueue.Insert(0, SongID);
				long prevSong = PrevQueue[PrevQueue.Count - 1];
				PrevQueue.RemoveAt(PrevQueue.Count - 1);
				StopSong();
				PlaySong(prevSong);
			}
		}

		static public void ResumeSong() {
			if (output.PlaybackState == PlaybackState.Paused) output.Play();
		}

		static public void VolumeUp(float amount) {
			if (output.Volume < 1.0f) output.Volume += amount;
		}

		static public void VolumeDown(float amount) {
			if (output.Volume > 0.0f) output.Volume -= amount;
		}

		static public void SeekBackward(double durationInSeconds) {
			audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.CurrentTime.TotalSeconds - durationInSeconds);
		}

		static public void SeekForward(double durationInSeconds) {
			audioFile.CurrentTime = TimeSpan.FromSeconds(audioFile.CurrentTime.TotalSeconds + durationInSeconds);
		}
	}
}