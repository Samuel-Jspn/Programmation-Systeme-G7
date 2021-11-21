using System;
using System.Collections.Generic;
using System.Text;

namespace AppliConsole
{
    class Controller : IController
    {
        private Model model;
        private View view;

        public Controller()
        {
            model = new Model();
            view = new View();

            //linking the controller to the view
            view.setController(this);

            view.backupInfo();
        }
        public void updateBackupInfos()
        {
            model.Name = view.Name;
            model.SourceFilePath = view.SourceFilePath;
            model.TargetFilePath = view.TargetFilePath;
            model.BackupType = view.BackupType;
            model.createBackup(model.BackupType);
        }

    }
}
