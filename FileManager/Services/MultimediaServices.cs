using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using System.Diagnostics;

namespace Services
{
    public class MultimediaServices : IFileUtilsServices
    {
        private const string _appPath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe";

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
