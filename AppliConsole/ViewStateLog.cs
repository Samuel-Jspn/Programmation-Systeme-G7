using System;
using System.Collections.Generic;
using System.Text;

namespace AppliConsole
{
    class ViewStateLog : View
    {
        #region VARIABLES
        private DateTime timestamp { get; set; }
        private string backupState { get; set; }
        private int totalFileToCopy { get; set; }
        private int totalFileSize { get; set; }
        private int nbFileLeftToDo { get; set; }
        private int fileLeftToDoSize { get; set; }
        #endregion

        #region GETER AND SETER
        
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
        public int TotalFileSize
        {
            get { return totalFileSize; }
            set { totalFileSize = value; }
        }
        public int NbFileLeftToDo
        {
            get { return nbFileLeftToDo; }
            set { nbFileLeftToDo = value; }
        }
        public int FileLeftToDoSize
        {
            get { return fileLeftToDoSize; }
            set { fileLeftToDoSize = value; }
        }
        #endregion

        //constructor
        public ViewStateLog()
        {
            Timestamp = default;
            BackupState = "";
            TotalFileToCopy = 0;
            TotalFileSize = 0;
            NbFileLeftToDo = 0;
            FileLeftToDoSize = 0;
        }

        public void stateLogInfo()
        {
            //getTimestamp();
            //getBackupState();
        }

        //public void getTimestamp()
        //{

        //}
        //public void getBackupState()
        //{

        //}


    }
}
