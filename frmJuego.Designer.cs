namespace pryLopezS
{
    partial class Galaga
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Galaga));
            nave = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)nave).BeginInit();
            SuspendLayout();
            // 
            // nave
            // 
            nave.BackColor = Color.Transparent;
            nave.Image = Properties.Resources.pngegg;
            nave.Location = new Point(303, 434);
            nave.Name = "nave";
            nave.Size = new Size(122, 83);
            nave.SizeMode = PictureBoxSizeMode.Zoom;
            nave.TabIndex = 0;
            nave.TabStop = false;
            nave.Click += Form1_Load;
            // 
            // Galaga
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MidnightBlue;
            BackgroundImage = Properties.Resources.star_fall;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(720, 525);
            Controls.Add(nave);
            Enabled = false;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Galaga";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Galaga";
            Click += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nave).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox nave;
    }
}