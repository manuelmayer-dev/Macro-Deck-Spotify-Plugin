using System;
using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Helpers;
using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Utils;
using Develeon64.SpotifyPlugin.ViewModels;
using SuchByte.MacroDeck.Language;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    public partial class ClientIdPage : UserControl
    {
        private readonly PluginConfigurationWindowViewModel _viewModel;
        
        public ClientIdPage(PluginConfigurationWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            lblCopyClientIdAndPaste.Text = PluginLanguageManager.PluginStrings.CopyClientIdAndPaste;
            clientId.PlaceHolderText = PluginLanguageManager.PluginStrings.PasteTheCopiedClientIdHere;
            btnAuthorize.Text = PluginLanguageManager.PluginStrings.Authorize;
            clientId.TextChanged += ClientId_TextChanged;
        }
        
        private void ClientId_TextChanged(object sender, EventArgs e)
        {
            btnAuthorize.Visible = clientId.Text.Length > 0;
        }

        private void BtnAuthorize_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _viewModel.ClientId = clientId.Text;
            Retry.Do(() =>
            {
                SpotifyHelper.Authorize(clientId.Text);
            }, TimeSpan.FromSeconds(1));
            Cursor.Current = Cursors.Default;
        }
    }
}
