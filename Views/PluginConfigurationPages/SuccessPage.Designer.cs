namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    partial class SuccessPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuccessPage));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.infoLimitedFunctionality = new System.Windows.Forms.Panel();
            this.lblLoggedInFreeAccount = new System.Windows.Forms.Label();
            this.lblLimitedFunctionality = new System.Windows.Forms.Label();
            this.btnDone = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.infoLimitedFunctionality.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(33, 16);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(675, 73);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome {0}\r\nYour Spotify account is now connected to Macro Deck!\r\n";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // infoLimitedFunctionality
            // 
            this.infoLimitedFunctionality.BackColor = System.Drawing.Color.Maroon;
            this.infoLimitedFunctionality.Controls.Add(this.lblLoggedInFreeAccount);
            this.infoLimitedFunctionality.Controls.Add(this.lblLimitedFunctionality);
            this.infoLimitedFunctionality.Location = new System.Drawing.Point(33, 203);
            this.infoLimitedFunctionality.Name = "infoLimitedFunctionality";
            this.infoLimitedFunctionality.Size = new System.Drawing.Size(675, 139);
            this.infoLimitedFunctionality.TabIndex = 2;
            this.infoLimitedFunctionality.Visible = false;
            // 
            // lblLoggedInFreeAccount
            // 
            this.lblLoggedInFreeAccount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLoggedInFreeAccount.Location = new System.Drawing.Point(3, 30);
            this.lblLoggedInFreeAccount.Name = "lblLoggedInFreeAccount";
            this.lblLoggedInFreeAccount.Size = new System.Drawing.Size(669, 109);
            this.lblLoggedInFreeAccount.TabIndex = 1;
            this.lblLoggedInFreeAccount.Text = resources.GetString("lblLoggedInFreeAccount.Text");
            // 
            // lblLimitedFunctionality
            // 
            this.lblLimitedFunctionality.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLimitedFunctionality.Location = new System.Drawing.Point(0, 0);
            this.lblLimitedFunctionality.Name = "lblLimitedFunctionality";
            this.lblLimitedFunctionality.Size = new System.Drawing.Size(672, 30);
            this.lblLimitedFunctionality.TabIndex = 0;
            this.lblLimitedFunctionality.Text = "Limited functionality";
            // 
            // btnDone
            // 
            this.btnDone.BorderRadius = 8;
            this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDone.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDone.ForeColor = System.Drawing.Color.White;
            this.btnDone.HoverColor = System.Drawing.Color.Empty;
            this.btnDone.Icon = null;
            this.btnDone.Location = new System.Drawing.Point(230, 377);
            this.btnDone.Name = "btnDone";
            this.btnDone.Progress = 0;
            this.btnDone.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.btnDone.Size = new System.Drawing.Size(281, 55);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.UseWindowsAccentColor = true;
            this.btnDone.Click += new System.EventHandler(this.BtnDone_Click);
            // 
            // SuccessPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.infoLimitedFunctionality);
            this.Controls.Add(this.lblWelcome);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "SuccessPage";
            this.Size = new System.Drawing.Size(741, 518);
            this.Load += new System.EventHandler(this.SuccessPage_Load);
            this.infoLimitedFunctionality.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel infoLimitedFunctionality;
        private System.Windows.Forms.Label lblLoggedInFreeAccount;
        private System.Windows.Forms.Label lblLimitedFunctionality;
        private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary btnDone;
    }
}
