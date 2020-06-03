using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Models;

namespace VirtualUI.Controller
{
    public interface IFileContentController
    {
        bool Add(FileContent fileContent);
        string GetContent(string id);
        bool UpdateFileContent(FileContent fileContent);
        string GetFileContentId(string fileId);
    }
}
