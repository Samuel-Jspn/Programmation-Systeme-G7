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
using InterfaceGraphiqueL2.Model;
using System.Linq;
using System.Windows;


namespace InterfaceGraphiqueL2
{
    class Backup
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
        private string encryptInfo;
        private string softwareSociety;
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
        public string EncryptInfo
        {
            get { return encryptInfo; }
            set { encryptInfo = value; }
        }
        public string SoftwareSociety
        {
            get { return softwareSociety; }
            set { softwareSociety = value; }
        }
        #endregion

        public Backup()
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
            EncryptInfo = "";
            SoftwareSociety = "";
        }

        public void createBackup(string type, string encryptExtension, DailyLog dailyLogModel, StateLog stateLogModel)
        {
            //-----------------Test thread------------------------------//
            Thread softwareSocietyThread = new Thread(()=>EnterpriseSoftwareRunning(SoftwareSociety));
            softwareSocietyThread.Start();
            //if (softwareSocietyThread == true)
            //{
            //    MessageBox.Show("pas de logiciel metier");
            //}
            //----------------------------------------------------------//


            State = "ACTIF";
            switch (type)
            {
                case "full":
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

                        string encryptTime = "";

                        //cryptage du fichier
                        if (encryptExtension == Extension)
                        {
                            DateTime startEncrypt = DateTime.Now;
                            encrypt(sourcePath, path);
                            DateTime stopEncrypt = DateTime.Now;
                            encryptTime = (stopEncrypt - startEncrypt).ToString();
                        }
                        else
                        {
                            encryptTime = "0";
                        }

                        //info temps cryptage pour DailyLogs
                        if (encryptTime == "0")
                        {
                            encryptInfo = "Pas de cryptage";
                        }
                        else if (encryptTime != "0")
                        {
                            EncryptInfo = "Cryptage en "+ encryptTime +" millisecondes";
                        }

                        //recup copy time
                        FileTransferTime = (stop - start).ToString();

                        //recup infos log
                        FileInfo file = new FileInfo(path);
                        FileSize = file.Length;
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

                        DateTime startEncrypt = DateTime.Now;
                        foreach (FileInfo file in files)
                        {
                            FileSize += file.Length;
                            string tempTargetPath = TargetPath + @"\" + Name + @"\" + file.Name;
                            string tempSourcePath = SourcePath + @"\" + file.Name;
                            string tempExtension = file.Name.Split(".").Last();
                            TotalFileToCopy++;

                            file.CopyTo(tempTargetPath, false);

                            //cryptage du fichier
                            if (encryptExtension == tempExtension)
                            {
                                encrypt(tempSourcePath, tempTargetPath);
                            }
                        }
                        DateTime stopEncrypt = DateTime.Now;
                        string encryptTime = (stopEncrypt - startEncrypt).ToString();
                        //info temps cryptage pour DailyLogs
                        if (encryptTime == "0")
                        {
                            encryptInfo = "Pas de cryptage";
                        }
                        else if (encryptTime != "0")
                        {
                            EncryptInfo = "Cryptage en " + encryptTime + " millisecondes";
                        }

                        DateTime stop = DateTime.Now;
                        
                        //recup copy time
                        FileTransferTime = (stop - start).ToString();
                    }
                    break;
                case "differential":
                    //MessageBox.Show("differential backup not available yet");
                    MessageBox.Show(InterfaceGraphiqueL2.Properties.Langs.Lang.differentialType);
                    break;
            }
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

        public bool EnterpriseSoftwareRunning(string nameSoftware)
        {
            if (Process.GetProcessesByName(nameSoftware).Length > 0)
            {
                string message = "You have to close your enterprise software if you want to continue the backup.\n Do you want to close it ?";
                string caption = "EasySave";
                var result = System.Windows.MessageBox.Show(message, caption,
                    System.Windows.MessageBoxButton.YesNo);
                switch (result)
                {
                    case System.Windows.MessageBoxResult.Yes:
                        Process[] proc = Process.GetProcessesByName(nameSoftware);
                        if (proc.Length == 0)
                        {
                            System.Windows.MessageBox.Show("The software has been closed");
                        }
                        else
                        {
                            proc[0].Kill();
                            System.Windows.MessageBox.Show("The software has been closed");
                        }
                        break;
                    case System.Windows.MessageBoxResult.No:
                        EnterpriseSoftwareRunning(nameSoftware);
                        break;
                }
                return true;

            }
            return false;
        }
    }
}

