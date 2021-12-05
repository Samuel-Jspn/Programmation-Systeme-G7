using System;
using System.Windows;
using System.Resources;
using InterfaceGraphiqueL2.Properties.Langs;
using System.Windows.Controls;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;

namespace InterfaceGraphiqueL2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new HomePage();
        }


        private void btn_param_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Settings();
        }
        private void btn_fr_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.languageCode = "fr-FR";
            Properties.Settings.Default.Save();
            RestartApp();
        }
        private void btn_en_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.languageCode = "en-US";
            Properties.Settings.Default.Save();
            RestartApp();
        }

        private void RestartApp()
        {
            var currentExecutablePath = Process.GetCurrentProcess().MainModule.FileName;
            Process.Start(currentExecutablePath);
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_menu_saves_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SavesPage();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new HomePage();

        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
