using Develeon64.SpotifyPlugin.Utils;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;

namespace Develeon64.SpotifyPlugin.Actions {
	public class SkipAction : PluginAction {
		public override string Name => PluginLanguageManager.PluginStrings.SkipActionName;
		public override string Description => PluginLanguageManager.PluginStrings.SkipActionDescription;
		public override bool CanConfigure => false;

		public override void Trigger (string clientId, ActionButton actionButton) {
			SpotifyHelper.Skip();
		}
	}
}
