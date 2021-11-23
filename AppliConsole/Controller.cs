using System;
using System.Collections.Generic;
using System.Text;

namespace AppliConsole
{
    class Controller : IController
    {
        #region VARIABLES
        private Model model;
        private View view;
        private ViewDailyLog viewDailyLog;
        private int nbBackup { get; set; }
        #endregion

        //constructor
        public Controller()
        {
            model = new Model();
            view = new View();
            viewDailyLog = new ViewDailyLog();
            nbBackup = 0;

            //linking the controller to the view
            view.setController(this);

            view.backupInfo();
        }
        public void updateBackupInfo()
        {
            if(nbBackup < 5)
            {
                model.DirOrFile = view.DirOrFile;
                model.Extension = view.Extension;
                model.Name = view.Name;
                model.SourcePath = view.SourcePath;
                model.TargetPath = view.TargetPath;
                model.BackupType = view.BackupType;

                model.createBackup(model.BackupType);
                nbBackup++;
                view.backupInfo();
            }
            else
            {
                Console.WriteLine("You have made 5 backups, you're not allowed to do more, buy the premium version !");
            }
            
        }

    }
}
