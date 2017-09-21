using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LendeskTest.Shapes;

namespace ShapePrinterTests
{
    [TestClass]
    public class RegularPolygonTests
    {
        [TestMethod]
        public void SquareNameIsCorrect()
        {
            RegularPolygon square = new RegularPolygon(sideCount: 4, sideLength: 1);
            Assert.AreEqual(square.Name, "square", "Name does not match");
        }

        [TestMethod]
        public void TriangleNameIsCorrect()
        {
            RegularPolygon triangle = new RegularPolygon(sideCount: 3, sideLength: 1);
            Assert.AreEqual(triangle.Name, "triangle", "Name does not match");
        }

        [TestMethod]
        public void SideLengthIsCorrect()
        {
            double sideLength = 1;
            RegularPolygon poly = new RegularPolygon(sideCount: 3, sideLength: sideLength);
            Assert.AreEqual(poly.sideLength, sideLength, "sideLength is not stored correctly");
        }

        [TestMethod]
        public void SideCountIsCorrect()
        {
            int sideCount = 8;
            RegularPolygon poly = new RegularPolygon(sideCount: sideCount, sideLength: 1);
            Assert.AreEqual(poly.sideCount, sideCount, "sideCount is not stored correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NeedsNonNegativeSideLength()
        {
            RegularPolygon poly = new RegularPolygon(sideCount: 6, sideLength: -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NeedsAtLeast3Sides()
        {
            RegularPolygon poly = new RegularPolygon(sideCount: 2, sideLength: 1);
        }

        [TestMethod]
        public void PerimiterIsCorrect()
        {
            RegularPolygon poly = new RegularPolygon(sideCount: 3, sideLength: 1);
            double expectedPerimeter = 3.0;
            bool isWithinTolerance = Math.Abs(poly.Perimeter - expectedPerimeter) < 0.01;
            Assert.IsTrue(isWithinTolerance, "Perimeter is not calculated correctly");
        }

        [TestMethod]
        public void TriangleAreaIsCorrect()
        {
            RegularPolygon triangle = new RegularPolygon(sideCount: 3, sideLength: 1);
            double expectedArea = Math.Sqrt(3) / 4;
            bool isWithinTolerance = Math.Abs(triangle.Area - expectedArea) < 0.01;
            Assert.IsTrue(isWithinTolerance, "Area is not calculated correctly");
        }

        [TestMethod]
        public void SquareAreaIsCorrect()
        {
            RegularPolygon square = new RegularPolygon(sideCount: 4, sideLength: 1);
            double expectedArea = 1.0;
            bool isWithinTolerance = Math.Abs(square.Area - expectedArea) < 0.01;
            Assert.IsTrue(isWithinTolerance, "Area is not calculated correctly");
        }
    }
}
