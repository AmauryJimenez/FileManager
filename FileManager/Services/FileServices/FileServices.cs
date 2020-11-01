using Contracts;
using Models;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Services.FileServices
{
    public class FileServices : IGetFileServices
    {
        public List<FileC> GetFileInformation(string path)
        {
            string[] fileEntries;
            FileInfo infofile;
            FileC filec;
            List<FileC> FileList = new List<FileC>();
            fileEntries = Directory.GetFiles(path);

            foreach (var fileItems in fileEntries)
            {
                infofile = new FileInfo(fileItems);
                filec = new FileC();
                filec.Name = infofile.Name;
                filec.Extension = infofile.Extension;
                filec.DirectoryName = infofile.DirectoryName;
                filec.IsReadOnly = infofile.IsReadOnly;
                filec.Size = infofile.Length;
                filec.DirectoryPath = infofile.FullName;
                FileList.Add(filec);
            }

            return FileList;
        }

        public FileTypes GetFileType(FileC file)
        {
            string fileType = file.Extension;
            FileTypes typeResult;

            switch (fileType)
            {
                case ".txt":
                    typeResult = FileTypes.txt;
                    break;
                case ".pdf":
                    typeResult = FileTypes.PDF;
                    break;
                case ".mp3":
                    typeResult = FileTypes.mp3;
                    break;
                case ".mp4":
                    typeResult = FileTypes.mp4;
                    break;
                default:
                    throw new InvalidOperationException("The File extension is not supported" + fileType.ToString());
            }

            return typeResult;
        }
    }
}
