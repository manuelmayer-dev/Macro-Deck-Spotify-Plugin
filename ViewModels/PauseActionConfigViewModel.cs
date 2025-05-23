using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.ViewModels
{
    internal class PauseActionConfigViewModel : ISerializableConfigViewModel {
		public readonly PluginAction _action;
		public PauseActionConfigModel Configuration { get; set; }
		ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

		public PauseActionConfigViewModel (PluginAction action) {
			_action = action;
			Configuration = PauseActionConfigModel.Deserialize(_action.Configuration);
		}

		public void SetConfig () {
			_action.ConfigurationSummary = Configuration.Mode switch {
				EMode.Activate => PluginLanguageManager.PluginStrings.PauseActionModeActivate,
				EMode.Deactivate => PluginLanguageManager.PluginStrings.PauseActionModeDeactivate,
				_ => PluginLanguageManager.PluginStrings.PauseActionModeToggle,
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
