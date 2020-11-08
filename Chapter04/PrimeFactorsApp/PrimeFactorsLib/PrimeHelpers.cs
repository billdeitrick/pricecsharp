using System.Collections.Generic;

namespace PrimeFactorsLib
{
    public class PrimeHelpers
    {

        /// <summary>
        /// Checks a number for primeness.
        /// </summary>
        /// <param name="n">Number to check for primeness.</param>
        /// <returns>True if the number is prime, False if it is not.</returns>
        public static bool isPrime(int n)
        {
            
            for (int i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;

        }

        /// <summary>
        /// Returns all prime numbers up to (but not including) the specified number. Be careful with large numbers.
        /// </summary>
        /// <param name="n">The number up to which all primes should be returned.</param>
        /// <returns>Integer array of prime numbers up to (but not including) n.</returns>
        public static int[] getPrimes(int n)
        {

            var numList = new List<int>();

            if ( n > 2) { numList.Add(2); }
            
            for(int i = 3; i < n; i += 2)
            {
                if (isPrime(i)) { numList.Add(i); }
            }

            return numList.ToArray();

        }
    }
}
