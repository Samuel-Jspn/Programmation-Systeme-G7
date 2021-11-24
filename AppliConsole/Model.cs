using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

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
        private string state;
        private DateTime timestamp;
        private long fileSize;
        private string fileTransferTime;


        ResourceManager rm = new ResourceManager("AppliConsole.Resources.Strings",
            Assembly.GetExecutingAssembly());

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
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }
        public string FileTransferTime
        {
            get { return fileTransferTime; }
            set { fileTransferTime = value; }
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
            FileTransferTime = default;
            FileSize = 0;
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
                            DateTime start = DateTime.Now;
                            File.Copy(SourcePath, path, true);
                            DateTime stop = DateTime.Now;
                            //recup copy time
                            FileTransferTime = (stop - start).ToString();

                            //recup infos log
                            Timestamp = DateTime.Now;
                            FileInfo file = new FileInfo(SourcePath);
                            FileSize = file.Length;

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

                            DateTime start = DateTime.Now;

                            foreach (FileInfo file in files)
                            {
                                FileSize += file.Length;
                                string tempPath = TargetPath + @"\" + Name + @"\" + file.Name;
                                file.CopyTo(tempPath, false);
                            }

                            if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                            {
                                DateTime stop = DateTime.Now;
                                //recup copy time
                                FileTransferTime = (stop - start).ToString();

                                Timestamp = DateTime.Now;
                                Console.WriteLine(rm.GetString("FullSuceedFR"));
                            }
                            else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                            {
                                DateTime stop = DateTime.Now;
                                //recup copy time
                                FileTransferTime = (stop - start).ToString();

                                Timestamp = DateTime.Now;
                                Console.WriteLine(rm.GetString("FullSuceedEN"));
                            }
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
            createDailyLog();
            State = "NON ACTIF";

            createStateLog(Name, SourcePath, TargetPath, Timestamp, State);
        }

        public void createDailyLog()
        {
            DailyLog dailyLog = new DailyLog();
            dailyLog.Timestamp = Timestamp;
            dailyLog.FileSize = FileSize;
            dailyLog.Name = Name + "." + Extension;
            dailyLog.SourcePath = SourcePath;
            dailyLog.TargetPath = TargetPath;
            dailyLog.FileTransferTime = FileTransferTime;

            string jsonSerializeObj = JsonConvert.SerializeObject(dailyLog, Formatting.Indented);

            Directory.CreateDirectory(@"C:\testBackup\DailyLogs");
            File.AppendAllText(@"C:\testBackup\DailyLogs\DailyLog.son", jsonSerializeObj);
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

    public class DailyLog
    {
        private string name;
        private string sourcePath;
        private string targetPath;
        private DateTime timestamp;
        private long fileSize;
        private string fileTransferTime;

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
        public DateTime Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }
        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }
        public string FileTransferTime
        {
            get { return fileTransferTime; }
            set { fileTransferTime = value; }
        }
    }
}
