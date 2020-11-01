using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.FileServices
{
    public class FileServicesExplorer : IFileExplorerService
    {
        public List<FileC> RequestFileListByType(List<FileC> fileList)//ask passing value-type or reference-type
        {
            return fileList.OrderBy(s => s.Extension).ToList();
        }

        public List<FileC> RequestFileListByName(List<FileC> fileList)
        {
            return fileList.OrderBy(s => s.Name).ToList();
        }

        public List<FileC> RequestFileListBySize(List<FileC> fileList)
        {
            return fileList.OrderBy(s => s.Size).ToList();
        }

    }
}
