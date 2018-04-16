using System.Collections.Generic;
using System.Linq;

namespace ArithmeticOperation
{
	public class Task
	{
		public static T Sum<T>(IEnumerable<T> items) where T : class, INumber<T>, new()
		{
			return items.Aggregate(new T(), (current, item) => current.Add(item));
		}

		public static T Mult<T>(IEnumerable<T> items) where T : class, INumber<T>, new()
		{
			return items.Aggregate(new T().ONE, (current, item) => current.Multiply(item));
		}
		
		public static T Average<T>(IEnumerable<T> items) where T : class, INumber<T>, new()
		{
			var arr = items as T[] ?? items.ToArray();
			return !arr.Any() ? new T() : Sum(arr).Divide(new T().getReal(arr.Length));
		}
	}
}