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
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.Actions
{
    public class LoopAction : PluginAction {
		public override string Name => PluginLanguageManager.PluginStrings.LoopActionName;
		public override string Description => PluginLanguageManager.PluginStrings.LoopActionDescription;
		public override bool CanConfigure => true;

		public override void Trigger (string clientId, ActionButton actionButton) {
			Enum.TryParse(typeof(EMode), LoopActionConfigModel.Deserialize(this.Configuration).Mode.ToString(), out var mode);
            Retry.Do(() =>
            {
                switch (mode)
                {
                    case EMode.Toggle:
                        SpotifyHelper.SetLoop(SpotifyAPI.Web.PlayerSetRepeatRequest.State.Track);
                        break;
                    case EMode.Activate:
                        SpotifyHelper.SetLoop(SpotifyAPI.Web.PlayerSetRepeatRequest.State.Context);
                        break;
                    default:
                        SpotifyHelper.SetLoop(SpotifyAPI.Web.PlayerSetRepeatRequest.State.Off);
                        break;
                }
            }, TimeSpan.FromMilliseconds(100));
        }

		public override ActionConfigControl GetActionConfigControl (ActionConfigurator actionConfigurator) {
			return new LoopActionConfigView(this);
		}
	}
}
