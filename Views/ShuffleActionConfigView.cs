using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Views
{
    public partial class ShuffleActionConfigView : ActionConfigControl {
		private readonly ShuffleActionConfigViewModel _viewModel;

		public ShuffleActionConfigView (PluginAction action) {
			InitializeComponent();
			_viewModel = new ShuffleActionConfigViewModel(action);
		}

		private void ShuffleActionConfigView_Load (object sender, EventArgs e) {
			rbtOn.Checked = _viewModel.Configuration.Mode == Models.EMode.Activate;
			rbtOff.Checked = _viewModel.Configuration.Mode == Models.EMode.Deactivate;
			rbtToggle.Checked = _viewModel.Configuration.Mode == Models.EMode.Toggle;

			lblMode.Text = PluginLanguageManager.PluginStrings.ShuffleActionWorkingModeText;
			rbtOff.Text = PluginLanguageManager.PluginStrings.ShuffleActionOff;
			rbtOn.Text = PluginLanguageManager.PluginStrings.ShuffleActionOn;
			rbtToggle.Text = PluginLanguageManager.PluginStrings.ShuffleActionToggle;
		}

		public override bool OnActionSave () {
			if (rbtOn.Checked) _viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (rbtOff.Checked) _viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else _viewModel.Configuration.Mode = Models.EMode.Toggle;

			return _viewModel.SaveConfig();
		}
	}
}
