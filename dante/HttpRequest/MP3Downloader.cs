
namespace HttpRequest
{
    public class MP3Downloader
    {
        public async static void DownloadSong(string songUrl, string destination)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(songUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            Stream contentStream = response.Content.ReadAsStream();
            Stream fileStream = new FileStream(destination, FileMode.Create, FileAccess.Write);
            contentStream.CopyTo(fileStream);

            Console.WriteLine($"MP3 file downloaded to: {destination}");
        }
    }
}
