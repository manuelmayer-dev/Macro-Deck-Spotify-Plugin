using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Helpers;
using Develeon64.SpotifyPlugin.Models;
using Develeon64.SpotifyPlugin.ViewModels;
using Develeon64.SpotifyPlugin.Views.PluginConfigurationPages;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;

namespace Develeon64.SpotifyPlugin.Windows
{
    public partial class PluginConfigurationWindow : DialogForm
    {

        private readonly PluginConfigurationWindowViewModel _viewModel = new PluginConfigurationWindowViewModel();

        private readonly List<UserControl> _pages;

        private int _currentPageNo = -1;

        public PluginConfigurationWindow()
        {
            InitializeComponent();
            _pages = new List<UserControl>()
            {
                new WelcomePage(),
                new DashboardPage(),
                new CreateAppPage(),
                new DashboardClickEditPage(),
                new EditSettingsPage(),
                new ClientIdPage(_viewModel),
                new SuccessPage(this)
            };
            SpotifyHelper.LoginSuccessful += SpotifyHelper_LoginSuccessful;
            SpotifyHelper.ConnectionStateChanged += SpotifyHelper_ConnectionStateChanged;
        }

        private void SpotifyHelper_ConnectionStateChanged(object sender, EventArgs e)
        {
            if (!SpotifyHelper.IsConnected) return;
            MacroDeckLogger.Info(PluginInstance.Main, "Spotify connected");
            SetPage(_pages.Count - 1);
        }

        private void SpotifyHelper_LoginSuccessful(object sender, EventArgs e)
        {
            if (!(e is LoginCredentials args)) return;
            CredentialHelper.UpdateCredentials(args.AccessToken, args.RefreshToken);
            PluginConfiguration.SetValue(PluginInstance.Main, "clientID", _viewModel.ClientId);
            SpotifyHelper.Connect(args.AccessToken);
        }

        private void SetPage(int num)
        {
            if (num < 0) return;
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetPage(num)));
                return;
            }
            MacroDeckLogger.Trace(PluginInstance.Main, $"Set page no {num}");
            var page = _pages[num];
            MacroDeckLogger.Trace(PluginInstance.Main, $"Set page name {nameof(page)}");
            pagePanel.Controls.Clear();
            pagePanel.Controls.Add(page ?? new WelcomePage());
            _currentPageNo = num;
            SetBackButtonVisible(num > 0);
            SetForwardButtonVisible(num < _pages.Count - 2);
        }

        private void SetBackButtonVisible(bool visible)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetBackButtonVisible(visible)));
                return;
            }
            btnBack.Visible = visible;
        }
        private void SetForwardButtonVisible(bool visible)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetForwardButtonVisible(visible)));
                return;
            }
            btnForward.Visible = visible;
        }

        private void PluginConfigurationWindow_Load(object sender, EventArgs e)
        {
            if (SpotifyHelper.IsConnected)
            {
                SetPage(_pages.Count - 1);
            }
            else
            {
                SetPage(0);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SetPage(_currentPageNo - 1);
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            SetPage(_currentPageNo + 1);
        }
    }
}
