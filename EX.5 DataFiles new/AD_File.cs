using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EX._5_DataFiles_new
{
    abstract class AD_File
    {
        protected string filename;
        protected DateTime lastupdatedtime;

        public AD_File(string filename)
        {
            Filename = filename;
            SetTime();
        }

        public string Filename
        {
            get { return this.filename; }
            set
            {
                if (!IsValidName(value))
                {
                    throw new Exception("Invalid file name.");
                }
                else
                    this.filename = value;
            }
        }

        public override string ToString()
        {
            return ($"File name: {Filename}. Last updated time: {lastupdatedtime}");
        }

        public override bool Equals(object obj)
        {
            AD_File temp = obj as AD_File;

            if (temp == null)
                throw new Exception("Invalid object!");
            else
            {
                return (Filename == temp.Filename);                    
            }
        }

        public abstract double GetSize();

        private bool IsValidName(string name)
        {
            char[] FalseChars = { '>', '?', '*', ':', '/', '\\', '|', '<' };
            return !(string.IsNullOrEmpty(name) || name.Any(c => FalseChars.Contains(c)));
        }

        protected void SetTime()
        {
            lastupdatedtime = DateTime.Now;
        }

    }
}
