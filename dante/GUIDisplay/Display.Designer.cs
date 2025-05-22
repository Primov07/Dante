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
            trackBar1 = new TrackBar();
            btnArtists = new Button();
            btnAlbums = new Button();
            btnSongs = new Button();
            artistsData = new DataGridView();
            btnBrowse = new Button();
            btnPlay = new Button();
            btnDownload = new Button();
            albumsData = new DataGridView();
            songsData = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)artistsData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)albumsData).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(163, 392);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(469, 56);
            trackBar1.TabIndex = 0;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // btnArtists
            // 
            btnArtists.Location = new Point(12, 304);
            btnArtists.Name = "btnArtists";
            btnArtists.Size = new Size(94, 29);
            btnArtists.TabIndex = 1;
            btnArtists.Text = "Artists";
            btnArtists.UseVisualStyleBackColor = true;
            // 
            // btnAlbums
            // 
            btnAlbums.Location = new Point(12, 353);
            btnAlbums.Name = "btnAlbums";
            btnAlbums.Size = new Size(94, 29);
            btnAlbums.TabIndex = 2;
            btnAlbums.Text = "Albums";
            btnAlbums.UseVisualStyleBackColor = true;
            // 
            // btnSongs
            // 
            btnSongs.Location = new Point(12, 404);
            btnSongs.Name = "btnSongs";
            btnSongs.Size = new Size(94, 29);
            btnSongs.TabIndex = 3;
            btnSongs.Text = "Songs";
            btnSongs.UseVisualStyleBackColor = true;
            // 
            // artistsData
            // 
            artistsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            artistsData.Location = new Point(246, 36);
            artistsData.Name = "artistsData";
            artistsData.ReadOnly = true;
            artistsData.RowHeadersWidth = 51;
            artistsData.Size = new Size(325, 213);
            artistsData.TabIndex = 4;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(665, 353);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 5;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(665, 289);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(94, 29);
            btnPlay.TabIndex = 6;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(440, 304);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(94, 29);
            btnDownload.TabIndex = 7;
            btnDownload.Text = "Download";
            btnDownload.UseVisualStyleBackColor = true;
            // 
            // albumsData
            // 
            albumsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            albumsData.Location = new Point(257, 52);
            albumsData.Name = "albumsData";
            albumsData.ReadOnly = true;
            albumsData.RowHeadersWidth = 51;
            albumsData.Size = new Size(300, 188);
            albumsData.TabIndex = 8;
            // 
            // songsData
            // 
            songsData.BackColor = Color.Firebrick;
            songsData.Location = new Point(276, 81);
            songsData.Name = "songsData";
            songsData.Size = new Size(258, 159);
            songsData.TabIndex = 9;
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(songsData);
            Controls.Add(albumsData);
            Controls.Add(btnDownload);
            Controls.Add(btnPlay);
            Controls.Add(btnBrowse);
            Controls.Add(artistsData);
            Controls.Add(btnSongs);
            Controls.Add(btnAlbums);
            Controls.Add(btnArtists);
            Controls.Add(trackBar1);
            Name = "Display";
            Text = "Form1";
            Load += Display_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)artistsData).EndInit();
            ((System.ComponentModel.ISupportInitialize)albumsData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private Button btnArtists;
        private Button btnAlbums;
        private Button btnSongs;
        private DataGridView artistsData;
        private Button btnBrowse;
        private Button btnPlay;
        private Button btnDownload;
        private SongViewer songViewer1;
        private DataGridView albumsData;
        private FlowLayoutPanel songsData;
    }
}
