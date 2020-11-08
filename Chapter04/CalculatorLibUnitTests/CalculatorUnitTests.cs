using CalculatorLib;
using System;
using Xunit;

namespace CalculatorLibUnitTests
{
    public class CalculatorUnitTests
    {
        [Fact]
        public void TestAdding2And2()
        {
            double a = 2;
            double b = 2;
            double expected = 4;

            var calculator = new Calculator();

            double actual = calculator.Add(2, 2);

            Assert.Equal(expected, actual);

        }

        [Fact]
        public void TestAdding2And3()
        {
            double a = 2;
            double b = 3;
            double expected = 5;

            var calc = new Calculator();
            double actual = calc.Add(a, b);

            Assert.Equal(expected, actual);
        }

    }
}
