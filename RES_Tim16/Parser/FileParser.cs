using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class FileParser : IFileParser
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public void CreateNewFileForParsing(string name, string content)
        {
            List<string> list = new List<string>();
            IParser p = new Parser();
            list = p.SplitHtmlText(content);

            string pathforParser = @"C:\Users\Bogdan\Tim16\" + name;

            File.AppendAllLines(pathforParser, list);
        }

        public void OpenExistingFileForParsing(string name)
        {
            List<string> list2 = new List<string>();
            bool checkIfOk = false;
            string pathforParser = @"C:\Users\Bogdan\Tim16\" + name;
            string textForParsing = File.ReadAllText(pathforParser);

            if (textForParsing.EndsWith("\n"))
            {
                textForParsing=textForParsing.Remove(textForParsing.Length - 2, 2);
            }

            Console.WriteLine(textForParsing);

            IParser p1 = new Parser();
            checkIfOk = p1.CheckAllTags(textForParsing);

            if (checkIfOk)
            {
                Content = textForParsing;
                Name = name;
            }
            else
            {
                Content = "INVALID!";
                Name = name;
            }
        }


    }
}
