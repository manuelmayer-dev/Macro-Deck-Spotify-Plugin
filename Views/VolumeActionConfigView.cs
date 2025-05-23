using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Views
{
    public partial class VolumeActionConfigView : ActionConfigControl {
		private readonly VolumeActionConfigViewModel _viewModel;

		public VolumeActionConfigView (PluginAction action) {
			InitializeComponent();
			_viewModel = new VolumeActionConfigViewModel(action);
		}

		private void VolumeActionConfigView_Load (object sender, EventArgs e) {
			rbtOn.Checked = _viewModel.Configuration.Mode == Models.EMode.Activate;
			rbtOff.Checked = _viewModel.Configuration.Mode == Models.EMode.Deactivate;
			rbtToggle.Checked = _viewModel.Configuration.Mode == Models.EMode.Toggle;
			numVolume.Value = _viewModel.Configuration.Value;

			lblMode.Text = PluginLanguageManager.PluginStrings.VolumeActionWorkingModeText;
			rbtOff.Text = PluginLanguageManager.PluginStrings.VolumeActionDecrease;
			rbtOn.Text = PluginLanguageManager.PluginStrings.VolumeActionIncrease;
			rbtToggle.Text = PluginLanguageManager.PluginStrings.VolumeActionSet;
		}

		public override bool OnActionSave () {
			if (rbtOn.Checked) _viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (rbtOff.Checked) _viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else _viewModel.Configuration.Mode = Models.EMode.Toggle;
			_viewModel.Configuration.Value = (int)numVolume.Value;

			return _viewModel.SaveConfig();
		}
	}
}
