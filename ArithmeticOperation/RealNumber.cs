using System;
using System.Globalization;
using System.IO;

namespace ArithmeticOperation
{
	public class Real: INumber<Real>
	{
		private double Num { get; set; }

		public Real()
		{
			Num = 0;
		}
		
		public Real(double num)
		{
			this.Num = num;
		}
		
		public object Clone()
		{
			return new Real(Num);
		}

		public override string ToString()
		{
			return $"{Num}";
		}

		private bool Equals(Real other)
		{
			return Num.Equals(other.Num);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == this.GetType() && Equals((Real) obj);
		}

		public override int GetHashCode()
		{
			return Num.GetHashCode();
		}

		public int CompareTo(Real other)
		{
			if (ReferenceEquals(this, other)) return 0;
			return ReferenceEquals(null, other) ? 1 : Num.CompareTo(other.Num);
		}

		public void Write(TextWriter Out)
		{
			Out.WriteLine(ToString());
		}

		public Real Read(TextReader In)
		{
			Num = double.Parse(In.ReadLine());
			return this;
		}

		public Real Add(Real other)
		{
			var num = Num + other.Num;
			return new Real(num);
		}

		public Real Subtract(Real other)
		{
			var num = Num - other.Num;
			return new Real(num);
		}

		public Real Multiply(Real other)
		{
			var num = Num * other.Num;
			return new Real(num);
		}

		public Real Divide(Real other)
		{
			var num = 0.0;
			if (Math.Abs(other.Num) > 0.00000001)
			{
				num = Num / other.Num;
			}
			else
			{
				throw new ArgumentException("You can't divide by 0");
			}

			return new Real(num);
		}
		
		
	}
}