using Develeon64.SpotifyPlugin.Helpers;
using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Models;
using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.Views;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Actions
{
    public class LibraryActionAction : PluginAction {
		public override string Name => PluginLanguageManager.PluginStrings.LibraryActionName;
		public override string Description => PluginLanguageManager.PluginStrings.LibraryActionDescription;
		public override bool CanConfigure => true;

		public override void Trigger (string clientId, ActionButton actionButton) {
			Enum.TryParse(typeof(EMode), LibraryActionConfigModel.Deserialize(Configuration).Mode.ToString(), out var mode);
            Retry.Do(() =>
            {
                switch (mode)
                {
                    case EMode.Activate:
                        SpotifyHelper.AddLibrary();
                        break;
                    case EMode.Deactivate:
                        SpotifyHelper.RemoveLibrary();
                        break;
                    default:
                        SpotifyHelper.SwitchLibrary();
                        break;
                }
            }, TimeSpan.FromMilliseconds(100));
        }


		public override ActionConfigControl GetActionConfigControl (ActionConfigurator actionConfigurator) {
			return new LibraryActionConfigView(this);
		}
	}
}
