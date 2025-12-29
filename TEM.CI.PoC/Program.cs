using System;

namespace TEM.CI.PoC
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("CI/CD Pipeline Demonstration");
			Console.WriteLine("============================");
			Console.WriteLine();

			var calculator = new Calculator();
			int a = 0;
			int b = 1;

			Console.WriteLine($"5 + 3 = {calculator.Add(5, 3)}");
			Console.WriteLine($"10 - 4 = {calculator.Subtract(10, 4)}");

			Console.WriteLine();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
