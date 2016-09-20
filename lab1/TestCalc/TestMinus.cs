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
    class TestMinus
    {
        [Test]
        public void MinusTestNegativeAndNull()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(-3, calc.calculate('-', -3, 0));
        }
        [Test]
        public void MinusTestFloat()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(1, calc.calculate('-', 3.22, 2.22));
        }
        [Test]
        public void MinusTestBigNumbers()
        {
            Calculator calc = new Calculator();
            Assert.AreEqual(9767688, calc.calculate('-', 9999999, 232311));
        }
    }
}
