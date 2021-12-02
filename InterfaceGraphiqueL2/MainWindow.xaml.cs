using System.Windows;
using System.Resources;
using InterfaceGraphiqueL2.resources;

namespace InterfaceGraphiqueL2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResourceManager rm;

        public ResourceManager RM
        {
            get { return rm; }
            set { rm = value; }
        }

        public MainWindow()
        {
            rm = new ResourceManager(typeof(en_language));
            InitializeComponent();
            btn_Save.Content = rm.GetString("saveButton");
            LabelSaveName.Content = rm.GetString("saveName");
            LabelSourcePath.Content = rm.GetString("sourcePath");
            LabelTargetPath.Content = rm.GetString("targetPath");
            LabelSaveType.Content = rm.GetString("saveType");
        }
        private void LanguageEN(object sender, RoutedEventArgs e)
        {
            rm = new ResourceManager(typeof(en_language));
            this.RM = this.rm;
            Translate();
        }
        private void LanguageFR(object sender, RoutedEventArgs e)
        {
            rm = new ResourceManager(typeof(fr_language));
            this.RM = this.rm;
            Translate();
        }
        public void Translate()
        {
            btn_Save.Content = rm.GetString("saveButton");
        }
    }
}
