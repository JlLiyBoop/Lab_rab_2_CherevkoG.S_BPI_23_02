using System;
using System.Collections.Generic;

namespace Lab_rab_2_CherevkoG.S_BPI_23_02
{
    public static class Calculate
    {
        public static double Calculate1(double a, int f)
        {
            return Math.Sin(f * a);
        }

        public static double Calculate2(double a, double b, int f)
        {
            return Math.Cos(f * a) + Math.Sin(f * b);
        }

        public static double Calculate3(double a, double b, int c, int d)
        {
            return c * Math.Pow(a, 2) + d * Math.Pow(b, 2);
        }

        public static double Calculate4(double a, int c, int d)
        {
            double sum = 0;
            for (int i = 0; i <= d; i++)
            {
                sum += Math.Pow(c + a, i);
            }
            return sum;
        }

        public static double Calculate5(int N, int K, double p, double x, double f, double y)
        {
            double sum = 0.0;
            double ysq = y * y;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    double chisl = Math.Pow(p, i - 1) * x + Math.Pow(f, j - 1) * ysq;
                    double znam = i * j;
                    sum += chisl / znam;
                }
            }
            return sum;
        }

        public static List<int> GetFValues1()
        {
            return new List<int> { 4, 5, 6, 7, 8, 9 };
        }

        public static List<int> GetFValues2()
        {
            return new List<int> { 10, 20, 30, 40 };
        }

        public static List<int> GetCValues3()
        {
            return new List<int> { 0, 1 };
        }

        public static List<int> GetDValues3()
        {
            return new List<int> { -1, 0, 1 };
        }

        public static List<int> GetCValues4()
        {
            return new List<int> { 0, 1, 2, 3, 4, 5 };
        }

        public static List<int> GetNKValues()
        {
            return new List<int> { 1, 2, 3, 4, 5, 10, 15, 20 };
        }

        public static List<double> GetOtherValues()
        {
            return new List<double> { 0.1, 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 5.0, 10.0 };
        }
    }
}