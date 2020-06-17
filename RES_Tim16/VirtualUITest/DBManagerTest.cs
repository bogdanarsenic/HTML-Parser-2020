using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI;
using VirtualUI.Access;
using VirtualUI.Models;

namespace VirtualUITest
{
    [TestFixture]
    public class DBManagerTest
    {

        private Delta delta;
        private Delta delta2;


        [SetUp]
        public void SetUp()
        {
            Mock<Delta> deltaDouble = new Mock<Delta>();
            deltaDouble.Setup(delta => delta.FileId).Returns("1");
            deltaDouble.Setup(delta => delta.Content).Returns("Neki kontent");
            deltaDouble.Setup(delta => delta.LineRange).Returns("1,2,");
            delta = deltaDouble.Object;
        }

        #region DeltaMethodTests

        [Test]
        public void AddDeltaGood()
        {
            IDBManager fakeDatabase = new FakeDBManager();

            fakeDatabase.AddDelta(delta);
            Assert.AreEqual(true,fakeDatabase.DeltaExists(delta.FileId));
        }

        [Test]
        [TestCase(null,"nesto","9,")]
        [TestCase("zv", null, "9,")]
        [TestCase("nesto", "nesto", null)]
        public void AddDeltaBadNullException(string id, string content, string linerange)
        {
            Mock<Delta> deltaDouble2 = new Mock<Delta>();
            deltaDouble2.Setup(delta => delta.FileId).Returns(id);
            deltaDouble2.Setup(delta => delta.Content).Returns(content);
            deltaDouble2.Setup(delta => delta.LineRange).Returns(linerange);

            delta = deltaDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.AddDelta(delta);
            }
            );

        }

        [Test]
        [TestCase("111111111111111111111111111111111111111111111111111", "nesto", "9,")]
        [TestCase("zv", "nesto", "111111111111111111111111111111111111111111111111111")]

        public void AddDeltaBadExceptionLength(string id, string content, string linerange)
        {
            Mock<Delta> deltaDouble2 = new Mock<Delta>();
            deltaDouble2.Setup(delta => delta.FileId).Returns(id);
            deltaDouble2.Setup(delta => delta.Content).Returns(content);
            deltaDouble2.Setup(delta => delta.LineRange).Returns(linerange);

            delta = deltaDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentException>(() =>
            {
                fakeDatabase.AddDelta(delta);
            }
            );

        }

        [Test]
        [TestCase("", "nesto", "9,")]
        [TestCase("nesto", "", "9,")]
        [TestCase("nesto", "nesto", "")]

        public void AddDeltaBadEmptyString(string id, string content, string linerange)
        {
            Mock<Delta> deltaDouble2 = new Mock<Delta>();
            deltaDouble2.Setup(delta => delta.FileId).Returns(id);
            deltaDouble2.Setup(delta => delta.Content).Returns(content);
            deltaDouble2.Setup(delta => delta.LineRange).Returns(linerange);

            delta = deltaDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();
            fakeDatabase.AddDelta(delta);


            Assert.AreEqual(false, fakeDatabase.DeltaExists(delta.FileId));
        }

        [Test]
        [TestCase("nesto","nesto","nesto")]
        public void AddDeltaBadAlreadyCreated(string id, string content, string linerange)
        {
            Mock<Delta> deltaDouble2 = new Mock<Delta>();
            deltaDouble2.Setup(delta => delta.FileId).Returns(id);
            deltaDouble2.Setup(delta => delta.Content).Returns(content);
            deltaDouble2.Setup(delta => delta.LineRange).Returns(linerange);

            delta = deltaDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();
            fakeDatabase.AddDelta(delta);

            Mock<Delta> deltaDouble3 = new Mock<Delta>();
            deltaDouble3.Setup(delta => delta.FileId).Returns(id);
            deltaDouble3.Setup(delta => delta.Content).Returns(content);
            deltaDouble3.Setup(delta => delta.LineRange).Returns(linerange);

            Assert.AreEqual(false, fakeDatabase.AddDelta(delta));
        }


        [Test]
        [TestCase("1","novo","novo")]
        public void UpdateDeltaGood(string id,string content, string linerange)
        {
            Mock<Delta> deltaDouble2 = new Mock<Delta>();
            deltaDouble2.Setup(delta2 => delta2.FileId).Returns(id);
            deltaDouble2.Setup(delta2 => delta2.Content).Returns(content);
            deltaDouble2.Setup(delta2 => delta2.LineRange).Returns(linerange);

            delta2 = deltaDouble2.Object;
            FakeDBManager fakeDatabase = new FakeDBManager();

            fakeDatabase.AddDelta(delta);

            fakeDatabase.UpdateDelta(delta2);
            Assert.AreEqual(fakeDatabase.GetDelta(delta.FileId).Content, delta2.Content);
            Assert.AreEqual(fakeDatabase.GetDelta(delta.FileId).LineRange, delta2.LineRange);

        }

        [Test]
        [TestCase(null, "nesto", "9,")]
        [TestCase("zv", null, "9,")]
        [TestCase("nesto", "nesto", null)]
        public void UpdateDeltaBadNullException(string id, string content, string linerange)
        {
            Mock<Delta> deltaDouble2 = new Mock<Delta>();
            deltaDouble2.Setup(delta => delta.FileId).Returns(id);
            deltaDouble2.Setup(delta => delta.Content).Returns(content);
            deltaDouble2.Setup(delta => delta.LineRange).Returns(linerange);

            delta = deltaDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.UpdateDelta(delta);
            }
            );

        }

        [Test]
        [TestCase("111111111111111111111111111111111111111111111111111", "nesto", "9,")]
        [TestCase("zv", "nesto", "111111111111111111111111111111111111111111111111111")]

        public void UpdateDeltaBadExceptionLength(string id, string content, string linerange)
        {
            Mock<Delta> deltaDouble2 = new Mock<Delta>();
            deltaDouble2.Setup(delta => delta.FileId).Returns(id);
            deltaDouble2.Setup(delta => delta.Content).Returns(content);
            deltaDouble2.Setup(delta => delta.LineRange).Returns(linerange);

            delta = deltaDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentException>(() =>
            {
                fakeDatabase.UpdateDelta(delta);
            }
            );

        }

        [Test]
        [TestCase("2", "nesto", "9,")] //nema ovaj id
        [TestCase("bzv", "nema", "9,")]
        [TestCase("", "nesto", "nema")]

        public void AddDeltaMissingIdString(string id, string content, string linerange)
        {
            Mock<Delta> deltaDouble2 = new Mock<Delta>();
            deltaDouble2.Setup(delta => delta.FileId).Returns(id);
            deltaDouble2.Setup(delta => delta.Content).Returns(content);
            deltaDouble2.Setup(delta => delta.LineRange).Returns(linerange);

            delta = deltaDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();


            Assert.AreEqual(false, fakeDatabase.UpdateDelta(delta));
        }



        [Test]
        [TestCase("1")]
        public void DeltaExistsGood(string id)
        {
            IDBManager fakeDatabase = new FakeDBManager();

            fakeDatabase.AddDelta(delta);
            Assert.AreEqual(true, fakeDatabase.DeltaExists(id));
        }

        [Test]
        [TestCase(null)]
        public void DeltaExistsBadNull(string id)
        {

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.DeltaExists(id);
            }
            );

        }

        [Test]
        [TestCase("nekiBzv")]
        public void DeltaDoesntExists(string id)
        {

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.AreEqual(false, fakeDatabase.DeltaExists(id));
        }



        #endregion

        [TearDown]
        public void TearDown()
        {
            delta = null;
        }
    }
}