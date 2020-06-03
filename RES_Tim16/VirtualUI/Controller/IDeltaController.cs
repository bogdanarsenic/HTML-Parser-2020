using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Models;

namespace VirtualUI.Controller
{
    public interface IDeltaController
    {
            bool Add(Delta delta);
            bool UpdateDelta(Delta delta);
            bool DeltaExists(string id);
    }
}
