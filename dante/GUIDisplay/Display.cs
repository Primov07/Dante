using Data;
using HttpRequest;
using NAudio.Wave;
namespace GUIDisplay
{
    public partial class Display : Form
    {
        private List<Song> allSongs;
        internal List<Album> allAlbums;
        internal List<Artist> allArtists;
        private List<SongViewer> songViewers = new();
        private List<AlbumViewer> albumViewers = new();
        private List<ArtistViewer> artistViewers = new();

        private Mp3FileReader audioFile = null;
        private WaveOutEvent output = null;

        private List<SongViewer> selectedSongs = new();
        private System.Windows.Forms.Timer timer;

        float volume = 1.0f;

        public Display()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (output.PlaybackState == PlaybackState.Playing)
            {
                output.Pause();
                timer.Stop();
                audioFile.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
                lblTime.Text = $"{trackBar1.Value / 60:00}:{trackBar1.Value % 60:00}";
                output.Play();
                timer.Start();
            }
            else if (output.PlaybackState == PlaybackState.Paused)
            {
                audioFile.CurrentTime = TimeSpan.FromSeconds(trackBar1.Value);
                lblTime.Text = $"{trackBar1.Value / 60:00}:{trackBar1.Value % 60:00}";
            }
        }

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            selectedSongs = songViewers.Where(v => v.IsSelected).ToList();
            if (selectedSongs.Count != 0)
            {
                if (output == null)
                {
                    await PlaySong();
                    btnPlay.Text = "Pause";
                    timer.Start();
                }
                else if (output.PlaybackState == PlaybackState.Playing)
                {
                    output.Pause();
                    timer.Stop();
                    btnPlay.Text = "Play";
                }
                else if (output.PlaybackState == PlaybackState.Paused)
                {
                    output.Play();
                    btnPlay.Text = "Pause";
                    timer.Start();
                }
            }
        }
        private async void Display_Load(object sender, EventArgs e)
        {
            await LoadDataSources();
            SetTimer();
           
        }

        private void SetTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += UpdateTrackBar;
        }
        private async void UpdateTrackBar(object sender, EventArgs e)
        {
            if (trackBar1.Value + 1 < trackBar1.Maximum)
            {
                trackBar1.Value++;
                lblTime.Text = $"{trackBar1.Value / 60:00}:{trackBar1.Value % 60:00}";
            }
            else if (trackBar1.Value + 1 == trackBar1.Maximum)
            {
                selectedSongs.RemoveAt(0);
                if (selectedSongs.Count != 0)
                {
                    await PlaySong();
                    trackBar1.Maximum = (int)audioFile.TotalTime.TotalSeconds;
                }
                else
                {
                    audioFile = null;
                    output = null;
                    trackBar1.Value++;
                    btnPlay.Text = "Play";
                    timer.Stop();
                }
            }
        }
        private async Task PlaySong()
        {
            audioFile = await Getter.GetSong(selectedSongs[0].Song.Id);
            output = new WaveOutEvent();
            output.Init(audioFile);
            output.Volume = volume;
            output.Play();
            trackBar1.Value = 0;
            trackBar1.Maximum = (int)audioFile.TotalTime.TotalSeconds;
        }
        private async Task LoadDataSources()
        {
            await GetData();
            LoadData();
            ShowSongsData();
        }
        private async Task GetData()
        {
            allSongs = await Getter.GetSongs();
            allArtists = await Getter.GetArtists();
            allAlbums = await Getter.GetAlbums();
        }
        private void LoadData()
        {
            LoadSongsData();
            LoadArtistsData();
            LoadAlbumsData();
        }
        private void LoadSongsData(long albumId = -1)
        {
            allSongs.ForEach(s => songViewers.Add(new SongViewer(s)));
        }
        private void LoadArtistsData()
        {
            allArtists.ForEach(a => artistViewers.Add(new ArtistViewer(a)));
        }
        private void LoadAlbumsData(long artistId = -1)
        {
            allAlbums.ForEach(a => albumViewers.Add(new AlbumViewer(a)));
        }
        internal void ShowSongsData(long albumId = -1)
        {
            data.Controls.Clear();
            List<SongViewer> filteredSongs = new();
            Album? album = allAlbums.FirstOrDefault(a => a.Id == albumId);
            if (album != null) filteredSongs = songViewers.Where(s => album.Songs.Contains(s.Song.Id)).ToList();
            else filteredSongs = songViewers;
            filteredSongs.ForEach(s => data.Controls.Add(s));
        }
        internal void ShowArtistsData()
        {
            data.Controls.Clear();
            artistViewers.ForEach(a => data.Controls.Add(a));
        }
        internal void ShowAlbumsData(long artistId = -1)
        {
            data.Controls.Clear();
            List<AlbumViewer> filteredAlbums = new();
            Artist? artist = allArtists.FirstOrDefault(a => a.Id == artistId);
            if (artist != null) filteredAlbums = albumViewers.Where(a => artist.Albums.Contains(a.Album.Id)).ToList();
            else filteredAlbums = albumViewers;
            filteredAlbums.ForEach(a => data.Controls.Add(a));
        }
        private void btnAlbums_Click(object sender, EventArgs e)
        {
            if (output == null)
            {
                lblTime.Visible = false;
                trackBar1.Visible = false;
                btnPlay.Visible = false;
                volumeBar.Visible = false;
            }
            ShowAlbumsData();
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            if (output == null)
            {
                lblTime.Visible = false;
                trackBar1.Visible = false;
                btnPlay.Visible = false;
                volumeBar.Visible = false;
            }
            ShowArtistsData();
        }

        private void btnSongs_Click(object sender, EventArgs e)
        {
            lblTime.Visible = true;
            trackBar1.Visible = true;
            btnPlay.Visible = true;
            volumeBar.Visible = true;
            ShowSongsData();
        }

        private void volumeBar_Scroll(object sender, EventArgs e)
        {
            volume = volumeBar.Value / 100f;
            if (output != null)
            {
output.Volume = volumeBar.Value / 100f;
}

        }
    }
}
