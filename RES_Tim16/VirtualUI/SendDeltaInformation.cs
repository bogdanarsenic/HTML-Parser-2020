using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIController;
using VirtualUI.Models;

namespace VirtualUI
{
    public class SendDeltaInformation
    {
        private IController controller;

        public SendDeltaInformation(IController ic)
        {
            this.controller = ic ?? throw new ArgumentNullException("Send delta infromation argument can't be null");
        }

        public void Send(Delta d, string previousContent)
        { 
            controller.SendDeltaInformation(d.Content, d.LineRange, previousContent);
        }

    }
}
