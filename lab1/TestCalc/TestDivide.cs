using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1;
using NUnit.Framework;

namespace TestCalc
{
    [TestFixture]
    class TestDivide
    {
        [Test]
        public void DivideTestPositiveAndZero()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(Double.PositiveInfinity, calc.calculate('/', 10, 0));
        }
        [Test]
        public void DivideTestNegativeAndZero()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(Double.NegativeInfinity, calc.calculate('/', -10, 0));
        }
        [Test]
        public void DivideTestNegativeAndNegative()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(7, calc.calculate('/', -35, -5));
        }
    }
}
