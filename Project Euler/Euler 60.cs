using System;

namespace Euler_60
{
    class Program
    {
        static void Main(string[] args)
        {
            int three = 3;
            int[] modone = new int[600];
            int modonecount = 0;
            int[] modtwo = new int[600];
            int modtwocount = 0;
            int[] primenum = new int[3500];
            int primecount = 0;
            int i = 7;
            bool primebool;
            while (modonecount < 600 || modtwocount < 600 || primecount < 3500)
            {
                primebool = true;
                for (int d = 3; d <= Math.Sqrt(i); d += 2)
                {
                    if(i % d == 0)
                    {
                        primebool = false;
                        break;
                    }
                }
                if (primebool)
                {
                    if(i % 3 == 1 && modonecount < 600)
                    {
                        modone[modonecount++] = i;
                    }
                    else if(modtwocount < 600)
                    {
                        modtwo[modtwocount++] = i;
                    }
                    if(primecount < 3500)
                    {
                        primenum[primecount++] = i;
                    }
                }
                i += 2;
            }
            long newNumber1;
            long newNumber2;
            for(int f = 0; f < 600 - 4; f++)
            {
                for (int a = f + 1; a < 600 - 3; a++)
                {
                    primebool = true;
                    newNumber1 = Convert.ToInt64(modone[f].ToString() + modone[a].ToString());
                    newNumber2 = Convert.ToInt64(modone[a].ToString() + modone[f].ToString());
                    for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                    {
                        if (newNumber1 % primenum[d] == 0)
                        {
                            primebool = false;
                            break;
                        }
                    }
                    if (!primebool) continue;
                    for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                    {
                        if (newNumber2 % primenum[d] == 0)
                        {
                            primebool = false;
                            break;
                        }
                    }
                    if (!primebool) continue;
                    for (int b = a + 1; b < 600 - 2; b++)
                    {
                        primebool = true;
                        newNumber1 = Convert.ToInt64(modone[f].ToString() + modone[b].ToString());
                        newNumber2 = Convert.ToInt64(modone[b].ToString() + modone[f].ToString());
                        for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                        {
                            if (newNumber1 % primenum[d] == 0)
                            {
                                primebool = false;
                                break;
                            }
                        }
                        if (!primebool) continue;
                        for(int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                            {
                            if (newNumber2 % primenum[d] == 0)
                            {
                                primebool = false;
                                break;
                            }
                        }
                        if (!primebool) continue;
                        newNumber1 = Convert.ToInt64(modone[a].ToString() + modone[b].ToString());
                        newNumber2 = Convert.ToInt64(modone[b].ToString() + modone[a].ToString());
                        for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                        {
                            if (newNumber1 % primenum[d] == 0)
                            {
                                primebool = false;
                                break;
                            }
                        }
                        if (!primebool) continue;
                        for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                        {
                            if (newNumber2 % primenum[d] == 0)
                            {
                                primebool = false;
                                break;
                            }
                        }
                        if (!primebool) continue;
                        for (int c = b + 1; c < 600 - 1; c++)
                        {
                            primebool = true;
                            newNumber1 = Convert.ToInt64(modone[f].ToString() + modone[c].ToString());
                            newNumber2 = Convert.ToInt64(modone[c].ToString() + modone[f].ToString());
                            for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                            {
                                if (newNumber1 % primenum[d] == 0)
                                {
                                    primebool = false;
                                    break;
                                }
                            }
                            if (!primebool) continue;
                            for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                            {
                                if (newNumber2 % primenum[d] == 0)
                                {
                                    primebool = false;
                                    break;
                                }
                            }
                            if (!primebool) continue;
                            newNumber1 = Convert.ToInt64(modone[a].ToString() + modone[c].ToString());
                            newNumber2 = Convert.ToInt64(modone[c].ToString() + modone[a].ToString());
                            for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                            {
                                if (newNumber1 % primenum[d] == 0)
                                {
                                    primebool = false;
                                    break;
                                }
                            }
                            if (!primebool) continue;
                            for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                            {
                                if (newNumber2 % primenum[d] == 0)
                                {
                                    primebool = false;
                                    break;
                                }
                            }
                            if (!primebool) continue;

                            newNumber1 = Convert.ToInt64(modone[b].ToString() + modone[c].ToString());
                            newNumber2 = Convert.ToInt64(modone[c].ToString() + modone[b].ToString());
                            for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                            {
                                if (newNumber1 % primenum[d] == 0)
                                {
                                    primebool = false;
                                    break;
                                }
                            }
                            if (!primebool) continue;
                            for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                            {
                                if (newNumber2 % primenum[d] == 0)
                                {
                                    primebool = false;
                                    break;
                                }
                            }
                            if (!primebool) continue;
                            for (int e = c + 1; e < 600; e++)
                            {
                                primebool = true;
                                newNumber1 = Convert.ToInt64(modone[f].ToString() + modone[e].ToString());
                                newNumber2 = Convert.ToInt64(modone[e].ToString() + modone[f].ToString());
                                for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                                {
                                    if (newNumber1 % primenum[d] == 0)
                                    {
                                        primebool = false;
                                        break;
                                    }
                                }
                                if (!primebool) continue;
                                for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                                {
                                    if (newNumber2 % primenum[d] == 0)
                                    {
                                        primebool = false;
                                        break;
                                    }
                                }
                                if (!primebool) continue;
                                newNumber1 = Convert.ToInt64(modone[a].ToString() + modone[e].ToString());
                                newNumber2 = Convert.ToInt64(modone[e].ToString() + modone[a].ToString());
                                for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                                {
                                    if (newNumber1 % primenum[d] == 0)
                                    {
                                        primebool = false;
                                        break;
                                    }
                                }
                                if (!primebool) continue;
                                for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                                {
                                    if (newNumber2 % primenum[d] == 0)
                                    {
                                        primebool = false;
                                        break;
                                    }
                                }
                                if (!primebool) continue;

                                newNumber1 = Convert.ToInt64(modone[b].ToString() + modone[e].ToString());
                                newNumber2 = Convert.ToInt64(modone[e].ToString() + modone[b].ToString());
                                for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                                {
                                    if (newNumber1 % primenum[d] == 0)
                                    {
                                        primebool = false;
                                        break;
                                    }
                                }
                                if (!primebool) continue;
                                for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                                {
                                    if (newNumber2 % primenum[d] == 0)
                                    {
                                        primebool = false;
                                        break;
                                    }
                                }
                                if (!primebool) continue;
                                newNumber1 = Convert.ToInt64(modone[c].ToString() + modone[e].ToString());
                                newNumber2 = Convert.ToInt64(modone[e].ToString() + modone[c].ToString());
                                for (int d = 0; primenum[d] <= Math.Sqrt(newNumber1); d++)
                                {
                                    if (newNumber1 % primenum[d] == 0)
                                    {
                                        primebool = false;
                                        break;
                                    }
                                }
                                if (!primebool) continue;
                                for (int d = 0; primenum[d] <= Math.Sqrt(newNumber2); d++)
                                {
                                    if (newNumber2 % primenum[d] == 0)
                                    {
                                        primebool = false;
                                        break;
                                    }
                                }
                                if (primebool)
                                {
                                    Console.Write(modone[a] + " " + modone[b] + " " + modone[c] + " " + modone[e] + " " + modone[f] + " = ");
                                    Console.WriteLine(modone[a] + modone[b] + modone[c] + modone[e] + modone[f]);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
