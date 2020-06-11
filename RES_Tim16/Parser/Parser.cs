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
            string htmlStartTagsUntilTitle = "<html><head><title>";
            string htmlTagsAfterTitleUntilBody = "</title></head><body>";
            string htmlTagsAfterBodyUntilEnd = "</body></html>";

            string trim = Regex.Replace(text, @"\s+", "");              // deleting all whitespaces
            //Console.WriteLine("deleting all whitespaces -> " + trim);

            if (htmlStartTagsUntilTitle.Length > trim.Length)
            {
                return false;
            }
            trim = trim.Remove(0, htmlStartTagsUntilTitle.Length);      // deleting tags until title
                                                                        //Console.WriteLine("deleting tags until title -> " + trim);
            if (!trim.Contains('<'))
            {
                return false;
            }
            trim = trim.Substring(trim.IndexOf('<'));                   // deleting title
            //Console.WriteLine("deleting title -> " + trim);

            if (htmlTagsAfterTitleUntilBody.Length > trim.Length)
            {
                return false;
            }
            trim = trim.Remove(0, htmlTagsAfterTitleUntilBody.Length);  // deleting tags after title and until the body
            //Console.WriteLine("deleting tags after title and until the body -> " + trim);

            if (!trim.Contains("</body>"))
            {
                return false;
            }
            trim = trim.Substring(trim.IndexOf("</body>"));                   // deleting text inside body tags
                                                                              //Console.WriteLine("deleting text inside body tags -> " + trim);
                                                                              // string trim should now be == </body></html>  if html file is in correct format

            if (trim.Equals(htmlTagsAfterBodyUntilEnd))
            {
                return true;
            }

            return false;
        }

        public bool CheckHtmlTagsAfterTitleUntilBody(string text)
        {
            string htmlStartTagsUntilTitle = "<html><head><title>";
            string htmlTagsAfterTitleUntilBody = "</title></head><body>";

            string trim = Regex.Replace(text, @"\s+", "");

            if (htmlStartTagsUntilTitle.Length > trim.Length)
            {
                return false;
            }
            trim = trim.Remove(0, htmlStartTagsUntilTitle.Length);

            if (!trim.Contains('<'))
            {
                return false;
            }
            trim = trim.Substring(trim.IndexOf('<'));

            if (trim.StartsWith(htmlTagsAfterTitleUntilBody))
            {
                return true;
            }

            return false;
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
