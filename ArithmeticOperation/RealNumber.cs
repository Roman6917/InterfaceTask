using System;
using System.IO;

namespace ArithmeticOperation
{
	public class RealNumber: INumber<RealNumber>
	{
		public RealNumber ZERO => new RealNumber();
		public RealNumber ONE => new RealNumber(1);

		
		public double Real { get; private set; }

		public RealNumber()
		{
			Real = 0;
		}
		
		public RealNumber(double real)
		{
			Real = real;
		}
		
		public object Clone()
		{
			return new RealNumber(Real);
		}

		public override string ToString()
		{
			return $"{Real}";
		}

		private bool Equals(RealNumber other)
		{
			return Real.Equals(other.Real);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((RealNumber) obj);
		}

		public override int GetHashCode()
		{
			return Real.GetHashCode();
		}

		public int CompareTo(RealNumber other)
		{
			if (ReferenceEquals(this, other)) return 0;
			return ReferenceEquals(null, other) ? 1 : Real.CompareTo(other.Real);
		}

		public void Write(TextWriter Out)
		{
			Out.WriteLine(ToString());
		}

		public RealNumber Read(TextReader In)
		{
			Real = double.Parse(In.ReadLine());
			return this;
		}

		public RealNumber getReal(double real)
		{
			return new RealNumber(real);
		}

		public RealNumber Add(RealNumber other)
		{
			var num = Real + other.Real;
			return new RealNumber(num);
		}

		public RealNumber Subtract(RealNumber other)
		{
			var num = Real - other.Real;
			return new RealNumber(num);
		}

		public RealNumber Multiply(RealNumber other)
		{
			var num = Real * other.Real;
			return new RealNumber(num);
		}

		public RealNumber Divide(RealNumber other)
		{
			double num;
			if (Math.Abs(other.Real) > 0.00000001)
			{
				num = Real / other.Real;
			}
			else
			{
				throw new ArgumentException("You can't divide by 0");
			}

			return new RealNumber(num);
		}
		
		
	}
}