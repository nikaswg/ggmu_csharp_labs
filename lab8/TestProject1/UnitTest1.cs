using NUnit.Framework;
using PolygonLibrary;
using PolygonManagerLibrary;
using System.IO;

namespace PolygonTests
{
    [TestFixture]
    public class PolygonTests
    {
        [Test]
        public void TriangleArea_ValidSides_ReturnsCorrectArea()
        {
            var triangle = new Triangle(new[] { 3.0, 4.0, 5.0 }, "red");
            Assert.That(triangle.Area(), Is.EqualTo(6.0).Within(1e-10));
        }

        [Test]
        public void RectangleArea_ValidSides_ReturnsCorrectArea()
        {
            var rectangle = new PolygonLibrary.Rectangle(new[] { 4.0, 5.0 }, "blue");
            Assert.That(rectangle.Area(), Is.EqualTo(20.0));
        }

        [Test]
        public void RegularPolygonArea_ValidSides_ReturnsCorrectArea()
        {
            var polygon = new RegularPolygon(new[] { 3.0, 3.0, 3.0 }, "green");
            Assert.That(polygon.Area(), Is.EqualTo(3.897114317).Within(1e-10)); // Area of an equilateral triangle
        }

        [Test]
        public void AddPolygon_ValidTriangle_AddsPolygon()
        {
            var manager = new PolygonManager();
            manager.AddPolygon(new[] { 3.0, 4.0, 5.0 }, "red");
            Assert.That(manager.Polygons.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetPolygonInfo_ReturnsCorrectInfo()
        {
            var manager = new PolygonManager();
            manager.AddPolygon(new[] { 3.0, 4.0, 5.0 }, "red");
            var info = manager.GetPolygonInfo();
            Assert.That(info.Count, Is.EqualTo(1));
            Assert.That(info[0], Does.Contain("red"));
        }

        [Test]
        public void LoadFromFile_EmptyFile_GeneratesDefaultPolygons()
        {
            var manager = new PolygonManager();
            var filePath = @"C:\Users\Никита\Downloads\lab8\test.txt";
            File.WriteAllText(filePath, string.Empty); // Clear the file for testing
            manager.LoadFromFile();
            Assert.That(manager.Polygons.Count, Is.GreaterThan(0)); // Ensure default polygons were generated
        }

        [Test]
        public void CalculateRedRightTrianglePerimeters_ReturnsCorrectPerimeters()
        {
            var manager = new PolygonManager();
            manager.AddPolygon(new[] { 3.0, 4.0, 5.0 }, "red"); // Right triangle
            manager.AddPolygon(new[] { 5.0, 12.0, 13.0 }, "red"); // Right triangle
            manager.AddPolygon(new[] { 2.0, 2.0, 3.0 }, "red"); // Not a right triangle

            var results = manager.CalculateRedRightTrianglePerimeters();
            Assert.That(results.Count, Is.EqualTo(2)); // Should find two right triangles
        }
    }
}