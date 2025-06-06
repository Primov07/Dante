namespace GUIDisplay
{
    partial class Display
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code

/// <summary>
///  Required method for Designer support - do not modify
///  the contents of this method with the code editor.
/// </summary>
private void InitializeComponent()
{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Display));
trackBar1 = new TrackBar();
btnArtists = new Button();
btnAlbums = new Button();
btnSongs = new Button();
btnPlay = new Button();
data = new FlowLayoutPanel();
lblTime = new Label();
volumeBar = new TrackBar();
((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
SuspendLayout();
//
// trackBar1
//
trackBar1.Location = new Point(215, 154);
trackBar1.Margin = new Padding(3, 2, 3, 2);
trackBar1.Maximum = 100;
trackBar1.Name = "trackBar1";
trackBar1.Size = new Size(508, 45);
trackBar1.TabIndex = 0;
trackBar1.Scroll += trackBar1_Scroll;
//
// btnArtists
//
btnArtists.BackColor = Color.FromArgb(77, 77, 77);
btnArtists.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
btnArtists.FlatStyle = FlatStyle.Flat;
btnArtists.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
btnArtists.ForeColor = SystemColors.ButtonFace;
btnArtists.Location = new Point(-3, -2);
btnArtists.Margin = new Padding(3, 2, 3, 2);
btnArtists.Name = "btnArtists";
btnArtists.Size = new Size(212, 80);
btnArtists.TabIndex = 1;
btnArtists.Text = "Artists";
btnArtists.UseVisualStyleBackColor = false;
btnArtists.Click += btnArtists_Click;
//
// btnAlbums
//
btnAlbums.BackColor = Color.FromArgb(77, 77, 77);
btnAlbums.FlatStyle = FlatStyle.Flat;
btnAlbums.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
btnAlbums.ForeColor = SystemColors.ButtonFace;
btnAlbums.Location = new Point(-3, 76);
btnAlbums.Margin = new Padding(3, 2, 3, 2);
btnAlbums.Name = "btnAlbums";
btnAlbums.Size = new Size(212, 80);
btnAlbums.TabIndex = 2;
btnAlbums.Text = "Albums";
btnAlbums.UseVisualStyleBackColor = true;
btnAlbums.Click += btnAlbums_Click;
//
// btnSongs
//
btnSongs.BackColor = Color.FromArgb(77, 77, 77);
btnSongs.FlatStyle = FlatStyle.Flat;
btnSongs.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
btnSongs.ForeColor = SystemColors.ButtonFace;
btnSongs.Location = new Point(-3, 148);
btnSongs.Margin = new Padding(3, 2, 3, 2);
btnSongs.Name = "btnSongs";
btnSongs.Size = new Size(212, 80);
btnSongs.TabIndex = 3;
btnSongs.Text = "Songs";
btnSongs.UseVisualStyleBackColor = true;
btnSongs.Click += btnSongs_Click;
//
// btnPlay
//
btnPlay.BackColor = Color.FromArgb(26, 26, 26);
btnPlay.FlatStyle = FlatStyle.Flat;
btnPlay.Font = new Font("Showcard Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
btnPlay.ForeColor = SystemColors.ButtonFace;
btnPlay.Location = new Point(446, 187);
btnPlay.Margin = new Padding(3, 2, 3, 2);
btnPlay.Name = "btnPlay";
btnPlay.Size = new Size(64, 33);
btnPlay.TabIndex = 6;
btnPlay.Text = "Play";
btnPlay.UseVisualStyleBackColor = false;
btnPlay.Click += btnPlay_Click;
//
// data
//
data.AutoScroll = true;
data.BackColor = Color.FromArgb(11, 11, 11);
data.Location = new Point(215, 9);
data.Margin = new Padding(3, 2, 3, 2);
data.Name = "data";
data.Size = new Size(508, 143);
data.TabIndex = 9;
//
// lblTime
//
lblTime.AutoSize = true;
lblTime.ForeColor = SystemColors.ButtonHighlight;
lblTime.Location = new Point(476, 137);
lblTime.Name = "lblTime";
lblTime.Size = new Size(34, 15);
lblTime.TabIndex = 10;
lblTime.Text = "00:00";
//
// volumeBar
//
volumeBar.Location = new Point(734, 11);
volumeBar.Margin = new Padding(3, 2, 3, 2);
volumeBar.Maximum = 100;
volumeBar.Name = "volumeBar";
volumeBar.Orientation = Orientation.Vertical;
volumeBar.RightToLeft = RightToLeft.Yes;
volumeBar.Size = new Size(45, 194);
volumeBar.TabIndex = 11;
volumeBar.Value = 100;
volumeBar.Scroll += volumeBar_Scroll;
//
// Display
//
AutoScaleDimensions = new SizeF(7F, 15F);
AutoScaleMode = AutoScaleMode.Font;
BackColor = Color.FromArgb(44, 44, 44);
ClientSize = new Size(788, 226);
Controls.Add(volumeBar);
Controls.Add(lblTime);
Controls.Add(data);
Controls.Add(btnPlay);
Controls.Add(btnSongs);
Controls.Add(btnAlbums);
Controls.Add(btnArtists);
Controls.Add(trackBar1);
Icon = (Icon)resources.GetObject("$this.Icon");
Margin = new Padding(3, 2, 3, 2);
Name = "Display";
Text = "Display";
Load += Display_Load;
((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
((System.ComponentModel.ISupportInitialize)volumeBar).EndInit();
ResumeLayout(false);
PerformLayout();
}

#endregion

private TrackBar trackBar1;
        private Button btnArtists;
        private Button btnAlbums;
        private Button btnSongs;
        private Button btnPlay;
        private SongViewer songViewer1;
        private FlowLayoutPanel data;
        private Label lblTime;
        private TrackBar volumeBar;
    }
}
