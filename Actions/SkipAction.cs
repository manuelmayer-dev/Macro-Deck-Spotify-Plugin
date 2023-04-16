using Develeon64.SpotifyPlugin.Helpers;
using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Utils;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Actions
{
    public class SkipAction : PluginAction {
		public override string Name => PluginLanguageManager.PluginStrings.SkipActionName;
		public override string Description => PluginLanguageManager.PluginStrings.SkipActionDescription;
		public override bool CanConfigure => false;

		public override void Trigger (string clientId, ActionButton actionButton) {
            Retry.Do(SpotifyHelper.Skip, TimeSpan.FromMilliseconds(100));
        }
	}
}
