using System.Windows;
using OsuHelper.Backend;
using OsuParsers.Decoders;
using OsuParsers.Database;
using OsuHelper.Properties;
using System.IO;
using OsuParsers.Database.Objects;
using System;
using OsuHelper.Backend;
using OsuHelper.Models;

namespace OsuHelper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void AppStartup(object sender, StartupEventArgs e)
        {
            OsuDirectory osuDirectory = new OsuDirectory();
            osuDirectory.FirstLaunchCheck();
            osuDirectory.CheckPathAndSelectNew(this);
        }
    }
}

