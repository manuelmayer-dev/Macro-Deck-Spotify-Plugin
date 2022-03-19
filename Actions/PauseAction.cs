using Develeon64.SpotifyPlugin.Models;
using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.Views;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Actions {
	public class PauseAction : PluginAction {
		public override string Name => PluginLanguageManager.PluginStrings.PauseActionName;
		public override string Description => PluginLanguageManager.PluginStrings.PauseActionDescription;
		public override bool CanConfigure => true;

		public override void Trigger (string clientId, ActionButton actionButton) {
			Enum.TryParse(typeof(EMode), PauseActionConfigModel.Deserialize(this.Configuration).Mode.ToString(), out object mode);
			switch (mode) {
				case EMode.Activate:
					SpotifyHelper.SetPlaying(true);
					break;
				case EMode.Deactivate:
					SpotifyHelper.SetPlaying(false);
					break;
				default:
					SpotifyHelper.SetPlaying(!SpotifyHelper.IsPlaying);
					break;
			}
		}

		public override ActionConfigControl GetActionConfigControl (ActionConfigurator actionConfigurator) {
			return new PauseActionConfigView(this);
		}
	}
}
