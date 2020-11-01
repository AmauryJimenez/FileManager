using Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Services
{
    public class TextFileServices : IFileUtilsServices
    {
        private const string _appPath = "C:\\Program Files\\Sublime Text 3\\sublime_text.exe";

        public void OpenFile(string filepath)
        {
            Process openFile = new Process();
            openFile.StartInfo = new ProcessStartInfo()
            {
                FileName = _appPath, //put the path to the pdf reading software e.g. Adobe Acrobat
                Arguments = filepath // put the path of the pdf file you want to print
            };
            openFile.Start();
        }
    }
}
