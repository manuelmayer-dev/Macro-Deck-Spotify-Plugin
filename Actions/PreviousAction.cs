using Develeon64.SpotifyPlugin.Utils;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;

namespace Develeon64.SpotifyPlugin.Actions {
	public class PreviousAction : PluginAction {
		public override string Name => PluginLanguageManager.PluginStrings.PreviousActionName;
		public override string Description => PluginLanguageManager.PluginStrings.PreviousActionDescription;
		public override bool CanConfigure => false;

		public override void Trigger (string clientId, ActionButton actionButton) {
			SpotifyHelper.Previous();
		}
	}
}
