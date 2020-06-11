using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Controller;
using VirtualUI.Models;

namespace VirtualUI
{
    public class CompareFiles
    {
        IDeltaController dc;
        public string Content { get; set; }
        public string DatabaseContent { get; set; }
        public string FileId { get; set; }

        public CompareFiles()
        {

        }
        public CompareFiles(string content, string databaseContent, string fileId)
        {
            if (content == null || databaseContent == null || fileId == null)
            {
                throw new ArgumentException("Properties can't be null!");
            }

            Content = content;
            DatabaseContent = databaseContent;
            FileId = fileId;
        }

        public Delta Compare(string content, string databaseContent, string fileId)
        {

            string[] newText = content.Split(new string[] { "\\n" }, StringSplitOptions.None);
            string[] previous = databaseContent.Split(new string[] { "\\n" }, StringSplitOptions.None);

            int lengthOfNewText = newText.Length;
            int lengthOfPreviousText = previous.Length;

            if (lengthOfNewText < lengthOfPreviousText)
            {
                lengthOfNewText = lengthOfPreviousText;
            }

            string deltaContent = "";
            string previousContent = "";
            bool change = false;
            int row = 0;

            dc = new DeltaController();

            Delta d = new Delta();

            for (int i = 0; i < lengthOfNewText; i++)
            {
                if (newText.Length > i)
                {
                    deltaContent = newText[i];
                }

                if (previous.Length > i)
                {
                    previousContent = previous[i];
                }

                if (deltaContent != previousContent)
                {
                    row = i;
                    d.LineRange += ++row + ",";
                    d.Content += deltaContent + "\n";
                    change = true;
                    deltaContent = "";
                    previousContent = "";
                }

            }


            if (change)
            {
                d.FileId = fileId;
                if (dc.DeltaExists(d.FileId))
                {
                    dc.UpdateDelta(d);
                }
                else
                    dc.Add(d);

            }
            else
                d = null;

            return d;
        }
    }
}
