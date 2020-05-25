using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public interface IValidation
    {
        bool CheckIfStringEmpty(string str);
        bool CheckIfPathCorrect(string path);
    }
}
