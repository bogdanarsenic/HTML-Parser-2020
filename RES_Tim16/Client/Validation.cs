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
                Console.WriteLine("String can not be empty!");
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

        public bool CheckIfNameEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name can not be empty!");
                return true;
            }
            else
                return false;
        }

        public bool CheckIfContentEmpty(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                Console.WriteLine("Content is empty!");
                return true;
            }
            else
                return false;
        }
    }
}
