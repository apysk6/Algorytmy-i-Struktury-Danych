using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class LCS
    {

        static String series = "";
        static char[,] b;

        static void Main(string[] args)
        {
            Console.WriteLine("Podaj pierwszy ciąg znaków.");
            String x = Console.ReadLine();

            Console.WriteLine("Podaj drugi ciąg znaków.");
            String y = Console.ReadLine();

            int m = x.Length;
            int n = y.Length;


            int length = lcsLength(x, y);

            Console.WriteLine("Najdłuższy ciąg: " + lcsPrint(x, y, b, m, n));
            Console.ReadLine();
        }

        public static int lcsLength(String x, String y)
        {
            int m = x.Length;
            int n = y.Length;

            int[,] c = new int[m + 1, n + 1];
            b = new char[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                c[i, 0] = 0;
            }

            for (int i = 0; i <= n; i++)
            {
                c[0, i] = 0;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (x[i - 1] == y[j - 1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                        b[i, j] = '/';
                    }
                    else if (c[i - 1, j] >= c[i, j - 1])
                    {
                        c[i, j] = c[i - 1, j];
                        b[i, j] = '|';
                    }
                    else
                    {
                        c[i, j] = c[i, j - 1];
                        b[i, j] = '-';
                    }
                }
            }

            return c[m, n];
        }

        public static String lcsPrint(String x, String y, char[,] b, int m, int n)
        {
            if (m == 0 || n == 0)
            {
            }
            else
            {
                if (b[m, n].Equals('/'))
                {
                    lcsPrint(x, y, b, m - 1, n - 1);
                    series = series + x[m - 1];
                }
                else if (b[m, n] == '|')
                {
                    lcsPrint(x, y, b, m - 1, n);
                }
                else
                {
                    lcsPrint(x, y, b, m, n - 1);
                }
            }
            return series;
        }
    }
}
