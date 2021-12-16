using System;
using System.Collections.Generic;
using System.Text;

namespace AppliConsole
{
    class ViewStateLog : ViewDailyLog
    {
        #region VARIABLES
        private string backupState;
        private int totalFileToCopy;
        private long totalFileSize;
        private int nbFileLeftToDo;
        private long fileSizeLeftToDo;
        #endregion

        #region GETER AND SETER
        
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

        //constructor
        public ViewStateLog()
        {
            BackupState = "";
            TotalFileToCopy = 0;
            TotalFileSize = 0;
            NbFileLeftToDo = 0;
            FileSizeLeftToDo = 0;
        }

        public void stateLogInfo()
        {
        }
    }
}
