using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using UIController;

namespace Client
{
    public class Menu
    {
        public IValidation validate;
        public string key;
        public bool input=false;

        public void Print()
        {
            validate = new Validation();
            key = "";

          while (!input)
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

                                    if (!p1.Content.Equals("INVALID!"))
                                    {
                                        IController uIController1 = new Controller(p1);
                                        VirtualUI.VirtualUI virtualUI1 = new VirtualUI.VirtualUI(uIController1);
                                        UIClass ui = new UIClass(uIController1);
                                    }
                                }
                                input = false;
                                Console.ReadLine();

                                break;
                    case "2":
                                Console.WriteLine("Write file name:");
                                string nameFile2 = Console.ReadLine();

                                if(validate.CheckIfPathCorrect(nameFile2) || validate.CheckIfStringEmpty(nameFile2))
                                {
                                        Console.WriteLine("Choose another name!");
                                        break;
                                }

                                Console.WriteLine("Write file content:");
                                string fileContent = Console.ReadLine();

                                if(validate.CheckIfStringEmpty(fileContent))
                                {
                                    break;
                                }

                                //Forward to parser
                                IFileParser fp2 = new FileParser();
                                fp2.CreateNewFileForParsing(nameFile2, fileContent);

                                fp2.OpenExistingFileForParsing(nameFile2);

                                if (!fp2.Content.Equals("INVALID!"))
                                {
                                    IController uIController2 = new Controller(fp2);
                                    VirtualUI.VirtualUI virtualUI2 = new VirtualUI.VirtualUI(uIController2);
                                    UIClass ui = new UIClass(uIController2);

                                }

                                input = false;
                                break;

                    case "x":
                                input = true;
                                break;
                    case "X":
                                input = true;
                                break;
                    default:
                                throw new NotSupportedException();
                }
            }
        }
    }
}
