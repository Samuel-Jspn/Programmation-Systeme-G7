using System;
using System.Collections.Generic;
using System.Text;

namespace AppliConsole
{
    class Model
    {
        private string backupType;

        public string BackupType
        {
            get { return backupType; }
            set { backupType = value; }
        }

        public Model()
        {
            BackupType = "";
        }

        public void createBackup(string type)
        {
            switch (type)
            {
                case "full":
                    Console.WriteLine("full backup");
                    break;
                case "differential":
                    Console.WriteLine("differential backup");
                    break;
            }
        }
    }
}
