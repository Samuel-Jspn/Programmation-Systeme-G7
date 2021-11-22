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
            model.DirOrFile = view.DirOrFile;
            model.Extension = view.Extension;
            model.Name = view.Name;
            model.SourcePath = view.SourcePath;
            model.TargetPath = view.TargetPath;
            model.BackupType = view.BackupType;
            model.createBackup(model.BackupType);
        }

    }
}
