using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX._5_DataFiles_new
{
    class Folder
    {
        private string folder,path;
        private static Folder root = new Folder("root","");
        private AD_File[] allfolders = new AD_File[0];

        public Folder(string folder,string path)
        {
            FolderName = folder;
            Path = path;
        }

        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }
        public string FolderName
        {
            get { return this.folder; }
            set
            {
                this.folder = value;
            }
        }
    }
}
