using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Controller;
using VirtualUI.Models;

namespace VirtualUI
{
    public class UpdatingDatabase
    {
        public IFileController fileController;
        public IFileContentController fileContentController;
        public IDeltaController deltaController;

        public UpdatingDatabase()
        {

        }

        public UpdatingDatabase(Files file, FileContent fileContent)
        {

            fileController = new FileController();
            fileContentController = new FileContentController();
 

            if (fileController.FileExists(file.Id))
            {
                Console.WriteLine("FILE EXISTS IN DATABASE!!");
                Console.WriteLine("We will now start processing for the changes...");
              
            }
            else
            {
                Console.WriteLine("File doesn't Exists in database. Now we are going to add it");
                AddToDatabase(file, fileContent, fileController, fileContentController);
            }

        }


        public void AddToDatabase(Files file, FileContent fileContent, IFileController fc, IFileContentController fcc)
        {
            fc.Add(file);
            fcc.Add(fileContent);
            Console.ReadLine();

        }
    }
}
