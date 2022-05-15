using System;

namespace Euler_27
{
    class Program
    {
        static void Main(string[] args)
        {
            int primemax = 0;
            int primeproduct = 0;
            for(int a = -999; a <= 999; a += 2)
            {
                for (int b = -999; b <= 999; b += 2)
                {
                    int n = 0;
                    int primecounter = 0;
                    bool primebool = true;
                    while (primebool)
                    {
                        int result = Math.Abs(Convert.ToInt32(Math.Pow(Convert.ToDouble(n),2) + a*n + b));
                        for (int i = 2; i <= Math.Sqrt(result); i++)
                        {
                            if (result % i == 0)
                            {
                                primebool = false;
                            }
                        }
                        if (primebool)
                        {
                            n++;
                            primecounter++;
                            if(primecounter > primemax)
                            {
                                primemax = primecounter;
                                primeproduct = a * b;
                            }

                        }
                    }
                }
            }
            Console.WriteLine(primeproduct);
        }
    }
}
