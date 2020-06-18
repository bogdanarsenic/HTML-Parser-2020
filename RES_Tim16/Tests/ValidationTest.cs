using Client;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ValidationTest
    {
        [Test]
        public void CheckIfStringEmpty()
        {
            string goodstring = "nesto";
            string badstring = "";
            string badstring2 = null;
            Validation v = new Validation();
            Assert.AreEqual(false, v.CheckIfStringEmpty(goodstring));
            Assert.AreEqual(true, v.CheckIfStringEmpty(badstring));
            Assert.AreEqual(true, v.CheckIfStringEmpty(badstring2));
        }

        [Test]
        public void CheckIfPathCorrect()
        {
            string goodpath = "bzv.txt";
            string badpath = "nepostojece";
            string badpath3 = "bzv";
            string badpath4 = null;
            string badpath5 = @"C:\Users\Bogdan\Tim16\bzv.txt";
            Validation v = new Validation();
            Assert.AreEqual(true, v.CheckIfPathCorrect(goodpath));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath3));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath4));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath5));
        }

        [Test]
        public void CheckIfValidFileName()
        {
            string goodpath = "bzv.txt";
            string badpath = "nepostojece";
            string badpath3 = "bzv";
            string badpath4 = ".,";
            string badpath5 = "*";
            string badpath6 = "nesto.nesto";
            string badpath7 = "/";
            string badpath8 = "<";



            Validation v = new Validation();
            Assert.AreEqual(true, v.CheckIfPathCorrect(goodpath));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath3));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath4));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath5));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath6));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath7));
            Assert.AreEqual(false, v.CheckIfPathCorrect(badpath8));
        }

    }
}
