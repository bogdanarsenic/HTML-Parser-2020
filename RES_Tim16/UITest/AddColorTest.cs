using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using UIController;

namespace UITest
{
    [TestFixture]
    public class AddColorTest
    {
        private IController controller;

        [Test]
        [TestCase(null,null)]
        [TestCase(new int[] { 4, 5 }, null)]
        public void AddClassNullParameteres(int []lines,IController ic)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                AddColor ac = new AddColor(lines,ic);
            }
           );
        }

        [TestCase("","","")]
        [TestCase("nesto\n", "nesto\n", "nesto\n")]
        [TestCase("nesto\r\n", "nesto\n", "nesto\n")]
        [TestCase("nesto\r\n", "nesto", "nesto\r\n")]
        public void AddClassBadException(string database,string delta,string content)
        {

            Mock<IController> controllerDouble = new Mock<IController>();
            controllerDouble.Setup(controller => controller.DatabaseContent).Returns(database);
            controllerDouble.Setup(controller => controller.DeltaContent).Returns(delta);
            controllerDouble.Setup(controller => controller.Content).Returns(content);

            controller = controllerDouble.Object;

            int[] lines = new int[1];
            lines[0] = 5;

            Assert.Throws<ArgumentException>(() =>
            {
                AddColor ac = new AddColor(lines, controller);
            }
          );
        }



     /*   [TestCase("nesto\r\n", "nesto\n", "nesto\r\n")]
        public void AddClassGood(string database, string delta, string content)
        {

            Mock<IController> controllerDouble = new Mock<IController>();
            controllerDouble.Setup(controller => controller.DatabaseContent).Returns(database);
            controllerDouble.Setup(controller => controller.DeltaContent).Returns(delta);
            controllerDouble.Setup(controller => controller.Content).Returns(content);

            controller = controllerDouble.Object;
            


            color.AddDifference();
        }
    */
    }
}
