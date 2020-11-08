using System.Collections.Generic;
using static PrimeFactorsLib.PrimeHelpers;

namespace PrimeFactorsLib
{
    public class PrimeFactors
    {

        private int[] _factors;

        /// <summary>
        /// Class for calculating the prime factors of a number. Pre-seeds a list of primes
        /// based on the maximum number you expect you might want to factor.
        /// </summary>
        /// <param name="maxFactor">The maximum number you might wich to factor, defaults to 1000.</param>
        public PrimeFactors(int maxFactor = 1000)
        {

            _factors = getPrimes(maxFactor / 2);

        }

        /// <summary>
        /// Get the prime factors for the specified number.
        /// </summary>
        /// <param name="n">The number for which prime factors should be calculated.</param>
        /// <returns>An integer array of the prime factors for the supplied number.</returns>
        public int[] getFactors(int n)
        {
            var nFactors = new List<int>();

            var cur = n;

            while (!isPrime(cur)) 
            {
                foreach(int factor in factors)
                {
                    if (cur % factor == 0)
                    {
                        nFactors.Add(factor);
                        cur = cur / factor;
                        break;
                    }
                }
            }

            nFactors.Add(cur);

            return nFactors.ToArray();

        }

        /// <summary>
        /// Prime factors < the "maxPrime" with which this class was initialized.
        /// </summary>
        public int[] factors { get => _factors; }

    }
}
