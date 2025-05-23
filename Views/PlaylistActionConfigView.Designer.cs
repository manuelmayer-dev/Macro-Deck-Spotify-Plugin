using SuchByte.MacroDeck.GUI.CustomControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.Views {
	public partial class PlaylistActionConfigView {
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
			this.cbxPlaylist = new SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox();
			this.lblPlaylist = new System.Windows.Forms.Label();
			this.lblTrackNumber = new System.Windows.Forms.Label();
			this.nupTrackNumber = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nupTrackNumber)).BeginInit();
			this.SuspendLayout();
			// 
			// cbxPlaylist
			// 
			this.cbxPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
			this.cbxPlaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxPlaylist.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.cbxPlaylist.Icon = null;
			this.cbxPlaylist.Location = new System.Drawing.Point(350, 125);
			this.cbxPlaylist.Name = "cbxPlaylist";
			this.cbxPlaylist.Padding = new System.Windows.Forms.Padding(8, 2, 8, 2);
			this.cbxPlaylist.SelectedIndex = -1;
			this.cbxPlaylist.SelectedItem = null;
			this.cbxPlaylist.Size = new System.Drawing.Size(250, 26);
			this.cbxPlaylist.TabIndex = 0;
			// 
			// lblPlaylist
			// 
			this.lblPlaylist.Location = new System.Drawing.Point(250, 125);
			this.lblPlaylist.Name = "lblPlaylist";
			this.lblPlaylist.Size = new System.Drawing.Size(100, 26);
			this.lblPlaylist.TabIndex = 1;
			this.lblPlaylist.Text = "Playlist:";
			this.lblPlaylist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblTrackNumber
			// 
			this.lblTrackNumber.Location = new System.Drawing.Point(250, 160);
			this.lblTrackNumber.Name = "lblTrackNumber";
			this.lblTrackNumber.Size = new System.Drawing.Size(100, 26);
			this.lblTrackNumber.TabIndex = 2;
			this.lblTrackNumber.Text = "Track:";
			this.lblTrackNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// nupTrackNumber
			// 
			this.nupTrackNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
			this.nupTrackNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.nupTrackNumber.ForeColor = System.Drawing.Color.White;
			this.nupTrackNumber.Location = new System.Drawing.Point(350, 160);
			this.nupTrackNumber.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.nupTrackNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nupTrackNumber.Name = "nupTrackNumber";
			this.nupTrackNumber.Size = new System.Drawing.Size(80, 26);
			this.nupTrackNumber.TabIndex = 3;
			this.nupTrackNumber.ThousandsSeparator = true;
			this.nupTrackNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// PlaylistActionConfigView
			// 
			this.Controls.Add(this.nupTrackNumber);
			this.Controls.Add(this.lblTrackNumber);
			this.Controls.Add(this.lblPlaylist);
			this.Controls.Add(this.cbxPlaylist);
			this.Name = "PlaylistActionConfigView";
			((System.ComponentModel.ISupportInitialize)(this.nupTrackNumber)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private SuchByte.MacroDeck.GUI.CustomControls.RoundedComboBox cbxPlaylist;
		private System.Windows.Forms.Label lblPlaylist;
		private System.Windows.Forms.Label lblTrackNumber;
		private System.Windows.Forms.NumericUpDown nupTrackNumber;
	}
}
