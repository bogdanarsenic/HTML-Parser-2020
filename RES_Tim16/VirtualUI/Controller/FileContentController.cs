using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Models;

namespace VirtualUI.Controller
{
    public class FileContentController : IFileContentController
    {
        DBManager dBManager = DBManager.Instance;


        public bool Add(FileContent fileContent)
        {
            return dBManager.AddFileContent(fileContent);         
        }

        public bool UpdateFileContent(FileContent fileContent)
        {
                return dBManager.UpdateFileContent(fileContent);
        }

        public string GetContent(string id)
        {
            string content = null;
            content = dBManager.GetContent(id);
            return content;
        }

        public string GetFileContentId(string id)
        {
            string idFileContent = null;
            idFileContent = dBManager.GetFileContentId(id);
            return idFileContent;
        }
    }
}
