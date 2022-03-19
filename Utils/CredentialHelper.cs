using Develeon64.SpotifyPlugin.Models;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Develeon64.SpotifyPlugin.Utils {
	public static class CredentialHelper {
		public static LoginCredentials GetCredentials () {
			try {
				List<Dictionary<string, string>> credentials = PluginCredentials.GetPluginCredentials(PluginInstance.Main);
				if (credentials == null || credentials.Count == 0) return null;

				Dictionary<string, string> credential = credentials.FirstOrDefault();
				return new LoginCredentials(credential?["access"], credential?["refresh"]);
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, $"Error while getting credentials: {e.Message}\n{e.StackTrace}");
				return null;
			}
		}

		public static void UpdateCredentials (LoginCredentials credentials) {
			UpdateCredentials(credentials.AccessToken, credentials.RefreshToken);
		}

		public static void UpdateCredentials (string accessToken, string refreshToken) {
			PluginCredentials.SetCredentials(PluginInstance.Main, new Dictionary<string, string> {
				["access"] = accessToken,
				["refresh"] = refreshToken,
			});
		}
	}
}
