using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Linq;
using InterfaceGraphiqueL2.Model;

namespace InterfaceGraphiqueL2
{
    public class Controller 
    {
        #region VARIABLES
        private Backup model;
        private DailyLog dailyLogModel;
        private StateLog stateLogModel;
        public string EncryptExtension { get; set; }
        public string SoftwareSociety { get; set; }
        #endregion
        public Controller()
        {
            model = new Backup();
            dailyLogModel = new DailyLog();
            stateLogModel = new StateLog();
        }

        public void updateBackupInfo(string DirOrFile, string Name, string SourcePath, string TargetPath, string BackupType)
        {
            //variable for the backupModel
            model.DirOrFile = DirOrFile;
            model.Extension = SourcePath.Split(".").Last();
            model.Name = Name;
            model.SourcePath = SourcePath;
            model.TargetPath = TargetPath;
            model.BackupType = BackupType;

            model.EnterpriseSoftwareRunning(SoftwareSociety);
            model.createBackup(model.BackupType, EncryptExtension, dailyLogModel, stateLogModel);

            //variable for the dailyLogModel
            if(model.DirOrFile == "File")
            {
                dailyLogModel.Name = model.Name + "." + model.Extension;

            }
            else
            {
                dailyLogModel.Name = model.Name;
            }
            dailyLogModel.SourcePath = model.SourcePath;
            dailyLogModel.TargetPath = model.TargetPath;
            dailyLogModel.FileTransferTime = model.FileTransferTime;
            dailyLogModel.Timestamp = model.Timestamp;
            dailyLogModel.FileSize = model.FileSize;
            dailyLogModel.createDailyLog(dailyLogModel);

            //variables for the stateLog
            stateLogModel.Name = model.Name;
            stateLogModel.SourcePath = model.SourcePath;
            stateLogModel.TargetPath = model.TargetPath;
            stateLogModel.Timestamp = model.Timestamp;
            stateLogModel.BackupState = model.State;
            if(stateLogModel.BackupState == "ACTIF")
            {
                stateLogModel.TotalFileToCopy = model.TotalFileToCopy;
                stateLogModel.TotalFileSize = model.FileSize;
                stateLogModel.FileSizeLeftToDo = model.FileSize;
                stateLogModel.NbFileLeftToDo = model.TotalFileToCopy;
            }
            stateLogModel.createStateLog(stateLogModel);
            stateLogModel.BackupState = "NON ACTIF";
            if (stateLogModel.BackupState == "NON ACTIF")
            {
                stateLogModel.TotalFileToCopy = 0;
                stateLogModel.TotalFileSize = 0;
                stateLogModel.FileSizeLeftToDo = 0;
                stateLogModel.NbFileLeftToDo = 0;
            }
            stateLogModel.createStateLog(stateLogModel);

        }

    }
}
