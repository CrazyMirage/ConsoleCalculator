using NUnit.Framework;
using ConsoleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Tests
{
    [TestFixture()]
    public class CalculatorTests
    {
        [Test()]
        public void CalculateTest()
        {
            double expected = 5;
            string income = "2 + 3";

            var result = Calculator.Calculate(income);
            Assert.AreEqual(expected, result, double.Epsilon);
        }

        [Test()]
        public void CalculateTestDivision()
        {
            double expected = (2.0/3.0);
            string income = "2 / 3";

            var result = Calculator.Calculate(income);
            Assert.AreEqual(expected, result, double.Epsilon);
        }

        [Test()]
        public void CalculateTestMultypli()
        {
            double expected = 2 * 3;
            string income = "2 * 3";

            var result = Calculator.Calculate(income);
            Assert.AreEqual(expected, result, double.Epsilon);
        }

        [Test()]
        public void CalculateTestWrongSign()
        {
            string income = "2 % 3";
            
            Assert.Throws(typeof(Exception), () => Calculator.Calculate(income));
        }


        [Test()]
        public void CalculateTestWrongQuery()
        {
            string income = "4+2 - 3";

            Assert.Throws(typeof(Exception), () => Calculator.Calculate(income));
        }

    }
}