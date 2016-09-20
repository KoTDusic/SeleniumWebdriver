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
    class TestMulitply
    {
        [Test]
        public void MulitplyTestZero()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(0, calc.calculate('*', 789656, 0));
        }
        [Test]
        public void MulitplyTestMinusAndPlus()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(-50, calc.calculate('*', -5, 10));
        }
        [Test]
        public void MulitplyTestMinusAndMinus()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(20, calc.calculate('*', -5, -4));
        }
    }
}
