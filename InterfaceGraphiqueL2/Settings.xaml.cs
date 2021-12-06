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

namespace InterfaceGraphiqueL2
{
    /// <summary>
    /// Logique d'interaction pour Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        #region VARIABLES
        private string encryptExtension;
        private string softwareSociety;
        Controller Controller;
        #endregion

        #region GETER AND SETER
        public string EncryptExtension
        {
            get { return encryptExtension; }
            set { encryptExtension = value; }
        }
        public string SoftwareSociety
        {
            get { return softwareSociety; }
            set { softwareSociety = value; }
        }
        #endregion

        public Settings(Controller controller)
        {
            this.Controller = controller;
            InitializeComponent();
        }

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            EncryptExtension = textBoxExtension.Text;
            SoftwareSociety = textBoxLogiciel.Text;
            Controller.EncryptExtension = EncryptExtension;
            Controller.SoftwareSociety = SoftwareSociety;
        }
    }
}
