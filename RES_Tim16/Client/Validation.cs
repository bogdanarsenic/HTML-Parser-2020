using System;
using System.Collections.Generic;
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
    }
}
