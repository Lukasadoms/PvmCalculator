using System;
using Xunit;

namespace PvmCalculator.UnitTests
{
    public class TestOne
    {
        public double CalculateWithPvm(double sum, double pvm)
        {
            public static double sumWithPvm = sum + sum * pvm / 100;
        }

    }
    
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            double expected = 2240;

            double actual = TestOne.CalculateWithPvm(2000, 12);

            Assert.Equal(expected, actual);

        }
    }
}
