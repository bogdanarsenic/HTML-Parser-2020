using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Parser
{
    public class Parser : IParser
    {
        public void AllowedTagsList(List<string> htmlTags)
        {
           
                int i = 1;
                Console.WriteLine("Allowed html tags: ");
                foreach (string s in htmlTags)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine(s + ' ');
                    }
                    else
                    {
                        Console.Write(s + ' ');
                    }
                    i++;
                }
            
        }

        public bool Check(string content)
        {
            throw new NotImplementedException();
        }

        public bool CheckHtmlStartTagsUntilTitle(string text)
        {
            string htmlStartTagsUntilTitle = "<html><head><title>";

            string trim = Regex.Replace(text, @"\s+", "");

            if (trim.StartsWith(htmlStartTagsUntilTitle))
            {
                return true;
            }

            return false;
        }

        public bool CheckHtmlTagsAfterBodyUntilEnd(string text)
        {
            throw new NotImplementedException();
        }

        public bool CheckHtmlTagsAfterTitleUntilBody(string text)
        {
            throw new NotImplementedException();
        }

        public bool CheckHtmlTagsInsideBody(string text)
        {
            throw new NotImplementedException();
        }

        public bool CheckHtmlTagsNotInsideBody(string text)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfValidTag(List<string> list, string tag)
        {
            throw new NotImplementedException();
        }

        public List<string> SplitHtmlText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
