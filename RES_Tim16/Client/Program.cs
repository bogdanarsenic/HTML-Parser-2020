using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string option = "";
            string textcontent="";

            while (option == "")
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

                        IValidation validate = new Validation();
                        Console.WriteLine("Insert file path:");
                        option = Console.ReadLine();
                        
                        if(!validate.CheckIfStringEmpty(option) && validate.CheckIfPathCorrect(option))
                        {
                            //Proslediti parseru
                            Console.ReadLine();
                        }

                        option = "";
                        break;

                    case "2":

                        IValidation validateOpt2 = new Validation();
                        Console.WriteLine("Write the filename:");
                        option = Console.ReadLine();
                        bool nameEmpty=validateOpt2.CheckIfNameEmpty(option);

                        if(nameEmpty)
                        {
                            option = "";
                            break;
                        }

                        Console.WriteLine("Write the file content:");
                        textcontent = Console.ReadLine();
                        bool contentEmpty=validateOpt2.CheckIfContentEmpty(textcontent);

                        if(contentEmpty)
                        {
                            option = "";
                            break;
                        }

                        //Prosledjuje se parseru.
                        option = "";
                        break;
                    case "X":
                        option = "x";
                        break;
                    default:
                        option = "";
                        Console.WriteLine("You need to put 1 or 2");
                        break;
                }
            }

        }

    }
}
