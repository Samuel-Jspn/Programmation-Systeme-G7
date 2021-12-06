using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Resources;
using InterfaceGraphiqueL2.Properties.Langs;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Globalization;

namespace InterfaceGraphiqueL2
{
    /// <summary>
    /// Logique d'interaction pour SavesPage.xaml
    /// </summary>
    public partial class SavesPage : Page
    {
        #region VARIABLES
        private string dirOrFile;
        private string name;
        private string sourcePath;
        private string targetPath;
        private string backupType;
        Controller Controller;
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
        public SavesPage(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
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

            Controller.updateBackupInfo(DirOrFile, Name, SourcePath, TargetPath, BackupType);
        }

    }
}
