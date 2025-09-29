using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_CherevkoG.S_BPI_23_02
{
    public static class Calculate
    {
        public static double CalcZ(int N, int K, double p, double x, double f, double y)
        {
            double sum = 0.0;
            double ysq = y * y;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {
                    double chisl = System.Math.Pow(p, i - 1) * x + System.Math.Pow(f, j - 1) * ysq;
                    double znam = i * j;
                    sum += chisl / znam;
                }
            }
            return sum;
        }

        public static List<int> GetNValues()
        {
            return new List<int> { 1, 2, 3, 4, 5, 10, 15, 20 };
        }

        public static List<int> GetKValues()
        {
            return new List<int> { 1, 2, 3, 4, 5, 10, 15, 20 };
        }

        public static List<double> GetOtherValues()
        {
            return new List<double> { 0.1, 0.5, 1.0, 1.5, 2.0, 2.5, 3.0, 5.0, 10.0 };
        }
    }
}
