using Contracts;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class DigitalAudioServices : IFileUtilsServices
    {
        private const string _appPath = "C:\\Program Files (x86)\\Windows Media Player\\wmplayer.exe";

        public void OpenFile(string filepath)
        {
            Process openFile = new Process();
            openFile.StartInfo = new ProcessStartInfo()
            {
                FileName = _appPath, //app path
                Arguments = filepath //file path
            };
            openFile.Start();
        }

    }
}
