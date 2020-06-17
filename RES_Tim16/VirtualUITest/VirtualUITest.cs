using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIController;
using VirtualUI;
using VirtualUI.Models;

namespace VirtualUITest
{
    [TestFixture]
    public class VirtualUITest
    {
        private IController controller;
        private Files file;
        private FileContent fileContent;
        private VirtualUI.VirtualUI virtualUI;
        private IUpdatingDatabase updatingDatabase;

        [SetUp]
        public void SetUp()
        {
            Mock<IController> controllerDouble = new Mock<IController>();

            controllerDouble.Setup(controller => controller.Name).Returns("Name");
            controllerDouble.Setup(controller => controller.Content).Returns("Content");

            controller = controllerDouble.Object;
        }

        [Test]
        public void VirtualUIGood()
        {

            VirtualUI.VirtualUI virtualUI = new VirtualUI.VirtualUI(controller);

            Assert.AreEqual(virtualUI.controller, controller);

        }


        [Test]
        [TestCase(null)]
        public void VirtualUIBadParameter(IController controller)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {             
                VirtualUI.VirtualUI virtualUI = new VirtualUI.VirtualUI(controller);
            }
            );
        }

        [Test]
        [TestCase(null,"content")]
        [TestCase("name", null)]

        public void VirtualUIBadParameterNullProperty(string name,string content)
        {
            Mock<IController> nestoDouble = new Mock<IController>();
            nestoDouble.Setup(controller => controller.Content).Returns(name);
            nestoDouble.Setup(controller => controller.Name).Returns(content);

            IController novo = nestoDouble.Object;

            Assert.Throws<ArgumentNullException>(() =>
            {
                VirtualUI.VirtualUI virtualUI = new VirtualUI.VirtualUI(novo);
            }
            );
        }

        [Test]
        [TestCase("", "content")]
        [TestCase("name", "")]

        public void VirtualUIBadParameterEmptyString(string name, string content)
        {
            Mock<IController> nestoDouble = new Mock<IController>();
            nestoDouble.Setup(controller => controller.Content).Returns(name);
            nestoDouble.Setup(controller => controller.Name).Returns(content);

            IController novo = nestoDouble.Object;

            Assert.Throws<ArgumentException>(() =>
            {
                VirtualUI.VirtualUI virtualUI = new VirtualUI.VirtualUI(novo);
            }
            );
        }

        [Test]
        [TestCase("nesto.txt", "bezveze")]
        public void ParseInformationFromControllerGood(string name, string content)
        {
            Mock<IController> nestoDouble = new Mock<IController>();
            nestoDouble.Setup(controller => controller.Name).Returns(name);
            nestoDouble.Setup(controller => controller.Content).Returns(content);

            IController novi = nestoDouble.Object;

            Mock<VirtualUI.VirtualUI> virtualDouble = new Mock<VirtualUI.VirtualUI>(novi);

            Mock<Files> filesDouble = new Mock<Files>();
            file = filesDouble.Object;

            Mock<FileContent> fileContentDouble = new Mock<FileContent>();
            fileContent = fileContentDouble.Object;

            Mock<IUpdatingDatabase> updatingDouble = new Mock<IUpdatingDatabase>();
            updatingDatabase = updatingDouble.Object;

            virtualDouble.Setup(vUI => vUI.update!=null).Verifiable();
            virtualUI = virtualDouble.Object;
            virtualUI.ParseInformationFromController();
            virtualDouble.Verify((vUI => vUI.update != null));

        }



        [Test]
        [TestCase(".","bezveze")]
        [TestCase("nematacke", "bezveze")]
        [TestCase("nesto.nesto.txt", "bezveze")]
        public void ParseInformationFromControllerException(string name,string content)
        {
            Mock<IController> nestoDouble = new Mock<IController>();
            nestoDouble.Setup(controller => controller.Name).Returns(name);
            nestoDouble.Setup(controller => controller.Content).Returns(content);

            IController novi = nestoDouble.Object;

            Mock<VirtualUI.VirtualUI> virtualDouble = new Mock<VirtualUI.VirtualUI>(novi);
            virtualUI = virtualDouble.Object;

            Assert.Throws<ArgumentException>(() =>
            {
                virtualUI.ParseInformationFromController();
            }
           );

        }


        [TearDown]
        public void TearDown()
        {

        }

    }
}
