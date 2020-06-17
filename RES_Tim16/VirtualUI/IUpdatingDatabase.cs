using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Controller;
using VirtualUI.Models;

namespace VirtualUI
{
    public interface IUpdatingDatabase
    {
        void AddToDatabase(Files file, FileContent fileContent, IFileController fc, IFileContentController fcc);
        void UpdateFileContent(IFileContentController fcc, FileContent fc, string fileId);
    }
}
