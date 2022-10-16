using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Develeon64.SpotifyPlugin.Managers;

namespace Develeon64.SpotifyPlugin.Views.PluginConfigurationPages
{
    public partial class CreateAppPage : UserControl
    {
        public CreateAppPage()
        {
            InitializeComponent();
            lblFillInAppDetails.Text = PluginLanguageManager.PluginStrings.FillInAppDetails;
        }
    }
}
