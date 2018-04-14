using System;
using Xunit;
using ArithmeticOperation;

namespace ArithmeticOperationTests
{
    public class RealNumberTest
    {
        private RealNumber _testVar = new RealNumber();
        private readonly RealNumber _testVarEmpty;

        [Fact]
        public void MainTest()
        {
            Assert.Null(_testVarEmpty);

            Assert.NotNull(_testVar.Real);
            Assert.Equal(0, _testVar.Real);
            Assert.NotEqual(2, _testVar.Real);

            _testVar = new RealNumber(1);
            Assert.Equal(1, _testVar.Real);
            Assert.NotEqual(2, _testVar.Real);
        }

        [Fact]
        public void ToStringTest()
        {
            Assert.Equal("0", _testVar.ToString());

            _testVar = new RealNumber(1);
            Assert.Equal("1", _testVar.ToString());
            Assert.NotEqual("0", _testVar.ToString());
            Assert.NotEqual("1)", _testVar.ToString());
        }
        
        [Fact]
        public void EqualsTest()
        {
            var testVar2 = new RealNumber(1);
            _testVar = new RealNumber(2);
            Assert.False(_testVar.Equals(testVar2));
            
            _testVar = new RealNumber(1);
            Assert.True(_testVar.Equals(testVar2));
        }
        
        [Fact]
        public void CompareToTest()
        {
            var testVar2 = new RealNumber(1);
            _testVar = new RealNumber(2);
            Assert.Equal(1, _testVar.CompareTo(testVar2));
            
            _testVar = new RealNumber(1);
            Assert.Equal(0, _testVar.CompareTo(testVar2));
            
            _testVar = new RealNumber();
            Assert.Equal(-1, _testVar.CompareTo(testVar2));
            
            testVar2 = new RealNumber();
            Assert.Equal(0, _testVar.CompareTo(testVar2));
        }
        
        [Fact]
        public void GetRealTest()
        {
            _testVar = _testVar.getReal(1);
            Assert.Equal(1, _testVar.Real);
        }
        
        [Fact]
        public void AddTest()
        {
            var testVar2 = new RealNumber(2);
            _testVar = new RealNumber(1);

            _testVar = _testVar.Add(testVar2);
            Assert.Equal(3, _testVar.Real);
        }
        
        [Fact]
        public void SubstractTest()
        {
            var testVar2 = new RealNumber(1);
            _testVar = new RealNumber(3);

            _testVar = _testVar.Subtract(testVar2);
            Assert.Equal(2, _testVar.Real);
        }
        
        [Fact]
        public void MultiplyTest()
        {
            var testVar2 = new RealNumber(1);
            _testVar = new RealNumber(2);
            
            _testVar = _testVar.Multiply(testVar2);
            Assert.Equal(2, _testVar.Real);
        }

        [Fact]
        public void DivideTest()
        {
            var testVar2 = new RealNumber(1);
            _testVar = new RealNumber(2);
            
            _testVar = _testVar.Divide(testVar2);
            Assert.Equal(2, _testVar.Real);
            
            testVar2 = new RealNumber(0);
            Assert.Throws<ArgumentException>(()=>_testVar.Divide(testVar2));
        }
    }
}