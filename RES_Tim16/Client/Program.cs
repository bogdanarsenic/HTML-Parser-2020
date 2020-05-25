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

            while (option == "")
            {

                Console.WriteLine("Choose an option from menu: ");
                Console.WriteLine("1. Insert file path");
                Console.WriteLine("2. Write html directly");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("Insert file path:");
                        option = Console.ReadLine();
                        IValidation validate = new Validation();

                        if(!validate.CheckIfStringEmpty(option))
                        {
                            
                        }
                        
                        break;
                    case "2":
                        Console.WriteLine("Write the filename:");
                        option = Console.ReadLine();
                        Console.WriteLine("Write the file content:");
                        break;
                    default:
                        option = "";
                        Console.WriteLine("You need to put 1 or 2");
                        break;
                }
            }

            Console.WriteLine("Enter for exit");
            Console.ReadLine();
        }

    }
}
