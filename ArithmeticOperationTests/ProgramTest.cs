using System;
using System.Collections.Generic;
using Xunit;
using ArithmeticOperation;

namespace ArithmeticOperationTests
{
    public static class ProgramTest
    {
        [Fact]
        private static void MainTest()
        {
            var complex = new List<ComplexNumber>
            {
                new ComplexNumber(1, 0.5),
                new ComplexNumber(1, 1),
                new ComplexNumber(1),
            };

            Assert.Equal(3, complex.Count);
            Assert.Equal(0.5, complex[0].ImagPart);
            Assert.Equal(1, complex[1].ImagPart);
            Assert.Equal(0, complex[2].ImagPart);
            Assert.Equal(1, complex[1].RealPart);

            var real = new List<RealNumber>
            {
                new RealNumber(1),
                new RealNumber(2),
                new RealNumber(3),
            };

            Assert.Equal(3, real.Count);
            Assert.Equal(2, real[1].Real);
            Assert.Equal(1, real[0].Real);

            var testVarReal = new RealNumber(6);
            Assert.Equal(testVarReal, Task.Mult(real));
            testVarReal = new RealNumber(1);
            Assert.NotEqual(testVarReal, Task.Mult(real));
            
            testVarReal = new RealNumber(2);
            Assert.Equal(testVarReal, Task.Average(real));
            testVarReal = new RealNumber();
            Assert.NotEqual(testVarReal, Task.Average(real));


            var testVarComplex = new ComplexNumber(0.5, 1.5);
            Assert.Equal(testVarComplex, Task.Mult(complex));
            testVarComplex = new ComplexNumber(7.5, 2.5);
            Assert.NotEqual(testVarComplex, Task.Mult(complex));
            
            testVarComplex = new ComplexNumber(1,0.5);
            Assert.Equal(testVarComplex, Task.Average(complex));
            testVarComplex = new ComplexNumber();
            Assert.NotEqual(testVarComplex, Task.Average(complex));
        }
    }
}