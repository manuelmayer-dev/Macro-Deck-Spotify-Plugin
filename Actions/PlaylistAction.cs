using Develeon64.SpotifyPlugin.Models;
using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.Views;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Actions {
	public class PlaylistAction : PluginAction {
		public override string Name => PluginLanguageManager.PluginStrings.PlaylistActionName;
		public override string Description => PluginLanguageManager.PluginStrings.PlaylistActionDescription;
		public override bool CanConfigure => true;

		public override void Trigger (string clientId, ActionButton actionButton) {
			PlaylistActionConfigModel config = PlaylistActionConfigModel.Deserialize(this.Configuration);
			SpotifyHelper.SetPlaylist(config.Uri, config.Track);
		}

		public override ActionConfigControl GetActionConfigControl (ActionConfigurator actionConfigurator) {
			return new PlaylistActionConfigView(this);
		}
	}
}
