using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Diagnostics;

namespace InterfaceGraphiqueL2
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
        private int totalFileToCopy;

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
        public int TotalFileToCopy
        {
            get { return totalFileToCopy; }
            set { totalFileToCopy = value; }
        }
        #endregion

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
            TotalFileToCopy = 0;
        }

        public void createBackup(string type)
        {
            State = "ACTIF";
            switch (type)
            {
                case "full":
                    try
                    {
                        if (DirOrFile == "File")
                        {
                            string path = TargetPath + @"\" + Name + "." + Extension;
                            DateTime start = DateTime.Now;

                            //info for stateLog
                            Timestamp = start;
                            TotalFileToCopy = 1;

                            //backup
                            File.Copy(SourcePath, path, true);
                            DateTime stop = DateTime.Now;

                            //cryptage du fichier
                            if (Extension == "txt")
                            {
                                encrypt(sourcePath, path);
                            }

                            //recup copy time
                            FileTransferTime = (stop - start).ToString();

                            //recup infos log
                            FileInfo file = new FileInfo(SourcePath);
                            FileSize = file.Length;

                            Console.WriteLine("full backup succeed");
                        }
                        else if (DirOrFile == "Directory")
                        {
                            DirectoryInfo dir = new DirectoryInfo(SourcePath);
                            DirectoryInfo[] dirs = dir.GetDirectories();
                            // If the destination directory doesn't exist, create it.       
                            Directory.CreateDirectory(TargetPath + @"\" + Name);
                            //get the file in the directory and copy them to the new location
                            FileInfo[] files = dir.GetFiles();

                            DateTime start = DateTime.Now;
                            Timestamp = start;
                            DateTime stop = DateTime.Now;
                            //recup copy time
                            FileTransferTime = (stop - start).ToString();

                            foreach (FileInfo file in files)
                            {
                                FileSize += file.Length;
                                string tempPath = TargetPath + @"\" + Name + @"\" + file.Name;

                                TotalFileToCopy++;

                                file.CopyTo(tempPath, false);
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
            //creation of stateLog when backupState actif
            createStateLog();
            createDailyLog();
            State = "NON ACTIF";
            createStateLog();
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
            File.AppendAllText(@"C:\testBackup\DailyLogs\DailyLog.json", jsonSerializeObj);
        }

        public void createStateLog()
        {
            StateLog stateLog = new StateLog();
            stateLog.Name = Name;
            stateLog.SourcePath = SourcePath;
            stateLog.TargetPath = TargetPath;
            stateLog.Timestamp = Timestamp;
            stateLog.BackupState = State;
            if (stateLog.BackupState == "ACTIF")
            {
                stateLog.TotalFileToCopy = TotalFileToCopy;
                stateLog.TotalFileSize = FileSize;
                stateLog.FileSizeLeftToDo = FileSize;
                stateLog.NbFileLeftToDo = TotalFileToCopy;
            }


            string jsonSerializeObj = JsonConvert.SerializeObject(stateLog, Formatting.Indented);

            Directory.CreateDirectory(@"C:\testBackup\StateLogs");

            File.AppendAllText(@"C:\testBackup\StateLogs\StateLog.json", jsonSerializeObj);
        }

        public void encrypt(string pathFileToEncrypt, string pathTargetFile)
        {
            StreamReader sr = new StreamReader(pathFileToEncrypt); //fichier à crypter
            StreamWriter sw = new StreamWriter(pathTargetFile); //fichier où écrire
            Process crypt = new Process(); //logiciel cryptosoft

            //recup du chemin vers l'exécutable de cryptosoft adapté à chaque PC
            string fullPath = Environment.CurrentDirectory;
            string halfPath = fullPath.Substring(0, 133);
            string path = halfPath + "Cryptage\\Cryptage.exe";

            crypt.StartInfo.FileName = path;
            crypt.StartInfo.UseShellExecute = false;
            crypt.StartInfo.RedirectStandardOutput = true;
            crypt.StartInfo.RedirectStandardInput = true;
            crypt.StartInfo.RedirectStandardError = true;

            string line;
            line = sr.ReadLine();

            while (line != null)
            {
                crypt.StartInfo.Arguments = line; //on demande au logiciel de cryptage de crypter le contenu du fichier
                crypt.Start(); //lancement de cryptosoft
                string cryptedLine = crypt.StandardOutput.ReadToEnd();
                crypt.WaitForExit();

                sw.WriteLine(cryptedLine); //on écrit dans le fichier le contenu crypté du précédent fichier 
                line = sr.ReadLine();
            }

            sr.Close();
            sw.Close();
        }
    }

    public class DailyLog
    {
        #region VARIABLES
        private string name;
        private string sourcePath;
        private string targetPath;
        private DateTime timestamp;
        private long fileSize;
        private string fileTransferTime;
        #endregion

        #region GETER AND SETER
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
        #endregion
    }

    public class StateLog
    {
        #region VARIABLES
        private string name;
        private string sourcePath;
        private string targetPath;
        private DateTime timestamp;
        private string backupState;
        private int totalFileToCopy;
        private long totalFileSize;
        private int nbFileLeftToDo;
        private long fileSizeLeftToDo;
        #endregion

        #region GETER AND SETER
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
        public string BackupState
        {
            get { return backupState; }
            set { backupState = value; }
        }
        public int TotalFileToCopy
        {
            get { return totalFileToCopy; }
            set { totalFileToCopy = value; }
        }
        public long TotalFileSize
        {
            get { return totalFileSize; }
            set { totalFileSize = value; }
        }
        public int NbFileLeftToDo
        {
            get { return nbFileLeftToDo; }
            set { nbFileLeftToDo = value; }
        }
        public long FileSizeLeftToDo
        {
            get { return fileSizeLeftToDo; }
            set { fileSizeLeftToDo = value; }
        }
        #endregion
    }

}

