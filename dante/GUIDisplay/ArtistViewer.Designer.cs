namespace GUIDisplay
{
    partial class ArtistViewer
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
            pictureBox1 = new PictureBox();
            lblString = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(117, 81);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblString
            // 
            lblString.Font = new Font("Lucida Sans Unicode", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblString.Location = new Point(0, 87);
            lblString.Name = "lblString";
            lblString.Size = new Size(123, 36);
            lblString.TabIndex = 1;
            lblString.Text = "label1";
            lblString.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ArtistViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblString);
            Controls.Add(pictureBox1);
            Name = "ArtistViewer";
            Size = new Size(123, 123);
            Load += ArtistViewer_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblString;
    }
}
