namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    partial class EditSettingsPage
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblAddRedirect = new System.Windows.Forms.Label();
            this.btnCopyRedirectUri = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.lblSaveAndContinue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Develeon64.SpotifyPlugin.Properties.Resources.Step4;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 512);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblAddRedirect
            // 
            this.lblAddRedirect.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAddRedirect.Location = new System.Drawing.Point(275, 110);
            this.lblAddRedirect.Name = "lblAddRedirect";
            this.lblAddRedirect.Size = new System.Drawing.Size(463, 59);
            this.lblAddRedirect.TabIndex = 1;
            this.lblAddRedirect.Text = "In the settings, you need to add \"http://localhost:5000/callback\" to the Redirect" +
    " URIs.";
            this.lblAddRedirect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCopyRedirectUri
            // 
            this.btnCopyRedirectUri.BorderRadius = 8;
            this.btnCopyRedirectUri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopyRedirectUri.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCopyRedirectUri.ForeColor = System.Drawing.Color.White;
            this.btnCopyRedirectUri.HoverColor = System.Drawing.Color.Empty;
            this.btnCopyRedirectUri.Icon = null;
            this.btnCopyRedirectUri.Location = new System.Drawing.Point(369, 172);
            this.btnCopyRedirectUri.Name = "btnCopyRedirectUri";
            this.btnCopyRedirectUri.Progress = 0;
            this.btnCopyRedirectUri.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.btnCopyRedirectUri.Size = new System.Drawing.Size(281, 55);
            this.btnCopyRedirectUri.TabIndex = 5;
            this.btnCopyRedirectUri.Text = "Copy Redirect URI to clipboard";
            this.btnCopyRedirectUri.UseVisualStyleBackColor = true;
            this.btnCopyRedirectUri.UseWindowsAccentColor = true;
            this.btnCopyRedirectUri.Click += new System.EventHandler(this.BtnCopyRedirectUri_Click);
            // 
            // lblSaveAndContinue
            // 
            this.lblSaveAndContinue.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSaveAndContinue.Location = new System.Drawing.Point(275, 340);
            this.lblSaveAndContinue.Name = "lblSaveAndContinue";
            this.lblSaveAndContinue.Size = new System.Drawing.Size(463, 59);
            this.lblSaveAndContinue.TabIndex = 6;
            this.lblSaveAndContinue.Text = "After you pasted the uri and clicked on \"Add\", you can click \"Save\" and continue " +
    "with the next page.";
            this.lblSaveAndContinue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EditSettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.lblSaveAndContinue);
            this.Controls.Add(this.btnCopyRedirectUri);
            this.Controls.Add(this.lblAddRedirect);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "EditSettingsPage";
            this.Size = new System.Drawing.Size(741, 518);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAddRedirect;
        private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary btnCopyRedirectUri;
        private System.Windows.Forms.Label lblSaveAndContinue;
    }
}
