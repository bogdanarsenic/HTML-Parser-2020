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
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("String is NULL or empty!");
                return true;
            }
            else
                return false;
        }

        public bool CheckIfPathCorrect(string path)
        {
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
