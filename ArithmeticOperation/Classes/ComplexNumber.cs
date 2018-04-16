using System;
using System.IO;


namespace ArithmeticOperation
{
	public class ComplexNumber : INumber<ComplexNumber>
	{
		public ComplexNumber ZERO => new ComplexNumber();
		public ComplexNumber ONE => new ComplexNumber(1);

		public double RealPart { get; private set; }
		public double ImagPart { get; private set; }

		public ComplexNumber(double real, double imag = 0)
		{
			RealPart = real;
			ImagPart = imag;
		}

		public ComplexNumber()
		{
			RealPart = 0;
			ImagPart = 0;
		}

		public void SetValue(double real, double imag)
		{
			RealPart = real;
			ImagPart = imag;
		}

		public bool IsReal()
		{
			return Math.Abs(ImagPart) < 0.00000001;
		}

		public bool IsImaginary()
		{
			return !IsReal();
		}

		public override string ToString()
		{
			return $"({RealPart} + {ImagPart}i)";
		}

		public double Magnitude()
		{
			return Math.Sqrt(RealPart * RealPart + ImagPart * ImagPart);
		}

		public double Argument()
		{
			return Math.Atan2(ImagPart, RealPart);
		}

		public ComplexNumber getReal(double real)
		{
			return new ComplexNumber(real);
		}

		public ComplexNumber Add(ComplexNumber another)
		{
			return new ComplexNumber(RealPart + another.RealPart, ImagPart + another.ImagPart);
		}

		public ComplexNumber Subtract(ComplexNumber another)
		{
			return new ComplexNumber(RealPart - another.RealPart, ImagPart - another.ImagPart);
		}

		public ComplexNumber Reciprocal()
		{
			var scale = RealPart * RealPart + ImagPart * ImagPart;
			RealPart /= scale;
			ImagPart /= scale;
			return this;
		}

		public ComplexNumber Divide(ComplexNumber another)
		{
			return Multiply(another.Reciprocal());
		}

		public ComplexNumber Conjugate()
		{
			RealPart = RealPart;
			ImagPart = ImagPart * (-1);
			return this;
		}

		public ComplexNumber Multiply(ComplexNumber other)
		{
			var real2 = RealPart * other.RealPart - ImagPart * other.ImagPart;
			var imag2 = RealPart * other.ImagPart + ImagPart * other.RealPart;
			return new ComplexNumber(real2, imag2);
		}

		public object Clone()
		{
			return new ComplexNumber(RealPart, ImagPart);
		}

		public void Write(TextWriter Out)
		{
			Out.WriteLine(ToString());
		}

		public ComplexNumber Read(TextReader In)
		{
			RealPart = double.Parse(In.ReadLine());
			ImagPart = double.Parse(In.ReadLine());
			return this;
		}

		private bool Equals(ComplexNumber other)
		{
			return RealPart.Equals(other.RealPart) && ImagPart.Equals(other.ImagPart);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((ComplexNumber) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (RealPart.GetHashCode() * 397) ^ ImagPart.GetHashCode();
			}
		}

		public int CompareTo(ComplexNumber other)
		{
			if (ReferenceEquals(this, other)) return 0;
			if (ReferenceEquals(null, other)) return 1;
			var realRartComparison = RealPart.CompareTo(other.RealPart);
			return realRartComparison != 0 ? realRartComparison : ImagPart.CompareTo(other.ImagPart);
		}
	}
}