using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Utils;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    public partial class EditSettingsPage : UserControl
    {
        public EditSettingsPage()
        {
            InitializeComponent();
            lblAddRedirect.Text = PluginLanguageManager.PluginStrings.YouNeedAddRedirectUri;
            btnCopyRedirectUri.Text = PluginLanguageManager.PluginStrings.CopyRedirectUriClipboard;
            lblSaveAndContinue.Text = PluginLanguageManager.PluginStrings.AfterPastedUriClickSave;
        }

        private void BtnCopyRedirectUri_Click(object sender, EventArgs e)
        {
            WindowsClipboard.SetText("http://localhost:5000/callback");
        }
    }
}
