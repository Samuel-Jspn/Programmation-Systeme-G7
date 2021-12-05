using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace InterfaceGraphiqueL2.Model
{
    class DailyLog
    {
        #region VARIABLES
        string name;
        string sourcePath;
        string targetPath;
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

        //public DailyLog()
        //{
        //    Timestamp = default;
        //    FileTransferTime = default;
        //    FileSize = 0;
           
        //    //createDailyLog(this);
        //}
        public void createDailyLog(DailyLog dailyLog)
        {
            string jsonSerializeObj = JsonConvert.SerializeObject(dailyLog, Formatting.Indented);
          
            Directory.CreateDirectory(@"C:\testBackup\DailyLogs");
            File.AppendAllText(@"C:\testBackup\DailyLogs\DailyLog.json", jsonSerializeObj);
        }
    }
}
