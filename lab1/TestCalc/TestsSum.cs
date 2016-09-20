using lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestCalc
{
    [TestFixture]
    public class TestsSum
    {
        [Test]
        public void SumTestPositive()
        {
            Calculator calc=new Calculator();
            Assert.AreEqual(15, calc.calculate('+',10,5));
        }
        [Test]
        public void SumTestNegative()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(9, calc.calculate('+', 14, -5));
        }
        [Test]
        public void SumTestNegativeAndNull()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(-5, calc.calculate('+', 0, -5));
        }
    }
}
