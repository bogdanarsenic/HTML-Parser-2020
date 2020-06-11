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

        public bool CheckAllTags(string content)
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
            List<string> tagList = new List<string>() { "b", "p", "a", "ul", "li" };

            bool check = false;

            foreach (string tag in tagList)
            {
                if (!CheckIfValidTag(SplitHtmlText(text), tag))
                {
                    check = false;
                    break;
                }
                else
                {
                    check = true;
                }
            }

            return check;
        }

        public bool CheckHtmlTagsNotInsideBody(string text)
        {
            if (CheckHtmlStartTagsUntilTitle(text) && CheckHtmlTagsAfterTitleUntilBody(text) && CheckHtmlTagsAfterBodyUntilEnd(text))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfValidTag(List<string> list, string tag)
        {
            // 1. number of open tags and closed tags must be equal
            int i, j;
            int numberOfOpenTags = 0;
            int numberOfClosedTags = 0;
            string tagOpen = '<' + tag + '>', tagClosed = "</" + tag + '>';

            for (i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(tagOpen))
                {
                    numberOfOpenTags++;
                }
                if (list[i].Equals(tagClosed))
                {
                    numberOfClosedTags++;
                }
            }

            if (numberOfOpenTags != numberOfClosedTags)
            {
                Console.WriteLine("Number of {0} and {1} tags is not the same!", tagOpen, tagClosed);
                return false;
            }

            if (numberOfOpenTags == 0)
            {
                // There are no this type of tags in body, so its valid

                return true;
            }

            // 2. if we encounter first CLOSED tag in the list (</p>), thats also not VALID (first tag in the list must be OPEN tag <p>)

            int firstTag = 0;       // if we encounter CLOSED tag == 1
                                    // if we encounter OPEN tag == 2
                                    // if none from above == 0
            i = 0;
            while (i < list.Count)
            {
                if (list[i].Equals(tagClosed))
                {
                    firstTag = 1;
                    break;
                }
                else if (list[i].Equals(tagOpen))
                {
                    firstTag = 2;
                    break;
                }
                else
                {
                    firstTag = 0;
                    i++;
                }
            }

            if (firstTag == 1)
            {
                Console.WriteLine("First encountered tag in list of tags is CLOSED, body is INVALID!");
                return false;
            }

            bool check = false;     // this check is if everything is okay in whole body

            for (i = 0; i < list.Count - 1; i++)
            {
                if (list[i].Equals(tagClosed))             // if we find two consecutive CLOSED p tags in body -> INVALID
                {
                    Console.WriteLine("Two consecutive CLOSED tags in body -> INVALID!");
                    return false;
                }

                if (list[i].Equals(tagOpen))             // when we find first open p tag, we are searching for the first closed p tag
                {
                    j = i + 1;

                    while (j < list.Count)         // searching until find </p> or until reach end of list or if we find two consecutive open p tags
                    {
                        if (list[j].Equals(tagClosed))
                        {
                            check = true;
                            break;
                        }
                        else if (list[j].Equals(tagOpen))    // if we find another open p tag, after the open p tag, INVALID
                        {
                            Console.WriteLine("Two consecutive OPEN tags in body -> INVALID!");
                            return false;
                        }
                        else
                        {
                            check = false;
                            j++;
                        }

                    }

                    i = j;

                }
            }

            return check;
        }

        public List<string> SplitHtmlText(string text)
        {
            string[] htmlTextListOfWords = text.Split('<', '>');
            List<string> list1 = new List<string>();

            foreach (string s in htmlTextListOfWords)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    list1.Add(s);
                }

            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Equals("html") || list1[i].Equals("/html") || list1[i].Equals("head") || list1[i].Equals("/head") || list1[i].Equals("body")
                    || list1[i].Equals("/body") || list1[i].Equals("p") || list1[i].Equals("/p") || list1[i].Equals("ul") || list1[i].Equals("/ul")
                    || list1[i].Equals("li") || list1[i].Equals("/li") || list1[i].Equals("b") || list1[i].Equals("/b") || list1[i].Equals("a") || list1[i].Equals("/a")
                    || list1[i].Equals("title") || list1[i].Equals("/title") || list1[i].Equals("br")
                    )
                {
                    list1[i] = '<' + list1[i] + '>';
                }

            }

            return list1;
        }
    }
}
