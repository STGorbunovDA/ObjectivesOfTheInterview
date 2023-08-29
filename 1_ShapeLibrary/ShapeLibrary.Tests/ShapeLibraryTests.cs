using static ShapeLibrary.ShapeLibrary;

namespace ShapeLibrary.Tests
{
    [TestClass]
    public class ShapeLibraryTests
    {
        [TestMethod]
        public void Circle_Area_CalculatedCorrectly()
        {
            // Arrange
            Circle circle = new Circle(5);

            // Act
            double area = circle.CalculateArea();

            // Assert
            Assert.AreEqual(78.539816339744829, area, 0.0001);
        }

        [TestMethod]
        public void Triangle_Area_CalculatedCorrectly()
        {
            // Arrange
            Triangle triangle = new Triangle(3, 4, 5);

            // Act
            double area = triangle.CalculateArea();

            // Assert
            Assert.AreEqual(6, area);
        }

        [TestMethod]
        public void Triangle_IsRightTriangle_Check()
        {
            // Arrange
            Triangle rightTriangle = new Triangle(3, 4, 5);
            Triangle nonRightTriangle = new Triangle(5, 7, 9);

            // Act
            bool isRight1 = rightTriangle.IsRightTriangle();
            bool isRight2 = nonRightTriangle.IsRightTriangle();

            // Assert
            Assert.IsTrue(isRight1);
            Assert.IsFalse(isRight2);
        }
    }
}