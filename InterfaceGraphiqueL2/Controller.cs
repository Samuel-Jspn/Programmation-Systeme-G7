using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;
using System.Linq;
using InterfaceGraphiqueL2.Model;
using InterfaceGraphiqueL2.View;
using System.Windows.Threading;

namespace InterfaceGraphiqueL2
{
    public class Controller 
    {
        #region VARIABLES
        private Backup model;
        private DailyLog dailyLogModel;
        private StateLog stateLogModel;
        public BackupManage backupManageView;
        public string EncryptExtension { get; set; }
        public string SoftwareSociety { get; set; }
        public bool IsStopBtnPress { get; set; }
        public string flagBackup { get; set; }
        public int percentage { get; set; }
        public string PriorityExtension { get; set; }
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
            model.SoftwareSociety = SoftwareSociety;
            model.DirOrFile = DirOrFile;
            model.Extension = SourcePath.Split(".").Last();
            model.Name = Name;
            model.SourcePath = SourcePath;
            model.TargetPath = TargetPath;
            model.BackupType = BackupType;
            model.backupManage = backupManageView;
            model.PriorityExtension = PriorityExtension;

            //variable for the dailyLogModel
            if (model.DirOrFile == "File")
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
            dailyLogModel.EncryptInfo = model.EncryptInfo;

            //variables for the stateLog
            stateLogModel.Name = model.Name;
            stateLogModel.SourcePath = model.SourcePath;
            stateLogModel.TargetPath = model.TargetPath;
            stateLogModel.Timestamp = model.Timestamp;
            stateLogModel.BackupState = model.State;
            if (stateLogModel.BackupState == "ACTIF")
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


            //checker si on clique sur stopper sauvegarde ou ouverture logiciel métier en boucle durant la sauvegarde
            model.IsStopBtnPress = IsStopBtnPress;
            model.EnterpriseSoftwareRunning(SoftwareSociety);

            //creation DailyLog, StateLog, et sauvegarde
            dailyLogModel.createDailyLog(dailyLogModel);
            stateLogModel.createStateLog(stateLogModel);
            Thread checkStopBtnThread = new Thread(checkStopBtn);
            checkStopBtnThread.Start();
            model.backupThread(EncryptExtension, dailyLogModel, stateLogModel);
        }

        //test ProgressBar
        public void updatePercentage(int percentageModel)
        {
            backupManageView.SetProgressBar(percentage);
        }

        //Check en continue si on appuie sur le btn stop sauvegarde, récupération de la valeur de la vue pour la passer au controller
        public void checkStopBtn()
        {
            while (true)
            {
                if(IsStopBtnPress == true)
                {
                    model.IsStopBtnPress = true;
                }
                else
                {
                    model.IsStopBtnPress = false;
                }
            }
        }



        //Check en continue si on appuie sur on arrive à la fin de la sauvegarde ou pas
        //public void checkBackupFlag()
        //{

        //    while (true)
        //    {
        //        if (model.flag == "fin")
        //        {
        //            backupManageView.closePage();
        //        }
        //    }
        //}
    }
}
