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

namespace GUIDisplay
{
    public partial class ObjectViewer : UserControl
    {
        private Song song;
        public ObjectViewer()
        {
            InitializeComponent();
            lblString.Text = song?.ToString();
            // pictureBox1.Image = new Image();
        }
        // [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private Image ObjectImage
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        private void ObjectViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
