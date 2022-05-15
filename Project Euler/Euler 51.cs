using System;

namespace Euler_51
{
    class Program
    {
        static void Main(string[] args)
        {
            int finalprimecount = 0;
            int finalnumber = 0;
            int n = 2;
            int[] p = new int[5000];
            int pindex = 1;
            p[0] = 2;
            for(int i = 3; pindex < 5000; i+=2)
            {
                bool primebool = true;
                for(int j = 3; j <= Math.Sqrt(i); j+=2)
                {
                    if(i % j == 0)
                    {
                        primebool = false;
                        break;
                    }
                }
                if (primebool)
                {
                    p[pindex++] = i;
                }
            }
            while (finalprimecount < 9)
            {
                for (int x = Convert.ToInt32(Math.Pow(10, Convert.ToDouble(n - 1))) + 1; x < Convert.ToInt32(Math.Pow(10, Convert.ToDouble(n))); x+=2)
                {
                    if(Convert.ToString(x).IndexOf("1") > -1 && x % 10 != 5)
                    {
                        int primecount = 0;
                        int ystart = 0;
                        if (Convert.ToString(x) != Convert.ToString(x).TrimStart('1'))
                        {
                            ystart = 1;
                        }
                        for (int y = ystart; y < 10; y++)
                        {
                            int useint = Convert.ToInt32(Convert.ToString(x).Replace("1", Convert.ToString(y)));
                            bool primebool = true;

                            for (int i = 0; p[i] <= Math.Sqrt(useint); i++)
                            {
                                if (useint % p[i] == 0)
                                {
                                    primebool = false;
                                    break;
                                }
                            }
                            if (primebool && useint > 1)
                            {
                                primecount++;
                                if (primecount > finalprimecount)
                                {
                                    finalprimecount = primecount;
                                    finalnumber = x;
                                    Console.WriteLine(finalnumber);
                                }
                            }
                        }
                    }
                }
                n++;
            }
            Console.WriteLine(finalnumber);
        }

    }
}
