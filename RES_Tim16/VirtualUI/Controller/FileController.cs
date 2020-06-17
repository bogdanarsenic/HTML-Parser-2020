using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Models;

namespace VirtualUI.Controller
{
    public class FileController : IFileController
    {
        DBManager dBManager = DBManager.Instance;

        public bool FileExists(string id)
        {
            return dBManager.FileExists(id);
        }   

        public bool Add(Files f)
        {
            return dBManager.AddFile(f);            
        }
    }
}
