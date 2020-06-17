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

namespace VirtualUITest.ControllerTest
{
    [TestFixture]
    public class DeltaControllerTest
    {
        private Delta delta;
        private IDeltaController deltaController;

        [SetUp]
        public void SetUp()
        {

            Mock<Delta> deltaDouble = new Mock<Delta>();
            delta = deltaDouble.Object;

        }

        [Test]
        [TestCase(null)]
        public void DeltaControllerBadParameter(IDBManager database)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                IDeltaController deltaController2 = new DeltaController(database);
            }
            );
        }

        [Test]

        public void AddDeltaMockVerify()
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.AddDelta(delta)).Verifiable();

            deltaController = new DeltaController(databaseMock.Object);

            delta.FileId = "nesto";
            delta.Content = "nesto2";
            delta.LineRange = "1,";
            deltaController.Add(delta);

            databaseMock.Verify(database => database.AddDelta(delta), Times.Once);
        }

        [Test]

        public void UpdateDeltaMockVerify()
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.UpdateDelta(delta)).Verifiable();

            deltaController = new DeltaController(databaseMock.Object);

            delta.FileId = "nesto";
            delta.Content = "nesto2";
            delta.LineRange = "1,";
            deltaController.UpdateDelta(delta);

            databaseMock.Verify(database => database.UpdateDelta(delta), Times.Once);
        }

        [Test]

        [TestCase("1")]
        public void DeltaExistMockVerify(string id)
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.DeltaExists(id)).Verifiable();

            deltaController = new DeltaController(databaseMock.Object);

            deltaController.DeltaExists(id);

            databaseMock.Verify(database => database.DeltaExists(id), Times.Once);
        }
   
    }
}
