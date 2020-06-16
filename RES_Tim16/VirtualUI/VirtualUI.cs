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

        public IController controller;


        public VirtualUI(IController controller)
        {
            this.controller = controller;

            ParseInformationFromController();

        }

        public void ParseInformationFromController()
        {

            Files file = new Files();
            file.Name = this.controller.Name.Split('.')[0];
            file.Extension = this.controller.Name.Split('.')[1];
            file.Id = this.controller.Name;

            FileContent fileContent = new FileContent();
            fileContent.FileId = file.Id;
            fileContent.Content = this.controller.Content;

            UpdatingDatabase update = new UpdatingDatabase(file, fileContent,this.controller);

        }

    }
}
