
using System.Text.Json;
using Data;
using NAudio.Wave;

namespace HttpRequest
{
    public class Getter
    {
        static JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        public async static Task<List<Artist>> GetArtists()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://dante.kartof.tk/getArtists");
            response.EnsureSuccessStatusCode();

            var streamContent = await response.Content.ReadAsStreamAsync();

            List<Artist>? artists = JsonSerializer.Deserialize<List<Artist>>(streamContent, options);

            return artists;
        }
        public async static Task<List<Song>> GetSongs()
        {
            HttpClient client = new HttpClient();
      
            HttpResponseMessage response = await client.GetAsync("https://dante.kartof.tk/getSongs");
            response.EnsureSuccessStatusCode();

            var streamContent = await response.Content.ReadAsStreamAsync();

            List<Song>? songs = JsonSerializer.Deserialize<List<Song>>(streamContent, options);

            return songs;
        }
        public async static Task<List<Album>> GetAlbums()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://dante.kartof.tk/getAlbums");
            response.EnsureSuccessStatusCode();

            var streamContent = await response.Content.ReadAsStreamAsync();

            List<Album>? albums = JsonSerializer.Deserialize<List<Album>>(streamContent, options);

            return albums;
        }
        public async static Task<MemoryStream> LoadImage(long id)
        {
            HttpClient client = new HttpClient();

            var data = await client.GetByteArrayAsync($"https://dante.kartof.tk/image/song/{id}");
            var ms = new MemoryStream(data);

            return ms;

        }
        public async static Task<Mp3FileReader> GetSong(long id)
        {
            HttpClient client = new HttpClient();

            var stream = await client.GetStreamAsync($"https://dante.kartof.tk/song/{id}");
			var ms = new MemoryStream();

            stream.CopyTo(ms);
            ms.Position = 0;

            var mp3FileReader = new Mp3FileReader(ms);
            return mp3FileReader;
        }
    }
}
