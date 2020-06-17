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
    public class SendDeltaInformationTest
    {
        private Delta delta;

        [Test]
        [TestCase(null)]
        public void SendDeltaInformationBadConstructor(IController ic)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                SendDeltaInformation send = new SendDeltaInformation(ic);
            }
           );
        }



        [Test]
        [TestCase("nesto","nesto","nesto")]
        public void SendDeltaInformationGoodConstructor(string content,string linerange,string database)
        {
            Mock<IController> controllerMock = new Mock<IController>();
            Mock<Delta> deltaMock = new Mock<Delta>();


            deltaMock.Setup(delta => delta.Content).Returns(content);
            deltaMock.Setup(delta => delta.LineRange).Returns(linerange);

            delta = deltaMock.Object;
            controllerMock.Setup(controller => controller.SendDeltaInformation(content, linerange, database)).Verifiable();
            SendDeltaInformation send = new SendDeltaInformation(controllerMock.Object);

            send.Send(delta, database);
            controllerMock.Verify(controller => controller.SendDeltaInformation(content, linerange, database), Times.Once);

        }

    }
}
