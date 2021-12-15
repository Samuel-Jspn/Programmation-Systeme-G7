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
using System.Windows.Shapes;

namespace InterfaceGraphiqueL2.View
{
    /// <summary>
    /// Logique d'interaction pour BackupManage.xaml
    /// </summary>
    public partial class BackupManage : Window
    {
        public Controller Controller { get; set; }
        public BackupManage(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void Button_Stop_Click(object sender, RoutedEventArgs e)
        {
            Controller.IsStopBtnPress = true;
            backupProgressInfo.Content= InterfaceGraphiqueL2.Properties.Langs.Lang.backupStop;
        }

        private void Button_InProgress_Click(object sender, RoutedEventArgs e)
        {
            Controller.IsStopBtnPress = false;
            backupProgressInfo.Content = InterfaceGraphiqueL2.Properties.Langs.Lang.backupInProgress;
        }
    }
}
