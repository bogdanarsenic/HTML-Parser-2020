using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public interface IFileParser
    {
        string OpenExistingFileForParsing(string path);
        void CreateNewFileForParsing(string name, string content);
    }
}
