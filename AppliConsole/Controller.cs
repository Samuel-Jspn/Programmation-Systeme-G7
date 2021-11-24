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
