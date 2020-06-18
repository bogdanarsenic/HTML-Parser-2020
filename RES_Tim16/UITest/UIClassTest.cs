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
    public class UIClassTest
    {
        private IController controller;

        [Test]
        [TestCase(null)]
        public void UIClassBadConstructor(IController ic)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                UIClass ui = new UIClass(ic);
            }
           );
        }

        [Test]
        [TestCase("nesto","nesto","1,6,")]
        [TestCase("nesto", "nesto", "5,7,")]
        public void UIClassGetLineRange(string database,string deltacontent, string lines)
        {
            Mock<IController> controllerDouble = new Mock<IController>();
            controllerDouble.Setup(controller => controller.DatabaseContent).Returns(database);
            controllerDouble.Setup(controller => controller.DeltaContent).Returns(deltacontent);
            controllerDouble.Setup(controller => controller.LineRange).Returns(lines);

            controller = controllerDouble.Object;

            UIClass ui = new UIClass(controller);    

            int[] i =new int [1];

            i=ui.GetLineRange(lines);

            Assert.AreEqual(i[0], ui.LineNumbers[0]);
            Assert.AreEqual(i[1], ui.LineNumbers[1]);

        }

        [TestCase("nesto", "nesto", "5")] //no ,
        public void UIClassBadException(string database, string deltacontent, string lines)
        {
            Mock<IController> controllerDouble = new Mock<IController>();
            controllerDouble.Setup(controller => controller.DatabaseContent).Returns(database);
            controllerDouble.Setup(controller => controller.DeltaContent).Returns(deltacontent);
            controllerDouble.Setup(controller => controller.LineRange).Returns(lines);

            controller = controllerDouble.Object;

            Assert.Throws<ArgumentException>(() =>
            {
                UIClass ui = new UIClass(controller);
            }
           );

        }
    }
}
