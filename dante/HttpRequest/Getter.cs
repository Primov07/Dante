using System.Text.Json;
using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Data;
using System.Net.Http.Headers;
using System.Net;
using System.Security.Authentication;
using static System.Net.WebRequestMethods;

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
            HttpClient client = new HttpClient(handler);
            HttpResponseMessage response = await client.GetAsync("https://dante.kartof.tk/getArtists");
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Artist>? artists = JsonSerializer.Deserialize<List<Artist>>(json);

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

            string json = await response.Content.ReadAsStringAsync();
            List<Album>? albums = JsonSerializer.Deserialize<List<Album>>(json);

            return albums;
        }
    }
}
