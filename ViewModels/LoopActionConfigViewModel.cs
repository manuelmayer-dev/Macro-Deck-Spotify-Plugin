using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.ViewModels
{
    internal class LoopActionConfigViewModel : ISerializableConfigViewModel {
		public readonly PluginAction _action;
		public LoopActionConfigModel Configuration { get; set; }
		ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

		public LoopActionConfigViewModel (PluginAction action) {
			this._action = action;
			this.Configuration = LoopActionConfigModel.Deserialize(this._action.Configuration);
		}

		public void SetConfig () {
			this._action.ConfigurationSummary = Configuration.Mode switch {
				EMode.Activate => PluginLanguageManager.PluginStrings.LoopActionModeActivate,
				EMode.Deactivate => PluginLanguageManager.PluginStrings.LoopActionModeDeactivate,
				_ => PluginLanguageManager.PluginStrings.LoopActionModeToggle,
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
