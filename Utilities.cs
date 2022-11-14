using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample
{
    internal static class Utilities
    {
        public static double TotalSumSquare(double[,] y, double Ymeans)
        {
            double sum = 0;
            for(int i = 0; i < y.GetLength(0); i++)
            {
                sum += Math.Pow(y[i, 0] - Ymeans, 2);
            }
            return sum;
        }

        public static double TotalSumResidual(double[,] y, double[,] Yevaluate)
        {
            double sum = 0;
            for (int i = 0; i < y.GetLength(0); i++)
            {
                sum += Math.Pow(Yevaluate[i, 0] - y[i, 0], 2);
            }
            return sum;
        }
        //TotalSumExplain
        public static double TotalSumExplain(double[,] Yevaluate, double Ymeans)
        {
            double sum = 0;
            for(int i = 0; i < Yevaluate.GetLength(0); i++)
            {
                sum += Yevaluate[i, 0] - Ymeans;
            }
            return sum;
        }
        public static double TabMeans(double[,] tab)
        {
            double sum = 0;
            for(int i = 0; i < tab.GetLength(0); i++)
            {
                sum += tab[i,0];
            }
            return sum / tab.GetLength(0);
        }
        public static int[] DDL(int n, int p)
        {
            return new int[3] { n - p - 1, p, n - 1 };
        }
        public static double Fisher(double SCE, double SCR, int ddl1, int ddl0)
        {
            double CME = SCE / ddl0;
            double CMR = SCR / ddl1;
            return CME / CMR;
        }
        public static double CM(double SCx, double dll)
        {
            return SCx / dll;
        }

        public static double[,] ANOVA(double[,] y, double[,] Yevaluate, double Ymeans,int n, int p)
        {
            var ddl = DDL(n, p);
            var SCR = TotalSumResidual(y, Yevaluate);
            var SCE = TotalSumExplain(Yevaluate, Ymeans);
            var SCT = TotalSumSquare(y, Ymeans);
            return new double[3, 4]
            {
                { SCR, ddl[0], CM(SCR, ddl[0]), Fisher(SCE, SCR, ddl[1], ddl[0])},
                { SCE, ddl[1], CM(SCE, ddl[1]), 0},
                { SCT, ddl[2], CM(SCT, ddl[2]), 0}
            };
        }

        public static double[,] CovarianceTable(double[,] tab, double Xaverage, double Yaverage)
        {
            var result = new double[tab.GetLength(0), tab.GetLength(0)];
            var tabTransposed = MatrixManager.TransposeMatrix(tab);
            for(int i = 0; i < tab.GetLength(0); i++)
            {
                for(int j = 0; j < tab.GetLength(0); j++)
                {
                    result[i, j] = CovariancePoint(tab[i, 0], tabTransposed[0, j], Xaverage, Yaverage);
                }
            }
            return result;
        }

        public static double CovariancePoint(double x, double y, double averageX, double averageY)
        {
            return (x-averageX)*(y-averageY);
        }
        public static double Covariance(double[,] x, double[,] y)
        {
            var mX = TabMeans(x);
            var mY = TabMeans(y);
            double sum = 0;
            for(var i=0; i < x.GetLength(0); i++)
            {
                sum += (x[i, 0] - mX) * (y[i,0] -mY);
            }
            return sum / x.GetLength(0);
        }

        public static double Variance(double[,] x, int ind)
        {
            double sum = 0;
            double Xmeans = TabMeans(MatrixManager.extractLineOrColumn(ind, x));
            for (int i = 0; i < x.GetLength(0); i++)
            {
                sum += Math.Pow(x[i, ind] - Xmeans, 2);
            }
            Debug.WriteLine(sum / x.GetLength(0));
            return sum/x.GetLength(0);
        }

        public static double EcartType(double[,] x, int ind)
        {
            return Math.Sqrt(Variance(x, ind));
        }

    }
}
