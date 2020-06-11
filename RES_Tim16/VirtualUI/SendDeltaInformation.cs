using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIControllerMiddleware;
using VirtualUI.Models;

namespace VirtualUI
{
    public class SendDeltaInformation
    {
        public SendDeltaInformation()
        {

        }

        public SendDeltaInformation(Delta d, string previousContent, IController ic)
        {
            ic.SendDeltaInformation(d.Content, d.LineRange, previousContent);
        }
    }
}
