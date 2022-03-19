using System;
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.Views {
	public partial class PauseActionConfigView {
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
			this.lblMode = new System.Windows.Forms.Label();
			this.rbtPause = new System.Windows.Forms.RadioButton();
			this.rbtPlay = new System.Windows.Forms.RadioButton();
			this.rbtToggle = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// lblMode
			// 
			this.lblMode.Location = new System.Drawing.Point(5, 100);
			this.lblMode.Name = "lblMode";
			this.lblMode.Size = new System.Drawing.Size(850, 30);
			this.lblMode.TabIndex = 0;
			this.lblMode.Text = "Working mode";
			this.lblMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// rbtPause
			// 
			this.rbtPause.Location = new System.Drawing.Point(360, 140);
			this.rbtPause.Name = "rbtPause";
			this.rbtPause.Size = new System.Drawing.Size(250, 30);
			this.rbtPause.TabIndex = 1;
			this.rbtPause.Text = "Pause";
			this.rbtPause.UseMnemonic = false;
			this.rbtPause.UseVisualStyleBackColor = true;
			// 
			// rbtPlay
			// 
			this.rbtPlay.Location = new System.Drawing.Point(360, 180);
			this.rbtPlay.Name = "rbtPlay";
			this.rbtPlay.Size = new System.Drawing.Size(250, 30);
			this.rbtPlay.TabIndex = 2;
			this.rbtPlay.Text = "Play";
			this.rbtPlay.UseMnemonic = false;
			this.rbtPlay.UseVisualStyleBackColor = true;
			// 
			// rbtToggle
			// 
			this.rbtToggle.Checked = true;
			this.rbtToggle.Location = new System.Drawing.Point(360, 220);
			this.rbtToggle.Name = "rbtToggle";
			this.rbtToggle.Size = new System.Drawing.Size(250, 30);
			this.rbtToggle.TabIndex = 3;
			this.rbtToggle.TabStop = true;
			this.rbtToggle.Text = "Toggle";
			this.rbtToggle.UseMnemonic = false;
			this.rbtToggle.UseVisualStyleBackColor = true;
			// 
			// PauseActionConfigView
			// 
			this.Controls.Add(this.rbtToggle);
			this.Controls.Add(this.rbtPlay);
			this.Controls.Add(this.rbtPause);
			this.Controls.Add(this.lblMode);
			this.Name = "PauseActionConfigView";
			this.Load += new System.EventHandler(this.PauseActionConfigView_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton rbtPause;
		private System.Windows.Forms.RadioButton rbtPlay;
		private System.Windows.Forms.RadioButton rbtToggle;
		private System.Windows.Forms.Label lblMode;
	}
}
