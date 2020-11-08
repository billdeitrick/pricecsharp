using PrimeFactorsLib;
using Xunit;

namespace PrimeFactorsLibTests
{
    public class PrimeFactorsTests
    {

        PrimeFactors factors;

        public PrimeFactorsTests()
        {
            factors = new PrimeFactors();
        }

        [Fact]
        public void primeFactorsGeneratesCorrectLength()
        {
            Assert.Equal(95, factors.factors.Length);
        }

        [Fact]
        public void primeFactorsContainSomeExpectedValues()
        {
            Assert.Contains(499, factors.factors);
            Assert.Contains(419, factors.factors);
            Assert.Contains(2, factors.factors);
        }

        [Theory]
        [InlineData(4, new int[] { 2, 2 })]
        [InlineData(7, new int[] { 7 })]
        [InlineData(10, new int[] { 2, 5 })]
        [InlineData(25, new int[] { 5, 5 })]
        [InlineData(30, new int[] { 2, 3, 5 })]
        [InlineData(40, new int[] { 2, 2, 2, 5 })]
        [InlineData(50, new int[] { 2, 5, 5 })]
        public void getPrimeFactorsTheory(int n, int[] expected)
        {
            Assert.Equal(expected, factors.getFactors(n));
        }
    }
}
