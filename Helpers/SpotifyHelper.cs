﻿using Develeon64.SpotifyPlugin.Models;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using SuchByte.MacroDeck.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Develeon64.SpotifyPlugin.Constants;
using Develeon64.SpotifyPlugin.Utils;

namespace Develeon64.SpotifyPlugin.Helpers
{
    public static class SpotifyHelper
    {
        private const int CallbackPort = 5000;
        private static readonly Uri CallbackUri = new Uri($"http://127.0.0.1:{CallbackPort}/callback");

        private static EmbedIOAuthServer _server;
        private static SpotifyClient _spotify;
        public static event EventHandler LoginSuccessful;
        public static event EventHandler ConnectionStateChanged;

        private static string _clientId;
        private static PKCETokenResponse _token;
        private static DateTime _tokenExpire;
        private static string _verifier;

        public static bool IsConnected => _spotify != null;

        public static bool IsPlaying =>
            bool.Parse(VariableManager.Variables.FirstOrDefault(v => v.Name.Equals("spotify_playing"))?.Value ??
                       string.Empty);

        public static bool IsShuffle =>
            bool.Parse(VariableManager.Variables.FirstOrDefault(v => v.Name.Equals("spotify_playing_shuffle"))?.Value ??
                       string.Empty);

        public static int Volume =>
            int.Parse(VariableManager.Variables.FirstOrDefault(v => v.Name.Equals("spotify_playing_volume"))?.Value ??
                      string.Empty);

        public static bool IsPremium { get; private set; } = false;

        public static string UserName { get; private set; } = string.Empty;

        public static void Initialize()
        {
            _clientId = PluginConfiguration.GetValue(PluginInstance.Main, "clientID");
        }

        public static void Connect(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return;

            Retry.Do(async () =>
            {
                try
                {
                    var spotifyConfig = SpotifyClientConfig.CreateDefault(token);
                    _spotify = new SpotifyClient(spotifyConfig);
                    var userProfile = _spotify.UserProfile.Current().Result;
                    IsPremium = userProfile.Product.Equals("premium");
                    UserName = userProfile.DisplayName;
                }
                catch (APIException ex)
                {
                    OnApiError(ex);
                }
                catch
                {
                    // ignored
                }

                ConnectionStateChanged?.Invoke(null, EventArgs.Empty);
                await UpdateVars();
            }, TimeSpan.FromSeconds(1));
        }

