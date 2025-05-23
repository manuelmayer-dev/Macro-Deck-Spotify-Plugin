using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.ViewModels;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;

namespace Develeon64.SpotifyPlugin.Views
{
    public partial class LibraryActionConfigView : ActionConfigControl {
		private readonly LibraryActionConfigViewModel _viewModel;

		public LibraryActionConfigView (PluginAction action) {
			InitializeComponent();
			_viewModel = new LibraryActionConfigViewModel(action);
		}

		private void LibraryActionConfigView_Load (object sender, EventArgs e) {
			rbtOn.Checked = _viewModel.Configuration.Mode == Models.EMode.Activate;
			rbtOff.Checked = _viewModel.Configuration.Mode == Models.EMode.Deactivate;
			rbtToggle.Checked = _viewModel.Configuration.Mode == Models.EMode.Toggle;

			lblMode.Text = PluginLanguageManager.PluginStrings.LibraryActionWorkingModeText;
			rbtOff.Text = PluginLanguageManager.PluginStrings.LibraryActionRemove;
			rbtOn.Text = PluginLanguageManager.PluginStrings.LibraryActionAdd;
			rbtToggle.Text = PluginLanguageManager.PluginStrings.LibraryActionToggle;
		}

		public override bool OnActionSave () {
			if (rbtOn.Checked) _viewModel.Configuration.Mode = Models.EMode.Activate;
			else if (rbtOff.Checked) _viewModel.Configuration.Mode = Models.EMode.Deactivate;
			else _viewModel.Configuration.Mode = Models.EMode.Toggle;

			return _viewModel.SaveConfig();
		}
	}
}
