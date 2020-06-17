using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Access;
using VirtualUI.Models;

namespace VirtualUI.Controller
{
    public class DeltaController : IDeltaController
    {

        public IDBManager dBManager;

        public DeltaController(IDBManager db)
        {
            this.dBManager = db ?? throw new ArgumentNullException("IDBManager can't be null");
        }

        public DeltaController()
        {
            this.dBManager = DBManager.Instance;
        }

        public bool Add(Delta delta)
        {
            return dBManager.AddDelta(delta);
        }

        public bool UpdateDelta(Delta delta)
        {
            return dBManager.UpdateDelta(delta);
               
        }

        public bool DeltaExists(string id)
        {
            return dBManager.DeltaExists(id);
        }

    }

}
