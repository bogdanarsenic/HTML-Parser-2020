using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Models;

namespace VirtualUI.Controller
{
    public interface IFileController
    {
        bool FileExists(string id);
        bool Add(Files f);
    }
}
