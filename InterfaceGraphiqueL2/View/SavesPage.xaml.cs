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
using Microsoft.Win32;


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
        private void btn_source_Click(object sender, RoutedEventArgs e)
        {
            if (CheckBoxFile.IsChecked == true)
            {
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
                Nullable<bool> result = openFileDlg.ShowDialog();
                if (result == true)
                {
                    TextBoxSourcePath.Text = openFileDlg.FileName;
                    //TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
                }
            }
            else if (CheckBoxDir.IsChecked == true)
            {
                Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            Nullable<bool> result = openDlg.ShowDialog();
            if (result == true)
            {
                TextBoxSourcePath.Text = openDlg.SelectedPath;
            }
            }
            else
            {
                MessageBox.Show(Lang.docTypeError);
            }
        }

        private void btn_target_Click(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            Nullable<bool> result = openDlg.ShowDialog();
            if (result == true)
            {
                TextBoxTargetPath.Text = openDlg.SelectedPath;
            }
        }

        private void CheckBoxFullBackup_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBoxFullBackup.IsChecked == true)
            {
                CheckBoxDifferentialBackup.IsChecked = false;
            }
        }
        private void CheckBoxDifferentialBackup_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBoxDifferentialBackup.IsChecked == true)
            {
                CheckBoxFullBackup.IsChecked = false;
            }
        }
        private void CheckBoxFile_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBoxFile.IsChecked == true)
            {
                CheckBoxDir.IsChecked = false;
            }
        }
        private void CheckBoxDir_Checked(object sender, RoutedEventArgs e)
        {
            if (CheckBoxDir.IsChecked == true)
            {
                CheckBoxFile.IsChecked = false;
            }
        }
    }
}
