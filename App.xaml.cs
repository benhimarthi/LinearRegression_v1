using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace WpfSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ///Unit test
            double[,] mat1 = new double[10, 1];
            double[,] mat2 = new double[1, 10];
            
            for (int n = 0; n < mat1.GetLength(0); n++)
                for (int m = 0; m < mat1.GetLength(1); m++)
                {
                    mat1[n, m] = new Random().NextDouble();
                    //Debug.WriteLine(mat1[n, m]);
                }

            for (int n = 0; n < mat2.GetLength(0); n++)
                for (int m = 0; m < mat2.GetLength(1); m++)
                    mat2[n, m] = new Random().NextDouble();
            double[,] mat3 = { { 1, 1 }, {  2, 1 }, { 3, 1 }, { 4, 1} };
            double[,] res = { { 85}, { 90 }, { 10 }, {135 } };

            //Debug.WriteLine(MatrixManager.MatrixAsString(mat2));
            //Debug.WriteLine(MatrixManager.MatrixAsString(MatrixManager.inverseMatrix(MatrixManager.MatrixProduct(mat1, mat2))));
            //Debug.WriteLine(MatrixManager.det);
            //Debug.WriteLine(MatrixManager.MatrixAsString(MatrixManager.MinorMatrix_F(MatrixManager.MatrixProduct(mat1, mat2), 3, 2)));
            //Debug.WriteLine(MatrixManager.MatrixAsString(MatrixManager.MatrixProduct(mat1, mat2)));
            //---------------------------------------------------------------------

            var data = DataExtractor.input(DataExtractor.ExtractDatas("C:/Users/DELL/source/repos/WpfSample/rfm_customers.xlsx"));
            //var prod1 = 1/
            //Debug.WriteLine(MatrixManager.MatrixAsString(MatrixManager.inverseMatrix(MatrixManager.MatrixProduct(MatrixManager.TransposeMatrix(mat3), mat3))));

            /*double[,] C = {{1, 2, 3}, {0, 1, 2}, {0, 4, 6} };
            double[,] D = {{ 1, 2, 3}, { 0, 1, 1}, { 0, 2, 3} };
            double[,] A = { { 2, -3}, { 1, -1}};

            var A1 = MatrixManager.inverseMatrix(MatrixManager.MatrixProduct(MatrixManager.TransposeMatrix(data[0]), data[0]));
            var A2 = MatrixManager.MatrixProduct(MatrixManager.TransposeMatrix(data[0]), data[1]);
            var A3 = MatrixManager.MatrixProduct(A1, A2);*/
            //Debug.WriteLine(MatrixManager.MatrixAsString(IHM.LinearRegression(data[0], data[1])));

            //Debug.WriteLine(MatrixManager.MatrixAsString(MatrixManager.MatrixProduct((mat3), res)));
            /*var mt1 = MatrixManager.MatrixProduct(MatrixManager.TransposeMatrix(mat3), mat3);
            var invmt1 = MatrixManager.inverseMatrix(mt1);*/
            //var model = MatrixManager.AddColunm(data[0], data[1], 0);
            //model = MatrixManager.AddColunm(model, MatrixManager.ConvertArrayToMatrix(ErrorCalculation.Errors()), 1);

            //Debug.WriteLine(MatrixManager.MatrixAsString(model));
            //Debug.WriteLine(ErrorCalculation.Errors());
        }
    }
}
