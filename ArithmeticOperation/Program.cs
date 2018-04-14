using System;
using System.Collections.Generic;

namespace ArithmeticOperation
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var complex = new List<ComplexNumber>
			{
				new ComplexNumber(1,0.5),
				new ComplexNumber(1,1),
				new ComplexNumber(1),
			};
			var real = new List<RealNumber>
			{
				new RealNumber(1),
				new RealNumber(2),
				new RealNumber(3),
			};
			
			Task.Mult(real).Write(Console.Out);
			Task.Mult(complex).Write(Console.Out);
			Task.Average(real).Write(Console.Out);
			Task.Average(complex).Write(Console.Out);
		}
	}
}