using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX._5_DataFiles_new
{
    enum FileTypeExtension { TXT = 1, DOC, DOCX, PDF, PPTX }

    class DataFile :AD_File,IComparable<DataFile>
    {
        private string data;
        private FileTypeExtension fileType;

        public DataFile(string filename,string data, FileTypeExtension filetype):base(filename)
        {
            Data = data;
            Filetype = fileType;
        }


        public FileTypeExtension Filetype
        {
            get { return this.fileType; }
            set
            {
                this.fileType = value;
            }
        }

        public string Data
        {
            get { return this.data; }
            set
            {
                this.data = value;
            }
        }

        public int CompareTo(DataFile other)
        {

            if (other == null)
                throw new Exception("Cant compare with null DataFile!");
            else
                return (this.GetSize().CompareTo(other.GetSize()));
        }

        public override bool Equals(object obj)
        {
            DataFile temp = obj as DataFile;

            if (temp == null)
                throw new Exception("Invalid object!");
            else
                return (base.Equals(obj) && this.data == temp.data);
        }

        public override string ToString()
        {
            string res = base.ToString();
            res += $"\nData: {Data}\n Size in KB: {GetSize()}";
            return res;
        }


        public override double GetSize()
        {
            return (long)(data.Length/1024.0);
        }
    }
}
