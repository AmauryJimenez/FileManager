using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FileC
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string DirectoryName { get; set; }
        public bool IsReadOnly { get; set; }
        public long Size { get; set; }
        public string DirectoryPath { get; set; }

        public FileC()
        {

        }
    
    }
}
