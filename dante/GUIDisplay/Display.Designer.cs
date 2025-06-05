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
            trackBar1.Location = new Point(335, 222);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(469, 56);
            trackBar1.TabIndex = 0;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // btnArtists
            // 
            btnArtists.BackColor = SystemColors.ControlDarkDark;
            btnArtists.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            btnArtists.FlatStyle = FlatStyle.Flat;
            btnArtists.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnArtists.Location = new Point(-3, -2);
            btnArtists.Name = "btnArtists";
            btnArtists.Size = new Size(242, 106);
            btnArtists.TabIndex = 1;
            btnArtists.Text = "Artists";
            btnArtists.UseVisualStyleBackColor = false;
            btnArtists.Click += btnArtists_Click;
            // 
            // btnAlbums
            // 
            btnAlbums.FlatStyle = FlatStyle.Flat;
            btnAlbums.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAlbums.Location = new Point(-3, 101);
            btnAlbums.Name = "btnAlbums";
            btnAlbums.Size = new Size(242, 106);
            btnAlbums.TabIndex = 2;
            btnAlbums.Text = "Albums";
            btnAlbums.UseVisualStyleBackColor = true;
            btnAlbums.Click += btnAlbums_Click;
            // 
            // btnSongs
            // 
            btnSongs.FlatStyle = FlatStyle.Flat;
            btnSongs.Font = new Font("Lucida Sans Unicode", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSongs.Location = new Point(-3, 197);
            btnSongs.Name = "btnSongs";
            btnSongs.Size = new Size(242, 106);
            btnSongs.TabIndex = 3;
            btnSongs.Text = "Songs";
            btnSongs.UseVisualStyleBackColor = true;
            btnSongs.Click += btnSongs_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(529, 260);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(73, 29);
            btnPlay.TabIndex = 6;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // data
            // 
            data.AutoScroll = true;
            data.BackColor = Color.Firebrick;
            data.Location = new Point(356, 12);
            data.Name = "data";
            data.Size = new Size(435, 167);
            data.TabIndex = 9;
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(544, 199);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(44, 20);
            lblTime.TabIndex = 10;
            lblTime.Text = "00:00";
            // 
            // volumeBar
            // 
            volumeBar.Location = new Point(833, 20);
            volumeBar.Name = "volumeBar";
            volumeBar.Orientation = Orientation.Vertical;
            volumeBar.RightToLeft = RightToLeft.Yes;
            volumeBar.Size = new Size(56, 258);
            volumeBar.TabIndex = 11;
            volumeBar.Scroll += volumeBar_Scroll;
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(901, 301);
            Controls.Add(volumeBar);
            Controls.Add(lblTime);
            Controls.Add(data);
            Controls.Add(btnPlay);
            Controls.Add(btnSongs);
            Controls.Add(btnAlbums);
            Controls.Add(btnArtists);
            Controls.Add(trackBar1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
