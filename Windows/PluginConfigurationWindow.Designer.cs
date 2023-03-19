using Develeon64.SpotifyPlugin.Helpers;
using SuchByte.MacroDeck.GUI.CustomControls;

namespace Develeon64.SpotifyPlugin.Windows
{
    partial class PluginConfigurationWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            SpotifyHelper.LoginSuccessful -= SpotifyHelper_LoginSuccessful;
            SpotifyHelper.ConnectionStateChanged -= SpotifyHelper_ConnectionStateChanged;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pagePanel = new System.Windows.Forms.Panel();
            this.btnForward = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.btnBack = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pagePanel
            // 
            this.pagePanel.Location = new System.Drawing.Point(4, 29);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(741, 518);
            this.pagePanel.TabIndex = 2;
            // 
            // btnForward
            // 
            this.btnForward.BorderRadius = 8;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnForward.ForeColor = System.Drawing.Color.White;
            this.btnForward.HoverColor = System.Drawing.Color.Empty;
            this.btnForward.Icon = global::Develeon64.SpotifyPlugin.Properties.Resources.arrow_right_thick;
            this.btnForward.Location = new System.Drawing.Point(705, 553);
            this.btnForward.Name = "btnForward";
            this.btnForward.Progress = 0;
            this.btnForward.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.btnForward.Size = new System.Drawing.Size(40, 40);
            this.btnForward.TabIndex = 3;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.UseWindowsAccentColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBack
            // 
            this.btnBack.BorderRadius = 8;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.HoverColor = System.Drawing.Color.Silver;
            this.btnBack.Icon = global::Develeon64.SpotifyPlugin.Properties.Resources.arrow_left_thick;
            this.btnBack.Location = new System.Drawing.Point(4, 553);
            this.btnBack.Name = "btnBack";
            this.btnBack.Progress = 0;
            this.btnBack.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.btnBack.Size = new System.Drawing.Size(40, 40);
            this.btnBack.TabIndex = 4;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.UseWindowsAccentColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkGray;
            this.lblTitle.Location = new System.Drawing.Point(4, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(328, 25);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Spotify plugin setup wizard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PluginConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(749, 597);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.pagePanel);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PluginConfigurationWindow";
            this.Text = "PluginConfigurationWindow";
            this.Load += new System.EventHandler(this.PluginConfigurationWindow_Load);
            this.Controls.SetChildIndex(this.pagePanel, 0);
            this.Controls.SetChildIndex(this.btnForward, 0);
            this.Controls.SetChildIndex(this.btnBack, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pagePanel;
        private ButtonPrimary btnForward;
        private ButtonPrimary btnBack;
        private System.Windows.Forms.Label lblTitle;
    }
}