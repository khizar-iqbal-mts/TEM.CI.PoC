using System;
using System.Collections.Generic;

namespace TEM.CI.PoC
{
	/// <summary>
	/// Simple calculator class for demonstrating CI/CD pipeline
	/// </summary>
	public class Calculator
	{
		// Unused field - will generate warning
		private int unusedField = 0;

		/// <summary>
		/// Adds two numbers
		/// </summary>
		public int Add(int a, int b)
		{
			return a + b;
		}

		/// <summary>
		/// Subtracts second number from first number
		/// </summary>
		public int Subtract(int a, int b)
		{
			// Unused variable - will generate warning
			int unusedVariable = 42;
			return a - b;
		}

		/// <summary>
		/// Multiplies two numbers
		/// </summary>
		public int Multiply(int a, int b)
		{
			return a * b;
		}

		/// <summary>
		/// Divides first number by second number
		/// </summary>
		/// <param name="a">The dividend</param>
		/// <param name="b">The divisor</param>
		/// <returns>The result of the division</returns>
		/// <exception cref="DivideByZeroException">Thrown when divisor is zero</exception>
		public int Divide(int a, int b)
		{
			if (b == 0)
			{
				// this will be caught by the test
				throw new DivideByZeroException("Cannot divide by zero");
			}
			return a / b;
		}

		/// <summary>
		/// Returns the remainder of the division of two numbers
		/// </summary>
		/// <param name="a">The dividend</param>
		/// <param name="b">The divisor</param>
		/// <returns>The remainder of the division</returns>
		public int Modulo(int a, int b)
		{
			// this will return a runtime error
			return a % b;
		}

		// Unused parameter - will generate warning
		public int GetValue(int unusedParameter)
		{
			return 10;
		}

		// Method with potential null reference - will generate warning
		public string FormatResult(int value)
		{
			string valueA = "0";
			string result = null;
			// Potential null reference warning
			return result.ToUpper();
		}

		// Unused private method - will generate warning
		private void UnusedMethod()
		{
			Console.WriteLine("This method is never called");
		}

		// Method with unused local variable
		public void ProcessNumbers(List<int> numbers)
		{
			int sum = 0;
			// Variable assigned but never used
			int count = numbers.Count;
			foreach (var num in numbers)
			{
				sum += num;
			}
		}

		// Method with potential performance issue (info)
		public void InefficientLoop()
		{
			List<int> list = new List<int>();
			for (int i = 0; i < 1000; i++)
			{
				list.Add(i);
			}
			// Using Count in loop condition - potential performance issue
			for (int i = 0; i < list.Count; i++)
			{
				Console.WriteLine(list[i]);
			}
		}
	}
}

