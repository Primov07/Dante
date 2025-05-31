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
        private Song song;
        private SongViewer()
        {
            InitializeComponent();
        }
        public SongViewer(Song song) : this()
        {
            this.song = song;
        }

        private async void SongViewer_Load(object sender, EventArgs e)
        {
            lblString.Text = song.ToString();
            pictureBox1.Image = await ResizeImage();
        }
        private async Task<Bitmap> ResizeImage()
        {
            Bitmap resized = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Image image = Image.FromStream(await Getter.LoadImage(song.Id));
            using (Graphics g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(image, 0, 0, pictureBox1.Width, pictureBox1.Height);
            }
            return resized;
        }
    }
}
