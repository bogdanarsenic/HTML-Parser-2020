using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI.Access;
using VirtualUI.Controller;
using VirtualUI.Models;

namespace VirtualUITest.ControllerTest
{
    [TestFixture]
    public class FileControllerTest
    {
        private Files file;
        private IFileController fileController;

        [SetUp]
        public void SetUp()
        {

            Mock<Files> fileDouble = new Mock<Files>();
            file = fileDouble.Object;

        }

        [Test]
        [TestCase(null)]
        public void FileControllerBadParameter(IDBManager database)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                IFileController deltaController2 = new FileController(database);
            }
            );
        }

        [Test]

        public void AddFileMockVerify()
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.AddFile(file)).Verifiable();

            fileController = new FileController(databaseMock.Object);

            file.Id = "nesto";
            file.Name = "nesto2";
            file.Extension = "1,";

            fileController.Add(file);

            databaseMock.Verify(database => database.AddFile(file), Times.Once);
        }

        [Test]
        [TestCase("1")]
        public void FileExistMockVerify(string id)
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.FileExists(id)).Verifiable();

            fileController = new FileController(databaseMock.Object);

            fileController.FileExists(id);

            databaseMock.Verify(database => database.FileExists(id), Times.Once);
        }
    }
}
