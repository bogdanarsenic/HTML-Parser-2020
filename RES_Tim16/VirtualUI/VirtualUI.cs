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

        private string Name { get; set; }
        private string Content { get; set; }

        public VirtualUI(IController controller)
        {
            Name = controller.Name;
            Content = controller.Content;

            ParseInformationFromController(Name, Content, controller);

        }

        public void ParseInformationFromController(string name, string content,IController ic)
        {
           

            Files file = new Files();
            file.Name = name.Split('.')[0];
            file.Extension = name.Split('.')[1];
            file.Id = name;

            FileContent fileContent = new FileContent();
            fileContent.FileId = file.Id;
            fileContent.Content = content;

            UpdatingDatabase update = new UpdatingDatabase(file, fileContent,ic);

        }

    }
}
