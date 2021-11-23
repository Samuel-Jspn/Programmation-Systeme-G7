using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace AppliConsole
{
    class Model
    {
        #region VARIABLES 
        private string dirOrFile;
        private string extension;
        private string name;
        private string sourcePath;
        private string targetPath;
        private string backupType;
        private DateTime timestamp;
        private string state;
        #endregion

        #region GETER AND SETER
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
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        #endregion

        //constructor
        public Model()
        {
            DirOrFile = "";
            Extension = "";
            Name = "";
            SourcePath = "";
            TargetPath = "";
            BackupType = "";
            Timestamp = default;
        }

        public void createBackup(string type)
        {
            Timestamp = DateTime.Now;
            State = "ACTIF";
            switch (type)
            {
                case "full":
                    try
                    {
                        if(DirOrFile == "File")
                        {
                            string path = TargetPath + @"\" + Name + "." + Extension;
                            File.Copy(SourcePath, path, true);
                            Console.WriteLine("full backup succeed");
                        }
                        else if(DirOrFile == "Directory")
                        {
                            DirectoryInfo dir = new DirectoryInfo(SourcePath);
                            DirectoryInfo[] dirs = dir.GetDirectories();
                            // If the destination directory doesn't exist, create it.       
                            Directory.CreateDirectory(TargetPath + @"\" + Name);
                            //get the file in the directory and copy them to the new location
                            FileInfo[] files = dir.GetFiles();
                            foreach(FileInfo file in files)
                            {
                                //file.CopyTo(TargetPath + @"\" + file.Name, false);
                                string tempPath = TargetPath + @"\" + Name + @"\" + file.Name;
                                file.CopyTo(tempPath, false);
                            }

                            Console.WriteLine("full backup succeed");
                        }
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
            State = "NON ACTIF";

            createStateLog(Name, SourcePath, TargetPath, Timestamp, State);
        }

        public void createStateLog(string name, string sourcePath, string targetPath, DateTime timestamp, string state)
        {
            ViewStateLog stateLog = new ViewStateLog();
            stateLog.Name = name;
            stateLog.SourcePath = sourcePath;
            stateLog.TargetPath = targetPath;
            stateLog.Timestamp = timestamp;
            stateLog.BackupState = state;
            //if(stateLog.BackupState == "ACTIF")
            //{

            //}

            string jsonSerializeObj = JsonConvert.SerializeObject(stateLog, Formatting.Indented);
            File.AppendAllText(@"C:\testBackup\StateLogs\StateLog.son", jsonSerializeObj);
        }
    }
}
