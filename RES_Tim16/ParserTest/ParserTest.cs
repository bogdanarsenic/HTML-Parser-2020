using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser;

namespace ParserTest
{
    [TestFixture]
    public class ParserTest
    {
        [Test]
        public void CheckHtmlStartTagsUntilTitleTest()
        {
            string textGood1 = "<html><head><title>";
            string textGood2 = "  < html> <  head    >       <    title    >  something blb lbaba ";
            string textBad1 = "";
            string textBad2 = "   <html>  <head><bla> something";
            string textBad3 = "   <head><html><title>";
            string textBad4 = "something <html><head><title>";

            Parser.Parser p = new Parser.Parser();

            Assert.AreEqual(true, p.CheckHtmlStartTagsUntilTitle(textGood1));
            Assert.AreEqual(true, p.CheckHtmlStartTagsUntilTitle(textGood2));
            Assert.AreEqual(false, p.CheckHtmlStartTagsUntilTitle(textBad1));
            Assert.AreEqual(false, p.CheckHtmlStartTagsUntilTitle(textBad2));
            Assert.AreEqual(false, p.CheckHtmlStartTagsUntilTitle(textBad3));
            Assert.AreEqual(false, p.CheckHtmlStartTagsUntilTitle(textBad4));
        }

        [Test]
        public void CheckHtmlTagsAfterTitleUntilBodyTest()
        {
            string textGood1 = "<html><head><title> Some title </title></head><body>";
            string textGood2 = "<html><head><title></title></head><body>";
            string textGood3 = "<  html  >   <head>  <  title> Some title <  /title>  <  /head  ><  body   > something";
            string textBad1 = "";
            string textBad2 = "<html><head><title";
            string textBad3 = "<html><head><title> something ";
            string textBad4 = "<html><head><title> something <";
            string textBad5 = "<html><head><title> Some title </title></head>";

            Parser.Parser p = new Parser.Parser();

            Assert.AreEqual(true, p.CheckHtmlTagsAfterTitleUntilBody(textGood1));
            Assert.AreEqual(true, p.CheckHtmlTagsAfterTitleUntilBody(textGood2));
            Assert.AreEqual(true, p.CheckHtmlTagsAfterTitleUntilBody(textGood3));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterTitleUntilBody(textBad1));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterTitleUntilBody(textBad2));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterTitleUntilBody(textBad3));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterTitleUntilBody(textBad4));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterTitleUntilBody(textBad5));
        }

        [Test]
        public void CheckHtmlTagsAfterBodyUntilEndTest()
        {
            string textGood1 = "<html><head><title> Some title </title></head><body> Some body < /body>  <  /html>";
            string textGood2 = "<html><head><title></title></head><body></body></html>";
            string textBad1 = "";
            string textBad2 = "<html><head><title";
            string textBad3 = "<html>head><title> Some title ";
            string textBad4 = "<html><head><title> Some title </title></head><body";
            string textBad5 = "<html><head><title> Some title </title></head><body> Some body ";
            string textBad6 = "<html><head><title> Some title </title></head><body> Some body </body>";

            Parser.Parser p = new Parser.Parser();

            Assert.AreEqual(true, p.CheckHtmlTagsAfterBodyUntilEnd(textGood1));
            Assert.AreEqual(true, p.CheckHtmlTagsAfterBodyUntilEnd(textGood2));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterBodyUntilEnd(textBad1));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterBodyUntilEnd(textBad2));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterBodyUntilEnd(textBad3));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterBodyUntilEnd(textBad4));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterBodyUntilEnd(textBad5));
            Assert.AreEqual(false, p.CheckHtmlTagsAfterBodyUntilEnd(textBad6));
        }

        [Test]
        public void CheckHtmlTagsNotInsideBodyTest()
        {
            string textGood1 = "<html><head><title> Some title </title></head><body> Some body < /body>  <  /html>";
            string textGood2 = "<html><head><title></title></head><body></body></html>";
            string textBad1 = "";
            string textBad2 = "<html><head><title";
            string textBad3 = "<html>head><title> Some title ";
            string textBad4 = "<html><head><title> Some title </title></head><body";
            string textBad5 = "<html><head><title> Some title </title></head><body> Some body ";
            string textBad6 = "<html><head><title> Some title </title></head><body> Some body </body>";

            Parser.Parser p = new Parser.Parser();

            Assert.AreEqual(true, p.CheckHtmlTagsNotInsideBody(textGood1));
            Assert.AreEqual(true, p.CheckHtmlTagsNotInsideBody(textGood2));
            Assert.AreEqual(false, p.CheckHtmlTagsNotInsideBody(textBad1));
            Assert.AreEqual(false, p.CheckHtmlTagsNotInsideBody(textBad2));
            Assert.AreEqual(false, p.CheckHtmlTagsNotInsideBody(textBad3));
            Assert.AreEqual(false, p.CheckHtmlTagsNotInsideBody(textBad4));
            Assert.AreEqual(false, p.CheckHtmlTagsNotInsideBody(textBad5));
            Assert.AreEqual(false, p.CheckHtmlTagsNotInsideBody(textBad6));

        }

        [Test]
        public void CheckIfValidTagTest()
        {
            List<string> goodList1 = new List<string>() { "<html>", "<head>",
                "<title>", "</title>", "</head>", "<body>",
                "<b>", "</b>", "<p>", "</p>",
                "<a>", "</a>", "<ul>", "</ul>", "<li>", "</li>",
                "</body>", "</html>"};

            List<string> goodList2 = new List<string>() { "<html>", "<head>",
                "<title>", "</title>", "</head>", "<body>",
                "<b>", "</b>", "<b>", "</b>", "<p>",
                 "<ul>",  "<li>", "<a>", "</a>", "</li>", "<li>", "<a>", "</a>", "</li>", "</ul>", "</p>",
                "</body>", "</html>"};

            List<string> goodList3 = new List<string>() { "<html>", "<head>",
                "<title>", "</title>", "</head>", "<body>",
                 "<p>","</p>",
                "</body>", "</html>"};

            List<string> badList1 = new List<string>() { "<html>", "<head>",
                "<title>", "</title>", "</head>", "<body>",
                "<b>", "</b>", "<p>", "<p>", "</p>",
                "<a>", "</a>", "<ul>", "</ul>", "<li>", "</li>",
                "</body>", "</html>"};

            List<string> badList2 = new List<string>() { "<html>", "<head>",
                "<title>", "</title>", "</head>", "<body>",
                "<b>", "</b>", "</p>", "<p>",
                "<a>", "</a>", "<ul>", "</ul>", "<li>", "</li>",
                "</body>", "</html>"};

            List<string> badList3 = new List<string>() { "<html>", "<head>",
                "<title>", "</title>", "</head>", "<body>",
                "<b>", "</b>", "<p>", "<p>", "</p>", "</p>",
                "<a>", "</a>", "<ul>", "</ul>", "<li>", "</li>",
                "</body>", "</html>"};

            string goodTag = "p";

            Parser.Parser p = new Parser.Parser();

            Assert.AreEqual(true, p.CheckIfValidTag(goodList1, goodTag));
            Assert.AreEqual(true, p.CheckIfValidTag(goodList2, goodTag));
            Assert.AreEqual(true, p.CheckIfValidTag(goodList3, goodTag));
            Assert.AreEqual(true, p.CheckIfValidTag(goodList1, goodTag));
            Assert.AreEqual(true, p.CheckIfValidTag(goodList2, goodTag));
            Assert.AreEqual(true, p.CheckIfValidTag(goodList3, goodTag));

            Assert.AreEqual(false, p.CheckIfValidTag(badList1, goodTag));
            Assert.AreEqual(false, p.CheckIfValidTag(badList2, goodTag));
            Assert.AreEqual(false, p.CheckIfValidTag(badList3, goodTag));

        }

        [Test]
        public void CheckHtmlTagsInsideBodyTest()
        {
            string textGood1 = "";
            string textGood2 = "<p> some <b> Paragraf </b> </p>";
            string textGood3 = "<p> some <b> Paragraf </b> </p> <ul> <li> <p> listItem1 </p> </li> <li> listItem2 </li> </ul>";
            string textBad1 = "<p> some Paragraf </p> </p>";
            string textBad2 = "<p> some paragraf </p> </p> <p>";
            string textBad3 = "</p> some paragraf <p> <p> </p>";
            string textBad4 = "<p> some paragraf </p> </p> <p>";

            Parser.Parser p = new Parser.Parser();

            Assert.AreEqual(true, p.CheckHtmlTagsInsideBody(textGood1));
            Assert.AreEqual(true, p.CheckHtmlTagsInsideBody(textGood2));
            Assert.AreEqual(true, p.CheckHtmlTagsInsideBody(textGood3));
            Assert.AreEqual(false, p.CheckHtmlTagsInsideBody(textBad1));
            Assert.AreEqual(false, p.CheckHtmlTagsInsideBody(textBad2));
            Assert.AreEqual(false, p.CheckHtmlTagsInsideBody(textBad3));
            Assert.AreEqual(false, p.CheckHtmlTagsInsideBody(textBad4));
        }

        [Test]
        public void CheckAllTagsTest()
        {
            string textGood1 = "<html><head><title> Some title </title></head><body><p> some <b> Paragraf </b> </p> <ul> <li> <p> listItem1 </p> </li> <li> listItem2 </li> </ul> < /body>  <  /html>";
            string textGood2 = "<html><head><title> Some title </title></head><body> < /body>  <  /html>";
            string textBad1 = "<html>   <title> Some title </title></head><body> < /body>  <  /html>";
            string textBad2 = "<html><head><title> Some title </title></head><body> some <p> paragraf < /body>  <  /html>";

            Parser.Parser p = new Parser.Parser();

            Assert.AreEqual(true, p.CheckAllTags(textGood1));
            Assert.AreEqual(true, p.CheckAllTags(textGood2));
            Assert.AreEqual(false, p.CheckAllTags(textBad1));
            Assert.AreEqual(false, p.CheckAllTags(textBad2));
        }

    }
}
