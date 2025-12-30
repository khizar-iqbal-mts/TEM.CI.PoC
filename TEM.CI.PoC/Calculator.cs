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
		/// <exception cref="DivideByZeroException">Thrown when divisor is zero</exception>
		public int Divide(int a, int b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException("Cannot divide by zero");
			}
			return a / b;
		}

		// Unused parameter - will generate warning
		public int GetValue(int unusedParameter)
		{
			return 10;
		}

		// Method with potential null reference - will generate warning
		public string FormatResult(int value)
		{
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

