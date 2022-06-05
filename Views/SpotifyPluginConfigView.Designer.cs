using SuchByte.MacroDeck.GUI.CustomControls;

namespace Develeon64.SpotifyPlugin.Views {
	public partial class SpotifyPluginConfigView {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose (bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komonenten-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent () {
			this.btnOk = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
			this.btnAuthorize = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
			this.txtAccessToken = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
			this.txtRefreshToken = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
			this.txtClientId = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
			this.lblClientId = new System.Windows.Forms.Label();
			this.lblAccessToken = new System.Windows.Forms.Label();
			this.lblRefreshToken = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.BorderRadius = 8;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnOk.ForeColor = System.Drawing.Color.White;
			this.btnOk.HoverColor = System.Drawing.Color.Empty;
			this.btnOk.Icon = null;
			this.btnOk.Location = new System.Drawing.Point(510, 160);
			this.btnOk.Name = "btnOk";
			this.btnOk.Progress = 0;
			this.btnOk.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(225)))));
			this.btnOk.Size = new System.Drawing.Size(75, 25);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseWindowsAccentColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// btnAuthorize
			// 
			this.btnAuthorize.BorderRadius = 8;
			this.btnAuthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAuthorize.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnAuthorize.ForeColor = System.Drawing.Color.White;
			this.btnAuthorize.HoverColor = System.Drawing.Color.Empty;
			this.btnAuthorize.Icon = null;
			this.btnAuthorize.Location = new System.Drawing.Point(400, 80);
			this.btnAuthorize.Name = "btnAuthorize";
			this.btnAuthorize.Progress = 0;
			this.btnAuthorize.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(225)))));
			this.btnAuthorize.Size = new System.Drawing.Size(125, 25);
			this.btnAuthorize.TabIndex = 0;
			this.btnAuthorize.Text = "Authorize Spotify";
			this.btnAuthorize.UseWindowsAccentColor = true;
			this.btnAuthorize.Click += new System.EventHandler(this.BtnAuthorize_Click);
			// 
			// txtAccessToken
			// 
			this.txtAccessToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
			this.txtAccessToken.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtAccessToken.Icon = null;
			this.txtAccessToken.Location = new System.Drawing.Point(140, 80);
			this.txtAccessToken.MaxCharacters = 32767;
			this.txtAccessToken.Multiline = false;
			this.txtAccessToken.Name = "txtAccessToken";
			this.txtAccessToken.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
			this.txtAccessToken.PasswordChar = true;
			this.txtAccessToken.PlaceHolderColor = System.Drawing.Color.Gray;
			this.txtAccessToken.PlaceHolderText = "";
			this.txtAccessToken.ReadOnly = true;
			this.txtAccessToken.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtAccessToken.SelectionStart = 0;
			this.txtAccessToken.Size = new System.Drawing.Size(250, 25);
			this.txtAccessToken.TabIndex = 0;
			this.txtAccessToken.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// txtRefreshToken
			// 
			this.txtRefreshToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
			this.txtRefreshToken.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtRefreshToken.Icon = null;
			this.txtRefreshToken.Location = new System.Drawing.Point(140, 110);
			this.txtRefreshToken.MaxCharacters = 32767;
			this.txtRefreshToken.Multiline = false;
			this.txtRefreshToken.Name = "txtRefreshToken";
			this.txtRefreshToken.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
			this.txtRefreshToken.PasswordChar = true;
			this.txtRefreshToken.PlaceHolderColor = System.Drawing.Color.Gray;
			this.txtRefreshToken.PlaceHolderText = "";
			this.txtRefreshToken.ReadOnly = true;
			this.txtRefreshToken.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtRefreshToken.SelectionStart = 0;
			this.txtRefreshToken.Size = new System.Drawing.Size(250, 25);
			this.txtRefreshToken.TabIndex = 2;
			this.txtRefreshToken.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// txtClientId
			// 
			this.txtClientId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
			this.txtClientId.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtClientId.Icon = null;
			this.txtClientId.Location = new System.Drawing.Point(140, 45);
			this.txtClientId.MaxCharacters = 32767;
			this.txtClientId.Multiline = false;
			this.txtClientId.Name = "txtClientId";
			this.txtClientId.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
			this.txtClientId.PasswordChar = false;
			this.txtClientId.PlaceHolderColor = System.Drawing.Color.Gray;
			this.txtClientId.PlaceHolderText = "";
			this.txtClientId.ReadOnly = false;
			this.txtClientId.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtClientId.SelectionStart = 0;
			this.txtClientId.Size = new System.Drawing.Size(250, 25);
			this.txtClientId.TabIndex = 3;
			this.txtClientId.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// lblClientId
			// 
			this.lblClientId.Location = new System.Drawing.Point(80, 45);
			this.lblClientId.Name = "lblClientId";
			this.lblClientId.Size = new System.Drawing.Size(60, 25);
			this.lblClientId.TabIndex = 4;
			this.lblClientId.Text = "Client ID:";
			this.lblClientId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblAccessToken
			// 
			this.lblAccessToken.Location = new System.Drawing.Point(80, 80);
			this.lblAccessToken.Name = "lblAccessToken";
			this.lblAccessToken.Size = new System.Drawing.Size(60, 25);
			this.lblAccessToken.TabIndex = 5;
			this.lblAccessToken.Text = "Token:";
			this.lblAccessToken.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblRefreshToken
			// 
			this.lblRefreshToken.Location = new System.Drawing.Point(80, 110);
			this.lblRefreshToken.Name = "lblRefreshToken";
			this.lblRefreshToken.Size = new System.Drawing.Size(60, 25);
			this.lblRefreshToken.TabIndex = 6;
			this.lblRefreshToken.Text = "Refresh:";
			this.lblRefreshToken.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// SpotifyPluginConfigView
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(600, 200);
			this.Controls.Add(this.lblRefreshToken);
			this.Controls.Add(this.lblAccessToken);
			this.Controls.Add(this.lblClientId);
			this.Controls.Add(this.txtClientId);
			this.Controls.Add(this.txtRefreshToken);
			this.Controls.Add(this.btnAuthorize);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtAccessToken);
			this.Location = new System.Drawing.Point(0, 0);
			this.Name = "SpotifyPluginConfigView";
			this.Load += new System.EventHandler(this.SpotifyPluginConfigView_Load);
			this.Controls.SetChildIndex(this.txtAccessToken, 0);
			this.Controls.SetChildIndex(this.btnOk, 0);
			this.Controls.SetChildIndex(this.btnAuthorize, 0);
			this.Controls.SetChildIndex(this.txtRefreshToken, 0);
			this.Controls.SetChildIndex(this.txtClientId, 0);
			this.Controls.SetChildIndex(this.lblClientId, 0);
			this.Controls.SetChildIndex(this.lblAccessToken, 0);
			this.Controls.SetChildIndex(this.lblRefreshToken, 0);
			this.ResumeLayout(false);

		}

		#endregion
		private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary btnOk;
		private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary btnAuthorize;
		private SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox txtAccessToken;
		private RoundedTextBox txtRefreshToken;
		private RoundedTextBox txtClientId;
		private System.Windows.Forms.Label lblClientId;
		private System.Windows.Forms.Label lblAccessToken;
		private System.Windows.Forms.Label lblRefreshToken;
	}
}
