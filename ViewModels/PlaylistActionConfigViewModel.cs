using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.ViewModels
{
    internal class PlaylistActionConfigViewModel : ISerializableConfigViewModel {
		public readonly PluginAction _action;
		public PlaylistActionConfigModel Configuration { get; set; }
		ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

		public PlaylistActionConfigViewModel (PluginAction action) {
			_action = action;
			Configuration = PlaylistActionConfigModel.Deserialize(_action.Configuration);
		}

		public void SetConfig () {
			_action.ConfigurationSummary = $"{PluginLanguageManager.PluginStrings.PlaylistActionSetPlaylist}: {Configuration.Name} ({PluginLanguageManager.PluginStrings.PlaylistActionTrack} {Configuration.Track + 1}) [{Configuration.Uri}]";
			_action.Configuration = Configuration.Serialize();
		}

		public bool SaveConfig () {
			try {
				SetConfig();
				MacroDeckLogger.Info(PluginInstance.Main, $"{GetType().Name}: config saved");
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, $"{GetType().Name}: Error while saving Config: {e.Message}\n{e.StackTrace}");
			}
			return true;
		}
	}
}
