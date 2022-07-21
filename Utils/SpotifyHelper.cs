using Develeon64.SpotifyPlugin.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Develeon64.SpotifyPlugin.Utils {
	public static class SpotifyHelper {
		private static readonly int callbackPort = 5000;
		private static readonly Uri callbackUri = new Uri($"http://localhost:{callbackPort}/callback");

		private static EmbedIOAuthServer _server;
		private static SpotifyClient spotify;
		public static event EventHandler LoginSuccessful;
		public static event EventHandler ConnectionStateChanged;

		private static string _clientId;
		private static PKCETokenResponse _token;
		private static DateTime tokenExpire;
		private static string _verifier;

		public static bool IsConnected {
			get { return spotify != null; }
		}

		public static bool IsPlaying {
			get { return bool.Parse(VariableManager.ListVariables.FirstOrDefault(v => v.Name.Equals("spotify_playing")).Value); }
			set { SetPlaying(value); }
		}

		public static PlayerSetRepeatRequest.State LoopMode {
			get {
				Enum.TryParse(typeof(PlayerSetRepeatRequest.State), VariableManager.ListVariables.FirstOrDefault(v => v.Name.Equals("spotify_playing_loop")).Value, out object mode);
				return (PlayerSetRepeatRequest.State)mode;
			}
			set { SetLoop(value); }
		}

		public static bool IsShuffle {
			get { return bool.Parse(VariableManager.ListVariables.FirstOrDefault(v => v.Name.Equals("spotify_playing_shuffle")).Value); }
			set { SetShuffle(value); }
		}
		public static int Volume {
			get { return int.Parse(VariableManager.ListVariables.FirstOrDefault(v => v.Name.Equals("spotify_playing_volume")).Value); }
			set { SetVolume(value); }
		}

		public static void Initialize () {
			_clientId = PluginConfiguration.GetValue(PluginInstance.Main, "clientID");
		}

		public static void Connect (string token) {
			if (token == null) return;

			SpotifyClientConfig spotifyConfig = SpotifyClientConfig.CreateDefault(token);
			spotify = new SpotifyClient(spotifyConfig);

			ConnectionStateChanged.Invoke(null, EventArgs.Empty);
			UpdateVars();
		}

		public static async void Authorize (string clientId) {
			_clientId = clientId;

			_server = new EmbedIOAuthServer(callbackUri, callbackPort);
			await _server.Start();
			_server.AuthorizationCodeReceived += OnCodeReceived;

			var (verifier, challenge) = PKCEUtil.GenerateCodes();
			_verifier = verifier;

			LoginRequest login = new LoginRequest(_server.BaseUri, _clientId, LoginRequest.ResponseType.Code) {
				CodeChallengeMethod = "S256",
				CodeChallenge = challenge,
				Scope = new List<string> {
					Scopes.AppRemoteControl,
					Scopes.PlaylistModifyPrivate,
					Scopes.PlaylistModifyPublic,
					Scopes.PlaylistReadCollaborative,
					Scopes.PlaylistReadPrivate,
					Scopes.Streaming,
					Scopes.UgcImageUpload,
					Scopes.UserFollowModify,
					Scopes.UserFollowRead,
					Scopes.UserLibraryModify,
					Scopes.UserLibraryRead,
					Scopes.UserModifyPlaybackState,
					Scopes.UserReadCurrentlyPlaying,
					Scopes.UserReadEmail,
					Scopes.UserReadPlaybackPosition,
					Scopes.UserReadPlaybackState,
					Scopes.UserReadPrivate,
					Scopes.UserReadRecentlyPlayed,
					Scopes.UserTopRead,
				}
			};

			BrowserUtil.Open(login.ToUri());
		}

		public static void Disconnect () {
			spotify = null;
			ConnectionStateChanged.Invoke(null, EventArgs.Empty);
		}

		private static async Task OnCodeReceived (object sender, AuthorizationCodeResponse response) {
			await _server.Stop();

			PKCETokenRequest request = new PKCETokenRequest(_clientId, response.Code, callbackUri, _verifier);
			_token = await new OAuthClient().RequestToken(request);

			LoginSuccessful.Invoke(sender, new LoginCredentials(_token.AccessToken, _token.RefreshToken));
		}

		public static async void CheckTokenRefresh () {
			if (_token == null || tokenExpire.Subtract(DateTime.Now).TotalMinutes < 5) {
				LoginCredentials credentials = CredentialHelper.GetCredentials();
				if (credentials == null || string.IsNullOrWhiteSpace(credentials.RefreshToken) || string.IsNullOrEmpty(_clientId)) return;

				try {
					PKCETokenRefreshRequest request = new PKCETokenRefreshRequest(_clientId, credentials.RefreshToken);
					_token = await new OAuthClient().RequestToken(request);
					SpotifyClientConfig config = SpotifyClientConfig.CreateDefault(_token.AccessToken);
					spotify = new SpotifyClient(config);
					tokenExpire = DateTime.Now.AddSeconds(_token.ExpiresIn);
				}
				catch (APIException ex) {
					MacroDeckLogger.Error(PluginInstance.Main, ex.Response.Body.ToString());
				}
				catch (Exception ex) {
					MacroDeckLogger.Error(PluginInstance.Main, $"Error: {ex.Message}");
				}

				CredentialHelper.UpdateCredentials(_token.AccessToken, _token.RefreshToken);
			}
		}

		public static async void UpdateVars (bool wait = false) {
			if (spotify == null) return;

			try {
				if (wait)
					Thread.Sleep(200);

				CurrentlyPlayingContext item = await spotify.Player.GetCurrentPlayback();
				if (item != null && item.Item is FullTrack track) {
					string artists = "";
					foreach (SimpleArtist artist in track.Artists)
						artists += ", " + artist.Name;
					artists = artists.Substring(2);

					VariableManager.SetValue("spotify_playing_shuffle", item.ShuffleState, VariableType.Bool, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_loop", item.RepeatState.Substring(0, 1).ToUpper() + item.RepeatState.Substring(1), VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_volume", item.Device.VolumePercent, VariableType.Integer, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_track_in_library", (await spotify.Library.CheckTracks(new LibraryCheckTracksRequest(new List<string>(new string[] { track.Id }))))[0], VariableType.Bool, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_artists", artists, VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_album", track.Album.Name, VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_title", track.Name, VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_link", track.ExternalUrls["spotify"], VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing", item.IsPlaying, VariableType.Bool, PluginInstance.Main, null);
				}
				else {
					VariableManager.SetValue("spotify_playing_shuffle", false, VariableType.Bool, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_loop", "Off", VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_volume", 100, VariableType.Integer, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_track_in_library", false, VariableType.Bool, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_artists", "", VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_album", "", VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_title", "", VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing_link", "https://open.spotify.com/track/", VariableType.String, PluginInstance.Main, null);
					VariableManager.SetValue("spotify_playing", false, VariableType.Bool, PluginInstance.Main, null);
				}
			}
			catch (APIException e) {
				if (e.Response.StatusCode != System.Net.HttpStatusCode.Forbidden && ConnectionStateChanged != null) {
					spotify = null;
					ConnectionStateChanged(null, EventArgs.Empty);
				}
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, "Error: " + e.Message + "\n" + e.StackTrace);
			}
		}

		public static async void SetPlaying (bool playing) {
			if (spotify == null) return;

			try {
				if (playing)
					await spotify.Player.ResumePlayback();
				else
					await spotify.Player.PausePlayback();
			}
			catch (APIException e) {
				if (e.Response.StatusCode != System.Net.HttpStatusCode.Forbidden && ConnectionStateChanged != null) {
					spotify = null;
					ConnectionStateChanged(null, EventArgs.Empty);
				}
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, "Error: " + e.Message + "\n" + e.StackTrace);
			}

			UpdateVars(true);
		}

		public static async void Skip () {
			if (spotify == null) return;

			try {
				await spotify.Player.SkipNext();
			}
			catch (APIException e) {
				if (e.Response.StatusCode != System.Net.HttpStatusCode.Forbidden && ConnectionStateChanged != null) {
					spotify = null;
					ConnectionStateChanged(null, EventArgs.Empty);
				}
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, "Error: " + e.Message + "\n" + e.StackTrace);
			}

			UpdateVars(true);
		}

		public static async void Previous () {
			if (spotify == null) return;

			try {
				await spotify.Player.SkipPrevious();
			}
			catch (APIException e) {
				if (e.Response.StatusCode != System.Net.HttpStatusCode.Forbidden && ConnectionStateChanged != null) {
					spotify = null;
					ConnectionStateChanged(null, EventArgs.Empty);
				}
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, "Error: " + e.Message + "\n" + e.StackTrace);
			}

			UpdateVars(true);
		}

		public static async void SetLoop (PlayerSetRepeatRequest.State state) {
			if (spotify == null) return;

			try {
				await spotify.Player.SetRepeat(new PlayerSetRepeatRequest(state));
			}
			catch (APIException e) {
				if (e.Response.StatusCode != System.Net.HttpStatusCode.Forbidden && ConnectionStateChanged != null) {
					spotify = null;
					ConnectionStateChanged(null, EventArgs.Empty);
				}
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, "Error: " + e.Message + "\n" + e.StackTrace);
			}

			UpdateVars(true);
		}

		public static async void SetShuffle (bool shuffle) {
			if (spotify == null) return;

			try {
				await spotify.Player.SetShuffle(new PlayerShuffleRequest(shuffle));
			}
			catch (APIException e) {
				if (e.Response.StatusCode != System.Net.HttpStatusCode.Forbidden && ConnectionStateChanged != null) {
					spotify = null;
					ConnectionStateChanged(null, EventArgs.Empty);
				}
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, "Error: " + e.Message + "\n" + e.StackTrace);
			}

			UpdateVars(true);
		}

		public static async void SetVolume (int volume) {
			if (spotify == null) return;

			try {
				if (volume < 0) volume = 0;
				if (volume > 100) volume = 100;

				await spotify.Player.SetVolume(new PlayerVolumeRequest(volume));
			}
			catch (APIException e) {
				if (e.Response.StatusCode != System.Net.HttpStatusCode.Forbidden && ConnectionStateChanged != null) {
					spotify = null;
					ConnectionStateChanged(null, EventArgs.Empty);
				}
			}
			catch (Exception e) {
				MacroDeckLogger.Error(PluginInstance.Main, "Error: " + e.Message + "\n" + e.StackTrace);
			}

			UpdateVars(true);
		}

		public static async void SetLibrary (bool add) {
			switch (add) {
				case true:
					AddLibrary();
					break;
				case false:
					RemoveLibrary();
					break;
				default:
					break;
			}
		}

		public static async void AddLibrary (FullTrack track = null) {
			if (spotify != null && spotify.Player != null) {
				if (track == null) {
					PlayerCurrentlyPlayingRequest request = new PlayerCurrentlyPlayingRequest(PlayerCurrentlyPlayingRequest.AdditionalTypes.Track);
					CurrentlyPlaying playing = await spotify.Player.GetCurrentlyPlaying(request);
					if (playing == null) return;
					track = (FullTrack)playing.Item;
				}
				await spotify.Library.SaveTracks(new LibrarySaveTracksRequest(new List<string>(new string[] { track.Id })));
			}
		}

		public static async void RemoveLibrary (FullTrack track = null) {
			if (spotify != null && spotify.Player != null) {
				if (track == null) {
					PlayerCurrentlyPlayingRequest request = new PlayerCurrentlyPlayingRequest(PlayerCurrentlyPlayingRequest.AdditionalTypes.Track);
					CurrentlyPlaying playing = await spotify.Player.GetCurrentlyPlaying(request);
					if (playing == null) return;
					track = (FullTrack)playing.Item;
				}
				await spotify.Library.RemoveTracks(new LibraryRemoveTracksRequest(new List<string>(new string[] { track.Id })));
			}
		}

		public static async void SwitchLibrary () {
			if (spotify != null && spotify.Player != null) {
				PlayerCurrentlyPlayingRequest request = new PlayerCurrentlyPlayingRequest(PlayerCurrentlyPlayingRequest.AdditionalTypes.Track);
				CurrentlyPlaying playing = await spotify.Player.GetCurrentlyPlaying(request);
				if (playing == null) return;
				FullTrack track = (FullTrack)playing.Item;
				if ((await spotify.Library.CheckTracks(new LibraryCheckTracksRequest(new List<string>(new string[] { track.Id }))))[0])
					RemoveLibrary(track);
				else
					AddLibrary(track);
			}
		}

		public static async void PlayLibrary (int track = 0) {
			try {
				PlayerResumePlaybackRequest request = new PlayerResumePlaybackRequest() {
					OffsetParam = new PlayerResumePlaybackRequest.Offset() { Position = track },
					Uris = new List<string>(),
				};
				foreach (Device device in (await spotify.Player.GetAvailableDevices()).Devices) {
					if (device.Name.ToLower() == Environment.MachineName.ToLower()) {
						request.DeviceId = device.Id;
						break;
					}
				}
				foreach (SavedTrack t in await GetLibraryTracks())
					request.Uris.Add(t.Track.Uri);
				await spotify.Player.ResumePlayback(request);
			}
			catch (Exception ex) { }
		}

		public static async Task<List<SavedTrack>> GetLibraryTracks () {
			List<SavedTrack> tracks = new List<SavedTrack>();
			LibraryTracksRequest request = new LibraryTracksRequest() {
				Limit = 50,
				Offset = 0,
			};

			var response = await spotify.Library.GetTracks(request);
			tracks.AddRange(response.Items);
			while (response.Next != null) {
				request.Offset += 50;
				if (request.Offset > 100000) break;
				response = await spotify.Library.GetTracks(request);
				tracks.AddRange(response.Items);
			}
			return tracks;
		}

		public static async Task<List<SimplePlaylist>> GetPlaylists () {
			List<SimplePlaylist> playlists = new List<SimplePlaylist>();
			PlaylistCurrentUsersRequest request = new PlaylistCurrentUsersRequest() {
				Limit = 50,
				Offset = 0,
			};
			var response = await spotify.Playlists.CurrentUsers(request);
			playlists.AddRange(response.Items);
			while (response.Next != null) {
				request.Offset += 50;
				if (request.Offset > 100000) break;
				response = await spotify.Playlists.CurrentUsers(request);
				playlists.AddRange(response.Items);
			}

			return playlists;
		}

		public static async void SetPlaylist (string id, int track = 0) {
			try {
				PlayerResumePlaybackRequest resumeRequest = new PlayerResumePlaybackRequest() {
					ContextUri = id,
					OffsetParam = new PlayerResumePlaybackRequest.Offset() { Position = track },
				};
				foreach (Device device in (await spotify.Player.GetAvailableDevices()).Devices) {
					if (device.Name.ToLower() == Environment.MachineName.ToLower()) {
						resumeRequest.DeviceId = device.Id;
						break;
					}
				}
				await spotify.Player.ResumePlayback(resumeRequest);
			}
			catch (Exception) { }
		}
	}
}
