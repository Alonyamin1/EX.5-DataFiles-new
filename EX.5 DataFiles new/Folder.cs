using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX._5_DataFiles_new
{
    class Folder:AD_File,ICompleteable
    {
        private string folder,path;
        private static Folder root = new Folder("root","");
        private AD_File[] allfiles;
        private int numOfFiles;
        public Folder(string folder,string path):base(folder)
        {
            numOfFiles = 0;
            Path = path;
            allfiles = new AD_File[10];
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

        public bool IsFull(uint size)
        {
            if (size < 0)
                throw new Exception("Size cant be negative");
            return (this.GetSize() >= size);
        }

        public void addfileToArray(AD_File f)
        {
            if (f == null)
                throw new Exception("Cant add null file.");
            try
            {
                for (int i = 0; i < numOfFiles; i++)
                {
                    if (allfiles[i].Equals(f))
                        throw new Exception("File already exists");

                }
                if (numOfFiles >= allfiles.Length)
                {
                    Array.Resize(ref allfiles, allfiles.Length * 2);
                    allfiles[++numOfFiles] = f;
                }
                else
                    allfiles[++numOfFiles] = f;
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message); 
            }
            catch(Exception)
            {
                Console.WriteLine("Unexpected error.");
            }
        }



        public override double GetSize()
        {
            double total = 0;
            for(int i=0;i<numOfFiles;i++)
            {
                //if (allfiles[i] is Folder f)
                //    total += f.GetSize();
                //else
                total += allfiles[i].GetSize();
            }
            return total;
        }

        public string getFullPath()
        {
            return (Path + "\\" + FolderName);
        }

        public Folder cd(string path)
        {
            string[] foldersarr = path.Split('\\');
            List<string> folders = new List<string>();
            folders.AddRange(foldersarr);
            string fol = folders[0];
            folders.Remove(fol);
            string new_path = String.Join("\\", folders);
            if (path == "") return this;
            foreach(AD_File f in root.allfiles)
            {
                Folder subfolder = f as Folder;
                if(subfolder != null)
                {
                    if(subfolder.folder == fol)
                    {
                        subfolder.cd(new_path);
                    }
                }
            }
            throw new Exception("No Such file or directory");


        }

    }
}
