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
            try
            {
                if (dBManager.FileExists(id))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

        }

        public bool Add(Files f)
        {
            try
            {
                if (dBManager.AddFile(f))
                {
                    Console.WriteLine("New file has been added.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Somethingg is wrong");
                    return false;
                }

            }
            catch 
            {
                return false;
            }
        }
    }
}
