using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIControllerMiddleware
{
    public interface IController : IControllerForUI
    {
        string Name { get; set; }
        string Content { get; set; }
        string DeltaContent { get; set; }
        string LineRange { get; set; }
        string DatabaseContent { get; set; }

        string GetFileInformation();

        void SendDeltaInformation(string name, string content, string databaseContent);
    }
}
