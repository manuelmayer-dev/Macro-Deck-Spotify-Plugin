using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Views
{
    public partial class PauseActionConfigView : ActionConfigControl {
		private readonly PauseActionConfigViewModel _viewModel;

		public PauseActionConfigView (PluginAction action) {
			this.InitializeComponent();
			this._viewModel = new PauseActionConfigViewModel(action);
		}

		private void PauseActionConfigView_Load (object sender, EventArgs e) {
			this.rbtPlay.Checked = this._viewModel.Configuration.Mode == Models.EMode.Activate;
			this.rbtPause.Checked = this._viewModel.Configuration.Mode == Models.EMode.Deactivate;
			this.rbtToggle.Checked = this._viewModel.Configuration.Mode == Models.EMode.Toggle;

			lblMode.Text = PluginLanguageManager.PluginStrings.PauseActionWorkingModeText;
			rbtPause.Text = PluginLanguageManager.PluginStrings.PauseActionPause;
			rbtPlay.Text = PluginLanguageManager.PluginStrings.PauseActionPlay;
			rbtToggle.Text = PluginLanguageManager.PluginStrings.PauseActionToggle;
		}

		public override bool OnActionSave () {
			if (this.rbtPlay.Checked) this._viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (this.rbtPause.Checked) this._viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else this._viewModel.Configuration.Mode = Models.EMode.Toggle;

			return this._viewModel.SaveConfig();
		}
	}
}
