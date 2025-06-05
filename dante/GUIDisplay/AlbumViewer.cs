
using System.ComponentModel;
using Data;
using HttpRequest;

namespace GUIDisplay
{
    public partial class AlbumViewer : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Album Album { get; set; }
        public AlbumViewer()
        {
            InitializeComponent();
        }
        public AlbumViewer(Album album) : this()
        {
            this.Album = album;
            this.Click += AlbumViewerClick;
            foreach (Control c in this.Controls) c.Click += AlbumViewerClick;
        }
        private async void AlbumViewer_Load(object sender, EventArgs e)
        {
            if (ParentForm is Display display) lblString.Text = Album.ToString() + display.allArtists.First(a => a.Albums.Contains(Album.Id)).Name;
            pictureBox1.Image = await ResizeImage();
            this.BackColor = Color.FromArgb(59, 139, 161);
        }
        private void AlbumViewerClick(object sender, EventArgs e)
        {
            if (ParentForm is Display display) display.ShowSongsData(this.Album.Id);
        }
        private async Task<Bitmap> ResizeImage()
        {
            Bitmap resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Image image = Image.FromStream(await Getter.LoadAlbumImage(Album.Id));
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            return resized;
        }
    }
}
