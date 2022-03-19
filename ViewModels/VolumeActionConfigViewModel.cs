using Develeon64.SpotifyPlugin.Models;
using Develeon64.SpotifyPlugin.Utils;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.ViewModels {
	internal class VolumeActionConfigViewModel : ISerializableConfigViewModel {
		public readonly PluginAction _action;
		public VolumeActionConfigModel Configuration { get; set; }
		ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

		public VolumeActionConfigViewModel (PluginAction action) {
			this._action = action;
			this.Configuration = VolumeActionConfigModel.Deserialize(this._action.Configuration);
		}

		public void SetConfig () {
			this._action.ConfigurationSummary = Configuration.Mode switch {
				EMode.Activate => $"{PluginLanguageManager.PluginStrings.VolumeActionModeIncrease} {Configuration.Value}%",
				EMode.Deactivate => $"{PluginLanguageManager.PluginStrings.VolumeActionModeDecrease} {Configuration.Value}%",
				_ => $"{PluginLanguageManager.PluginStrings.VolumeActionModeSet} {Configuration.Value}%",
			};
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
