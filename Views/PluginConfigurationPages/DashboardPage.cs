using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Managers;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    public partial class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            InitializeComponent();
            lblCreatedLoggedIn.Text = PluginLanguageManager.PluginStrings.AfterCreatedDevAccount;
        }
    }
}
