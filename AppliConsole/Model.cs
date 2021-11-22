using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AppliConsole
{
    class Model
    {
        private string name;
        private string sourceFilePath;
        private string targetFilePath;
        private string backupType;

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

        public Model()
        {
            Name = "";
            SourceFilePath = "";
            TargetFilePath = "";
            BackupType = "";
        }

        public void createBackup(string type)
        {
            switch (type)
            {
                case "full":
                    try
                    {
                        File.Copy(SourceFilePath, TargetFilePath + @"\" + Name, true);
                        Console.WriteLine("full backup succeed");
                    }
                    catch (IOException iox)
                    {
                        Console.WriteLine(iox.Message);
                    }
                    break;
                case "differential":
                    Console.WriteLine("differential backup not available yet");
                    break;
            }
        }
    }
}
