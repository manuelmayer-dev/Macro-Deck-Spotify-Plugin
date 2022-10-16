using System;
using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Helpers;
using Develeon64.SpotifyPlugin.Managers;
using Develeon64.SpotifyPlugin.Windows;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    public partial class SuccessPage : UserControl
    {
        private readonly PluginConfigurationWindow _window;


        public SuccessPage(PluginConfigurationWindow window)
        {
            _window = window;
            InitializeComponent();
            lblLimitedFunctionality.Text = PluginLanguageManager.PluginStrings.LimitedFunctionality;
            lblLoggedInFreeAccount.Text = PluginLanguageManager.PluginStrings.LoggedInFreeSpotifyAccount;
            btnDone.Text = PluginLanguageManager.PluginStrings.Done;
        }

        private void SuccessPage_Load(object sender, EventArgs e)
        {
            try
            {
                infoLimitedFunctionality.Visible = !SpotifyHelper.IsPremium;
                lblWelcome.Text = string.Format(PluginLanguageManager.PluginStrings.PluginConfigurationWelcomeUser, SpotifyHelper.UserName);
            } catch {}
        }

        private void BtnDone_Click(object sender, EventArgs e)
        {
            _window.Close();
        }
    }
}
