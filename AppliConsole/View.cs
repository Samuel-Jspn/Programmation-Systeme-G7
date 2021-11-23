using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace AppliConsole
{
    class View
    {
        #region VARIABLES 

        internal string dirOrFile;
        internal string extension;
        private string name;
        private string sourcePath;
        private string targetPath;
        internal string backupType;
        internal IController controller;
        #endregion

        #region GETER AND SETER

        //geter and seter of the variables
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
        public IController Controller
        {
            get { return controller; }
            set { controller = value; }
        }
        #endregion

        //Constructor
        public View()
        {
            dirOrFile = "";
            Extension = "";
            Name = "";
            SourcePath = "";
            TargetPath = "";
            backupType = "";
        }

        

        #region FUNCTION TO GET BACKUP INFO

        //get the backup info
        public void backupInfo()
        {
            dirOrFileChoice();
            getName();
            getSourcePath();
            getTargetPath();
            Extension = SourcePath.Split('.').Last();
            chooseBackupType();
            controller.updateBackupInfo();
        }

        //Functions linked to the backup infos one by one
        public void getName()
        {
            bool isNameValid = false;
            while(isNameValid != true)
            {
                Console.WriteLine("Please enter the backup's name");
                Name = Console.ReadLine();
                if(Name != "")
                {
                    isNameValid = true;
                }
            }
        }
        public void dirOrFileChoice()
        {
            bool isDirOrFileValid = false;
            while (isDirOrFileValid != true)
            {
                Console.WriteLine("Pease choose if you want to save a directory or a file (enter \"Directory\" or \"File\")");
                DirOrFile = Console.ReadLine();
                if(DirOrFile == "Directory" || DirOrFile == "File")
                {
                    isDirOrFileValid = true;
                }
            }
        }
        public void getSourcePath()
        {
            bool isSourcePathValid = false;
            while(isSourcePathValid != true)
            {
                if(DirOrFile == "File")
                {
                    Console.WriteLine("Please enter the path to the file you want to save");
                    SourcePath = Console.ReadLine();
                    isSourcePathValid = checkFilePath(SourcePath);
                }
                else if(DirOrFile == "Directory")
                {
                    Console.WriteLine("Please enter the path to the directory you want to save");
                    SourcePath = Console.ReadLine();
                    isSourcePathValid = checkDirPath(SourcePath);
                }
            }
        }
        public void getTargetPath()
        {
            bool isTargetPathValid = false;
            while (isTargetPathValid != true)
            {
                Console.WriteLine("Please enter the path to the directory where you want to save");
                TargetPath = Console.ReadLine();
                isTargetPathValid = checkDirPath(TargetPath);
            }
        }
        public bool checkFilePath(string filePath)
        {
            bool result = File.Exists(filePath);
            return result;
        }
        public bool checkDirPath(string dirPath)
        {
            bool result = Directory.Exists(dirPath);
            return result;
        }

        //function to choose the saving type
        public void chooseBackupType()
        {
            bool isTypeValid = false;
            while(isTypeValid != true)
            {
                Console.WriteLine("Choose a saving type (full or differential)");
                BackupType = Console.ReadLine();
                if(BackupType == "full" || BackupType == "differential")
                {
                    isTypeValid = true;
                }
            }
        }

        //link the view to the controller
        public void setController(IController cont)
        {
            controller = cont;
        }

        #endregion
    }
}
