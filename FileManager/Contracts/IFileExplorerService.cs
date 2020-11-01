using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Contracts
{
    public interface IFileExplorerService
    {

        public List<FileC> RequestFileListByType(List<FileC> fileList);

        public List<FileC> RequestFileListByName(List<FileC> fileList);

        public List<FileC> RequestFileListBySize(List<FileC> fileList);

    }
}
