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

            Mock<Delta>deltaDouble = new Mock<Delta>();
            delta = deltaDouble.Object;

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

        /*
                [Test]

                public void AddDeltaGood()
                {
                    delta.FileId = "nesto";
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";

                    deltaController.FakeAdd(delta);
                    Assert.AreEqual(true, deltaController.FakeDeltaExists(delta.FileId));
                }


                [Test]
                public void AddDeltaBadNullArgument()
                {
                    delta.FileId = null;
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";

                    Assert.Throws<ArgumentNullException>(() =>
                    {
                        deltaController.FakeAdd(delta);
                    }
                    );
                }

                [Test]
                public void AddDeltaBadAboveLength()
                {
                    delta.FileId = "opet";
                    delta.LineRange = "gegegegegegegegegegegegegegegegegegegegegegegegegeg"; //51 karakter
                    delta.Content = "FakeContent";
                    Assert.Throws<ArgumentException>(() =>
                    {
                        deltaController.FakeAdd(delta);
                    }
                    );
                }

                [Test]
                public void AddDeltaBadEmptyString()
                {
                    delta.FileId = "";
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";
                    deltaController.FakeAdd(delta);
                    Assert.AreEqual(false, deltaController.FakeDeltaExists(delta.FileId));
                }

                [Test]
                public void AddDeltaBadTwoTimesSameDeltaAdd()
                {
                    delta.FileId = "nesto";
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";
                    deltaController.FakeAdd(delta);
                    Assert.AreEqual(false, deltaController.FakeAdd(delta));
                }

                [Test]
                public void UpdateDeltaGood()
                {
                    delta.FileId = "nesto";
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";
                    deltaController.FakeAdd(delta);

                    delta2.FileId = "nesto";
                    delta2.LineRange = "1,2,3,";
                    delta2.Content = "Fake";


                    Assert.AreEqual(true, deltaController.FakeUpdateDelta(delta2));
                    Assert.AreEqual("Fake", delta.Content);
                }

                [Test]
                public void UpdateDeltaBadNull()
                {
                    delta.FileId = "nesto";
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";
                    database = new FakeDBManager();
                    deltaController.FakeAdd(delta);

                    delta2.FileId = null;
                    delta2.LineRange = "1,2,3,";
                    delta2.Content = "Fake";

                    Assert.Throws<ArgumentNullException>(() =>
                    {
                        deltaController.FakeUpdateDelta(delta2);
                    }
                    );

                    Assert.AreEqual("FakeContent", delta.Content);
                }

                [Test]
                public void UpdateDeltaBadNotSameFileId()
                {
                    delta.FileId = "nesto";
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";
                    database = new FakeDBManager();
                    deltaController.FakeAdd(delta);

                    delta2.FileId = "nesto1";
                    delta2.LineRange = "1,2,3,";
                    delta2.Content = "Fake";


                    Assert.AreEqual(false, deltaController.FakeUpdateDelta(delta2));
                    Assert.AreEqual("FakeContent", delta.Content);
                }


                [Test]
                public void UpdateDeltaBadAboveLength()
                {
                    delta.FileId = "nesto";
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";

                    deltaController.FakeAdd(delta);

                    delta2.FileId = "nesto1";
                    delta2.LineRange = "gegegegegegegegegegegegegegegegegegegegegegegegegeg";
                    delta2.Content = "Fake";


                    Assert.Throws<ArgumentException>(() =>
                    {
                        deltaController.FakeUpdateDelta(delta2);
                    }
                    );
                    Assert.AreEqual("FakeContent", delta.Content);
                }

                [Test]
                [TestCase("1")]
                public void DeltaExistsGood(string id)
                {
                    delta.FileId = "nesto";
                    delta.LineRange = "1,";
                    delta.Content = "FakeContent";

                    deltaController.FakeAdd(delta);
                    Assert.AreEqual(true, deltaController.FakeDeltaExists(delta.FileId));
                }


                [Test]
                [TestCase("1")]
                public void DeltaExistsBad(string id)
                {
                    delta.FileId = id;
                    delta.LineRange = "1,";
                    delta.Content = "Fake";

                    Assert.AreEqual(false, deltaController.FakeDeltaExists(id));

                }

                public void DeltaExistsBadNull()
                {
                    delta.FileId = null;
                    delta.LineRange = "1,";
                    delta.Content = "Fake";
                    Assert.Throws<ArgumentNullException>(() =>
                    {
                        deltaController.FakeDeltaExists(null);
                    }
                   );

                }


                [TearDown]
                public void TearDown()
                {
                    delta = null;
                }


                */
    }
}
