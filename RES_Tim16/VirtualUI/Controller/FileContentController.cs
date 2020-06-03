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
            try
            {
                if (dBManager.AddFileContent(fileContent))
                {
                    Console.WriteLine(DateTime.Now + ": FileContent Added to Database.");

                    return true;
                }
                else
                {
                    Console.WriteLine(DateTime.Now + ": FileContent wasn't added to Database.");
                    return false;
                }
            }
            catch
            { 
                return false;
            }
        }

        public bool UpdateFileContent(FileContent fileContent)
        {
            try
            {
                if (dBManager.UpdateFileContent(fileContent))
                {
                    Console.WriteLine(DateTime.Now + ": FileContent Updated to Database.");

                    return true;
                }
                else
                {
                    Console.WriteLine(DateTime.Now + ": FileContent wasn't Updated to Database.");
                    return false;
                }
            }
            catch
            {
                Console.WriteLine(DateTime.Now + ": FileContent wasn't Updated to Database.");
                return false;
            }
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
