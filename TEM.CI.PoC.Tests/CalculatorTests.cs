using Microsoft.VisualStudio.TestTools.UnitTesting;

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
	}
}

