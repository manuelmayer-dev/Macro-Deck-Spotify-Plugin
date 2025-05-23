using Develeon64.SpotifyPlugin.Actions;
using Develeon64.SpotifyPlugin.Views;
using SuchByte.MacroDeck;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Windows;
using Timer = System.Timers.Timer;
using Develeon64.SpotifyPlugin.Helpers;
using Develeon64.SpotifyPlugin.Managers;

namespace Develeon64.SpotifyPlugin
{
    public static class PluginInstance {
		public static Main Main { get; set; }
	}

	public class Main : MacroDeckPlugin {
		public override bool CanConfigure => true;

        public const uint TimerIntervalMs = 1000 * 2;

        private ToolTip _statusToolTip = new ToolTip();
        private ContentSelectorButton _statusButton = new ContentSelectorButton();

		private MainWindow _mainWindow;

        private readonly Timer _timer = new Timer()
        {
			Interval = TimerIntervalMs,
			Enabled = false,
        };

		public Main () {
			PluginInstance.Main ??= this;
            _timer.Elapsed += UpdateTimer_Elapsed;
        }

		public override void Enable () {
			PluginLanguageManager.Initialize();
			SpotifyHelper.Initialize();

			Actions = new List<PluginAction> {
				new PauseAction(),
				new SkipAction(),
				new PreviousAction(),
				new LoopAction(),
				new ShuffleAction(),
				new VolumeAction(),
				new PlaylistAction(),
				new LibraryActionAction(),
			};

			MacroDeck.OnMacroDeckLoaded += MacroDeck_OnMacroDeckLoaded;
			MacroDeck.OnMainWindowLoad += MacroDeck_OnMainWindowLoad;
			SpotifyHelper.ConnectionStateChanged += SpotifyHelper_ConnectionStateChanged;

			if (MacroDeck.MainWindow is { IsDisposed: false, IsHandleCreated: true })
				MacroDeck_OnMainWindowLoad(MacroDeck.MainWindow, EventArgs.Empty);

			SpotifyHelper.Connect(CredentialHelper.GetCredentials()?.AccessToken ?? null);
		}

		private void MacroDeck_OnMacroDeckLoaded (object sender, EventArgs e)
        {
            _timer.Enabled = true;
        }
		
		private void MacroDeck_OnMainWindowLoad (object sender, EventArgs e) {
			_mainWindow = sender as MainWindow;

            _statusToolTip = new ToolTip();
			_statusButton = new ContentSelectorButton() {
				BackgroundImageLayout = ImageLayout.Stretch,
			};
			_statusButton.Click += StatusButton_Click;
			_mainWindow?.contentButtonPanel.Controls.Add(_statusButton);
			
			SpotifyHelper.CheckTokenRefresh();
			UpdateStatus();
		}

		private void SpotifyHelper_ConnectionStateChanged (object sender, EventArgs e) {
			UpdateStatus();
		}

		private void StatusButton_Click (object sender, EventArgs e) {
			var spotifyToken = CredentialHelper.GetCredentials()?.AccessToken;
			if (spotifyToken == null) {
				OpenConfigurator();
				return;
			}

			if (SpotifyHelper.IsConnected)
				SpotifyHelper.Disconnect();
			else
				SpotifyHelper.Connect(spotifyToken);
		}

		private void UpdateTimer_Elapsed (object sender, EventArgs e)
        {
            if (!SpotifyHelper.IsConnected) return;
			SpotifyHelper.CheckTokenRefresh();
            SpotifyHelper.UpdateVars();
			UpdateStatus();
		}

		private void UpdateStatus ()
        {
            if (_mainWindow == null || _mainWindow.IsDisposed || _statusButton == null ||
                _statusButton.IsDisposed) return;
			
            _mainWindow.Invoke(new Action(() => {
                _statusButton.BackgroundImage = SpotifyHelper.IsConnected ? Properties.Resources.Spotify_Connected : Properties.Resources.Spotify_Disconnected;
                _statusToolTip.SetToolTip(_statusButton, "Spotify " + (SpotifyHelper.IsConnected ? $"Connected ({SpotifyHelper.UserName})" : "Disconnected"));
            }));
        }

		public override void OpenConfigurator ()
        {
            using var configurator = new PluginConfigurationWindow();
            configurator.ShowDialog();
        }
	}
}
