using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Linq;

namespace InterfaceGraphiqueL2
{
    class Controller 
    {
        #region VARIABLES
        private Model model;
        private MainWindow view;
        //private ViewDailyLog viewDailyLog;
        //private ViewStateLog viewStateLog;
        #endregion
        public Controller()
        {
            model = new Model();
            view = new MainWindow();
        }

        public void updateBackupInfo(string DirOrFile, string Name, string SourcePath, string TargetPath, string BackupType)
        {
            //variable for the model
            model.DirOrFile = DirOrFile;
            model.Extension = SourcePath.Split(".").Last();
            model.Name = Name;
            model.SourcePath = SourcePath;
            model.TargetPath = TargetPath;
            model.BackupType = BackupType;

            //variables for the stateLog
            //viewStateLog.Name = model.Name;
            //viewStateLog.SourcePath = model.SourcePath;
            //viewStateLog.TargetPath = model.TargetPath;

            model.createBackup(model.BackupType);

            //viewStateLog.Timestamp = model.Timestamp;
            //viewStateLog.BackupState = model.State;
        }

    }
}
