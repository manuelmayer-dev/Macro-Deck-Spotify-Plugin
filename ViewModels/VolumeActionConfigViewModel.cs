using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.ViewModels
{
    internal class VolumeActionConfigViewModel : ISerializableConfigViewModel {
		public readonly PluginAction _action;
		public VolumeActionConfigModel Configuration { get; set; }
		ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

		public VolumeActionConfigViewModel (PluginAction action) {
			_action = action;
			Configuration = VolumeActionConfigModel.Deserialize(_action.Configuration);
		}

		public void SetConfig () {
			_action.ConfigurationSummary = Configuration.Mode switch {
				EMode.Activate => $"{PluginLanguageManager.PluginStrings.VolumeActionModeIncrease} {Configuration.Value}%",
				EMode.Deactivate => $"{PluginLanguageManager.PluginStrings.VolumeActionModeDecrease} {Configuration.Value}%",
				_ => $"{PluginLanguageManager.PluginStrings.VolumeActionModeSet} {Configuration.Value}%",
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
