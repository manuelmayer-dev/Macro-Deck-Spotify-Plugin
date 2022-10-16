using System;
using System.Diagnostics;
using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Managers;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    public partial class WelcomePage : UserControl
    {
        public WelcomePage()
        {
            InitializeComponent();
            lblWelcome.Text = PluginLanguageManager.PluginStrings.WelcomeToSpotifyPlugin;
            lblCreateSpotifyApp.Text = PluginLanguageManager.PluginStrings.InThisWizardYouCreateSpotifyApp;
            lblSpotifyDevAccount.Text = PluginLanguageManager.PluginStrings.YouNeedASpotifyDevAccount;
            btnOpenDeveloperPortal.Text = PluginLanguageManager.PluginStrings.OpenSpotifyDeveloperPortal;
            lblContinueAfterLoggedIn.Text = PluginLanguageManager.PluginStrings.ContinueAfterLoggedIn;
        }

        private void BtnOpenDeveloperPortal_Click(object sender, EventArgs e)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo("https://developer.spotify.com/dashboard/login")
                {
                    UseShellExecute = true,
                }
            };
            p.Start();
        }
    }
}
