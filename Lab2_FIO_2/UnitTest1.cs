using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Lab2_FIO_2;

namespace TriangleTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void GetTriangleInfo_InvalidData()
        {
            var result = Triangle.GetTriangleInfo("a", "b", "c");
            Assert.AreEqual("", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (-2, -2), (-2, -2), (-4, -2) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_NegativeSides()
        {
            var result = Triangle.GetTriangleInfo("-1", "-2", "-3");
            Assert.AreEqual("", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (-2, -2), (-2, -2), (-4, -2) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_NotATriangle()
        {
            var result = Triangle.GetTriangleInfo("1", "2", "10");
            Assert.AreEqual("не треугольник", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (-4, -1), (-1, -1), (-1, -1) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_EquilateralTriangle()
        {
            var result = Triangle.GetTriangleInfo("4", "4", "4");
            Assert.AreEqual("равносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (4, 0), (2, 3) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_IsoscelesTriangle()
        {
            var result = Triangle.GetTriangleInfo("4", "4", "5");
            Assert.AreEqual("равнобедренный", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (4, 0), (3, 4) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_ScaleneTriangle()
        {
            var result = Triangle.GetTriangleInfo("3", "4", "5");
            Assert.AreEqual("разносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (3, 0), (4, 3) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_EquilateralTriangleWithFloatSides()
        {
            var result = Triangle.GetTriangleInfo("4.5", "4.5", "4.5");
            Assert.AreEqual("равносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (4, 0), (2, 3) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_IsoscelesTriangleWithFloatSides()
        {
            var result = Triangle.GetTriangleInfo("3.5", "3.5", "4.5");
            Assert.AreEqual("равнобедренный", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (3, 0), (4, 3) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_ScaleneTriangleWithFloatSides()
        {
            var result = Triangle.GetTriangleInfo("3.2", "4.7", "5.8");
            Assert.AreEqual("разносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (3, 0), (4, 5) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_PerfectlyEquilateralTriangle()
        {
            var result = Triangle.GetTriangleInfo("10000", "10000", "10000");
            Assert.AreEqual("равносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (10000, 0), (5000, 8660) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_PerfectlyIsoscelesTriangle()
        {
            var result = Triangle.GetTriangleInfo("9999", "9999", "8888");
            Assert.AreEqual("равнобедренный", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (9999, 0), (4944, 8888) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_PerfectlyScaleneTriangle()
        {
            var result = Triangle.GetTriangleInfo("7.1", "9.2", "5.3");
            Assert.AreEqual("разносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (7.1, 0), (9.2, 5.3) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_MaxFloatSides()
        {
            var result = Triangle.GetTriangleInfo("3.40282347E+38", "1.401298E-45", "1.79769313E+308");
            Assert.AreEqual("разносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (3.40282347E+38, 0), (1.401298E-45, 1.79769313E+308) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_LargestPossibleEquilateralTriangle()
        {
            var result = Triangle.GetTriangleInfo("2147483647", "2147483647", "2147483647");
            Assert.AreEqual("равносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (2147483647, 0), (1073741823, 1859212725) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_LargestPossibleIsoscelesTriangle()
        {
            var result = Triangle.GetTriangleInfo("2147483647", "2147483647", "1000000000");
            Assert.AreEqual("равнобедренный", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (2147483647, 0), (500000000, 1000000000) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_LargestPossibleScaleneTriangle()
        {
            var result = Triangle.GetTriangleInfo("2147483647", "1000000000", "500000000");
            Assert.AreEqual("разносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (2147483647, 0), (1000000000, 500000000) }, result.Item2);
        }

        [TestMethod]
        public void GetTriangleInfo_SpecialCoordinates()
        {
            var result = Triangle.GetTriangleInfo("7.5", "12.1", "14.8");
            Assert.AreEqual("разносторонний", result.Item1);
            CollectionAssert.AreEqual(new List<(double, double)> { (0, 0), (7.5, 0), (12.1, 14.8) }, result.Item2);
        }
    }
}
