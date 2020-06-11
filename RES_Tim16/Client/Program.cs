using Parser;
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
                        string path = Console.ReadLine();
                        
                        if(!validate.CheckIfStringEmpty(path) && validate.CheckIfPathCorrect(path))
                        {
                            //Forward to parser
                            FileParser fp1 = new FileParser();
                            string checkIfValidFileContent1 = "";
                            checkIfValidFileContent1 = fp1.OpenExistingFileForParsing(path);

                            if (!checkIfValidFileContent1.Equals("INVALID!"))
                            {
                                IController uIController1 = new Controller(path, checkIfValidFileContent1);
                                VirtualUI.VirtualUI virtualUI1 = new VirtualUI.VirtualUI(uIController1);
                            }

                            input = false;
                            Console.ReadLine();
                        }

                        break;

                    case "2":

                        Console.WriteLine("Write the filename:");
                        string fileName = Console.ReadLine();
                        bool nameEmpty = validate.CheckIfStringEmpty(fileName);

                        if(nameEmpty || validate.CheckIfPathCorrect(fileName))
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

                        //Forward to parser
                        FileParser fp2 = new FileParser();
                        fp2.CreateNewFileForParsing(fileName, textcontent);

                        string checkIfValidFileContent2 = "";
                        checkIfValidFileContent2 = fp2.OpenExistingFileForParsing(fileName);

                        if (!checkIfValidFileContent2.Equals("INVALID!"))
                        {
                            IController uIController2 = new Controller(fileName, checkIfValidFileContent2);
                            VirtualUI.VirtualUI virtualUI2 = new VirtualUI.VirtualUI(uIController2);
                        }

                        input = false;
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
