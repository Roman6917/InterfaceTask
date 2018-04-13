using System;
using System.IO;

// ReSharper disable NonReadonlyMemberInGetHashCode

namespace ArithmeticOperation
{
	public class Complex : INumber<Complex>
	{
		private double RealRart { get; set; }
		private double ImagPart { get; set; }

		public Complex(double real, double imag = 0)
		{
			RealRart = real;
			ImagPart = imag;
		}

		public Complex()
		{
			RealRart = 0;
			ImagPart = 0;
		}

		public double GetReal()
		{
			return RealRart;
		}

		public void GetReal(double real)
		{
			this.RealRart = real;
		}

		public double GetImag()
		{
			return ImagPart;
		}

		public void GetImag(double imag)
		{
			this.ImagPart = imag;
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

		public Complex Add(Complex another)
		{
			return new Complex(RealRart + another.RealRart, ImagPart + another.ImagPart);
		}

		public Complex Subtract(Complex another)
		{
			return new Complex(RealRart - another.RealRart, ImagPart - another.ImagPart);
		}

		public Complex Reciprocal()
		{
			var scale = RealRart * RealRart + ImagPart * ImagPart;
			RealRart /= scale;
			ImagPart /= scale;
			return this;
		}

		public Complex Divide(Complex another)
		{
			return Multiply(another.Reciprocal());
		}

		public Complex Conjugate()
		{
			this.RealRart = RealRart;
			this.ImagPart = ImagPart * (-1);
			return this;
		}

		public Complex Multiply(Complex other)
		{
			var real2 = RealRart * other.RealRart - ImagPart * other.ImagPart;
			var imag2 = RealRart * other.ImagPart + ImagPart * other.RealRart;
			return new Complex(real2, imag2);
		}

		public object Clone()
		{
			return new Complex(RealRart, ImagPart);
		}

		public void Write(TextWriter Out)
		{
			Out.WriteLine(ToString());
		}

		public Complex Read(TextReader In)
		{
			RealRart = double.Parse(In.ReadLine());
			ImagPart = double.Parse(In.ReadLine());
			return this;
		}

		private bool Equals(Complex other)
		{
			return RealRart.Equals(other.RealRart) && ImagPart.Equals(other.ImagPart);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((Complex) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (RealRart.GetHashCode() * 397) ^ ImagPart.GetHashCode();
			}
		}

		public int CompareTo(Complex other)
		{
			if (ReferenceEquals(this, other)) return 0;
			if (ReferenceEquals(null, other)) return 1;
			var realRartComparison = RealRart.CompareTo(other.RealRart);
			return realRartComparison != 0 ? realRartComparison : ImagPart.CompareTo(other.ImagPart);
		}
	}
}