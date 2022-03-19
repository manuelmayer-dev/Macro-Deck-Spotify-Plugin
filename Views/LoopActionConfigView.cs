using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Views {
	public partial class LoopActionConfigView : ActionConfigControl {
		private readonly LoopActionConfigViewModel _viewModel;

		public LoopActionConfigView (PluginAction action) {
			this.InitializeComponent();
			this._viewModel = new LoopActionConfigViewModel(action);
		}

		private void LoopActionConfigView_Load (object sender, EventArgs e) {
			this.rbtContext.Checked = this._viewModel.Configuration.Mode == Models.EMode.Activate;
			this.rbtOff.Checked = this._viewModel.Configuration.Mode == Models.EMode.Deactivate;
			this.rbtSingle.Checked = this._viewModel.Configuration.Mode == Models.EMode.Toggle;

			lblMode.Text = PluginLanguageManager.PluginStrings.LoopActionWorkingModeText;
			rbtOff.Text = PluginLanguageManager.PluginStrings.LoopActionOff;
			rbtContext.Text = PluginLanguageManager.PluginStrings.LoopActionContext;
			rbtSingle.Text = PluginLanguageManager.PluginStrings.LoopActionSingle;
		}

		public override bool OnActionSave () {
			if (this.rbtContext.Checked) this._viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (this.rbtOff.Checked) this._viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else this._viewModel.Configuration.Mode = Models.EMode.Toggle;

			return this._viewModel.SaveConfig();
		}
	}
}
