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

        public IController controller;

        public UIClass(IController controller)
        {
            if (controller.LineRange == "" || controller.LineRange==null)
            {
                Console.WriteLine("This is a content which is the same: ");
                Console.WriteLine(controller.Content);
                Console.ReadLine();
            }
            else
            {
                this.controller = controller;
                int[] linenumbers = GetLineRange(this.controller.LineRange);

                // add colour
                AddColor ac = new AddColor(linenumbers, this.controller);
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
