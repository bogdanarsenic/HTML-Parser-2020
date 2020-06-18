using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIController;
using VirtualUI;
using VirtualUI.Controller;
using VirtualUI.Models;

namespace VirtualUITest
{
    [TestFixture]
    public class UpdatingDatabaseTest
    {
        private FileContent fileContent;
        private Files file;
        private IFileContentController fileContentController;
        private IFileController fileController;
        private IController controller;
        private IUpdatingDatabase updatingDatabase;


        [Test]
        public void UpdatingDatabaseGood()
        {
            Mock<FileContent> fileContentDouble = new Mock<FileContent>();
            fileContent = fileContentDouble.Object;

            Mock<IFileContentController> fileContentContrellerDouble = new Mock<IFileContentController>();
            fileContentController = fileContentContrellerDouble.Object;

            Mock<Files> fileDouble = new Mock<Files>();
            fileDouble.Setup(fileproba => fileproba.Id).Returns("nestoBezveze");
            file = fileDouble.Object;

            Mock<IFileController> fileContrellerDouble = new Mock<IFileController>();
            fileContrellerDouble.Setup(controller => controller.Add(file)).Verifiable();


            Mock<IController> controllerDouble = new Mock<IController>();
            controller = controllerDouble.Object;

            UpdatingDatabase UpdateDouble =new  UpdatingDatabase();
            UpdateDouble.AddToDatabase(file, fileContent, fileContrellerDouble.Object,fileContentController);

            fileContrellerDouble.Verify(controller => controller.Add(file), Times.Once);

        }

        [Test]
        [TestCase("NekiFajl")]
        public void UpdateFileContentGoodGetFileContentId(string fileId)
        {
            Mock<IFileContentController> fileContentContrellerDouble = new Mock<IFileContentController>();
            fileContentContrellerDouble.Setup(controller => controller.GetFileContentId(fileId)).Verifiable();

            Mock<FileContent> fileContentDouble = new Mock<FileContent>();
            fileContent = fileContentDouble.Object;

            IUpdatingDatabase u = new UpdatingDatabase();

            u.UpdateFileContent(fileContentContrellerDouble.Object, fileContent, fileId);
            fileContentContrellerDouble.Verify(controller => controller.GetFileContentId(fileId), Times.Once);

        }

        [TestCase("NekiFajl")]
        public void UpdateFileContentGoodUpdateFileContent(string fileId)
        {
            Mock<FileContent> fileContentDouble = new Mock<FileContent>();
            fileContent = fileContentDouble.Object;

            Mock<IFileContentController> fileContentContrellerDouble = new Mock<IFileContentController>();
            fileContentContrellerDouble.Setup(controller => controller.UpdateFileContent(fileContent)).Verifiable();


            IUpdatingDatabase u = new UpdatingDatabase();

            u.UpdateFileContent(fileContentContrellerDouble.Object, fileContent, fileId);
            fileContentContrellerDouble.Verify(controller => controller.UpdateFileContent(fileContent), Times.Once);

        }


        [Test]
        public void UpdateFileContentGoodAddToDatabase()
        {
            Mock<FileContent> fileContentDouble = new Mock<FileContent>();
            fileContent = fileContentDouble.Object;

            Mock<IFileContentController> fileContentContrellerDouble = new Mock<IFileContentController>();
            fileContentContrellerDouble.Setup(controller => controller.Add(fileContent)).Verifiable();

            Mock<Files> fileDouble = new Mock<Files>();
            file = fileDouble.Object;

            Mock<IFileController> fileContrellerDouble = new Mock<IFileController>();
            fileContrellerDouble.Setup(fileController => fileController.Add(file)).Verifiable();

            IUpdatingDatabase u = new UpdatingDatabase();

            u.AddToDatabase(file, fileContent, fileContrellerDouble.Object,fileContentContrellerDouble.Object);
            fileContentContrellerDouble.Verify(controller => controller.Add(fileContent), Times.Once);
            fileContrellerDouble.Verify(fileController => fileController.Add(file), Times.Once);

        }

    }
}
