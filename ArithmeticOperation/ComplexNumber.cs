using System;
using System.IO;


namespace ArithmeticOperation
{
	public class ComplexNumber : INumber<ComplexNumber>
	{
		public ComplexNumber ZERO => new ComplexNumber();
		public ComplexNumber ONE => new ComplexNumber(1);

		private double RealRart { get; set; }
		private double ImagPart { get; set; }

		public ComplexNumber(double real, double imag = 0)
		{
			RealRart = real;
			ImagPart = imag;
		}

		public ComplexNumber()
		{
			RealRart = 0;
			ImagPart = 0;
		}

		public void SetValue(double real, double imag)
		{
			this.RealRart = real;
			this.ImagPart = imag;
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
			return $"({RealRart} + {ImagPart}i)";
		}

		public double Magnitude()
		{
			return Math.Sqrt(RealRart * RealRart + ImagPart * ImagPart);
		}

		public double Argument()
		{
			return Math.Atan2(ImagPart, RealRart);
		}

		public ComplexNumber getReal(double real)
		{
			return new ComplexNumber(real);
		}

		public ComplexNumber Add(ComplexNumber another)
		{
			return new ComplexNumber(RealRart + another.RealRart, ImagPart + another.ImagPart);
		}

		public ComplexNumber Subtract(ComplexNumber another)
		{
			return new ComplexNumber(RealRart - another.RealRart, ImagPart - another.ImagPart);
		}

		public ComplexNumber Reciprocal()
		{
			var scale = RealRart * RealRart + ImagPart * ImagPart;
			RealRart /= scale;
			ImagPart /= scale;
			return this;
		}

		public ComplexNumber Divide(ComplexNumber another)
		{
			return Multiply(another.Reciprocal());
		}

		public ComplexNumber Conjugate()
		{
			this.RealRart = RealRart;
			this.ImagPart = ImagPart * (-1);
			return this;
		}

		public ComplexNumber Multiply(ComplexNumber other)
		{
			var real2 = RealRart * other.RealRart - ImagPart * other.ImagPart;
			var imag2 = RealRart * other.ImagPart + ImagPart * other.RealRart;
			return new ComplexNumber(real2, imag2);
		}

		public object Clone()
		{
			return new ComplexNumber(RealRart, ImagPart);
		}

		public void Write(TextWriter Out)
		{
			Out.WriteLine(ToString());
		}

		public ComplexNumber Read(TextReader In)
		{
			RealRart = double.Parse(In.ReadLine());
			ImagPart = double.Parse(In.ReadLine());
			return this;
		}

		private bool Equals(ComplexNumber other)
		{
			return RealRart.Equals(other.RealRart) && ImagPart.Equals(other.ImagPart);
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
				return (RealRart.GetHashCode() * 397) ^ ImagPart.GetHashCode();
			}
		}

		public int CompareTo(ComplexNumber other)
		{
			if (ReferenceEquals(this, other)) return 0;
			if (ReferenceEquals(null, other)) return 1;
			var realRartComparison = RealRart.CompareTo(other.RealRart);
			return realRartComparison != 0 ? realRartComparison : ImagPart.CompareTo(other.ImagPart);
		}
	}
}