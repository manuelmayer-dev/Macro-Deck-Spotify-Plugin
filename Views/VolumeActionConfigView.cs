using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Views {
	public partial class VolumeActionConfigView : ActionConfigControl {
		private readonly VolumeActionConfigViewModel _viewModel;

		public VolumeActionConfigView (PluginAction action) {
			this.InitializeComponent();
			this._viewModel = new VolumeActionConfigViewModel(action);
		}

		private void VolumeActionConfigView_Load (object sender, EventArgs e) {
			this.rbtOn.Checked = this._viewModel.Configuration.Mode == Models.EMode.Activate;
			this.rbtOff.Checked = this._viewModel.Configuration.Mode == Models.EMode.Deactivate;
			this.rbtToggle.Checked = this._viewModel.Configuration.Mode == Models.EMode.Toggle;
			this.numVolume.Value = this._viewModel.Configuration.Value;

			lblMode.Text = PluginLanguageManager.PluginStrings.VolumeActionWorkingModeText;
			rbtOff.Text = PluginLanguageManager.PluginStrings.VolumeActionDecrease;
			rbtOn.Text = PluginLanguageManager.PluginStrings.VolumeActionIncrease;
			rbtToggle.Text = PluginLanguageManager.PluginStrings.VolumeActionSet;
		}

		public override bool OnActionSave () {
			if (this.rbtOn.Checked) this._viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (this.rbtOff.Checked) this._viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else this._viewModel.Configuration.Mode = Models.EMode.Toggle;
			this._viewModel.Configuration.Value = (int)this.numVolume.Value;

			return this._viewModel.SaveConfig();
		}
	}
}
