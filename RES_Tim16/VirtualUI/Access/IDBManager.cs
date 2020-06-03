using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Models;

namespace VirtualUI.Access
{
    public interface IDBManager
    {
        #region File
        bool AddFile(Files f);
        bool FileExists(string id);
        #endregion

        #region FileContent
        bool AddFileContent(FileContent fcontent);
        bool UpdateFileContent(FileContent fcontent);
        string GetContent(string id);
        #endregion

        #region Delta
        bool AddDelta(Delta d);
        bool UpdateDelta(Delta d);
        bool DeltaExists(string id);

        #endregion
    }
}
