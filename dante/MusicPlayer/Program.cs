using MusicPlayer.CLIDisplay;
using MusicControl;
using NAudio.Wave;
using HttpRequest;
using Data;
using System.Xml.Schema;

namespace MusicPlayer
{
    internal class Program
    {
        static async Task Main(string[] args) {
            //Примерен код

            // Display display = new Display();

            //Controls.PlaySong("06 Runaway.flac");
            //while (true) {
            //	var key = Console.ReadKey(true);
            //	if (key.Key == ConsoleKey.LeftArrow) {
            //		Controls.SeekBackward(5);
            //	} else if (key.Key == ConsoleKey.RightArrow) {
            //		Controls.SeekForward(5);
            //	} else if (key.Key == ConsoleKey.UpArrow) {
            //		Controls.VolumeUp(0.01f);
            //	} else if (key.Key == ConsoleKey.DownArrow) {
            //		Controls.VolumeDown(0.01f);
            //	} else if (key.Key == ConsoleKey.Spacebar && Controls.GetPlaybackState()==PlaybackState.Playing) {
            //		Controls.PauseSong();
            //	} else if (key.Key == ConsoleKey.Spacebar && Controls.GetPlaybackState() == PlaybackState.Paused) {
            //		Controls.ResumeSong();
            //	}
            //}
            // https://dante.kartof.tk/
            //List<Artist> artists = await Getter.GetArtists();
            //Console.WriteLine(artists.First().Name);
            //List<Song> songs = await Getter.GetSongs();
            //Console.WriteLine(songs.First().Title);
            List<Album> albums = await Getter.GetAlbums();
            Console.WriteLine(albums.First().Title);
        }
    }
}
