
using NUnit.Framework;
using SalesTaxes.Helpers;


namespace SalesTaxes.Tests
{
    [TestFixture]
    public class HelperTests
    {
        [Test]
        [TestCase(1.499, 1.5)]
        [TestCase(7.125, 7.15)]
        [TestCase(4.1985, 4.2)]
        [TestCase(0.5, 0.5)]
        [TestCase(1.899, 1.9)]
        [TestCase(0.5625, 0.6)]
        public void RoundUp_AnyDecimal_ShouldBeRoundedToToTheNearEstPointZeroFive(decimal input, decimal expected)
        {
            //Arrange
            //Act
            var result = input.RoundUp();
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }




        [Test]
        [TestCase(1.499, 1.4)]
        [TestCase(7.125, 7.1)]
        [TestCase(4.1985, 4.1)]
        [TestCase(0.5, 0.5)]
        [TestCase(1.899, 1.8)]
        [TestCase(0.5625, 0.5)]
        public void TruncateDecimal_AnyDecimal_ShouldReturnIntPlusOnNumberAfterDecimalPoint(decimal input, decimal expected)
        {
            //Arrange
            //Act
            var result = input.TruncateDecimal();
            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
