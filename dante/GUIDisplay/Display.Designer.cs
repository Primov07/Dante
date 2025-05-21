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
            dataGridView1 = new DataGridView();
            btnBrowse = new Button();
            btnStart = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(319, 25);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(325, 213);
            dataGridView1.TabIndex = 4;
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
            // btnStart
            // 
            btnStart.Location = new Point(665, 289);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(94, 29);
            btnStart.TabIndex = 6;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // Display
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStart);
            Controls.Add(btnBrowse);
            Controls.Add(dataGridView1);
            Controls.Add(btnSongs);
            Controls.Add(btnAlbums);
            Controls.Add(btnArtists);
            Controls.Add(trackBar1);
            Name = "Display";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private Button btnArtists;
        private Button btnAlbums;
        private Button btnSongs;
        private DataGridView dataGridView1;
        private Button btnBrowse;
        private Button btnStart;
    }
}
