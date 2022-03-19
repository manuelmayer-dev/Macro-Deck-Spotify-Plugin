using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.ViewModels;
using SpotifyAPI.Web;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace Develeon64.SpotifyPlugin.Views {
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

			this.playlists = await SpotifyHelper.GetPlaylists();
			foreach (SimplePlaylist playlist in playlists)
				this.cbxPlaylist.Items.Add(playlist.Name);
			this.cbxPlaylist.SelectedIndex = this.playlists.FindIndex(p => p.Uri == this._viewModel.Configuration.Uri);
			this.nupTrackNumber.Value = this._viewModel.Configuration.Track + 1;
		}

		public override bool OnActionSave () {
			this._viewModel.Configuration.Name = this.cbxPlaylist.SelectedItem as string;
			this._viewModel.Configuration.Uri = this.playlists[this.cbxPlaylist.SelectedIndex].Uri;
			this._viewModel.Configuration.Track = (int)this.nupTrackNumber.Value - 1;
			return this._viewModel.SaveConfig();
		}

		private void CbxPlaylist_SelectedIndexChanged (object sender, EventArgs e) {
			this.nupTrackNumber.Maximum = this.playlists[this.cbxPlaylist.SelectedIndex].Tracks.Total ?? int.MaxValue;
		}
	}
}
