using System;
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.Views {
	public partial class LoopActionConfigView {
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
			this.rbtOff = new System.Windows.Forms.RadioButton();
			this.rbtContext = new System.Windows.Forms.RadioButton();
			this.rbtSingle = new System.Windows.Forms.RadioButton();
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
			// rbtOff
			// 
			this.rbtOff.Location = new System.Drawing.Point(360, 140);
			this.rbtOff.Name = "rbtOff";
			this.rbtOff.Size = new System.Drawing.Size(250, 30);
			this.rbtOff.TabIndex = 1;
			this.rbtOff.Text = "No loop";
			this.rbtOff.UseMnemonic = false;
			this.rbtOff.UseVisualStyleBackColor = true;
			// 
			// rbtContext
			// 
			this.rbtContext.Checked = true;
			this.rbtContext.Location = new System.Drawing.Point(360, 180);
			this.rbtContext.Name = "rbtContext";
			this.rbtContext.Size = new System.Drawing.Size(250, 30);
			this.rbtContext.TabIndex = 2;
			this.rbtContext.TabStop = true;
			this.rbtContext.Text = "Loop playlist";
			this.rbtContext.UseMnemonic = false;
			this.rbtContext.UseVisualStyleBackColor = true;
			// 
			// rbtSingle
			// 
			this.rbtSingle.Location = new System.Drawing.Point(360, 220);
			this.rbtSingle.Name = "rbtSingle";
			this.rbtSingle.Size = new System.Drawing.Size(250, 30);
			this.rbtSingle.TabIndex = 3;
			this.rbtSingle.Text = "Loop song";
			this.rbtSingle.UseMnemonic = false;
			this.rbtSingle.UseVisualStyleBackColor = true;
			// 
			// LoopActionConfigView
			// 
			this.Controls.Add(this.rbtSingle);
			this.Controls.Add(this.rbtContext);
			this.Controls.Add(this.rbtOff);
			this.Controls.Add(this.lblMode);
			this.Name = "LoopActionConfigView";
			this.Load += new System.EventHandler(this.LoopActionConfigView_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton rbtOff;
		private System.Windows.Forms.RadioButton rbtContext;
		private System.Windows.Forms.RadioButton rbtSingle;
		private System.Windows.Forms.Label lblMode;
	}
}
