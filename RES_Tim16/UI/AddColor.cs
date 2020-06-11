using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class AddColor
    {
        public AddColor(string deltaText, int[] lines, string previousContent, string newContent)
        {

            string[] delta = deltaText.Split(new string[] { "\n" }, StringSplitOptions.None);
            string[] previous = previousContent.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] newContents = newContent.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            Array.Resize(ref delta, delta.Length - 1);

            int numLines = newContents.Length;
            int numLines1 = previous.Length;

            if (numLines < numLines1)
            {
                numLines = numLines1;
            }

            Console.WriteLine("Comparing old and new file...");
            Console.WriteLine("New file content is: ");


        }
    }
}
