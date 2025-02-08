using NUnit.Framework;
using PolynomialLibrary;
using PolynomialLibrary.Exceptions;

namespace PolynomialLibraryTests
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void CreatePolynomial_WithValidCoefficients_ShouldSucceed()
        {
            // Arrange
            var coefficients = new double[] { 3, 4, 5 }; // 5x^2 + 4x + 3
            var polynomial = new Polynomial(coefficients);

            // Act & Assert
            Assert.That(polynomial, Is.Not.Null);
            Assert.That(polynomial.GetCoefficient(2), Is.EqualTo(5));
            Assert.That(polynomial.GetCoefficient(1), Is.EqualTo(4));
            Assert.That(polynomial.GetCoefficient(0), Is.EqualTo(3));
        }

        [Test]
        public void CreatePolynomial_WithNullCoefficients_ShouldThrowPolynomialNullException()
        {
            // Act & Assert
            Assert.That(() => new Polynomial(null), Throws.Exception.TypeOf<PolynomialNullException>());
        }

        [Test]
        public void CreatePolynomial_WithZeroCoefficients_ShouldSucceed()
        {
            // Arrange
            var polynomial = new Polynomial(0); // Полином 0

            // Act & Assert
            Assert.That(polynomial.GetCoefficient(0), Is.EqualTo(0));
        }

        [Test]
        public void CreatePolynomial_WithSingleNonZeroCoefficient_ShouldSucceed()
        {
            // Act
            var polynomial = new Polynomial(1); // Полином 1

            // Assert
            Assert.That(polynomial.GetCoefficient(0), Is.EqualTo(1));
        }

        [Test]
        public void AddPolynomials_ShouldReturnCorrectResult()
        {
            // Arrange
            var p1 = new Polynomial(1, 2, 3); // 3x^2 + 2x + 1
            var p2 = new Polynomial(2, 3, 4); // 4x^2 + 3x + 2
            var expectedSum = new Polynomial(3, 5, 7); // 7x^2 + 5x + 3

            // Act
            var result = p1 + p2;

            // Assert
            Assert.That(result, Is.EqualTo(expectedSum));
        }

        [Test]
        public void MultiplyPolynomials_ShouldReturnCorrectResult()
        {
            // Arrange
            var p1 = new Polynomial(1, 2); // 2x + 1
            var p2 = new Polynomial(2, 3); // 3x + 2
            var expectedProduct = new Polynomial(2, 7, 6); // 3x^2 + 7x + 2

            // Act
            var result = p1 * p2;

            // Assert
            Assert.That(result, Is.EqualTo(expectedProduct));
        }


        [Test]
        public void AddPolynomials_WithResultZero_ShouldReturnZeroPolynomial()
        {
            // Arrange
            var p1 = new Polynomial(-1, -1); // -x - 1
            var p2 = new Polynomial(1, 1);   // x + 1
            var expectedSum = new Polynomial(0); // 0

            // Act
            var result = p1 + p2;

            // Assert
            Assert.That(result.GetCoefficient(0), Is.EqualTo(0));
        }
    }
}