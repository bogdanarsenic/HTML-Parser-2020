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
        public int[] LineNumbers { get; set; }

        public UIClass(IController controller)
        {
            if(controller==null)
            {
                this.controller = controller ?? throw new ArgumentNullException("IController while making UI Class can't be null");

            }

            if (controller.DatabaseContent==null || controller.DeltaContent==null || controller.LineRange==null)
            {
                Console.WriteLine("This is a content: ");
                Console.WriteLine(controller.Content);
                Console.ReadLine();
            }
            else
            {
                this.controller = controller;
                int[] linenumbers = GetLineRange(controller.LineRange);
                this.LineNumbers = linenumbers;
            }
        }

        public int[] GetLineRange(string lines)
        {
            if(lines==null)
            {
                throw new ArgumentNullException("Can't be null");
            }

            if(!lines.Contains(","))
            {
                throw new ArgumentException("Lines needs to have at least one , ");
            }

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
