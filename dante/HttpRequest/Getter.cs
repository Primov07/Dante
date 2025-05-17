using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Data;

namespace HttpRequest
{
    class Getter
    {
        public async static Task<List<Artist>> GetArtists(string artistsUrl)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(artistsUrl);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Artist>? artists = JsonSerializer.Deserialize<List<Artist>>(json);

            return artists;
        }
        public async static Task<List<Song>> GetSongs(string songsUrl)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(songsUrl);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Song>? songs = JsonSerializer.Deserialize<List<Song>>(json);

            return songs;
        }
        public async static Task<List<Album>> GetAlbums(string albumsUrl)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(albumsUrl);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            List<Album>? albums = JsonSerializer.Deserialize<List<Album>>(json);

            return albums;
        }
        public async static Task<Song> GetSongById(string songsUrl, int id)
        {
            List<Song> songs = await GetSongs(songsUrl);
            return songs.FirstOrDefault(s => s.ID == id);
        }
    }
}
