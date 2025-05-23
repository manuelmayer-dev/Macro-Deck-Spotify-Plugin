using Develeon64.SpotifyPlugin.Helpers;
using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.ViewModels;
using SpotifyAPI.Web;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Develeon64.SpotifyPlugin.Views
{
    public partial class PlaylistActionConfigView : ActionConfigControl {
		private readonly PlaylistActionConfigViewModel _viewModel;
		private List<FullPlaylist> playlists;

		public PlaylistActionConfigView (PluginAction action) {
			InitializeComponent();
			Load += PlaylistActionConfigView_Load;
			cbxPlaylist.SelectedIndexChanged += CbxPlaylist_SelectedIndexChanged;
			_viewModel = new PlaylistActionConfigViewModel(action);
		}

		private async void PlaylistActionConfigView_Load (object sender, EventArgs e) {
			lblPlaylist.Text = PluginLanguageManager.PluginStrings.PlaylistActionPlaylist;
			lblTrackNumber.Text = PluginLanguageManager.PluginStrings.PlaylistActionTrack;

			cbxPlaylist.Items.Add(PluginLanguageManager.PluginStrings.PlaylistActionLibrary);

			playlists = await SpotifyHelper.GetPlaylists();
			playlists.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.Ordinal));
			foreach (var playlist in playlists)
				cbxPlaylist.Items.Add(playlist.Name);
			cbxPlaylist.SelectedIndex = playlists.FindIndex(p => p.Uri == _viewModel.Configuration.Uri) + 1;
			nupTrackNumber.Value = _viewModel.Configuration.Track + 1;
		}

		public override bool OnActionSave () {
			_viewModel.Configuration.Name = cbxPlaylist.SelectedItem as string;
			_viewModel.Configuration.Uri = cbxPlaylist.SelectedIndex == 0 ? "Library" : playlists[cbxPlaylist.SelectedIndex - 1].Uri;
			_viewModel.Configuration.Track = (int)nupTrackNumber.Value - 1;
			return _viewModel.SaveConfig();
		}

		private async void CbxPlaylist_SelectedIndexChanged (object sender, EventArgs e) {
			nupTrackNumber.Maximum = cbxPlaylist.SelectedIndex > 0
				? playlists[cbxPlaylist.SelectedIndex - 1].Tracks.Total ?? int.MaxValue
				: (await SpotifyHelper.GetLibraryTracks()).Count;
		}
	}
}
