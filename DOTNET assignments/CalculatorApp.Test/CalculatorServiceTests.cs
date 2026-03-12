using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Test
{
    public class CalculatorServiceTests
    {
        // Arrange
        private readonly CalculatorService _calculator;

        // Constructor runs before each test; creates fresh CalculatorService instance
        public CalculatorServiceTests()
        {
            // Arrange
            _calculator = new CalculatorService();
        }

        // Test Add method for adding positive numbers
        [Fact]
        public void Add_WhenCalledWith2And3_Returns5()
        {
            // Arrange - done in constructor

            // Act
            var result = _calculator.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
        }

        // Test Subtract method with positive numbers
        [Fact]
        public void Subtract_WhenCalledWith5And3_Returns2()
        {
            // Arrange - done in constructor

            // Act
            var result = _calculator.Subtract(5, 3);

            // Assert
            Assert.Equal(2, result);
        }

        // Parameterized test for Multiply method using Theory and InlineData
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-2, 3, -6)]
        [InlineData(0, 5, 0)]
        public void Multiply_WhenCalled_ReturnsExpectedResult(int a, int b, int expected)
        {
            // Arrange - done in constructor

            // Act
            var result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        // Test Divide method for normal case
        [Fact]
        public void Divide_WhenCalledWith6And3_Returns2()
        {
            // Arrange - done in constructor

            // Act
            var result = _calculator.Divide(6, 3);

            // Assert
            Assert.Equal(2, result);
        }

        // Test Divide method to check division by zero throws exception
        [Fact]
        public void Divide_WhenDividingByZero_ThrowsDivideByZeroException()
        {
            // Act and Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}