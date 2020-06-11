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
        public void CreateNewFileForParsing(string name, string content)
        {
            string pathforParser = @"C:\Users\Bogdan\Tim16\" + name;
            File.WriteAllText(pathforParser, content);
        }

        public string OpenExistingFileForParsing(string path)
        {
            bool checkIfOk = false;
            string pathforParser = @"C:\Users\Bogdan\Tim16\" + path;
            string textForParsing = File.ReadAllText(pathforParser);

            Console.WriteLine(textForParsing);

            Parser p1 = new Parser();
            checkIfOk = p1.CheckAllTags(textForParsing);

            if (checkIfOk)
            {
                return textForParsing;
            }
            else
            {
                return "INVALID!";
            }
        }


    }
}
