using SuchByte.MacroDeck.GUI.CustomControls;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    partial class WelcomePage
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblCreateSpotifyApp = new System.Windows.Forms.Label();
            this.lblSpotifyDevAccount = new System.Windows.Forms.Label();
            this.btnOpenDeveloperPortal = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.lblContinueAfterLoggedIn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(9, 16);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(723, 70);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to the Spotify plugin for Macro Deck!";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCreateSpotifyApp
            // 
            this.lblCreateSpotifyApp.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCreateSpotifyApp.Location = new System.Drawing.Point(9, 86);
            this.lblCreateSpotifyApp.Name = "lblCreateSpotifyApp";
            this.lblCreateSpotifyApp.Size = new System.Drawing.Size(723, 92);
            this.lblCreateSpotifyApp.TabIndex = 1;
            this.lblCreateSpotifyApp.Text = "In this wizard, you\'ll create a Spotify app to get the required credentials but d" +
    "on\'t worry. You\'ll be guided through this process.";
            this.lblCreateSpotifyApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSpotifyDevAccount
            // 
            this.lblSpotifyDevAccount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSpotifyDevAccount.Location = new System.Drawing.Point(15, 258);
            this.lblSpotifyDevAccount.Name = "lblSpotifyDevAccount";
            this.lblSpotifyDevAccount.Size = new System.Drawing.Size(723, 78);
            this.lblSpotifyDevAccount.TabIndex = 2;
            this.lblSpotifyDevAccount.Text = "First of all, you need a Spotify developer account. This account is automatically" +
    " generated when you login to the Spotify developer portal with your Spotify cred" +
    "entials.\r\n";
            this.lblSpotifyDevAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOpenDeveloperPortal
            // 
            this.btnOpenDeveloperPortal.BorderRadius = 8;
            this.btnOpenDeveloperPortal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDeveloperPortal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpenDeveloperPortal.ForeColor = System.Drawing.Color.White;
            this.btnOpenDeveloperPortal.HoverColor = System.Drawing.Color.Empty;
            this.btnOpenDeveloperPortal.Icon = null;
            this.btnOpenDeveloperPortal.Location = new System.Drawing.Point(230, 339);
            this.btnOpenDeveloperPortal.Name = "btnOpenDeveloperPortal";
            this.btnOpenDeveloperPortal.Progress = 0;
            this.btnOpenDeveloperPortal.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.btnOpenDeveloperPortal.Size = new System.Drawing.Size(281, 55);
            this.btnOpenDeveloperPortal.TabIndex = 3;
            this.btnOpenDeveloperPortal.Text = "Open Spotify Developer Portal";
            this.btnOpenDeveloperPortal.UseVisualStyleBackColor = true;
            this.btnOpenDeveloperPortal.UseWindowsAccentColor = true;
            this.btnOpenDeveloperPortal.Click += new System.EventHandler(this.BtnOpenDeveloperPortal_Click);
            // 
            // lblContinueAfterLoggedIn
            // 
            this.lblContinueAfterLoggedIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblContinueAfterLoggedIn.Location = new System.Drawing.Point(9, 397);
            this.lblContinueAfterLoggedIn.Name = "lblContinueAfterLoggedIn";
            this.lblContinueAfterLoggedIn.Size = new System.Drawing.Size(723, 49);
            this.lblContinueAfterLoggedIn.TabIndex = 4;
            this.lblContinueAfterLoggedIn.Text = "Continue with the next page after you\'re logged in to the Spotify developer accou" +
    "nt";
            this.lblContinueAfterLoggedIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WelcomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.Controls.Add(this.lblContinueAfterLoggedIn);
            this.Controls.Add(this.btnOpenDeveloperPortal);
            this.Controls.Add(this.lblSpotifyDevAccount);
            this.Controls.Add(this.lblCreateSpotifyApp);
            this.Controls.Add(this.lblWelcome);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "WelcomePage";
            this.Size = new System.Drawing.Size(741, 518);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblCreateSpotifyApp;
        private System.Windows.Forms.Label lblSpotifyDevAccount;
        private ButtonPrimary btnOpenDeveloperPortal;
        private System.Windows.Forms.Label lblContinueAfterLoggedIn;
    }
}
