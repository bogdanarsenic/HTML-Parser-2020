using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Validation : IValidation
    {
        

        public bool CheckIfStringEmpty(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                Console.WriteLine("Input can not be empty!");
                return true;
            }
            else
                return false;
        }

        public bool CheckIfPathCorrect(string path)
        {
            path = @"C:\Users\Bogdan\Tim16\" + path;

            if (File.Exists(path))
            {
                Console.WriteLine("File exists!");
                return true;
            }
            else
            {
                Console.WriteLine("File does not exists!");
                return false;
            }
        }

        public bool ValidFileName(string name)
        {
            if(!name.Contains(".")||name.Split('.').Length!=2)
            {
                Console.WriteLine("Invalid file name. You need to put one dot.");
                return false;
            }
            string fileName = name.Split('.')[0];
            string extension= name.Split('.')[1];
            if(extension!="txt")
            {
                Console.WriteLine("Invalid extension!");
                return false; 
            }
            if (fileName.Contains("< ")||fileName.Contains(">")||fileName.Contains(":")|| fileName.Contains("/")||fileName.Contains("|") || fileName.Contains("?") || fileName.Contains("*"))
            {
                Console.WriteLine("Invalid file name. You have forbidden character in file name!");
                return false;
            }

            return true;
        }
    }
}
