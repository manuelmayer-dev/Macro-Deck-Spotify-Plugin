using Develeon64.SpotifyPlugin.Actions;
using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.Views;
using SuchByte.MacroDeck;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Develeon64.SpotifyPlugin {
	public static class PluginInstance {
		public static Main Main { get; set; }
	}

	public class Main : MacroDeckPlugin {
		public override bool CanConfigure => true;

		private ContentSelectorButton statusButton = new ContentSelectorButton();
		private MainWindow mainWindow;
		private System.Timers.Timer timer;

		public Main () {
			PluginInstance.Main ??= this;
		}

		public override void Enable () {
			PluginLanguageManager.Initialize();
			SpotifyHelper.Initialize();

			this.Actions = new List<PluginAction> {
				new PauseAction(),
				new SkipAction(),
				new PreviousAction(),
				new LoopAction(),
				new ShuffleAction(),
				new VolumeAction(),
				new PlaylistAction(),
			};

			MacroDeck.OnMainWindowLoad += this.MacroDeck_OnMainWindowLoad;
			SpotifyHelper.ConnectionStateChanged += this.SpotifyHelper_ConnectionStateChanged;

			if (MacroDeck.MainWindow != null && !MacroDeck.MainWindow.IsDisposed)
				this.MacroDeck_OnMainWindowLoad(MacroDeck.MainWindow, EventArgs.Empty);

			SpotifyHelper.Connect(CredentialHelper.GetCredentials()?.AccessToken ?? null);
			this.SetUpdateTimer();
		}

		private void SetUpdateTimer () {
			if (this.timer != null) {
				this.timer.Enabled = false;
				this.timer.Dispose();
			}

			if (SpotifyHelper.IsConnected) {
				this.timer = new System.Timers.Timer {
					Enabled = true,
					Interval = 2 * 1000,
				};
				this.timer.Elapsed += this.UpdateTimer_Elapsed;
			}
		}

		private void MacroDeck_OnMainWindowLoad (object sender, EventArgs e) {
			this.mainWindow = sender as MainWindow;

			this.statusButton = new ContentSelectorButton() {
				BackgroundImageLayout = ImageLayout.Stretch,
			};
			statusButton.Click += this.StatusButton_Click;
			mainWindow.contentButtonPanel.Controls.Add(statusButton);

			SpotifyHelper.CheckTokenRefresh();
			this.UpdateStatus();
		}

		private void SpotifyHelper_ConnectionStateChanged (object sender, EventArgs e) {
			this.UpdateStatus();
		}

		private void StatusButton_Click (object sender, EventArgs e) {
			string spotifyToken = CredentialHelper.GetCredentials()?.AccessToken;
			if (spotifyToken == null) {
				this.OpenConfigurator();
				return;
			}

			if (SpotifyHelper.IsConnected)
				SpotifyHelper.Disconnect();
			else
				SpotifyHelper.Connect(spotifyToken);
		}

		private void UpdateTimer_Elapsed (object sender, EventArgs e) {
			SpotifyHelper.CheckTokenRefresh();

			SpotifyHelper.UpdateVars();
			this.UpdateStatus();
		}

		private void UpdateStatus () {
			if (this.mainWindow != null && !this.mainWindow.IsDisposed && this.statusButton != null && !this.statusButton.IsDisposed) {
				this.mainWindow.Invoke(new Action(() => {
					this.statusButton.BackgroundImage = SpotifyHelper.IsConnected ? Properties.Resources.Spotify_Connected : Properties.Resources.Spotify_Disconnected;
				}));

				this.SetUpdateTimer();
			}
		}

		public override void OpenConfigurator () {
			using (var configurator = new SpotifyPluginConfigView()) {
				configurator.ShowDialog();
			}
		}
	}
}
