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
        private FileContent fileContent;
        private FileContent fileContent2;
        private Files file;


        [SetUp]
        public void SetUp()
        {
            Mock<Delta> deltaDouble = new Mock<Delta>();
            deltaDouble.Setup(delta => delta.FileId).Returns("1");
            deltaDouble.Setup(delta => delta.Content).Returns("Neki kontent");
            deltaDouble.Setup(delta => delta.LineRange).Returns("1,2,");
            delta = deltaDouble.Object;

            Mock<FileContent> fileContentDouble = new Mock<FileContent>();
            fileContentDouble.Setup(fileContent => fileContent.FileId).Returns("bzv.txt");
            fileContentDouble.Setup(fileContent => fileContent.Content).Returns("Neki kontent");
            fileContentDouble.Setup(fileContent => fileContent.Id).Returns("gegegegege");
            fileContent = fileContentDouble.Object;

            Mock<Files> fileDouble = new Mock<Files>();
            fileDouble.Setup(file => file.Id).Returns("bz2.txt");
            fileDouble.Setup(file => file.Name).Returns("bzv2");
            fileDouble.Setup(file => file.Extension).Returns("txt");
            file = fileDouble.Object;


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

            FakeDBManager fakeDatabase = new FakeDBManager();

            Assert.AreEqual(false, fakeDatabase.DeltaExists(id));
        }



        #endregion

        #region FileContentMethods

        [Test]
        [TestCase("bzv.txt")]
        public void AddFileContentGood(string id)
        {
            FakeDBManager fakeDatabase = new FakeDBManager();

            fakeDatabase.AddFileContent(fileContent);
            //Assert.AreEqual(fileContent.Content, fakeDatabase.GetContent(id));
        }

        [Test]
        [TestCase(null, "nesto", "9,")]
        [TestCase("zv", null, "9,")]
        public void AddFileContentBadNull(string fileid, string content, string id)
        {
            Mock<FileContent> fileContentDouble2 = new Mock<FileContent>();
            fileContentDouble2.Setup(fileContent => fileContent.FileId).Returns(fileid);
            fileContentDouble2.Setup(fileContent => fileContent.Content).Returns(content);
            fileContentDouble2.Setup(fileContent => fileContent.Id).Returns(id);

            fileContent = fileContentDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.AddFileContent(fileContent);
            }
            );

        }

        [Test]
        [TestCase("111111111111111111111111111111111111111111111111111", "nesto", "9,")]

        public void AddFileContentBadExceptionLength(string fileid, string content, string id)
        {

            Mock<FileContent> fileContentDouble2 = new Mock<FileContent>();
            fileContentDouble2.Setup(fileContent => fileContent.FileId).Returns(fileid);
            fileContentDouble2.Setup(fileContent => fileContent.Content).Returns(content);
            fileContentDouble2.Setup(fileContent => fileContent.Id).Returns(id);

            fileContent = fileContentDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentException>(() =>
            {
                fakeDatabase.AddFileContent(fileContent);
            }
            );

        }


        [Test]
        [TestCase("", "nesto", "9,")]
        [TestCase("nesto", "", "9,")]

        public void AddFileContentBadEmptyString(string fileid, string content, string id)
        {
            Mock<FileContent> fileContentDouble2 = new Mock<FileContent>();
            fileContentDouble2.Setup(fileContent => fileContent.FileId).Returns(fileid);
            fileContentDouble2.Setup(fileContent => fileContent.Content).Returns(content);
            fileContentDouble2.Setup(fileContent => fileContent.Id).Returns(id);

            fileContent = fileContentDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.AreEqual(false, fakeDatabase.AddFileContent(fileContent));
        }


        [Test]
        [TestCase("bzv.txt", "novo", "novo")]
        public void UpdateFileContentGood(string fileid, string content, string id)
        {
            Mock<FileContent> fileContentDouble2 = new Mock<FileContent>();
            fileContentDouble2.Setup(fileContent2 => fileContent2.FileId).Returns(fileid);
            fileContentDouble2.Setup(fileContent2 => fileContent2.Content).Returns(content);
            fileContentDouble2.Setup(fileContent2 => fileContent2.Id).Returns(id);

            fileContent2 = fileContentDouble2.Object;

            FakeDBManager fakeDatabase = new FakeDBManager();

            fakeDatabase.AddFileContent(fileContent);

            fakeDatabase.UpdateFileContent(fileContent2);

            Assert.AreEqual(fakeDatabase.GetContent(fileid), fileContent2.Content);

        }

        [Test]
        [TestCase(null, "nesto", "9,")]
        [TestCase("zv", null, "9,")]
        public void UpdateFileContentBadNullException(string fileid, string content, string id)
        {
            Mock<FileContent> fileContentDouble2 = new Mock<FileContent>();
            fileContentDouble2.Setup(fileContent => fileContent.FileId).Returns(fileid);
            fileContentDouble2.Setup(fileContent => fileContent.Content).Returns(content);
            fileContentDouble2.Setup(fileContent => fileContent.Id).Returns(id);

            fileContent = fileContentDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.UpdateFileContent(fileContent);
            }
            );

        }

        [Test]
        [TestCase("111111111111111111111111111111111111111111111111111", "nesto", "9,")]
        [TestCase("zv", "nesto", "111111111111111111111111111111111111111111111111111")]

        public void UpdateFileContentBadExceptionLength(string fileid, string content, string id)
        {
            Mock<FileContent> fileContentDouble2 = new Mock<FileContent>();
            fileContentDouble2.Setup(fileContent => fileContent.FileId).Returns(fileid);
            fileContentDouble2.Setup(fileContent => fileContent.Content).Returns(content);
            fileContentDouble2.Setup(fileContent => fileContent.Id).Returns(id);

            fileContent = fileContentDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentException>(() =>
            {
                fakeDatabase.UpdateFileContent(fileContent);
            }
            );

        }


        [Test]
        [TestCase("bzv.txt")]
        public void GetContentGood(string id)
        {
            IDBManager fakeDatabase = new FakeDBManager();

            fakeDatabase.AddFileContent(fileContent);
            Assert.AreEqual(fileContent.Content, fakeDatabase.GetContent(id));
        }

        [Test]
        [TestCase(null)]
        public void GetContentBadNull(string id)
        {
            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.GetContent(id);
            }
            );
        }

        [Test]
        [TestCase("nekiBzv")]
        public void GetContentIdDoesntExist(string id)
        {

            FakeDBManager fakeDatabase = new FakeDBManager();

            Assert.AreEqual("INVALID", fakeDatabase.GetContent(id));
        }



        [Test]
        [TestCase("bzv.txt")]
        public void GetFileContentIdGood(string id)
        {
            IDBManager fakeDatabase = new FakeDBManager();

            fakeDatabase.AddFileContent(fileContent);
            Assert.AreEqual(fileContent.Id, fakeDatabase.GetFileContentId(id));
        }

        [Test]
        [TestCase(null)]
        public void GetFileContentIdBadNull(string id)
        {
            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.GetFileContentId(id);
            }
            );
        }

        [Test]
        [TestCase("nekiBzv")]
        public void GetFileContentIdDoesntExists(string id)
        {

            FakeDBManager fakeDatabase = new FakeDBManager();

            Assert.AreEqual("INVALID", fakeDatabase.GetFileContentId(id));
        }

        #endregion

        #region File

        [Test]
        public void AddFileGood()
        {
            IDBManager fakeDatabase = new FakeDBManager();
            fakeDatabase.AddFile(file);
            Assert.AreEqual(true, fakeDatabase.FileExists(file.Id));
        }


        [Test]
        [TestCase(null, "nesto", "9,")]
        [TestCase("zv", null, "9,")]
        [TestCase("nesto", "nesto", null)]
        public void AddFileBadNullException(string id, string name, string extension)
        {
            Mock<Files> fileDouble2 = new Mock<Files>();
            fileDouble2.Setup(file => file.Id).Returns(id);
            fileDouble2.Setup(file => file.Name).Returns(name);
            fileDouble2.Setup(file => file.Extension).Returns(extension);

            file = fileDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.AddFile(file);
            }
            );

        }

        [Test]
        [TestCase("111111111111111111111111111111111111111111111111111", "nesto", "9,")]
        [TestCase("zv", "nesto", "111111111111111111111111111111111111111111111111111")]

        public void AddFileBadException(string id, string name, string extension)
        {
            Mock<Files> fileDouble2 = new Mock<Files>();
            fileDouble2.Setup(file => file.Id).Returns(id);
            fileDouble2.Setup(file => file.Name).Returns(name);
            fileDouble2.Setup(file => file.Extension).Returns(extension);

            file = fileDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentException>(() =>
            {
                fakeDatabase.AddFile(file);
            }
            );

        }

        [Test]
        [TestCase("", "nesto", "9,")]
        [TestCase("nesto", "", "9,")]
        [TestCase("nesto", "nesto", "")]

        public void AddFileBadEmptyString(string id, string name, string extension)
        {
            Mock<Files> fileDouble2 = new Mock<Files>();
            fileDouble2.Setup(file => file.Id).Returns(id);
            fileDouble2.Setup(file => file.Name).Returns(name);
            fileDouble2.Setup(file => file.Extension).Returns(extension);

            file = fileDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();
            fakeDatabase.AddFile(file);


            Assert.AreEqual(false, fakeDatabase.FileExists(file.Id));
        }

        [Test]
        [TestCase("nesto", "nesto", "nesto")]
        public void AddFileBadAlreadyCreated(string id, string name, string extension)
        {
            Mock<Files> fileDouble2 = new Mock<Files>();
            fileDouble2.Setup(file => file.Id).Returns(id);
            fileDouble2.Setup(file => file.Name).Returns(name);
            fileDouble2.Setup(file => file.Extension).Returns(extension);
            
             file = fileDouble2.Object;

            IDBManager fakeDatabase = new FakeDBManager();
            fakeDatabase.AddFile(file);

            Mock<Files> fileDouble3 = new Mock<Files>();
            fileDouble3.Setup(file => file.Id).Returns(id);
            fileDouble3.Setup(file => file.Name).Returns(name);
            fileDouble3.Setup(file => file.Extension).Returns(extension);

            Assert.AreEqual(false, fakeDatabase.AddFile(file));
        }

        [Test]
        [TestCase("bz2.txt")]
        public void FileExistsGood(string id)
        {
            IDBManager fakeDatabase = new FakeDBManager();

            fakeDatabase.AddFile(file);
            Assert.AreEqual(true, fakeDatabase.FileExists(id));
        }

        [Test]
        [TestCase(null)]
        public void FileExistsBadNull(string id)
        {

            IDBManager fakeDatabase = new FakeDBManager();

            Assert.Throws<ArgumentNullException>(() =>
            {
                fakeDatabase.FileExists(id);
            }
            );

        }

        [Test]
        [TestCase("nekiBzv")]
        public void FileDoesntExists(string id)
        {

            FakeDBManager fakeDatabase = new FakeDBManager();

            Assert.AreEqual(false, fakeDatabase.FileExists(id));
        }



        #endregion
        [TearDown]
        public void TearDown()
        {
            delta = null;
            delta2 = null;
            fileContent = null;
            fileContent2 = null;
        }
    }
}