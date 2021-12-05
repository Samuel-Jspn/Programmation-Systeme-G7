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
        #region VARIABLES
        private string dirOrFile;
        private string name;
        private string sourcePath;
        private string targetPath;
        private string backupType;
        Controller controller;
        #endregion

        #region GETTER AND SETTER
        public string DirOrFile
        {
            get { return dirOrFile; }
            set { dirOrFile = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string SourcePath
        {
            get { return sourcePath; }
            set { sourcePath = value; }
        }
        public string TargetPath
        {
            get { return targetPath; }
            set { targetPath = value; }
        }
        public string BackupType
        {
            get { return backupType; }
            set { backupType = value; }
        }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new HomePage();
        }


        private void btn_param_Click(object sender, RoutedEventArgs e)
        {
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
