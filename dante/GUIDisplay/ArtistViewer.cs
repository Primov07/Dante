
using System.ComponentModel;
using Data;
using HttpRequest;

namespace GUIDisplay
{
    public partial class ArtistViewer : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Artist Artist { get; set; }
        public ArtistViewer()
        {
            InitializeComponent();
        }
        public ArtistViewer(Artist artist) : this()
        {
            this.Artist = artist;
            this.Click += ArtistViewerClick;
            foreach (Control c in this.Controls) c.Click += ArtistViewerClick;
        }
        private async void ArtistViewer_Load(object sender, EventArgs e)
        {
            lblString.Text = Artist.ToString();
            pictureBox1.Image = await ResizeImage();
            this.BackColor = Color.FromArgb(59, 139, 161);
        }
        private void ArtistViewerClick(object sender, EventArgs e)
        {
            if (ParentForm is Display display) display.ShowAlbumsData(this.Artist.Id);
        }
        private async Task<Bitmap> ResizeImage()
        {
            Bitmap resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Image image = Image.FromStream(await Getter.LoadArtistImage(Artist.Id));
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            return resized;
        }
    }
}
