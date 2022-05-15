using System;
using System.Collections.Generic;

namespace Euler_72
{
    class Program
    {
        static void Main(string[] args)
        {
            long fraccount = 0;
            int finald = 1000000;
            for (int n = 1; n < finald; n++)
            {
                fraccount += FindCoprime(n, finald);
            }
            Console.WriteLine(fraccount);
        }
        static int FindCoprime(int x, int max)
        {
            if(x == 1)
            {
                return max - 1;
            }
            int xquotient = (max - x) / x;
            int xremainder = (max - x) % x;

            List<int> divisors = new List<int>();
            for (int d = 2; d <= Math.Sqrt(x); d++)
            {
                if (x % d == 0)
                {
                    divisors.Add(d);
                    if (d != Math.Sqrt(x))
                    {
                        divisors.Add(x / d);
                    }
                }
            }

            if (divisors.Count == 0)
            {
                return xquotient*(x - 1) + xremainder;
            }
            else
            {
                divisors.Sort();
            }
            bool coprimebool = true;
            int coprimecount = 0;
            int coprimecountremainder = 0;

            int usemax;
            if (xquotient > 0)
            {
                usemax = x;
            }
            else
            {
                usemax = xremainder + 1;
            }

            for (int i = 1; i < usemax; i++)
            {
                coprimebool = true;
                for (int d = 0; d < divisors.Count && (divisors[d] <= i/2 || divisors.Contains(i)); d++)
                {
                    if (i % divisors[d] == 0 || divisors.Contains(i))
                    {
                        coprimebool = false;
                        break;
                    }
                }
                if (coprimebool)
                {
                    coprimecount += 1;
                    if (i <= xremainder)
                    {
                        coprimecountremainder += 1;
                    }
                }
            }
            return xquotient*coprimecount + coprimecountremainder;
        }
    }
}
