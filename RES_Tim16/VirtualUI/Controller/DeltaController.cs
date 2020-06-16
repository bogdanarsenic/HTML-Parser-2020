using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Models;

namespace VirtualUI.Controller
{
    public class DeltaController : IDeltaController
    {
        DBManager dBManager = DBManager.Instance;

        FakeDBManager fake = FakeDBManager.Instance;

        public bool Add(Delta delta) //fejkovanje add delta metode
        {

                if (dBManager.AddDelta(delta))
                {
                    Console.WriteLine(DateTime.Now + ": Delta Added to Database.");

                    return true;
                }
                else
                {
                    Console.WriteLine(DateTime.Now + ": Delta wasn't added to Database.");
                    return false;
                }
        }

        public bool FakeAdd(Delta delta) //fejkovanje add delta metode
        {

                if (fake.AddDelta(delta))
                {
                    Console.WriteLine(DateTime.Now + ": Delta Added to Database.");

                    return true;
                }
                else
                {
                    Console.WriteLine(DateTime.Now + ": Delta wasn't added to Database.");
                    return false;
                }
        }

        public bool UpdateDelta(Delta delta)
        {
                if (dBManager.UpdateDelta(delta))
                {
                    Console.WriteLine(DateTime.Now + ": Delta Updated to Database.");

                    return true;
                }
                else
                {
                    Console.WriteLine(DateTime.Now + ": Delta wasn't Updated to Database.");
                    return false;
                }
        }

        public bool FakeUpdateDelta(Delta delta)
        {

                if (fake.UpdateDelta(delta))
                {
                    Console.WriteLine(DateTime.Now + ": Delta Updated to Database.");

                    return true;
                }
                else
                {
                    Console.WriteLine(DateTime.Now + ": Delta wasn't Updated to Database.");
                    return false;
                }
        }

        public bool DeltaExists(string id)
        {
        
            if (dBManager.DeltaExists(id))
            { 
                Console.WriteLine(DateTime.Now + ": Delta exists in Database.");
                     return true;
            }
            else
                {
                    Console.WriteLine(DateTime.Now + ": Delta doesn't exists in Database.");
                    return false;
                }

        }

        public bool FakeDeltaExists(string id)
        {
            if (fake.DeltaExists(id))
            {
                Console.WriteLine(DateTime.Now + ": Delta exists in Database.");
                return true;
            }
            else
            {
                Console.WriteLine(DateTime.Now + ": Delta doesn't exists in Database.");
                return false;
            }

        }

    }

}
