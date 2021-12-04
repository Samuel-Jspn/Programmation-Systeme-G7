using System;
using System.Windows;
using System.Resources;
using InterfaceGraphiqueL2.Properties.Langs;
using System.Windows.Controls;
using System.Threading;

namespace InterfaceGraphiqueL2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool ButtonFrWasCliked = false;
        private bool ButtonEnWasCliked = false;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_param_Click(object sender, RoutedEventArgs e)
        {
        }
        private void btn_fr_Click(object sender, RoutedEventArgs e)
        {
            ButtonFrWasCliked = true;
            Translate();
            ButtonFrWasCliked = false;
            MessageBox.Show("L'application va se fermer. Veuillez la relancer.");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        private void btn_en_Click(object sender, RoutedEventArgs e)
        {
            ButtonEnWasCliked = true;
            Translate();
            ButtonEnWasCliked = false;
            MessageBox.Show("The application is about to close. Please start it again");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }

        private void Translate()
        {
            if (ButtonFrWasCliked == true)
            {
                Properties.Settings.Default.languageCode = "fr-FR";
                Properties.Settings.Default.Save();
            }
            else if (ButtonEnWasCliked == true)
            {
                Properties.Settings.Default.languageCode = "en-US";
                Properties.Settings.Default.Save();
            }
        }
    }
}
