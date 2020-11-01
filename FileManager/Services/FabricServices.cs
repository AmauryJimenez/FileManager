using Contracts;
using Models.Enum;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class FabricServices : IFabricService
    {
        private Container _container;
        private IFileExplorerService _fileExplorerService;
        private IGetFileServices _fileUtilsServices;


        public FabricServices(Container container, IFileExplorerService fileExplorerService, IGetFileServices fileUtilsServices)
        {
            _container = container;
            _fileExplorerService = fileExplorerService;
            _fileUtilsServices = fileUtilsServices;
        }

        public IFileExplorerService CreateFileExplorerService()
        {
            return _fileExplorerService;
        }

        public IGetFileServices IGetFileServices()
        {
            return _fileUtilsServices;
        }

        public IFileUtilsServices CreateIFileUtilsServices(FileTypes fileType)
        {
            IFileUtilsServices result;

            if (fileType == FileTypes.PDF)
                result = _container.GetInstance<PDFServices>();
            else if (fileType == FileTypes.txt)
                result = _container.GetInstance<TextFileServices>();
            else if (fileType == FileTypes.mp4)
                result = _container.GetInstance<MultimediaServices>();
            else if (fileType == FileTypes.mp3)
                result = _container.GetInstance<DigitalAudioServices>();
            else
                throw new InvalidOperationException("Fail upon creating the file instance " + fileType.ToString());

            return result;
        }
    }
}
