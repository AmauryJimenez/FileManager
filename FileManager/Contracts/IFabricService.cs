using Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IFabricService
    {

        public IFileExplorerService CreateFileExplorerService();

        public IGetFileServices IGetFileServices();

        public IFileUtilsServices CreateIFileUtilsServices(FileTypes fileType);
    }
}
