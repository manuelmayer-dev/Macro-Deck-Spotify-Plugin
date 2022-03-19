using Develeon64.SpotifyPlugin.Models;
using Develeon64.SpotifyPlugin.Utils;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.ViewModels {
	internal class PlaylistActionConfigViewModel : ISerializableConfigViewModel {
		public readonly PluginAction _action;
		public PlaylistActionConfigModel Configuration { get; set; }
		ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

		public PlaylistActionConfigViewModel (PluginAction action) {
			this._action = action;
			this.Configuration = PlaylistActionConfigModel.Deserialize(this._action.Configuration);
		}

		public void SetConfig () {
			this._action.ConfigurationSummary = $"{PluginLanguageManager.PluginStrings.PlaylistActionSetPlaylist}: {this.Configuration.Name} ({PluginLanguageManager.PluginStrings.PlaylistActionTrack} {this.Configuration.Track + 1}) [{this.Configuration.Uri}]";
			this._action.Configuration = this.Configuration.Serialize();
		}

		public bool SaveConfig () {
			try {
				this.SetConfig();
				MacroDeckLogger.Info(PluginInstance.Main, $"{this.GetType().Name}: config saved");
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, $"{this.GetType().Name}: Error while saving Config: {e.Message}\n{e.StackTrace}");
			}
			return true;
		}
	}
}
