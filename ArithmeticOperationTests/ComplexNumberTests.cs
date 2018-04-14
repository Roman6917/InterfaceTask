using System;
using Xunit;
using ArithmeticOperation;

namespace ArithmeticOperationTests
{
    public class ComplexNumberTest
    {
        private ComplexNumber _testVar = new ComplexNumber();
        private readonly ComplexNumber _testVarEmpty;

        [Fact]
        public void MainTest()
        {
            Assert.Null(_testVarEmpty);

            Assert.NotNull(_testVar.RealPart);
            Assert.NotNull(_testVar.ImagPart);
            Assert.Equal(0, _testVar.RealPart);
            Assert.Equal(0, _testVar.ImagPart);
            Assert.NotEqual(2, _testVar.RealPart);
            Assert.NotEqual(3, _testVar.ImagPart);

            _testVar = new ComplexNumber(1);
            Assert.Equal(1, _testVar.RealPart);
            Assert.Equal(0, _testVar.ImagPart);
            Assert.NotEqual(1, _testVar.ImagPart);

            _testVar = new ComplexNumber(1, 1);
            Assert.Equal(1, _testVar.RealPart);
            Assert.Equal(1, _testVar.ImagPart);
            Assert.NotEqual(2, _testVar.RealPart);
            Assert.NotEqual(2, _testVar.ImagPart);
        }

        [Fact]
        public void SetValueTest()
        {
            _testVar.SetValue(1, 1);
            Assert.Equal(1, _testVar.RealPart);
            Assert.Equal(1, _testVar.ImagPart);
            Assert.NotEqual('s', _testVar.RealPart);
            Assert.NotEqual(0, _testVar.ImagPart);
        }

        [Fact]
        public void IsRealTest()
        {
            Assert.True(_testVar.IsReal());

            _testVar = new ComplexNumber(1, 1);
            Assert.False(_testVar.IsReal());
        }

        [Fact]
        public void IsImaginaryTest()
        {
            _testVar.IsReal();
            Assert.False(_testVar.IsImaginary());

            _testVar = new ComplexNumber(1, 1);
            _testVar.IsReal();
            Assert.True(_testVar.IsImaginary());
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("(0 + 0i)", _testVar.ToString());

            _testVar = new ComplexNumber(1, 1);
            Assert.Equal("(1 + 1i)", _testVar.ToString());
            Assert.NotEqual("(0 + 1i)", _testVar.ToString());
        }

        [Fact]
        public void MagnitudeTest()
        {
            Assert.Equal(0, _testVar.Magnitude());

            _testVar = new ComplexNumber(6, 8);
            Assert.Equal(10, _testVar.Magnitude());
        }

        [Fact]
        public void ArgumentTest()
        {
            Assert.Equal(0, _testVar.Argument());

            _testVar = new ComplexNumber(2, 3);
            Assert.Equal(Math.Atan2(3, 2), _testVar.Argument());
        }

        [Fact]
        public void GetRealTest()
        {
            _testVar = _testVar.getReal(1);
            Assert.Equal(1, _testVar.RealPart);
        }

        [Fact]
        public void AddTest()
        {
            var testVar2 = new ComplexNumber(2, 2);
            _testVar = new ComplexNumber(1, 1);

            _testVar = _testVar.Add(testVar2);
            Assert.Equal(3, _testVar.RealPart);
            Assert.Equal(3, _testVar.ImagPart);
        }

        [Fact]
        public void SubstractTest()
        {
            var testVar2 = new ComplexNumber(1, 1);
            _testVar = new ComplexNumber(3, 3);

            _testVar = _testVar.Subtract(testVar2);
            Assert.Equal(2, _testVar.RealPart);
            Assert.Equal(2, _testVar.ImagPart);
        }

        [Fact]
        public void ReciprocalTest()
        {
            _testVar = new ComplexNumber(2, 4);

            _testVar = _testVar.Reciprocal();
            Assert.Equal(0.1, _testVar.RealPart);
            Assert.Equal(0.2, _testVar.ImagPart);
        }

        [Fact]
        public void DivideTest()
        {
            var testVar2 = new ComplexNumber(1,1);
            _testVar = new ComplexNumber(2, 2);
            
            _testVar = _testVar.Divide(testVar2);
            Assert.Equal(0, _testVar.RealPart);
            Assert.Equal(2, _testVar.ImagPart);
        }

        [Fact]
        public void ConjugateTest()
        {
            _testVar = new ComplexNumber(2, 2);
            
            _testVar = _testVar.Conjugate();
            Assert.Equal(2, _testVar.RealPart);
            Assert.Equal(-2, _testVar.ImagPart);
        }

        [Fact]
        public void MultiplyTest()
        {
            var testVar2 = new ComplexNumber(1,1);
            _testVar = new ComplexNumber(2, 2);
            
            _testVar = _testVar.Multiply(testVar2);
            Assert.Equal(0, _testVar.RealPart);
            Assert.Equal(4, _testVar.ImagPart);
        }

        [Fact]
        public void EqualsTest()
        {
            var testVar2 = new ComplexNumber(1,1);
            _testVar = new ComplexNumber(2, 2);
            Assert.False(_testVar.Equals(testVar2));
            
            _testVar = new ComplexNumber(1,1);
            Assert.True(_testVar.Equals(testVar2));
        }
        
        [Fact]
        public void CompareToTest()
        {
            var testVar2 = new ComplexNumber(1,1);
            _testVar = new ComplexNumber(2, 2);
            Assert.Equal(1, _testVar.CompareTo(testVar2));
            
            _testVar = new ComplexNumber(1, 1);
            Assert.Equal(0, _testVar.CompareTo(testVar2));
            
            _testVar = new ComplexNumber();
            Assert.Equal(-1, _testVar.CompareTo(testVar2));
            
            testVar2 = new ComplexNumber();
            Assert.Equal(0, _testVar.CompareTo(testVar2));
        }
        
        
    }
}