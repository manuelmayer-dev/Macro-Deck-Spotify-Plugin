using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.ViewModels
{
    internal class ShuffleActionConfigViewModel : ISerializableConfigViewModel {
		public readonly PluginAction _action;
		public ShuffleActionConfigModel Configuration { get; set; }
		ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

		public ShuffleActionConfigViewModel (PluginAction action) {
			_action = action;
			Configuration = ShuffleActionConfigModel.Deserialize(_action.Configuration);
		}

		public void SetConfig () {
			_action.ConfigurationSummary = Configuration.Mode switch {
				EMode.Activate => PluginLanguageManager.PluginStrings.ShuffleActionModeActivate,
				EMode.Deactivate => PluginLanguageManager.PluginStrings.ShuffleActionModeDeactivate,
				_ => PluginLanguageManager.PluginStrings.ShuffleActionModeToggle,
			};
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
