using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Views
{
    public partial class LoopActionConfigView : ActionConfigControl {
		private readonly LoopActionConfigViewModel _viewModel;

		public LoopActionConfigView (PluginAction action) {
			InitializeComponent();
			_viewModel = new LoopActionConfigViewModel(action);
		}

		private void LoopActionConfigView_Load (object sender, EventArgs e) {
			rbtContext.Checked = _viewModel.Configuration.Mode == Models.EMode.Activate;
			rbtOff.Checked = _viewModel.Configuration.Mode == Models.EMode.Deactivate;
			rbtSingle.Checked = _viewModel.Configuration.Mode == Models.EMode.Toggle;

			lblMode.Text = PluginLanguageManager.PluginStrings.LoopActionWorkingModeText;
			rbtOff.Text = PluginLanguageManager.PluginStrings.LoopActionOff;
			rbtContext.Text = PluginLanguageManager.PluginStrings.LoopActionContext;
			rbtSingle.Text = PluginLanguageManager.PluginStrings.LoopActionSingle;
		}

		public override bool OnActionSave () {
			if (rbtContext.Checked) _viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (rbtOff.Checked) _viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else _viewModel.Configuration.Mode = Models.EMode.Toggle;

			return _viewModel.SaveConfig();
		}
	}
}
