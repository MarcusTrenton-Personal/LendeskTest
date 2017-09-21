using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LendeskTest.Shapes;

namespace ShapePrinterTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void NameIsCorrect()
        {
            Circle circle = new Circle(radius: 1);
            Assert.AreEqual(circle.Name, "circle", "Name does not match");
        }

        [TestMethod]
        public void RadiusIsCorrect()
        {
            double radius = 1;
            Circle circle = new Circle(radius: radius);
            Assert.AreEqual(circle.radius, radius, "Radius is not stored correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NeedsNonNegativeRadius()
        {
            Circle circle = new Circle(radius: -1);
        }

        [TestMethod]
        public void PerimiterIsCorrect()
        {
            Circle circle = new Circle(radius: 1);
            double expectedPerimeter = 2 * Math.PI;
            bool isWithinTolerance = Math.Abs(circle.Perimeter - expectedPerimeter) < 0.01;
            Assert.IsTrue(isWithinTolerance, "Perimeter is not calculated correctly");
        }

        [TestMethod]
        public void AreaIsCorrect()
        {
            Circle circle = new Circle(radius: 1);
            double expectedArea = Math.PI;
            bool isWithinTolerance = Math.Abs(circle.Area - expectedArea) < 0.01;
            Assert.IsTrue(isWithinTolerance, "Area is not calculated correctly");
        }
    }
}
