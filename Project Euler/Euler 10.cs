using System;

namespace Euler_10
{
    class Program
    {
        static void Main(string[] args)
        {
            long primesum = 2;
            for (int i = 3; i < 2000000; i += 2)
            {
                bool primebool = true;
                for (int j = 3; j <= Math.Sqrt(i); j += 2)
                {
                    if (i % j == 0)
                    {
                        primebool = false;
                        break;
                    }
                }
                if (primebool)
                {
                    primesum += i;
                }
            }
            Console.WriteLine(primesum);
        }
    }
}
