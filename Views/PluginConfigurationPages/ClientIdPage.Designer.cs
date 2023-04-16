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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCopyClientIdAndPaste = new System.Windows.Forms.Label();
            this.lblClientId = new System.Windows.Forms.Label();
            this.clientId = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.btnAuthorize = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Develeon64.SpotifyPlugin.Properties.Resources.Step5;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(102, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(537, 282);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblCopyClientIdAndPaste
            // 
            this.lblCopyClientIdAndPaste.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCopyClientIdAndPaste.Location = new System.Drawing.Point(33, 288);
            this.lblCopyClientIdAndPaste.Name = "lblCopyClientIdAndPaste";
            this.lblCopyClientIdAndPaste.Size = new System.Drawing.Size(675, 50);
            this.lblCopyClientIdAndPaste.TabIndex = 1;
            this.lblCopyClientIdAndPaste.Text = "Now you\'re on the overview page of your created app. Copy the \"Client ID\" and pas" +
    "te it in the textbox below";
            this.lblCopyClientIdAndPaste.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblClientId
            // 
            this.lblClientId.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClientId.Location = new System.Drawing.Point(148, 352);
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(107, 25);
            this.lblClientId.TabIndex = 2;
            this.lblClientId.Text = "Client ID";
            this.lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clientId
            // 
            this.clientId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.clientId.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.clientId.Icon = null;
            this.clientId.Location = new System.Drawing.Point(261, 351);
            this.clientId.MaxCharacters = 32767;
            this.clientId.Multiline = false;
            this.clientId.Name = "clientId";
            this.clientId.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.clientId.PasswordChar = false;
            this.clientId.PlaceHolderColor = System.Drawing.Color.Gray;
            this.clientId.PlaceHolderText = "Paste the copied Client ID here";
            this.clientId.ReadOnly = false;
            this.clientId.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.clientId.SelectionStart = 0;
            this.clientId.Size = new System.Drawing.Size(332, 29);
            this.clientId.TabIndex = 3;
            this.clientId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.BorderRadius = 8;
            this.btnAuthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuthorize.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAuthorize.ForeColor = System.Drawing.Color.White;
            this.btnAuthorize.HoverColor = System.Drawing.Color.Empty;
            this.btnAuthorize.Icon = null;
            this.btnAuthorize.Location = new System.Drawing.Point(230, 402);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Progress = 0;
            this.btnAuthorize.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.btnAuthorize.Size = new System.Drawing.Size(281, 55);
            this.btnAuthorize.TabIndex = 4;
            this.btnAuthorize.Text = "Authorize";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.UseWindowsAccentColor = true;
            this.btnAuthorize.Visible = false;
            this.btnAuthorize.Click += new System.EventHandler(this.BtnAuthorize_Click);
            // 
            // ClientIdPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.clientId);
            this.Controls.Add(this.lblClientId);
            this.Controls.Add(this.lblCopyClientIdAndPaste);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ClientIdPage";
            this.Size = new System.Drawing.Size(741, 518);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCopyClientIdAndPaste;
        private System.Windows.Forms.Label lblClientId;
        private RoundedTextBox clientId;
        private ButtonPrimary btnAuthorize;
    }
}
