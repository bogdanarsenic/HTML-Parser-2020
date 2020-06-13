using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIController;
using VirtualUI.Models;

namespace VirtualUI
{
    public class VirtualUI
    {

        public string Name { get; set; }
        public string Content { get; set; }

        public IController controller;


        public VirtualUI(IController controller)
        {
            this.controller = controller;

            Name = controller.Name;
            Content = controller.Content;

            ParseInformationFromController(Name, Content);

        }

        public void ParseInformationFromController(string name, string content)
        {

            Files file = new Files();
            file.Name = name.Split('.')[0];
            file.Extension = name.Split('.')[1];
            file.Id = name;

            FileContent fileContent = new FileContent();
            fileContent.FileId = file.Id;
            fileContent.Content = content;

            UpdatingDatabase update = new UpdatingDatabase(file, fileContent,this.controller);

        }

    }
}
