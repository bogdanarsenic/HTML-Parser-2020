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

            AddDifference(previous, newContents, delta, numLines, lines);
        }

        public void AddDifference(string[] databaseText, string[] newText, string[] delta, int numberOfLines, int[] lines)
        {
            int y = 0;
            for (int i = 1; i <= numberOfLines; i++)
            {

                if (lines.Contains(i))
                {
                    if (databaseText.Length >= i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("-" + i + "." + databaseText[i - 1]);

                    }

                    if (delta[y] == "")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        y++;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("+" + i + "." + newText[i - 1]);

                        y++;
                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("*" + i + "." + newText[i - 1]);
                }
            }

            Console.ReadLine();
        }
    }
}
