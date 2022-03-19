using Develeon64.SpotifyPlugin.Models;
using Develeon64.SpotifyPlugin.Utils;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Language;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Views {
	public partial class SpotifyPluginConfigView : DialogForm {
		public SpotifyPluginConfigView () {
			this.InitializeComponent();
		}

		private void SpotifyPluginConfigView_Load (object sender, EventArgs e) {
			this.btnAuthorize.Text = PluginLanguageManager.PluginStrings.SpotifyAuthorize;
			this.btnOk.Text = PluginLanguageManager.PluginStrings.SpotifyOkButton;

			this.txtClientId.Text = PluginConfiguration.GetValue(PluginInstance.Main, "clientID");
			this.txtAccessToken.Text = CredentialHelper.GetCredentials()?.AccessToken ?? "";
			this.txtRefreshToken.Text = CredentialHelper.GetCredentials()?.RefreshToken ?? "";
			SpotifyHelper.LoginSuccessful += this.SpotifyHelper_LoginSuccessful;
		}

		private void SpotifyHelper_LoginSuccessful (object sender, EventArgs e) {
			LoginCredentials args = e as LoginCredentials;

			this.Invoke(new Action(() => {
				this.txtAccessToken.Text = args.AccessToken;
				this.txtRefreshToken.Text = args.RefreshToken;
			}));
		}

		private void BtnAuthorize_Click (object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(this.txtClientId.Text)) {
				using (var msgBox = new MessageBox())
					msgBox.ShowDialog(LanguageManager.Strings.Error, "Please type in a Client ID.", System.Windows.Forms.MessageBoxButtons.OK);
				return;
			}
			SpotifyHelper.Authorize(this.txtClientId.Text);
		}

		private void BtnOk_Click (object sender, EventArgs e) {
			if (string.IsNullOrWhiteSpace(this.txtAccessToken.Text)) {
				using (var msgBox = new MessageBox())
					msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.TokenCannotBeEmpty, System.Windows.Forms.MessageBoxButtons.OK);
				return;
			}

			CredentialHelper.UpdateCredentials(this.txtAccessToken.Text, this.txtRefreshToken.Text);
			PluginConfiguration.SetValue(PluginInstance.Main, "clientID", this.txtClientId.Text);
			SpotifyHelper.Connect(this.txtAccessToken.Text);
			
			this.Close();
		}
	}
}
