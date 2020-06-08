using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIControllerMiddleware;

namespace UIController
{
    public class Controller : IController
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string DeltaContent { get; set; }
        public string LineRange { get; set; }
        public string DatabaseContent { get; set; }

        public Controller()
        {

        }

        public Controller(string name, string content)
        {
            if (name == null || content == null)
            {
                throw new ArgumentException("Properties can't be null!");
            }

            Name = name;
            Content = content;

            GetFileInformation();
        }

        public string GetFileInformation()
        {
           return Name + '|' + Content;
        }

        public string ReceiveDeltaInformation()
        {
            return DeltaContent + '|' + LineRange + '|' + DatabaseContent;
        }

        public void SendDeltaInformation(string textcontent, string lineRange, string databaseContent)
        {
            DeltaContent = textcontent;
            LineRange = lineRange;
            DatabaseContent = databaseContent;
            ReceiveDeltaInformation();
        }
    }
}
