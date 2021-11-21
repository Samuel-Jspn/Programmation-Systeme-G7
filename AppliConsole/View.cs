using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AppliConsole
{
    class View
    {
        private string sourceFilePath;
        private string targetFilePath;

        public View()
        {
            SourceFilePath = "";
            TargetFilePath = "";
        }

        public string SourceFilePath
        {
            get { return sourceFilePath; }
            set { sourceFilePath = value; }
        }
        public string TargetFilePath
        {
            get { return targetFilePath; }
            set { targetFilePath = value; }
        }

        public void getSourcePath()
        {
            bool isSourcePathValid = false;
            while(isSourcePathValid != true)
            {
                Console.WriteLine("Please enter the path to the file you want to save");
                SourceFilePath = Console.ReadLine();
                isSourcePathValid = checkSourcePath(SourceFilePath);
            }
        }
        public void getTargetPath()
        {
            bool isTargetPathValid = false;
            while (isTargetPathValid != true)
            {
                Console.WriteLine("Please enter the path of the location where you want to save the file");
                TargetFilePath = Console.ReadLine();
                isTargetPathValid = checkTargetPath(TargetFilePath);
            }
        }
        public bool checkSourcePath(string sourceFilePath)
        {
            bool result = File.Exists(sourceFilePath);
            return result;
        }
        public bool checkTargetPath(string targetFilePath)
        {
            bool result = Directory.Exists(TargetFilePath);
            return result;
        }
    }
}
