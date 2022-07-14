using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using OsuHelper.Models;
using Ookii.Dialogs.Wpf;
using System.Drawing;
using OsuHelper.Properties;
using OsuHelper.Backend;

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