        public static async Task Authorize(string clientId)
        {
            try
            {
                _clientId = clientId;

                _server = new EmbedIOAuthServer(CallbackUri, CallbackPort);
                await _server.Start();
                _server.AuthorizationCodeReceived += OnCodeReceived;

                var (verifier, challenge) = PKCEUtil.GenerateCodes();
                _verifier = verifier;

                var login = new LoginRequest(_server.BaseUri, _clientId, LoginRequest.ResponseType.Code)
                {
                    CodeChallengeMethod = "S256",
                    CodeChallenge = challenge,
                    Scope = new List<string>
                    {
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
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static void Disconnect()
        {
            _spotify = null;
            ConnectionStateChanged?.Invoke(null, EventArgs.Empty);
        }

        private static async Task OnCodeReceived(object sender, AuthorizationCodeResponse response)
        {
            try
            {
                await _server.Stop();

                var request = new PKCETokenRequest(_clientId, response.Code, CallbackUri, _verifier);
                _token = await new OAuthClient().RequestToken(request);
                LoginSuccessful?.Invoke(sender, new LoginCredentials(_token.AccessToken, _token.RefreshToken));
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

        }

        public static async Task CheckTokenRefresh()
        {
            if (_token != null && !(_tokenExpire.Subtract(DateTime.Now).TotalMinutes < 5)) return;

            var credentials = CredentialHelper.GetCredentials();
            if (credentials == null || string.IsNullOrWhiteSpace(credentials.RefreshToken) || string.IsNullOrEmpty(_clientId))
                return;

            try
            {
                var request = new PKCETokenRefreshRequest(_clientId, credentials.RefreshToken);
                _token = await new OAuthClient().RequestToken(request);
                var config = SpotifyClientConfig.CreateDefault(_token.AccessToken);
                _spotify = new SpotifyClient(config);
                _tokenExpire = DateTime.Now.AddSeconds(_token.ExpiresIn);
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            if (_token == null) return;
            CredentialHelper.UpdateCredentials(_token.AccessToken, _token.RefreshToken);
        }

        public static async Task UpdateVars(bool wait = false)
        {
            if (_spotify == null)
                return;

            try
            {
                if (wait)
                    Thread.Sleep(200);

                var item = await _spotify?.Player?.GetCurrentPlayback();
                if (item == null) return;
                if (item.Item is FullTrack track)
                {
                    var artists = track.Artists.Aggregate("", (current, artist) => current + ", " + artist.Name);
                    artists = artists[2..];

                    VariableManager.SetValue(VariableNames.PlayingShuffle, item.ShuffleState, VariableType.Bool, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingLoop, item.RepeatState[..1].ToUpper() + item.RepeatState[1..], VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingVolume, item?.Device?.VolumePercent ?? 0, VariableType.Integer, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.TrackInLibrary, (await _spotify?.Library?.CheckTracks(new LibraryCheckTracksRequest(new List<string>(
                        [track.Id]))))?[0] ?? false, VariableType.Bool, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingArtists, artists, VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingAlbum, track.Album.Name, VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingTitle, track.Name, VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingLink, track.ExternalUrls["spotify"], VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.IsPlaying, item.IsPlaying, VariableType.Bool, PluginInstance.Main, null);
                }
                else
                {
                    VariableManager.SetValue(VariableNames.PlayingShuffle, false, VariableType.Bool, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingLoop, "Off", VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingVolume, 100, VariableType.Integer, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.TrackInLibrary, false, VariableType.Bool, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingArtists, "", VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingAlbum, "", VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingTitle, "", VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.PlayingLink, "https://open.spotify.com/track/", VariableType.String, PluginInstance.Main, null);
                    VariableManager.SetValue(VariableNames.IsPlaying, false, VariableType.Bool, PluginInstance.Main, null);
                }
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static async Task SetPlaying(bool playing)
        {
            if (_spotify == null)
                return;

            try
            {
                if (playing)
                    await _spotify.Player.ResumePlayback();
                else
                    await _spotify.Player.PausePlayback();
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            await UpdateVars(true);
        }

        public static async Task Skip()
        {
            if (_spotify == null)
                return;

            try
            {
                await _spotify.Player.SkipNext();
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            await UpdateVars(true);
        }

        public static async Task Previous()
        {
            if (_spotify == null)
                return;

            try
            {
                await _spotify.Player.SkipPrevious();
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            await UpdateVars(true);
        }

        public static async Task SetLoop(PlayerSetRepeatRequest.State state)
        {
            if (_spotify == null)
                return;

            try
            {
                await _spotify.Player.SetRepeat(new PlayerSetRepeatRequest(state));
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            await UpdateVars(true);
        }

        public static async Task SetShuffle(bool shuffle)
        {
            if (_spotify == null)
                return;

            try
            {
                await _spotify.Player.SetShuffle(new PlayerShuffleRequest(shuffle));
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            await UpdateVars(true);
        }

        public static async Task SetVolume(int volume)
        {
            if (_spotify == null)
                return;

            try
            {
                if (volume < 0)
                    volume = 0;
                if (volume > 100)
                    volume = 100;

                await _spotify.Player.SetVolume(new PlayerVolumeRequest(volume));
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            await UpdateVars(true);
        }
        
        public static async Task AddLibrary(FullTrack track = null)
        {
            if (_spotify == null) return;
            try
            {
                if (track == null)
                {
                    var request =
                        new PlayerCurrentlyPlayingRequest(PlayerCurrentlyPlayingRequest.AdditionalTypes.Track);
                    var playing = await _spotify.Player.GetCurrentlyPlaying(request);
                    track = (FullTrack)playing.Item;
                }

                await _spotify.Library.SaveTracks(
                    new LibrarySaveTracksRequest(new List<string>([track.Id])));
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static async Task RemoveLibrary(FullTrack track = null)
        {
            if (_spotify == null) return;
            try
            {
                if (track == null)
                {
                    var request =
                        new PlayerCurrentlyPlayingRequest(PlayerCurrentlyPlayingRequest.AdditionalTypes.Track);
                    var playing = await _spotify.Player.GetCurrentlyPlaying(request);
                    track = (FullTrack)playing.Item;
                }

                await _spotify.Library.RemoveTracks(
                    new LibraryRemoveTracksRequest(new List<string>(new[] { track.Id })));
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static async Task SwitchLibrary()
        {
            if (_spotify == null) return;
            try
            {
                var request = new PlayerCurrentlyPlayingRequest(PlayerCurrentlyPlayingRequest.AdditionalTypes.Track);
                var playing = await _spotify.Player.GetCurrentlyPlaying(request);
                var track = (FullTrack)playing.Item;
                if ((await _spotify.Library.CheckTracks(
                        new LibraryCheckTracksRequest(new List<string>(new[] { track.Id }))))[0])
                    await RemoveLibrary(track);
                else
                    await AddLibrary(track);
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static async Task PlayLibrary(int track = 0)
        {
            try
            {
                var request = new PlayerResumePlaybackRequest()
                {
                    OffsetParam = new PlayerResumePlaybackRequest.Offset() { Position = track },
                    Uris = new List<string>(),
                };
                foreach (var device in (await _spotify.Player.GetAvailableDevices()).Devices.Where(device =>
                             device.Name.ToLower() == Environment.MachineName.ToLower()))
                {
                    request.DeviceId = device.Id;
                    break;
                }

                foreach (var t in await GetLibraryTracks())
                    request.Uris.Add(t.Track.Uri);

                await _spotify.Player.ResumePlayback(request);
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        public static async Task<List<SavedTrack>> GetLibraryTracks()
        {
            var tracks = new List<SavedTrack>();
            try
            {
                var request = new LibraryTracksRequest()
                {
                    Limit = 50,
                    Offset = 0,
                };

                var response = await _spotify.Library.GetTracks(request);
                if (response.Items != null)
                {
                    tracks.AddRange(response.Items);
                    while (response.Next != null)
                    {
                        request.Offset += 50;
                        if (request.Offset > 100000)
                            break;
                        response = await _spotify.Library.GetTracks(request);
                        if (response.Items != null) tracks.AddRange(response.Items);
                    }
                }
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            return tracks;
        }

        public static async Task<List<FullPlaylist>> GetPlaylists()
        {
            var playlists = new List<FullPlaylist>();
            try
            {
                var request = new PlaylistCurrentUsersRequest()
                {
                    Limit = 50,
                    Offset = 0,
                };
                var response = await _spotify.Playlists.CurrentUsers(request);
                if (response.Items != null)
                {
                    playlists.AddRange(response.Items);
                    while (response.Next != null)
                    {
                        request.Offset += 50;
                        if (request.Offset > 100000)
                            break;
                        response = await _spotify.Playlists.CurrentUsers(request);
                        if (response.Items != null) playlists.AddRange(response.Items);
                    }
                }
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }

            return playlists;
        }

        public static async Task SetPlaylist(string id, int track = 0)
        {
            try
            {
                var resumeRequest = new PlayerResumePlaybackRequest()
                {
                    ContextUri = id,
                    OffsetParam = new PlayerResumePlaybackRequest.Offset() { Position = track },
                };
                foreach (var device in (await _spotify.Player.GetAvailableDevices()).Devices.Where(device =>
                             device.Name.ToLower() == Environment.MachineName.ToLower()))
                {
                    resumeRequest.DeviceId = device.Id;
                    break;
                }

                await _spotify.Player.ResumePlayback(resumeRequest);
            }
            catch (APIException ex)
            {
                OnApiError(ex);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Error: " + ex.Message + "\n" + ex.StackTrace);
            }
        }

        private static void OnApiError(APIException ex)
        {
            if (ex.Response == null) return;
            switch (ex.Response.StatusCode)
            {
                case HttpStatusCode.Forbidden:
                    if (ex.Message.ToLower().Contains("premium"))
                        NotificationManager.Notify(PluginInstance.Main, "Spotify-Premium required",
                            "Unfortunately you need an active Spotify-Premium subscription to be able to control your player with Macro Deck.",
                            true);
                    else
                        goto default;
                    break;
                case HttpStatusCode.NotFound:
                    if (ex.Response.Body != null && ex.Response.Body.ToString()!.Contains("NO_ACTIVE_DEVICE"))
                        NotificationManager.Notify(PluginInstance.Main, "No Device",
                            "Please start the playback on your device first.", true);
                    else
                        goto default;
                    break;
                case HttpStatusCode.TooManyRequests:
                    NotificationManager.Notify(PluginInstance.Main, "Too many requests",
                        "There were too many actions made in a short time. Please wait a minute and try again.",
                        false);
                    break;
                case HttpStatusCode.Unauthorized:
                    MacroDeckLogger.Warning(PluginInstance.Main, "The Spotify api token is expired. The plugin will try to renew the token.");
                    break;
                case HttpStatusCode.ServiceUnavailable:
                    MacroDeckLogger.Warning(PluginInstance.Main, "The Spotify api service is temporarily unavailable. Please wait a minute and try again.");
                    break;
                default:
                    MacroDeckLogger.Warning(PluginInstance.Main,
                        $"There was an Error with the Spotify-API ({ex.Response.StatusCode}): {ex.Response.Body}");
                    break;
            }
        }
    }
}
