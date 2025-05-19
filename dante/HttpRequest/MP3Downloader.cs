
namespace HttpRequest
{
    public class MP3Downloader
    {
        public async static void DownloadSong(int id, string destination)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://dante.kartof.tk/song/{id}", HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            Stream contentStream = await response.Content.ReadAsStreamAsync();
            Stream fileStream = new FileStream(destination, FileMode.Create, FileAccess.Write);
            contentStream.CopyTo(fileStream);

            Console.WriteLine($"MP3 file downloaded to: {destination}");
        }
    }
}
