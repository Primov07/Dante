using System.ComponentModel;
using Data;
using HttpRequest;

namespace GUIDisplay
{
    public partial class SongViewer : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Song Song { get; set; }
        private bool isSelected = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.BackColor = isSelected ? Color.LightBlue : Color.FromArgb(59, 139, 161);
            }
        }
        private SongViewer()
        {
            InitializeComponent();
        }
        public SongViewer(Song song) : this()
        {
            this.Song = song;
            this.Click += SongViewerClick;
            foreach (Control c in this.Controls) c.Click += SongViewerClick;
        }
        private void SongViewerClick(object sender, EventArgs e)
        {
            IsSelected = !IsSelected;
            if (ParentForm is Display display)
            {
                if (IsSelected) display.selectedSongs.Add(this);
                else display.selectedSongs.Remove(this);
            }
        }
        private async void SongViewer_Load(object sender, EventArgs e)
        {
            if (ParentForm is Display display) lblString.Text = Song.ToString() + display.allArtists.First(a => a.Songs.Contains(Song.Id)).Name;
            pictureBox1.Image = await ResizeImage();
        }
        private async Task<Bitmap> ResizeImage()
        {
            Bitmap resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Image image = Image.FromStream(await Getter.LoadSongImage(Song.Id));
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            return resized;
        }


    }
}
