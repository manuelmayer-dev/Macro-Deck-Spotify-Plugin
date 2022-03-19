using System;

namespace Develeon64.SpotifyPlugin.Models {
	public class LoginCredentials : EventArgs {
		public string AccessToken { get; }
		public string RefreshToken { get; }

		public LoginCredentials (string accessToken, string refreshToken) {
			AccessToken = accessToken;
			RefreshToken = refreshToken;
		}
	}
}
