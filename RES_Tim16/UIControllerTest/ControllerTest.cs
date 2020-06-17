using Moq;
using NUnit.Framework;
using Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIController;
using VirtualUI;

namespace UIControllerTest
{
    [TestFixture]
    public class ControllerTest
    {
        private IFileParser parser;
        private IController controller;

        [SetUp]
        public void SetUp()
        {
            Mock<IFileParser> parserDouble = new Mock<IFileParser>();

            parserDouble.Setup(parser => parser.Name).Returns("Name");
            parserDouble.Setup(parser => parser.Content).Returns("Content");

            parser = parserDouble.Object;
        }

        [Test]
        public void UIControllerGood()
        {
                controller = new Controller(parser);

                Assert.AreEqual(controller.Content, parser.Content);
                Assert.AreEqual(controller.Name, parser.Name);
        }

        [Test]
        [TestCase(null)]
        public void ControllerBadParameterNull(IFileParser parser)
        {

            Assert.Throws<ArgumentNullException>(() =>
            {
                controller = new Controller(parser);
            }
            );
        }

        [Test]
        [TestCase(null, "content")]
        [TestCase("name", null)]

        public void ControllerBadParameterNullProperty(string name, string content)
        {
            Mock<IFileParser> nestoDouble = new Mock<IFileParser>();
            nestoDouble.Setup(parser => parser.Content).Returns(content);
            nestoDouble.Setup(parser => parser.Name).Returns(name);

            IFileParser novo = nestoDouble.Object;

            Assert.Throws<ArgumentNullException>(() =>
            {
                IController controller = new Controller(novo);
            }
            );
        }

        [Test]
        [TestCase("", "content")]
        [TestCase("name", "")]

        public void ControllerBadParameterEmptyString(string name, string content)
        {
            Mock<IFileParser> nestoDouble = new Mock<IFileParser>();
            nestoDouble.Setup(parser => parser.Content).Returns(content);
            nestoDouble.Setup(parser => parser.Name).Returns(name);

            IFileParser novo = nestoDouble.Object;

            Assert.Throws<ArgumentException>(() =>
            {
                IController controller = new Controller(novo);
            }
            );
        }

        [Test]
        [TestCase(null,"nesto","nesto")]
        [TestCase("nesto",null, "nesto")]
        [TestCase("nesto", "nesto", null)]

        public void SendDeltaInformationBadNull(string textcontent, string lineRange, string databaseContent)
        {


            Mock<IFileParser> fileParserDouble = new Mock<IFileParser>();
            fileParserDouble.Setup(fileparser => fileparser.Name).Returns("ime");
            fileParserDouble.Setup(fileparser => fileparser.Content).Returns("content");
            parser = fileParserDouble.Object;

            IController controllerProba = new Controller(parser);


            Assert.Throws<ArgumentNullException>(() =>
            {
                controllerProba.SendDeltaInformation(textcontent, lineRange, databaseContent);
            }
            );

        }

        [Test]
        [TestCase("", "nesto", "nesto")]
        [TestCase("nesto", "", "nesto")]
        [TestCase("nesto", "nesto", "")]
        public void SendDeltaInformationEmptyBad(string textcontent, string lineRange, string databaseContent)
        {
            Mock<IFileParser> fileParserDouble = new Mock<IFileParser>();
            fileParserDouble.Setup(fileparser => fileparser.Name).Returns("ime");
            fileParserDouble.Setup(fileparser => fileparser.Content).Returns("content");
            parser = fileParserDouble.Object;

            IController controllerProba = new Controller(parser);


            Assert.Throws<ArgumentException>(() =>
            {
                controllerProba.SendDeltaInformation(textcontent, lineRange, databaseContent);
            }
            );

        }

        [Test]
        [TestCase("nesto", "nesto", "nesto")]
        public void SendDeltaInformationGood(string textcontent, string lineRange, string databaseContent)
        {
            Mock<IFileParser> fileParserDouble = new Mock<IFileParser>();
            fileParserDouble.Setup(fileparser => fileparser.Name).Returns("ime");
            fileParserDouble.Setup(fileparser => fileparser.Content).Returns("content");
            parser = fileParserDouble.Object;

            IController controllerProba = new Controller(parser);

            controllerProba.SendDeltaInformation(textcontent, lineRange, databaseContent);

            Assert.AreEqual(controllerProba.DeltaContent, textcontent);
            Assert.AreEqual(controllerProba.LineRange, lineRange);
            Assert.AreEqual(controllerProba.DatabaseContent, databaseContent);


        }


        [TearDown]
        public void TearDown()
        {
            parser = null;
        }
        
    }
}
