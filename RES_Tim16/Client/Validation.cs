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
            path = @"C:\Users\Dejan\Desktop\Tim16\" + path;

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
    }
}
