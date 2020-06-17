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

        private IDBManager dBManager;

        public DeltaController(IDBManager db)
        {
            this.dBManager = db;
        }

        public DeltaController()
        {
            this.dBManager = DBManager.Instance;
        }

        public bool Add(Delta delta) //fejkovanje add delta metode
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
