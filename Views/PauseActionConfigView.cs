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
			InitializeComponent();
			_viewModel = new PauseActionConfigViewModel(action);
		}

		private void PauseActionConfigView_Load (object sender, EventArgs e) {
			rbtPlay.Checked = _viewModel.Configuration.Mode == Models.EMode.Activate;
			rbtPause.Checked = _viewModel.Configuration.Mode == Models.EMode.Deactivate;
			rbtToggle.Checked = _viewModel.Configuration.Mode == Models.EMode.Toggle;

			lblMode.Text = PluginLanguageManager.PluginStrings.PauseActionWorkingModeText;
			rbtPause.Text = PluginLanguageManager.PluginStrings.PauseActionPause;
			rbtPlay.Text = PluginLanguageManager.PluginStrings.PauseActionPlay;
			rbtToggle.Text = PluginLanguageManager.PluginStrings.PauseActionToggle;
		}

		public override bool OnActionSave () {
			if (rbtPlay.Checked) _viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (rbtPause.Checked) _viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else _viewModel.Configuration.Mode = Models.EMode.Toggle;

			return _viewModel.SaveConfig();
		}
	}
}
