using Develeon64.SpotifyPlugin.Models;
using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.Views;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Actions {
	public class VolumeAction : PluginAction {
		public override string Name => PluginLanguageManager.PluginStrings.VolumeActionName;
		public override string Description => PluginLanguageManager.PluginStrings.VolumeActionDescription;
		public override bool CanConfigure => true;

		public override void Trigger (string clientId, ActionButton actionButton) {
			VolumeActionConfigModel model = VolumeActionConfigModel.Deserialize(this.Configuration);
			Enum.TryParse(typeof(EMode), model.Mode.ToString(), out object mode);
			switch (mode) {
				case EMode.Activate:
					SpotifyHelper.SetVolume(SpotifyHelper.Volume + model.Value);
					break;
				case EMode.Deactivate:
					SpotifyHelper.SetVolume(SpotifyHelper.Volume - model.Value);
					break;
				default:
					SpotifyHelper.SetVolume(model.Value);
					break;
			}
		}

		public override ActionConfigControl GetActionConfigControl (ActionConfigurator actionConfigurator) {
			return new VolumeActionConfigView(this);
		}
	}
}
