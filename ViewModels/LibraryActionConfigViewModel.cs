using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.ViewModels
{
    internal class LibraryActionConfigViewModel : ISerializableConfigViewModel {
		public readonly PluginAction _action;
		public LibraryActionConfigModel Configuration { get; set; }
		ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

		public LibraryActionConfigViewModel (PluginAction action) {
			_action = action;
			Configuration = LibraryActionConfigModel.Deserialize(_action.Configuration);
		}

		public void SetConfig () {
			_action.ConfigurationSummary = Configuration.Mode switch {
				EMode.Activate => PluginLanguageManager.PluginStrings.LibraryActionModeActivate,
				EMode.Deactivate => PluginLanguageManager.PluginStrings.LibraryActionModeDeactivate,
				_ => PluginLanguageManager.PluginStrings.LibraryActionModeToggle,
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
