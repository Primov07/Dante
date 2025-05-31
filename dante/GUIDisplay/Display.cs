using Data;
using HttpRequest;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace GUIDisplay
{
    public partial class Display : Form
    {
        private List<Song> allSongs;
        private List<Album> allAlbums;
        private List<Artist> allArtists;
        private System.Windows.Forms.Timer timer;
        public Display()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {

        }

        private void songViewer1_Load(object sender, EventArgs e)
        {

        }

        private async void Display_Load(object sender, EventArgs e)
        {
            await LoadDataSources();
            SetVisibilites();
            SetDataGridViews();
        }
        private void SetDataGridViews()
        {  
            albumsData.Width = albumsData.RowHeadersWidth + albumsData.Columns.Cast<DataGridViewColumn>().Sum(c => c.Width);
            albumsData.Location = new Point(205, 0);
            artistsData.Width = albumsData.RowHeadersWidth + artistsData.Columns.Cast<DataGridViewColumn>().Sum(c => c.Width);
            artistsData.Location = new Point(130, 0);
        }
        private async Task LoadDataSources()
        {
            await LoadAlbumsData();
            await LoadArtistsData();
            await LoadSongsData();
        }
        private async Task LoadSongsData()
        {
            List<Song> songs = await Getter.GetSongs();
            List<SongViewer> viewers = new List<SongViewer>();
            foreach (var song in songs) viewers.Add(new SongViewer(song));
            viewers.ForEach(v => songsData.Controls.Add(v));
        }
        private async Task LoadAlbumsData()
        {
            allSongs = await Getter.GetSongs();
            albumsData.AutoGenerateColumns = false;
            var titleCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Title",
                Name = "Title"
            };
            var songsCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Songs",
                HeaderText = "Songs",
                Name = "Songs"
            };
            albumsData.Columns.Add(titleCol);
            albumsData.Columns.Add(songsCol);

            albumsData.CellFormatting += albumsData_CellFormatting;
            albumsData.DataSource = await Getter.GetAlbums();
        }
        private async Task LoadArtistsData()
        {
            allAlbums = await Getter.GetAlbums();
            allArtists = await Getter.GetArtists();
            artistsData.AutoGenerateColumns = false;
            var nameCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Name",
                Name = "Name"
            };
            var ratingCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rating",
                HeaderText = "Rating",
                Name = "Rating"
            };
            var albumsCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Albums",
                HeaderText = "Albums",
                Name = "Albums"
            };
            var songsCol = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Songs",
                HeaderText = "Songs",
                Name = "Songs"
            };
            artistsData.Columns.Add(nameCol);
            artistsData.Columns.Add(ratingCol);
            artistsData.Columns.Add(albumsCol);
            artistsData.Columns.Add(songsCol);


            artistsData.CellFormatting += artistsData_CellFormatting;
            artistsData.DataSource = await Getter.GetArtists();
        }
        private void SetVisibilites()
        {
            songsData.Visible = true;
            albumsData.Visible = false;
            artistsData.Visible = false;
        }
        private void btnAlbums_Click(object sender, EventArgs e)
        {
            albumsData.Visible = true;
            songsData.Visible = false;
            artistsData.Visible = false;
            btnPlay.Visible = false;
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            artistsData.Visible = true;
            songsData.Visible = false;
            albumsData.Visible = false;
            btnPlay.Visible = false;
        }

        private void btnSongs_Click(object sender, EventArgs e)
        {
            btnPlay.Visible = true;
            songsData.Visible = true;
            albumsData.Visible = false;
            artistsData.Visible = false;
        }
        private async void albumsData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (albumsData.Columns[e.ColumnIndex].Name == "Songs")
            {
                if (e.Value is List<long> songs)
                {
                    List<string> titles = allSongs.Where(s => songs.Contains(s.Id)).Select(s => "\"" + s.Title + "\"").ToList();
                    e.Value = string.Join(", ", titles);
                    e.FormattingApplied = true;
                }
            }
        }
        private async void artistsData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (artistsData.Columns[e.ColumnIndex].Name == "Songs")
            {
                if (e.Value is List<long> songs)
                {
                    List<string> titles = allSongs.Where(s => songs.Contains(s.Id)).Select(s => "\"" + s.Title + "\"").ToList();
                    e.Value = string.Join(", ", titles);
                    e.FormattingApplied = true;
                }
            }
            if (artistsData.Columns[e.ColumnIndex].Name == "Albums")
            {
                if (e.Value is List<long> albums)
                {
                    List<string> titles = allAlbums.Where(a => albums.Contains(a.Id)).Select(a => "\"" + a.Title + "\"").ToList();
                    e.Value = string.Join(", ", titles);
                    e.FormattingApplied = true;
                }
            }
        }

    }
}
