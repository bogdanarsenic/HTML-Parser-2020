using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIController;
using VirtualUI.Models;

namespace VirtualUI
{
    public class VirtualUI
    {

        public IController controller;
        public IUpdatingDatabase update;
        public Files file;
        public FileContent fileContent;


        public VirtualUI(IController controller)
        {
            if(controller==null||controller.Name==null||controller.Content==null)
            {
                throw new ArgumentNullException("Can't be null");
            }

            if (controller.Name == "" || controller.Content == "")
            {
                throw new ArgumentException("Can't be empty");
            }

            this.controller = controller;

        }

        public void ParseInformationFromController()
        {
            if(!controller.Name.Contains('.')||controller.Name.Split('.').Length != 2 || controller.Name == ".")
            {
                throw new ArgumentException("Must have one dot");
            }

            file = new Files();
            file.Name = controller.Name.Split('.')[0];
            file.Extension = controller.Name.Split('.')[1];
            file.Id = controller.Name;

            fileContent = new FileContent();
            fileContent.FileId = file.Id;
            fileContent.Content = controller.Content;

            update = new UpdatingDatabase(file, fileContent, controller);
        }

    }
}
