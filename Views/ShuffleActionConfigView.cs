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
			this.InitializeComponent();
			this._viewModel = new ShuffleActionConfigViewModel(action);
		}

		private void ShuffleActionConfigView_Load (object sender, EventArgs e) {
			this.rbtOn.Checked = this._viewModel.Configuration.Mode == Models.EMode.Activate;
			this.rbtOff.Checked = this._viewModel.Configuration.Mode == Models.EMode.Deactivate;
			this.rbtToggle.Checked = this._viewModel.Configuration.Mode == Models.EMode.Toggle;

			lblMode.Text = PluginLanguageManager.PluginStrings.ShuffleActionWorkingModeText;
			rbtOff.Text = PluginLanguageManager.PluginStrings.ShuffleActionOff;
			rbtOn.Text = PluginLanguageManager.PluginStrings.ShuffleActionOn;
			rbtToggle.Text = PluginLanguageManager.PluginStrings.ShuffleActionToggle;
		}

		public override bool OnActionSave () {
			if (this.rbtOn.Checked) this._viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (this.rbtOff.Checked) this._viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else this._viewModel.Configuration.Mode = Models.EMode.Toggle;

			return this._viewModel.SaveConfig();
		}
	}
}
