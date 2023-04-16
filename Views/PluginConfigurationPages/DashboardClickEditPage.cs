using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Managers;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    public partial class DashboardClickEditPage : UserControl
    {
        public DashboardClickEditPage()
        {
            InitializeComponent();
            lblAfterCreatedApp.Text = PluginLanguageManager.PluginStrings.AfterCreatedApp;
        }
    }
}
