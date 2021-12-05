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
        private string extension;
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
        public string Extension
        {
            get { return extension; }
            set { extension = value; }
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

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxDir.IsChecked == true)
            {
                DirOrFile = "Directory";
            }
            else
            {
                DirOrFile = "File";
            }
            Name = TextBoxName.Text;
            SourcePath = TextBoxSourcePath.Text;
            TargetPath = TextBoxTargetPath.Text;
            if (CheckBoxFullBackup.IsChecked == true)
            {
                BackupType = "full";
            }
            else
            {
                BackupType = "differential";
            }

            controller = new Controller();
            controller.updateBackupInfo(DirOrFile, Name, SourcePath, TargetPath, BackupType);
        }

        private void btn_param_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
