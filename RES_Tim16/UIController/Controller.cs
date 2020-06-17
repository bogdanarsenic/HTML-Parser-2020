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
        public IFileParser fp;


        public Controller(IFileParser fp)
        {
            if (fp == null || fp.Name == null || fp.Content == null)
            {
                throw new ArgumentNullException("Properties can't be null!");
            }

            if(fp.Name == "" || fp.Content == "")
            {
                throw new ArgumentException("Properties can't be empty!");
            }

            Name = fp.Name;
            Content = fp.Content;

        }

        public void SendDeltaInformation(string textcontent, string lineRange, string databaseContent)
        {

            if(textcontent==null || lineRange==null || databaseContent==null)
            {
                throw new ArgumentNullException("Can't have null properties in Send Delta Information");
            }

            if (textcontent == "" || lineRange == "" || databaseContent == "")
            {
                throw new ArgumentException("Can't have empty properties in Send Delta Information");
            }

            DeltaContent = textcontent;
            LineRange = lineRange;
            DatabaseContent = databaseContent;
        }
    }
}
