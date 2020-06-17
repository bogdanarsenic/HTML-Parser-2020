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
    public class FileContentControllerTest
    {
        private FileContent fileContent;
        private IFileContentController fileContentController;

        [SetUp]
        public void SetUp()
        {
            Mock<FileContent> fileContentDouble = new Mock<FileContent>();
            fileContent = fileContentDouble.Object;
        }

        [Test]
        public void AddFileContentMockVerify()
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.AddFileContent(fileContent)).Verifiable();

            fileContentController = new FileContentController(databaseMock.Object);

            fileContent.FileId = "nesto";
            fileContent.Content = "nesto2";
            fileContent.Id = "1,";
            fileContentController.Add(fileContent);

            databaseMock.Verify(database => database.AddFileContent(fileContent), Times.Once);
        }

        [Test]

        public void UpdateFileContentMockVerify()
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.UpdateFileContent(fileContent)).Verifiable();

            fileContentController = new FileContentController(databaseMock.Object);

            fileContent.FileId = "nesto";
            fileContent.Content = "nesto2";
            fileContent.Id = "1,";
            fileContentController.UpdateFileContent(fileContent);

            databaseMock.Verify(database => database.UpdateFileContent(fileContent), Times.Once);
        }

        [Test]
        [TestCase("1")]
        public void GetFileContentMockVerify(string id)
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.GetContent(id)).Verifiable();

            fileContentController = new FileContentController(databaseMock.Object);

            fileContentController.GetContent(id);

            databaseMock.Verify(database => database.GetContent(id), Times.Once);
        }

        [Test]
        [TestCase("1")]
        public void GetFileContentIdMockVerify(string id)
        {
            Mock<IDBManager> databaseMock = new Mock<IDBManager>();

            databaseMock.Setup(database => database.GetFileContentId(id)).Verifiable();

            fileContentController = new FileContentController(databaseMock.Object);

            fileContentController.GetFileContentId(id);

            databaseMock.Verify(database => database.GetFileContentId(id), Times.Once);
        }


        [TearDown]
        public void TearDown()
        {
            fileContent = null;
        }
    }
}
