using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI;
using VirtualUI.Access;
using VirtualUI.Controller;
using VirtualUI.Models;

namespace VirtualUITest.ControllerTests
{
    [TestFixture]
    public class DeltaControllerTest
    {
        private Delta delta;
        private DeltaController deltaController;
        private IDBManager database;

        [SetUp]
        public void SetUp()
        {
            Mock<Delta> deltaDouble = new Mock<Delta>();
            delta = deltaDouble.Object;
            Mock<DeltaController> deltaControllerDouble = new Mock<DeltaController>();
            deltaController = deltaControllerDouble.Object;

        }

        [Test]

        public void AddDeltaGood()
        {
            delta.FileId = "nesto";
            delta.LineRange = "1,";
            delta.Content = "FakeContent";
            database = new FakeDBManager();

            deltaController.FakeAdd(delta);
            Assert.AreEqual(true, deltaController.FakeDeltaExists(delta.FileId));
        }


        [Test]
        public void AddDeltaBad()
        {
            delta.FileId = null;
            delta.LineRange = "1,";
            delta.Content = "FakeContent";
            database = new FakeDBManager();

            Assert.Throws<ArgumentException>(() =>
            {
                deltaController.FakeAdd(delta);
            }
            );
        }

        [Test]
        public void AddDeltaBad2()
        {
            delta.FileId = "opet";
            delta.LineRange = "gegegegegegegegegegegegegegegegegegegegegegegegegeg"; //51 karakter
            delta.Content = "FakeContent";
            database = new FakeDBManager();
            Assert.Throws<ArgumentException>(() =>
            {
                deltaController.FakeAdd(delta);
            }
            );
        }

        [Test]
        public void AddDeltaBad3()
        {
            delta.FileId = "";
            delta.LineRange = "1,";
            delta.Content = "FakeContent";
            database = new FakeDBManager();
            deltaController.FakeAdd(delta);
            Assert.AreEqual(false, deltaController.FakeDeltaExists(delta.FileId));
        }

        [Test]
        public void AddDeltaBad4()
        {
            delta.FileId = "nesto";
            delta.LineRange = "1,";
            delta.Content = "FakeContent";
            database = new FakeDBManager();
            deltaController.FakeAdd(delta);
            Assert.AreEqual(false, deltaController.FakeAdd(delta));
        }




        [TearDown]
        public void TearDown()
        {
            delta = null;
        }



    }
}
