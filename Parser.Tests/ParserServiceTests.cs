using HtmlAgilityPack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parser.BusinessLayer.Services;
using Parser.DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Parser.Tests
{
    [TestClass]
    public class ParserServiceTests
    {
        [TestMethod]
        public void GetWordsStatisticsTest()
        {
            //Arrange
            string htmlContent =
           @"<html>
                <body>
                    <p>
                        <a href='http://www.example.com'>
                        </a>
                        Слово
                    </p>
                 </body>
             </html>";

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            var expected = new List<WordStatistics> { new WordStatistics {Id = 0, Word = "слово", Count = 1} };

            //Act
            var actual = ParserService.GetWordsStatisitics(doc);
            
            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}