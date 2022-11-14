using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample
{
    internal static class ErrorCalculation
    {
        public static List<double[,]> data = DataExtractor.input(DataExtractor.ExtractDatas("C:/Users/DELL/source/repos/WpfSample/rfm_customers.xlsx"));
        static List<double> error = new List<double>();
        public static Double[,] x = IHM.LinearRegression(data[0], data[1]);
        
        public static double CalculateYAtPoint(double a1, double a2)
        {
            return a1 * x[0, 0] + a2 * x[1, 0] + x[2, 0];
        }

        public static List<double> YEval()
        {
            List<double> res = new List<double>();
            for (int i = 0; i < 2000; i++)
            {
                // Debug.WriteLine(;
                res.Add(CalculateYAtPoint(data[0][i, 0], data[0][i, 1]));
            }
            return res;
        }
        public static double CalculateError(double a1, double a2, double y)
        {
            return CalculateYAtPoint(a1, a2) - y;
        }

        public static List<double> Errors()
        {
            for(int i=0; i < 2000; i++)
            {
               // Debug.WriteLine(;
                error.Add(CalculateError(data[0][i, 0], data[0][i, 1], data[1][i, 0]));
            }
            return error;
        }
    }
}
