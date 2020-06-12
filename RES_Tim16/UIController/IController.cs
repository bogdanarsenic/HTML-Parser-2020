using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIController
{
    public interface IController
    {
        string Name { get; set; }
        string Content { get; set; }
        string DeltaContent { get; set; }
        string LineRange { get; set; }
        string DatabaseContent { get; set; }

        void SendDeltaInformation(string name, string content, string databaseContent);
    }
}
