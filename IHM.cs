using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample
{
    internal class IHM
    {
        public static double[,] LinearRegression(double[,] matX, double[,] matY)
        {
            var result = MatrixManager.MatrixProduct(MatrixManager.TransposeMatrix(matX), matX);
            Debug.WriteLine("==========MAT TRANSPOSER==========");
            Debug.WriteLine(MatrixManager.MatrixAsString(result));

            result = MatrixManager.inverseMatrix(result);
            Debug.WriteLine("==========MAT INVERSE==========");
            Debug.WriteLine(MatrixManager.MatrixAsString(result));

            var mt = MatrixManager.MatrixProduct(MatrixManager.TransposeMatrix(matX), matY);
            Debug.WriteLine("==========MAT TRANSPOSE * MAT_Y==========");
            Debug.WriteLine(MatrixManager.MatrixAsString(mt));
            Debug.WriteLine("==========MAT==========");
            Debug.WriteLine(MatrixManager.MatrixAsString(MatrixManager.MatrixProduct(result, mt)));
            return MatrixManager.MatrixProduct(result, mt);
        }
    }
}
