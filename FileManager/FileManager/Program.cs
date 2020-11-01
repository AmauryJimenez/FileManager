using SimpleInjector;
using System;
using Contracts;
using Services;
using System.Collections.Generic;
using Models;
using Services.Enum;
using Services.FileServices;
using Models.Enum;

namespace FileManager
{
    class Program
    {

        private const string _welcomeMessage = "This program was made for test concept purpouses";
        private static Container container;
        private static List<FileC> fileList;
        private static string path = "C:\\temp\\files";
        static void Main(string[] args)
        {
            container = new Container();
            container.Register<IFabricService, FabricServices>(Lifestyle.Singleton);
            container.Register<IFileExplorerService, FileServicesExplorer>(Lifestyle.Singleton);
            container.Register<IGetFileServices, FileServices>(Lifestyle.Singleton);
            container.Verify();

            try
            {
                GetFilesInformation(false);
                WelcomeMenu();
                MainMenu();
            }
            catch (Exception exe)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exe.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                Console.Clear();
                Console.WriteLine("Program ended successfully!!");
                Console.ReadKey();
            }
  
        }

        private static void WelcomeMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(_welcomeMessage);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        private static void MainMenu()
        {
            int option = -1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("============================================");
                Console.WriteLine("======          FILE MANAGER          ======");
                Console.WriteLine("============================================");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Request file information list");
                Console.WriteLine("2. Sort list by Type");
                Console.WriteLine("3. Sort list by Name");
                Console.WriteLine("4. Sort list by BySize");
                Console.WriteLine("5. Open a file");
                Console.WriteLine("0. Exit");
                Console.WriteLine();

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Wait a sec please!...");
                Console.ForegroundColor = ConsoleColor.White;

                if (Int32.TryParse(key.KeyChar.ToString(), out option))
                {
                    

                    switch (option)
                    {
                        case 1:
                            DisplayRequestFilesInformation();
                            break;
                        case 2:
                            RequestSortedFileInformation(OrderBy.ByType, fileList);
                            break;
                        case 3:
                            RequestSortedFileInformation(OrderBy.ByName, fileList);
                            break;
                        case 4:
                            RequestSortedFileInformation(OrderBy.BySize, fileList);
                            break;
                        case 5:
                            OpenFile(fileList);
                            break;
                    }
                }

            } while (option != 0);
        }



        private static void GetFilesInformation(bool byPath = true)
        {
            if (byPath)
                GetPath();

            IGetFileServices getFileList = container.GetInstance<IFabricService>().IGetFileServices();
            fileList = getFileList.GetFileInformation(path);
        }

        private static void DisplayRequestFilesInformation()
        {
            GetFilesInformation();
            ShowFilesAndWait(fileList);
        }

        private static void RequestSortedFileInformation(OrderBy option, List<FileC> fileList)
        {
            IFileExplorerService orderByService = container.GetInstance<IFabricService>().CreateFileExplorerService();
            List<FileC> SortedFileList = new List<FileC>();

            switch (option)
            {
                case OrderBy.ByType:
                    SortedFileList = orderByService.RequestFileListByType(fileList);
                    break;
                case OrderBy.ByName:
                    SortedFileList =  orderByService.RequestFileListByName(fileList);
                    break;
                case OrderBy.BySize:
                    SortedFileList =  orderByService.RequestFileListBySize(fileList);
                    break;
            }

            ShowFilesAndWait(SortedFileList);
        }

        private static string GetPath()
        {
            Console.WriteLine("Enter the path to perform a search");
            Console.WriteLine();
            path = Console.ReadLine();

            return path;
        }

        private static void OpenFile(IList<FileC> filec)
        {
            IGetFileServices getService = container.GetInstance<IFabricService>().IGetFileServices();            
            string filenumber;
            FileTypes fileType;

            DisplayFiles(filec);

            Console.WriteLine("Type the file number you would like to open");
            Console.WriteLine();
            filenumber = Console.ReadLine();

            Int32.TryParse(filenumber, out int index);
            index = index - 1;
            fileType = getService.GetFileType(filec[index]);
            IFileUtilsServices openFile = container.GetInstance<IFabricService>().CreateIFileUtilsServices(fileType);
            openFile.OpenFile(filec[index].DirectoryPath);
        }

        private static void ShowFilesAndWait(IList<FileC> filec)
        {
            DisplayFiles(filec);
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void DisplayFiles(IList<FileC> filec)
        {
            int count = 1;
            foreach (var fileItem in filec)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{count++}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Name:{fileItem.Name}\n Extension:{fileItem.Extension}\n Size:{fileItem.Size}\n IsReadOnly:{fileItem.IsReadOnly}\n DirectoryName:{fileItem.DirectoryName}\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("**********************************************************");
                Console.WriteLine();
            }
        }

    }
}
