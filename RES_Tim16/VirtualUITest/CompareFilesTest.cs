using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualUI;
using VirtualUI.Controller;
using VirtualUI.Models;

namespace VirtualUITest
{
    [TestFixture]
    public class CompareFilesTest
    {
        private IDeltaController deltaController;
        [Test]
        [TestCase(null)]
        public void CompareFilesBadConstructor(IDeltaController ic)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                CompareFiles cf = new CompareFiles(ic);
            }
           );
        }

        [Test]
        public void CompareFilesGoodConstructor()
        {
            Mock<IDeltaController> deltacontrollerDouble = new Mock<IDeltaController>();
            deltaController = deltacontrollerDouble.Object;

            CompareFiles cf = new CompareFiles(deltaController);
            Assert.AreEqual(cf.dc, deltaController);
        }

        [Test]
        [TestCase("nesto","nesto")]
        public void CompareFilesBadException(string content,string databaseContent)
        {
            Mock<IDeltaController> deltacontrollerDouble = new Mock<IDeltaController>();
            deltaController = deltacontrollerDouble.Object;

            CompareFiles cf = new CompareFiles(deltaController);

            Assert.Throws<ArgumentException>(() =>
            {
                cf.Compare(content, databaseContent, "bzvId");
            }
            );
        }

        [Test]
        [TestCase("nesto\r\n druga\r\n", "drugo\r\n prvo\r\n")]
        public void CompareFiles(string content, string databaseContent)
        {
            Mock<IDeltaController> deltacontrollerDouble = new Mock<IDeltaController>();
            deltaController = deltacontrollerDouble.Object;

            CompareFiles cf = new CompareFiles(deltaController);

            Delta d=cf.Compare(content, databaseContent, "nekiFajl");

            Assert.AreEqual(d.Content, "nesto\n druga\n");
            Assert.AreEqual(d.LineRange, "1,2,");
        }


    }
}
