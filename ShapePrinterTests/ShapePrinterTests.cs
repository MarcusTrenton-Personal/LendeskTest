using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using LendeskTest;

namespace ShapePrinterTests
{
    [TestClass]
    public class ShapePrinterTests
    {
        [TestMethod]
        public void CanFindFileThatExists()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, "../../empty.csv");
            Console.Out.WriteLine("path: " + path);

            ShapePrinter printer = new ShapePrinter(filePath: path);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void CannotFindMissingFile()
        {
            ShapePrinter printer = new ShapePrinter(filePath: "notFound.txt");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailsToParseInvalidFile()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = Path.Combine(currentDirectory, "../../invalidShapeName.csv");
            Console.Out.WriteLine("path: " + path);

            ShapePrinter printer = new ShapePrinter(filePath: path);
        }
    }
}
