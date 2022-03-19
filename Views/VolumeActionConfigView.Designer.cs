using System;
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.Views {
	public partial class VolumeActionConfigView {
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
			this.rbtOn = new System.Windows.Forms.RadioButton();
			this.rbtToggle = new System.Windows.Forms.RadioButton();
			this.numVolume = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
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
			this.rbtOff.Text = "Decrease";
			this.rbtOff.UseMnemonic = false;
			this.rbtOff.UseVisualStyleBackColor = true;
			// 
			// rbtOn
			// 
			this.rbtOn.Location = new System.Drawing.Point(360, 180);
			this.rbtOn.Name = "rbtOn";
			this.rbtOn.Size = new System.Drawing.Size(250, 30);
			this.rbtOn.TabIndex = 2;
			this.rbtOn.Text = "Increase";
			this.rbtOn.UseMnemonic = false;
			this.rbtOn.UseVisualStyleBackColor = true;
			// 
			// rbtToggle
			// 
			this.rbtToggle.Checked = true;
			this.rbtToggle.Location = new System.Drawing.Point(360, 220);
			this.rbtToggle.Name = "rbtToggle";
			this.rbtToggle.Size = new System.Drawing.Size(250, 30);
			this.rbtToggle.TabIndex = 3;
			this.rbtToggle.TabStop = true;
			this.rbtToggle.Text = "Set";
			this.rbtToggle.UseMnemonic = false;
			this.rbtToggle.UseVisualStyleBackColor = true;
			// 
			// numVolume
			// 
			this.numVolume.Location = new System.Drawing.Point(360, 260);
			this.numVolume.Name = "numVolume";
			this.numVolume.Size = new System.Drawing.Size(60, 30);
			this.numVolume.TabIndex = 4;
			this.numVolume.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numVolume.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// VolumeActionConfigView
			// 
			this.Controls.Add(this.numVolume);
			this.Controls.Add(this.rbtToggle);
			this.Controls.Add(this.rbtOn);
			this.Controls.Add(this.rbtOff);
			this.Controls.Add(this.lblMode);
			this.Name = "VolumeActionConfigView";
			this.Load += new System.EventHandler(this.VolumeActionConfigView_Load);
			((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RadioButton rbtOff;
		private System.Windows.Forms.RadioButton rbtOn;
		private System.Windows.Forms.RadioButton rbtToggle;
		private System.Windows.Forms.Label lblMode;
		private System.Windows.Forms.NumericUpDown numVolume;
	}
}
