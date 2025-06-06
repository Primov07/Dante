namespace GUIDisplay
{
    partial class AlbumViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblString = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblString
            // 
            lblString.Font = new Font("Lucida Sans Unicode", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblString.Location = new Point(0, 89);
            lblString.Name = "lblString";
            lblString.Size = new Size(135, 52);
            lblString.TabIndex = 0;
            lblString.Text = "label1";
            lblString.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(129, 86);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // AlbumViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(59, 139, 161);
            Controls.Add(pictureBox1);
            Controls.Add(lblString);
            Name = "AlbumViewer";
            Size = new Size(135, 141);
            Load += AlbumViewer_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblString;
        private PictureBox pictureBox1;
    }
}
