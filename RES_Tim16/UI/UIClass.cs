using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIController;

namespace UI
{
    public class UIClass
    {
        private string DeltaContent { get; set; }
        private string TextContent { get; set; }
        private string LineRange { get; set; }
        private string DatabaseContent { get; set; }


        public UIClass(IController controller)
        {
            if (controller.LineRange == "")
            {
                Console.WriteLine("This is a content which is the same: ");
                Console.WriteLine(controller.Content);
                Console.ReadLine();
            }
            else
            {

                this.DeltaContent = controller.DeltaContent;
                this.LineRange = controller.LineRange;
                this.DatabaseContent = controller.DatabaseContent;
                this.TextContent = controller.Content;

                // get line range
                int[] linenumbers = GetLineRange(this.LineRange);

                // add colour
                AddColor ac = new AddColor(this.DeltaContent, linenumbers, this.DatabaseContent, this.TextContent);
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
