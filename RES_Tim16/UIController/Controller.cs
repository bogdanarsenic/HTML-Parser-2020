using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIController
{
    public class Controller : IController
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string DeltaContent { get; set; }
        public string LineRange { get; set; }
        public string DatabaseContent { get; set; }

        public Controller(IFileParser fp)
        {
            if (fp.Name == null || fp.Content == null)
            {
                throw new ArgumentException("Properties can't be null!");
            }

            Name = fp.Name;
            Content = fp.Content;

        }

        public void SendDeltaInformation(string textcontent, string lineRange, string databaseContent)
        {
            DeltaContent = textcontent;
            LineRange = lineRange;
            DatabaseContent = databaseContent;
        }
    }
}
