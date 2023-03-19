using Develeon64.SpotifyPlugin.Helpers;
using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.ViewModels;
using SpotifyAPI.Web;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.Views
{
    public partial class PlaylistActionConfigView : ActionConfigControl {
		private readonly PlaylistActionConfigViewModel _viewModel;
		private List<SimplePlaylist> playlists;

		public PlaylistActionConfigView (PluginAction action) {
			this.InitializeComponent();
			this._viewModel = new PlaylistActionConfigViewModel(action);
		}

		private async void PlaylistActionConfigView_Load (object sender, EventArgs e) {
			this.lblPlaylist.Text = PluginLanguageManager.PluginStrings.PlaylistActionPlaylist;
			this.lblTrackNumber.Text = PluginLanguageManager.PluginStrings.PlaylistActionTrack;

			this.cbxPlaylist.Items.Add(PluginLanguageManager.PluginStrings.PlaylistActionLibrary);

			this.playlists = await SpotifyHelper.GetPlaylists();
			this.playlists.Sort((x, y) => x.Name.CompareTo(y.Name));
			foreach (SimplePlaylist playlist in this.playlists)
				this.cbxPlaylist.Items.Add(playlist.Name);
			this.cbxPlaylist.SelectedIndex = this.playlists.FindIndex(p => p.Uri == this._viewModel.Configuration.Uri) + 1;
			this.nupTrackNumber.Value = this._viewModel.Configuration.Track + 1;
		}

		public override bool OnActionSave () {
			this._viewModel.Configuration.Name = this.cbxPlaylist.SelectedItem as string;
			this._viewModel.Configuration.Uri = this.cbxPlaylist.SelectedIndex == 0 ? "Library" : this.playlists[this.cbxPlaylist.SelectedIndex - 1].Uri;
			this._viewModel.Configuration.Track = (int)this.nupTrackNumber.Value - 1;
			return this._viewModel.SaveConfig();
		}

		private async void CbxPlaylist_SelectedIndexChanged (object sender, EventArgs e) {
			this.nupTrackNumber.Maximum = this.cbxPlaylist.SelectedIndex > 0
				? this.playlists[this.cbxPlaylist.SelectedIndex - 1].Tracks.Total ?? int.MaxValue
				: (await SpotifyHelper.GetLibraryTracks()).Count;
		}
	}
}
