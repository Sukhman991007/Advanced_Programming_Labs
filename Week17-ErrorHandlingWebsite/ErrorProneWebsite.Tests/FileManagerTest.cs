using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net;
using ErrorProneWebsite.Models;

namespace ErrorProneWebsite.Tests
{
    [TestClass]
    public class FileManagerTest
    {
        private const string TEST_FILE_PATH = @"C:\Users\Sulur\Documents\Desktop\New folder\Week17-ErrorHandlingWebsite\ErrorProneWebsite.Tests\TestContent\TestContent.txt";
        private readonly ILog logger = LogManager.GetLogger(typeof(FileManager).Name);

        [TestMethod]
        public void TheFileManagerCanReadAFile()
        {
            FileManager fileManager = new FileManager(TEST_FILE_PATH);

            Assert.AreEqual("Here is some test content.", fileManager.GetContent());


        }
        [TestMethod]
        public void TheFileManagerHandlesAMissingFile()
        {
            FileManager fileManager =
            new FileManager(@"D:\MissingFileThereIsNoFileHere.txt");
            Assert.IsTrue(fileManager.GetContent().Contains("Oops! The content could not be found at the location specified."));
        }
    }
}
