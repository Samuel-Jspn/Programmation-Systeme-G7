using System;
using System.Collections.Generic;
using System.Text;

namespace AppliConsole
{
    class ViewDailyLog : View
    {
        #region VARIABLES
        private DateTime timestamp;
        private long fileSize;
        private string fileTransferTime;
        #endregion

        #region GETER AND SETER
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
}
