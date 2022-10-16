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
			this._action = action;
			this.Configuration = ShuffleActionConfigModel.Deserialize(this._action.Configuration);
		}

		public void SetConfig () {
			this._action.ConfigurationSummary = Configuration.Mode switch {
				EMode.Activate => PluginLanguageManager.PluginStrings.ShuffleActionModeActivate,
				EMode.Deactivate => PluginLanguageManager.PluginStrings.ShuffleActionModeDeactivate,
				_ => PluginLanguageManager.PluginStrings.ShuffleActionModeToggle,
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
