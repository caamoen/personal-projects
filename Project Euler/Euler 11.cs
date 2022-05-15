using System.IO;
using System;

namespace Euler_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] readtext = File.ReadAllLines("C:/Users/camag/C# Projects/C# Files/numbergridEP11.txt");
            int row = readtext.Length;
            int col = readtext[0].Length - readtext[0].Replace(" ", "").Length + 1;
            int[,] numgrid = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                string[] temp = readtext[i].Split(" ");
                for(int j = 0; j < col; j++)
                {
                    numgrid[i, j] = Convert.ToInt32(temp[j]);
                }
            }
            int gridmax = 0;
            int seedrow = 0;
            int seedcol = 0;
            char seeddirection = 'A';
            for (int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    if(i < row - 3)
                    {
                        if (numgrid[i, j] * numgrid[i + 1, j] * numgrid[i + 2, j] * numgrid[i + 3, j] > gridmax)
                        {
                            gridmax = numgrid[i, j] * numgrid[i + 1, j] * numgrid[i + 2, j] * numgrid[i + 3, j];
                            seedrow = i;
                            seedcol = j;
                            seeddirection = 'H';
                        }

                    }
                    if(j < col - 3)
                    {
                        if (numgrid[i, j] * numgrid[i, j + 1] * numgrid[i, j + 2] * numgrid[i, j + 3] > gridmax)
                        {
                            gridmax = numgrid[i, j] * numgrid[i, j + 1] * numgrid[i, j + 2] * numgrid[i, j + 3];
                            seedrow = i;
                            seedcol = j;
                            seeddirection = 'V';
                        }
                    }
                    if (i < row - 3 && j < col - 3)
                    {
                        if (numgrid[i, j] * numgrid[i + 1, j + 1] * numgrid[i + 2, j + 2] * numgrid[i + 3, j + 3] > gridmax)
                        {
                            gridmax = numgrid[i, j] * numgrid[i + 1, j + 1] * numgrid[i + 2, j + 2] * numgrid[i + 3, j + 3];
                            seedrow = i;
                            seedcol = j;
                            seeddirection = 'D';
                        }
                    }
                    if (i < row - 3 && j >= 3)
                    {
                        if (numgrid[i, j] * numgrid[i + 1, j - 1] * numgrid[i + 2, j - 2] * numgrid[i + 3, j - 3] > gridmax)
                        {
                            gridmax = numgrid[i, j] * numgrid[i + 1, j - 1] * numgrid[i + 2, j - 2] * numgrid[i + 3, j - 3];
                            seedrow = i;
                            seedcol = j;
                            seeddirection = 'E';
                        }
                    }
                }
            }
            Console.WriteLine(gridmax);
            Console.WriteLine(seedrow);
            Console.WriteLine(seedcol);
            Console.WriteLine(seeddirection);
        }
    }
}
