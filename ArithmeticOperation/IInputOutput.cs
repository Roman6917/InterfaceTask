using System;
using System.IO;
namespace ArithmeticOperation
{
	public interface IInputOutput<out T>
	{
		void Write(TextWriter Out);
		T Read(TextReader In);
	}
}