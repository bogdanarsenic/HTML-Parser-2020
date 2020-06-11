using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIController;
using UIControllerMiddleware;
using VirtualUI;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = "";
            string textcontent="";
            bool input = false;

            IValidation validate = new Validation();


            while (!input)
            {
                Console.WriteLine("-----MENU-----");
                Console.WriteLine("Choose an option from menu: ");
                Console.WriteLine("1. Insert file path");
                Console.WriteLine("2. Write html directly");
                Console.WriteLine("If you want to exit - click X");
                Console.WriteLine("--------------");
                option = Console.ReadLine();

                switch (option)
                {
                    case "1": 

                        Console.WriteLine("Insert file path:");
                        option = Console.ReadLine();
                        
                        if(!validate.CheckIfStringEmpty(option) && validate.CheckIfPathCorrect(option))
                        {
                            //Proslediti parseru
                            input = true;
                            Console.ReadLine();
                        }

                        break;

                    case "2":

                        Console.WriteLine("Write the filename:");
                        option = Console.ReadLine();
                        bool nameEmpty = validate.CheckIfStringEmpty(option);

                        if(nameEmpty || validate.CheckIfPathCorrect(option))
                        {
                            Console.WriteLine("Choose another name!");
                            break;
                        }

                        Console.WriteLine("Write the file content:");
                        textcontent = Console.ReadLine();
                        bool contentEmpty=validate.CheckIfStringEmpty(textcontent);

                        if(contentEmpty)
                        {
                            break;
                        }

                        IController uIController = new Controller(option, textcontent);

                        VirtualUI.VirtualUI virtualUI5 = new VirtualUI.VirtualUI(uIController);

                        //Prosledjuje se parseru.
                        input = true;
                        break;
                    case "X":
                        input = true;
                        break;
                    default:
                        Console.WriteLine("You need to put 1 or 2");
                        break;
                }
            }

        }

    }
}
