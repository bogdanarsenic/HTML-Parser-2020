using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIControllerMiddleware;
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

        public UpdatingDatabase(Files file, FileContent fileContent, IController ic)
        {
            Delta delta = new Delta();
            fileController = new FileController();
            fileContentController = new FileContentController();

            deltaController = new DeltaController();

            delta = null;

            if (fileController.FileExists(file.Id))
            {
                Console.WriteLine("FILE EXISTS IN DATABASE!!");
                Console.WriteLine("We will now start processing for the changes...");

                string databaseContent = fileContentController.GetContent(file.Id);

                if (databaseContent != fileContent.Content)
                {
                   CompareFiles cf = new CompareFiles(fileContent.Content, databaseContent, file.Id);
                   delta = cf.Compare(fileContent.Content, databaseContent, file.Id);
                }

                if (delta != null)
                {
                    UpdateFileContent(fileContentController, fileContent, file.Id);
                    SendDeltaInformation sd = new SendDeltaInformation(delta, databaseContent, ic);

                }
                else
                {
                    Console.WriteLine("No changes! File contents are completely the same");
                }
            }
            else
            {
                Console.WriteLine("File doesn't Exists in database. Now we are going to add it");
                AddToDatabase(file, fileContent, fileController, fileContentController);
            }

        }

        public void UpdateFileContent(IFileContentController fcc, FileContent fc, string fileId)
        {
            string fileContentId = fcc.GetFileContentId(fileId);
            fc.Id = fileContentId;
            fcc.UpdateFileContent(fc);
        }

        public void AddToDatabase(Files file, FileContent fileContent, IFileController fc, IFileContentController fcc)
        {
            fc.Add(file);
            fcc.Add(fileContent);
            Console.ReadLine();

        }
    }
}
