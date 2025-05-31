using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using HttpRequest;

namespace GUIDisplay
{
    public partial class SongViewer : UserControl
    {
        private bool isSelected = false;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.BackColor = isSelected ? Color.LightBlue : Color.RosyBrown;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Song Song { get; set; }
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
        }
        private async void SongViewer_Load(object sender, EventArgs e)
        {
            lblString.Text = Song.ToString();
            pictureBox1.Image = await ResizeImage();
        }
        private async Task<Bitmap> ResizeImage()
        {
            Bitmap resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Image image = Image.FromStream(await Getter.LoadImage(Song.Id));
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            return resized;
        }
    }
}
