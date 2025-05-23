using SuchByte.MacroDeck.GUI.CustomControls;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    partial class ClientIdPage
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
            lblCopyClientIdAndPaste = new System.Windows.Forms.Label();
            lblClientId = new System.Windows.Forms.Label();
            clientId = new RoundedTextBox();
            btnAuthorize = new ButtonPrimary();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.spotify_3;
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox1.Location = new System.Drawing.Point(18, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(705, 282);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblCopyClientIdAndPaste
            // 
            lblCopyClientIdAndPaste.Font = new System.Drawing.Font("Tahoma", 12F);
            lblCopyClientIdAndPaste.Location = new System.Drawing.Point(33, 317);
            lblCopyClientIdAndPaste.Name = "lblCopyClientIdAndPaste";
            lblCopyClientIdAndPaste.Size = new System.Drawing.Size(675, 50);
            lblCopyClientIdAndPaste.TabIndex = 1;
            lblCopyClientIdAndPaste.Text = "Now you're on the overview page of your created app. Copy the \"Client ID\" and paste it in the textbox below";
            lblCopyClientIdAndPaste.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblClientId
            // 
            lblClientId.Font = new System.Drawing.Font("Tahoma", 12F);
            lblClientId.Location = new System.Drawing.Point(90, 381);
            lblClientId.Name = "lblClientId";
            lblClientId.Size = new System.Drawing.Size(107, 25);
            lblClientId.TabIndex = 2;
            lblClientId.Text = "Client ID";
            lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clientId
            // 
            clientId.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
            clientId.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic);
            clientId.Icon = null;
            clientId.Location = new System.Drawing.Point(203, 380);
            clientId.MaxCharacters = 32767;
            clientId.Multiline = false;
            clientId.Name = "clientId";
            clientId.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            clientId.PasswordChar = false;
            clientId.PlaceHolderColor = System.Drawing.Color.Gray;
            clientId.PlaceHolderText = "Paste the copied Client ID here";
            clientId.ReadOnly = false;
            clientId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            clientId.SelectionStart = 0;
            clientId.Size = new System.Drawing.Size(447, 29);
            clientId.TabIndex = 3;
            clientId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnAuthorize
            // 
            btnAuthorize.BorderRadius = 8;
            btnAuthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAuthorize.Font = new System.Drawing.Font("Tahoma", 12F);
            btnAuthorize.ForeColor = System.Drawing.Color.White;
            btnAuthorize.HoverColor = System.Drawing.Color.Empty;
            btnAuthorize.Icon = null;
            btnAuthorize.Location = new System.Drawing.Point(230, 431);
            btnAuthorize.Name = "btnAuthorize";
            btnAuthorize.Progress = 0;
            btnAuthorize.ProgressColor = System.Drawing.Color.FromArgb(0, 103, 205);
            btnAuthorize.Size = new System.Drawing.Size(281, 55);
            btnAuthorize.TabIndex = 4;
            btnAuthorize.Text = "Authorize";
            btnAuthorize.UseVisualStyleBackColor = true;
            btnAuthorize.UseWindowsAccentColor = true;
            btnAuthorize.Visible = false;
            btnAuthorize.WriteProgress = true;
            btnAuthorize.Click += BtnAuthorize_Click;
            // 
            // ClientIdPage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            Controls.Add(btnAuthorize);
            Controls.Add(clientId);
            Controls.Add(lblClientId);
            Controls.Add(lblCopyClientIdAndPaste);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Tahoma", 9F);
            ForeColor = System.Drawing.Color.White;
            Name = "ClientIdPage";
            Size = new System.Drawing.Size(741, 518);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCopyClientIdAndPaste;
        private System.Windows.Forms.Label lblClientId;
        private RoundedTextBox clientId;
        private ButtonPrimary btnAuthorize;
    }
}
