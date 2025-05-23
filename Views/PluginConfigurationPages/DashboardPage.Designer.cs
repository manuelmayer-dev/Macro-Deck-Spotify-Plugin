namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    partial class DashboardPage
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lblCreatedLoggedIn = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.spotify_1;
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox1.Location = new System.Drawing.Point(38, 99);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(665, 189);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblCreatedLoggedIn
            // 
            lblCreatedLoggedIn.Font = new System.Drawing.Font("Tahoma", 12F);
            lblCreatedLoggedIn.Location = new System.Drawing.Point(33, 291);
            lblCreatedLoggedIn.Name = "lblCreatedLoggedIn";
            lblCreatedLoggedIn.Size = new System.Drawing.Size(675, 97);
            lblCreatedLoggedIn.TabIndex = 1;
            lblCreatedLoggedIn.Text = "After you created and logged in to the Spotify developer account, you'll be redirected to the dashboard.\r\n\r\nNow click on \"Create app\" and continue with the next page.";
            lblCreatedLoggedIn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DashboardPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            Controls.Add(lblCreatedLoggedIn);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Tahoma", 9F);
            ForeColor = System.Drawing.Color.White;
            Name = "DashboardPage";
            Size = new System.Drawing.Size(741, 518);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCreatedLoggedIn;
    }
}
