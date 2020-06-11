using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    public interface IParser
    {
        bool CheckAllTags(string content);
        void AllowedTagsList(List<string> htmlTags);
        bool CheckHtmlStartTagsUntilTitle(string text);
        bool CheckHtmlTagsAfterTitleUntilBody(string text);
        bool CheckHtmlTagsAfterBodyUntilEnd(string text);
        bool CheckHtmlTagsNotInsideBody(string text);
        List<string> SplitHtmlText(string text);
        bool CheckHtmlTagsInsideBody(string text);
        bool CheckIfValidTag(List<string> list, string tag);

    }
}
