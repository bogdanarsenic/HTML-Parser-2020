using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public interface IFileParser
    {
        string Name { get; set; }
        string Content { get; set; }

        void OpenExistingFileForParsing(string name);
        void CreateNewFileForParsing(string name, string content);
    }
}
