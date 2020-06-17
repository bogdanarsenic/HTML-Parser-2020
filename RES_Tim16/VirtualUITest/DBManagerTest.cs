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
        private FileContent fileContent;
        private FileContent fileContent2;
        private Files file;
        private Delta delta;
        private const string FILEID = "1";
        private const string ID = "4i30i430i30i403";
        private const string CONTENT = "Nesto";
        private IDBManager fakeDatabase;

        [SetUp]
        public void SetUp()
        {
            Mock<FileContent> contentDouble = new Mock<FileContent>();
            contentDouble.Setup(content => content.FileId).Returns(FILEID);
            contentDouble.Setup(content => content.Id).Returns(ID);
            contentDouble.Setup(content => content.Content).Returns(CONTENT);
            fileContent = contentDouble.Object;


            fakeDatabase = new FakeDBManager();
            fakeDatabase.AddFileContent(fileContent);

        }

        [Test]
        public void AddFileContentGood()
        {
            string fc = fakeDatabase.GetFileContentId(ID);
            Assert.IsNotNull(fc);
        }


        [TearDown]
        public void TearDown()
        {
            fileContent2 = null;
            fileContent = null;
        }
    }
}