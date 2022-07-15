using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using OsuHelper.Pages;

namespace OsuHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new ReplaysPage();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var buttonType = ((Button)sender).Tag;

            switch (buttonType)
            {
                case "SettingsPage":
                    MainFrame.Content = new SettingsPage();
                    break;
            }
        }
    }
}
