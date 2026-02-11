using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TEM.CI.PoC.Tests
{
	[TestClass]
	public class CalculatorTests
	{
		private Calculator _calculator;

		[TestInitialize]
		public void Setup()
		{
			_calculator = new Calculator();
		}

		[TestMethod]
		public void Add_WhenGivenTwoNumbers_ReturnsSum()
		{
			// Arrange
			int a = 5;
			int b = 3;

			// Act
			int result = _calculator.Add(a, b);

			// Assert
			Assert.AreEqual(8, result);
		}

		[TestMethod]
		public void Add_WhenGivenNegativeNumbers_ReturnsCorrectSum()
		{
			// Arrange
			int a = -5;
			int b = -3;

			// Act
			int result = _calculator.Add(a, b);

			// Assert
			Assert.AreEqual(-8, result);
		}

		[TestMethod]
		public void Subtract_WhenGivenTwoNumbers_ReturnsDifference()
		{
			// Arrange
			int a = 10;
			int b = 4;

			// Act
			int result = _calculator.Subtract(a, b);

			// Assert
			Assert.AreEqual(6, result);
		}

		[TestMethod]
		public void Subtract_WhenResultIsNegative_ReturnsNegativeNumber()
		{
			// Arrange
			int a = 3;
			int b = 10;

			// Act
			int result = _calculator.Subtract(a, b);

			// Assert
			Assert.AreEqual(-7, result);
		}

		[TestMethod]
		public void Multiply_WhenGivenTwoNumbers_ReturnsProduct()
		{
			// Arrange
			int a = 6;
			int b = 7;

			// Act
			int result = _calculator.Multiply(a, b);

			// Assert
			Assert.AreEqual(42, result);
		}

		[TestMethod]
		public void Multiply_WhenGivenZero_ReturnsZero()
		{
			// Arrange
			int a = 5;
			int b = 0;

			// Act
			int result = _calculator.Multiply(a, b);

			// Assert
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Multiply_WhenGivenNegativeNumbers_ReturnsPositive()
		{
			// Arrange
			int a = -4;
			int b = -3;

			// Act
			int result = _calculator.Multiply(a, b);

			// Assert
			Assert.AreEqual(12, result);
		}

		[TestMethod]
		public void Multiply_WhenOneNumberIsNegative_ReturnsNegative()
		{
			// Arrange
			int a = 5;
			int b = -3;

			// Act
			int result = _calculator.Multiply(a, b);

			// Assert
			Assert.AreEqual(-15, result);
		}

		[TestMethod]
		public void Divide_WhenGivenTwoNumbers_ReturnsQuotient()
		{
			// Arrange
			int a = 15;
			int b = 3;

			// Act
			int result = _calculator.Divide(a, b);

			// Assert
			Assert.AreEqual(5, result);
		}

		[TestMethod]
		public void Divide_WhenResultIsNotWhole_ReturnsIntegerPart()
		{
			// Arrange
			int a = 10;
			int b = 3;

			// Act
			int result = _calculator.Divide(a, b);

			// Assert
			Assert.AreEqual(3, result); // Integer division truncates
		}

		[TestMethod]
		public void Divide_WhenDivisorIsZero_ThrowsDivideByZeroException()
		{
			// Arrange
			int a = 10;
			int b = 0;

			// Act & Assert
			Assert.ThrowsException<DivideByZeroException>(() => _calculator.Divide(a, b));
		}

		[TestMethod]
		public void Divide_WhenBothNumbersAreNegative_ReturnsPositive()
		{
			// Arrange
			int a = -12;
			int b = -3;

			// Act
			int result = _calculator.Divide(a, b);

			// Assert
			Assert.AreEqual(4, result);
		}

		[TestMethod]
		public void Divide_WhenDividendIsNegative_ReturnsNegative()
		{
			// Arrange
			int a = -15;
			int b = 3;

			// Act
			int result = _calculator.Divide(a, b);

			// Assert
			Assert.AreEqual(-5, result);
		}

		[TestMethod]
		public void Divide_WhenDivisorIsNegative_ReturnsNegative()
		{
			// Arrange
			int a = 20;
			int b = -4;

			// Act
			int result = _calculator.Divide(a, b);

			// Assert
			Assert.AreEqual(-5, result);
		}

		[TestMethod]
		public void Modulo_WhenGivenTwoNumbers_ReturnsRemainder()
		{
			// Arrange
			int a = 10;
			int b = 3;

			// Act
			int result = _calculator.Modulo(a, b);

			// Assert
			Assert.AreEqual(1, result);
		}

		// add Cube tests here
		[TestMethod]
		public void Cube_WhenGivenNumber_ReturnsCubedValue()
		{
			// Arrange
			int a = 3;
			// Act
			int result = _calculator.Cube(a);
			// Assert
			Assert.AreEqual(27, result);
		}

		[TestMethod]
		public void Cube_WhenGivenNegativeNumber_ReturnsNegativeCubedValue()
		{
			// Arrange
			int a = -2;
			// Act
			int result = _calculator.Cube(a);
			// Assert
			Assert.AreEqual(-8, result);
		}
	}
}

