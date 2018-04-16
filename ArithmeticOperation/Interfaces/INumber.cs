using System;

namespace ArithmeticOperation
{
	public interface INumber<T> : ICloneable, IComparable<T>, IInputOutput<T>
	where T: class
	{
		T ZERO { get;}
		T ONE { get;}

		T getReal(double real);
		
		T Add(T other);
		T Subtract(T other);
		T Multiply(T other);
		T Divide(T other);
	}
}

