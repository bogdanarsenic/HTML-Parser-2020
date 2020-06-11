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


        public bool Add(Delta delta) //fejkovanje add delta metode
        {
            try
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
            catch
            {
                throw new ArgumentException("Something wrong with the AddDelta function for Database");
            }
        }

        public bool UpdateDelta(Delta delta)
        {
            try
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
            catch
            {
                throw new ArgumentException("Something wrong with the UpdateDelta function for Database");
            }
        }

        public bool DeltaExists(string id)
        {
            try
            {
                if (dBManager.DeltaExists(id))
                    return true;
                else
                {

                    Console.WriteLine(DateTime.Now + ": Delta doesn't exists in Database.");
                    return false;

                }
            }
            catch
            {
                throw new ArgumentException("Something wrong with the DeltaExists function for Database");

            }

        }
    }

}
