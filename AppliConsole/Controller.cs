using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace AppliConsole
{
    class Controller : IController
    {
        #region VARIABLES
        private Model model;
        private View view;
        private ViewDailyLog viewDailyLog;
        private ViewStateLog viewStateLog;
        private int nbBackup { get; set; }

        ResourceManager rm = new ResourceManager("AppliConsole.Resources.Strings",
    Assembly.GetExecutingAssembly());

        #endregion

        //constructor
        public Controller()
        {
            model = new Model();
            view = new View();
            viewDailyLog = new ViewDailyLog();
            viewStateLog = new ViewStateLog();
            nbBackup = 0;

            //linking the controller to the view
            view.setController(this);
            viewStateLog.setController(this);

            view.backupInfo();

            viewStateLog.stateLogInfo();
        }
        public void updateBackupInfo()
        {
            if(nbBackup < 5)
            {
                //variable for the model
                model.DirOrFile = view.DirOrFile;
                model.Extension = view.Extension;
                model.Name = view.Name;
                model.SourcePath = view.SourcePath;
                model.TargetPath = view.TargetPath;
                model.BackupType = view.BackupType;

                //variables for the stateLog
                viewStateLog.Name = model.Name;
                viewStateLog.SourcePath = model.SourcePath;
                viewStateLog.TargetPath = model.TargetPath;

                model.createBackup(model.BackupType);

                viewStateLog.Timestamp = model.Timestamp;
                viewStateLog.BackupState = model.State;

               
                nbBackup++;
                view.backupInfo();
            }
            else
            {
                if (Thread.CurrentThread.CurrentUICulture.Name == "fr-FR")
                {
                Console.WriteLine(rm.GetString("MaxBackupNbFR"));
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
                {
                Console.WriteLine(rm.GetString("MaxBackupNbEN"));
                }
            }
            
        }

    }
}
