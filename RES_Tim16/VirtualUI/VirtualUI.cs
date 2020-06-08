using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Models;

namespace VirtualUI
{
    public class VirtualUI
    {

        private string Name { get; set; }
        private string Content { get; set; }

        public VirtualUI()
        {
  

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

        }

    }
}
