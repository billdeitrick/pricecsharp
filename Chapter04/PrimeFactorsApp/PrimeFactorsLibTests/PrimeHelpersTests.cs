using PrimeFactorsLib;
using Xunit;

namespace PrimeFactorsLibTests
{
    public class PrimeHelpersTests
    {

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(7, true)]
        [InlineData(8, false)]
        [InlineData(9, false)]
        [InlineData(10, false)]
        public void isPrimeTheory(int n, bool expected)
        {
            Assert.Equal(expected, PrimeHelpers.isPrime(n));
        }

        [Theory]
        [InlineData(2, new int[] { })]
        [InlineData(3, new int[] { 2 })]
        [InlineData(10, new int[] {2, 3, 5, 7})]
        [InlineData(30, new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29})]
        public void getPrimesTheory(int n, int[] expected)
        {
            Assert.Equal(expected, PrimeHelpers.getPrimes(n));
        }

    }

}
