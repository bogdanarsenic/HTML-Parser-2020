using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public class Parser : IParser
    {
        public void AllowedTagsList(List<string> htmlTags)
        {
            throw new NotImplementedException();
        }

        public bool Check(string content)
        {
            throw new NotImplementedException();
        }

        public bool CheckHtmlStartTagsUntilTitle(string text)
        {
            throw new NotImplementedException();
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
