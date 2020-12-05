using System;
using Xunit;
using PvmCalculator;

namespace XUnitTestProject1
{
    public class TestOne
    {
        public static int Add(int a, int b) => a + b;
    }
    public class TestOneTests
    {
        [Fact]
        public void Add_AddsTwoNumbersTogether()
        {
            var result = TestOne.Add(1, 1);
            Assert.Equal(2, result);
            Calcul
        }

        
    }
}
