using Data;
using HttpRequest;
namespace GUIDisplay
{
    public partial class Display : Form
    {
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
            List<Song> songs = await Getter.GetSongs();
            List<SongViewer> viewers = new List<SongViewer>();
            foreach (var song in songs) viewers.Add(new SongViewer(song));
            viewers.ForEach(v => songsData.Controls.Add(v));
        }
    }
}
