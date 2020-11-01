using Models;
using Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IGetFileServices
    {
        public List<FileC> GetFileInformation(string path);

        public FileTypes GetFileType(FileC file);
    }
}
