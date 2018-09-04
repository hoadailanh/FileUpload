using API.models;
using API.services;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tests;

namespace Test
{
    [TestClass]
    public class FileParserTests
    {
        private readonly CSVFIleParser fileParser;
        public FileParserTests()
        {
            fileParser = new CSVFIleParser();
        }

        [TestMethod]
        public void ReturnTypeIsResultModel()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir, "TestCSVFiles", "DealerTrack-CSV-Empty.csv");
            var physicalFile = new FileInfo(path);
            IFormFile formFile = physicalFile.AsMockIFormFile();
            var result = (ResultModel)fileParser.Parse(formFile);
            Assert.IsInstanceOfType(result, typeof(ResultModel));
        }

        [TestMethod]
        public void Test_EmptyCSVFile()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir, "TestCSVFiles", "DealerTrack-CSV-Empty.csv");
            var physicalFile = new FileInfo(path);
            IFormFile formFile = physicalFile.AsMockIFormFile();
            ResultModel result = (ResultModel)fileParser.Parse(formFile);
            Assert.AreEqual(result.Headers.Count, 0);
            Assert.AreEqual(result.Rows.Count, 0);
        }

        [TestMethod]
        public void Test_CSVFileWith6HeardersOnly()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir, "TestCSVFiles", "Dealertrack-CSV-headers-only.csv");
            var physicalFile = new FileInfo(path);
            IFormFile formFile = physicalFile.AsMockIFormFile();
            ResultModel result = (ResultModel)fileParser.Parse(formFile);
            Assert.AreEqual(result.Headers.Count, 6);
            Assert.AreEqual(result.Rows.Count, 0);
        }

        [TestMethod]
        public void Test_CSVFileWithOneRow()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir, "TestCSVFiles", "Dealertrack-CSV-one-record.csv");
            var physicalFile = new FileInfo(path);
            IFormFile formFile = physicalFile.AsMockIFormFile();
            ResultModel result = (ResultModel)fileParser.Parse(formFile);
            Assert.AreEqual(result.Rows.Count, 1);
        }

        [TestMethod]
        public void TestCSVFileWithOneColumn()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir, "TestCSVFiles", "Dealertrack-CSV-one-column.csv");
            var physicalFile = new FileInfo(path);
            IFormFile formFile = physicalFile.AsMockIFormFile();
            ResultModel result = (ResultModel)fileParser.Parse(formFile);
            Assert.AreEqual(result.Headers.Count, 1);
            Assert.AreEqual(result.Rows.Count, 1);
        }

        [TestMethod]
        public void TestCSVFileWithManyRows()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir, "TestCSVFiles", "Dealertrack-CSV-Example.csv");
            var physicalFile = new FileInfo(path);
            IFormFile formFile = physicalFile.AsMockIFormFile();
            ResultModel result = (ResultModel)fileParser.Parse(formFile);
            Assert.AreEqual(result.Rows.Count, 10);
        }

        [TestMethod]
        public void TestCSVFileWithDifferentFormat()
        {
            string currentDir = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDir, "TestCSVFiles", "Dealertrack-CSV-AnotherFormat.csv");
            var physicalFile = new FileInfo(path);
            IFormFile formFile = physicalFile.AsMockIFormFile();
            ResultModel result = (ResultModel)fileParser.Parse(formFile);
            Assert.AreEqual(result.Headers.Count, 5);
            Assert.AreEqual(result.Rows.Count, 2);
        }
    }
}
