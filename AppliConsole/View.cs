using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AppliConsole
{
    class View
    {
        private string name;
        private string sourceFilePath;
        private string targetFilePath;
        private string backupType;
        private IController controller;

        //Constructor
        public View()
        {
            Name = "";
            SourceFilePath = "";
            TargetFilePath = "";
            backupType = "";
        }

        //geter and seter of the variables
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string SourceFilePath
        {
            get { return sourceFilePath; }
            set { sourceFilePath = value; }
        }
        public string TargetFilePath
        {
            get { return targetFilePath; }
            set { targetFilePath = value; }
        }
        public string BackupType
        {
            get { return backupType; }
            set { backupType = value; }
        }
        public IController Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        //get the backup info
        public void backupInfo()
        {
            Console.WriteLine("Please enter the backup's name");
            Name = Console.ReadLine();
            getSourcePath();
            getTargetPath();
            chooseBackupType();
            controller.updateBackupInfos();
        }

        //Functions linked to the source path and the target path of the save
        public void getSourcePath()
        {
            bool isSourcePathValid = false;
            while(isSourcePathValid != true)
            {
                Console.WriteLine("Please enter the path to the file you want to save");
                SourceFilePath = Console.ReadLine();
                isSourcePathValid = checkSourcePath(SourceFilePath);
            }
        }
        public void getTargetPath()
        {
            bool isTargetPathValid = false;
            while (isTargetPathValid != true)
            {
                Console.WriteLine("Please enter the path of the location where you want to save the file");
                TargetFilePath = Console.ReadLine();
                isTargetPathValid = checkTargetPath(TargetFilePath);
            }
        }
        public bool checkSourcePath(string sourceFilePath)
        {
            bool result = File.Exists(sourceFilePath);
            return result;
        }
        public bool checkTargetPath(string targetFilePath)
        {
            bool result = Directory.Exists(TargetFilePath);
            return result;
        }

        //function to choose the saving type
        public string chooseBackupType()
        {
            Console.WriteLine("Choose a saving type (full or differential)");
            BackupType = Console.ReadLine();
            return BackupType;
        }

        //link the view to the controller
        public void setController(IController cont)
        {
            controller = cont;
        }
    }
}
