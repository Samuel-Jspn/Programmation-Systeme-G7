using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

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

            ResourceManager rm = new ResourceManager("AppliConsole.Resources.Strings",
                Assembly.GetExecutingAssembly());
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
            DirOrFile = "";
            Extension = "";
            Name = "";
            SourcePath = "";
            TargetPath = "";
            BackupType = "";
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
                if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine(rm.GetString("BackupNameFR"));
                    Name = Console.ReadLine();
                    if(Name != "")
                    {
                    isNameValid = true;
                    }
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine(rm.GetString("BackupNameEN"));
                    Name = Console.ReadLine();
                    if (Name != "")
                    {
                        isNameValid = true;
                    }
                }
            }
        }
        public void dirOrFileChoice()
        {
            bool isDirOrFileValid = false;
            while (isDirOrFileValid != true)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine(rm.GetString("DirOrFileFR"));
                    DirOrFile = Console.ReadLine();
                    if (DirOrFile == "Directory" || DirOrFile == "File")
                    {
                        isDirOrFileValid = true;
                    }
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine(rm.GetString("DirOrFileEN"));
                    DirOrFile = Console.ReadLine();
                if(DirOrFile == "Directory" || DirOrFile == "File")
                {
                    isDirOrFileValid = true;
                }
                }
            }
        }
        public void getSourcePath()
        {
            bool isSourcePathValid = false;
            while(isSourcePathValid != true)
            {
                if (DirOrFile == "File")
                {
                    if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                    {
                        Console.WriteLine(rm.GetString("SourcePathFileFR"));
                        SourcePath = Console.ReadLine();
                        isSourcePathValid = checkFilePath(SourcePath);
                    }
                    else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                    {
                        Console.WriteLine(rm.GetString("SourcePathFileEN"));
                        SourcePath = Console.ReadLine();
                        isSourcePathValid = checkFilePath(SourcePath);
                    }
                }
                else if (DirOrFile == "Directory")
                {
                    if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                    {
                    Console.WriteLine(rm.GetString("SourcePathDirectoryFR"));
                    SourcePath = Console.ReadLine();
                    isSourcePathValid = checkDirPath(SourcePath);
                    }
                    else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                    {
                        Console.WriteLine(rm.GetString("SourcePathDirectoryEN"));
                        SourcePath = Console.ReadLine();
                        isSourcePathValid = checkDirPath(SourcePath);
                    }
                }

            }
        }
        public void getTargetPath()
        {
            bool isTargetPathValid = false;
            while (isTargetPathValid != true)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine(rm.GetString("TargetPathFR"));
                    TargetPath = Console.ReadLine();
                    isTargetPathValid = checkDirPath(TargetPath);
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                    Console.WriteLine(rm.GetString("TargetPathEN"));
                    TargetPath = Console.ReadLine();
                    isTargetPathValid = checkDirPath(TargetPath);
                }
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
                if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                    Console.WriteLine(rm.GetString("BackupTypeFR"));
                    BackupType = Console.ReadLine();
                    if (BackupType == "full" || BackupType == "differential")
                    {
                        isTypeValid = true;
                    }
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                Console.WriteLine(rm.GetString("BackupTypeEN"));
                BackupType = Console.ReadLine();
                if(BackupType == "full" || BackupType == "differential")
                {
                    isTypeValid = true;
                }
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
