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

namespace HttpRequest
{
    public class Getter
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
        public async static Task GetSongs()
        {
            var handler = new SocketsHttpHandler
            {
                SslOptions = new SslClientAuthenticationOptions
                {
                    EnabledSslProtocols = SslProtocols.Tls12,
                    RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
                }
            };

            HttpClient client = new HttpClient(handler);
      
            HttpResponseMessage response = await client.GetAsync("https://dante.kartof.tk");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

        }
        private static bool CustomCertificateValidation(HttpRequestMessage request, X509Certificate2 cert, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // Rebuild the chain but skip revocation checks
            var customChain = new X509Chain();
            customChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            customChain.ChainPolicy.VerificationFlags =
                X509VerificationFlags.IgnoreEndRevocationUnknown |
                X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown;

            bool isValid = customChain.Build(cert);

            // Print out any issues found
            if (!isValid)
            {
                Console.WriteLine("SSL certificate validation errors:");
                foreach (var status in customChain.ChainStatus)
                {
                    Console.WriteLine($"- {status.Status}: {status.StatusInformation}");
                }
            }

            // Accept only if the chain is otherwise valid, or errors are revocation-related
            foreach (var status in customChain.ChainStatus)
            {
                if (status.Status != X509ChainStatusFlags.RevocationStatusUnknown &&
                    status.Status != X509ChainStatusFlags.OfflineRevocation)

                {
                    return false;
                }
            }

            return true;
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
        public async static Task GetSongById(string songsUrl, int id)
        {
            // List<Song> songs = await GetSongs();
            // return songs.FirstOrDefault(s => s.Id == id);
        }
    }
}
