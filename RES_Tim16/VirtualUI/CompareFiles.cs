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
        public IDeltaController dc;

        public CompareFiles(IDeltaController dc)
        {
            this.dc = dc ?? throw new ArgumentNullException("IDeltaController can't be null");
        }

        public Delta Compare(string content, string databaseContent, string fileId)
        {
            if(!content.Contains("\r\n") || !databaseContent.Contains("\r\n"))
            {
                throw new ArgumentException("Must have \r\n so it could be parsed");
            }


            string[] newText = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] previous = databaseContent.Split(new string[] { "\r\n" }, StringSplitOptions.None);

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
