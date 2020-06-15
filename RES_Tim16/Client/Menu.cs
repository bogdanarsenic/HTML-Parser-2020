using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Menu
    {
        public IValidation validate;
        public string key;

        public void Print()
        {
            do
            {
                Console.WriteLine("-----MENU-----");
                Console.WriteLine("Choose an option from menu: ");
                Console.WriteLine("1. Insert file name");
                Console.WriteLine("2. Write html directly");
                Console.WriteLine("If you want to exit - click X");
                Console.WriteLine("--------------");

                key = Console.ReadLine();

            } while (key != "1" && key != "2" && key != "x" && key != "X");


            switch(key)
            {
                case "1":
                            Console.WriteLine("Insert file name:");
                            string nameFile = Console.ReadLine();

                            if (validate.CheckIfPathCorrect(nameFile) && !validate.CheckIfStringEmpty(nameFile))
                            {
                                IFileParser p1 = new FileParser();
                                p1.OpenExistingFileForParsing(nameFile);
                                
                                
                                
                            }

                            break;
                case "2":
                            Console.WriteLine("Write file name:");
                            string nameFile2 = Console.ReadLine();

                            if(validate.CheckIfPathCorrect(nameFile2) || validate.CheckIfStringEmpty(nameFile2))
                            {
                                
                            }
                            Console.WriteLine("Write file content:");
                            string fileContent = Console.ReadLine();

                    break;
                case "x":
                    break;
                case "X":
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
