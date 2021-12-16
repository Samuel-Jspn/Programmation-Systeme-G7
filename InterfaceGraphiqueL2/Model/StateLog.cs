using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace InterfaceGraphiqueL2.Model
{
    class StateLog
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



        public void createStateLog(StateLog stateLog)
        {
            string jsonSerializeObj = JsonConvert.SerializeObject(stateLog, Formatting.Indented);

            Directory.CreateDirectory(@"C:\testBackup\StateLogs");

            File.AppendAllText(@"C:\testBackup\StateLogs\StateLog.json", jsonSerializeObj);
        }
    }
}
