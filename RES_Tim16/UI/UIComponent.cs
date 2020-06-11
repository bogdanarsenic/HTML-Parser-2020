using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIControllerMiddleware;

namespace UI
{
    public class UIComponent
    {
        private string DeltaContent { get; set; }
        private string TextContent { get; set; }
        private string LineRange { get; set; }
        private string DatabaseContent { get; set; }


        public UIComponent(IController controller)
        {
            string content = controller.ReceiveDeltaInformation();

            if (!content.Contains("|") || content.Split('|').Length != 3)
            {
                throw new ArgumentException("Something is wrong");
            }

            if (content.Split('|')[0] == "" || content.Split('|')[1] == "" || content.Split('|')[2] == "")
            {
                content = controller.Content;
                Console.WriteLine("This is a content which is the same: ");
                Console.WriteLine(content);
                Console.ReadLine();
            }
            else
            {

                this.DeltaContent = content.Split('|')[0];
                this.LineRange = content.Split('|')[1];
                this.DatabaseContent = content.Split('|')[2];
                this.TextContent = controller.Content;

                // get line range
                int[] linenumbers = GetLineRange(this.LineRange);

                // add colour

            }
        }

        public int[] GetLineRange(string lines)
        {
            int i = lines.Split(',').Length - 1;

            int[] linenumbers = new int[i];

            int LineNumber = 0;


            for (int y = 0; y < i; y++)
            {
                LineNumber = Convert.ToInt32(lines.Split(',')[y]);
                linenumbers[y] = LineNumber;
            }

            return linenumbers;
        }
    }
}
