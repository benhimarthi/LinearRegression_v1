using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample
{
    internal static class MatrixManager
    {
        public static double[,] MatrixCreate(int rows, int cols)
        {
            double[,] result = new double[rows, cols];
            return result;
        }

        public static double[,] MatrixProduct(double[,] matrixA, double[,] matrixB)
        {
            int aRows = matrixA.GetLength(0);
            int aCols = matrixA.GetLength(1);
            int bRows = matrixB.GetLength(0);
            int bCols = matrixB.GetLength(1);
            if (aCols != bRows)throw new Exception("Non-conformable matrices");
            double[,] result = MatrixCreate(aRows, bCols);
            for (int i = 0; i < aRows; ++i)
                for (int j = 0; j < bCols; ++j)
                    for (int k = 0; k < aCols; ++k)
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
            return result;
        }

        public static double[,] TransposeMatrix(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);

            var result = new double[columns, rows];

            for (var c = 0; c < columns; c++)
            {
                for (var r = 0; r < rows; r++)
                {
                    result[c, r] = matrix[r, c];
                }
            }

            return result;
        }

        public static string MatrixAsString(double[,] matrix)
        {
            string s = "";
            for (int i = 0; i < matrix.GetLength(0); ++i)
            {
                for (int j = 0; j < matrix.GetLength(1); ++j)
                    s += matrix[i, j].ToString("F3").PadLeft(8) + " ";
                s += Environment.NewLine;
            }
            return s;
        }

        /*public static double[,] minorMatrix(double[,] majorMatrix)
        {

        }*/

        public static double[,] MinorMatrix(double[,] matrix, int row, int col)
        {
            var mtc = new double[matrix.GetLength(0)-1, matrix.GetLength(0) - 1];
            
            for (int n = 0; n < matrix.GetLength(0); n++)
            {
                if (row != n)
                {
                    for (int m = 0; m < matrix.GetLength(1); ++m)
                    {
                        //Debug.WriteLine(m);
                        if (col != m)mtc[row > n ? n : n-1, col > m ? m : m-1] = matrix[n, m];
                    }
                }
            }

            //MatrixManager.MatrixAsString(mtc);
            return mtc;
        }
        public static double det = 0;
        static int sign = 1;
        public static double[,] MinorMatrix_F(double[,] matrix, int row, int col)
        {
            var matrixRes = matrix;
            int r = row;
            int c = col;
            double currentVal = 1;

            if(matrixRes.Length > 4)
            {
                do
                {
                    if (row == 0)
                    {
                        currentVal *= matrixRes[r, c];
                    }
                    matrixRes = MinorMatrix(matrixRes, r, c);
                    if (c == matrixRes.GetLength(1) && matrixRes.GetLength(1) >= 1) c--;
                    if (r == matrixRes.GetLength(0) && matrixRes.GetLength(0) >= 1) r--;
                } while (matrixRes.Length != 4);
            }
            else
            {
                det = DeterminantValue(matrixRes);
                return matrixRes;
            }
            if (row==0)
            {
                currentVal *= DeterminantValue(matrixRes) * sign;
                det += currentVal;
                //Debug.WriteLine(DeterminantValue(matrixRes) * sign);
                sign *= -1;
            }

            return matrixRes;
        }

        private static double DeterminantValue(double[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
        }

        public static double[,] GenerateMinorMatrix(double[,] matrix)
        {
            var matRes = new double[matrix.GetLength(0), matrix.GetLength(0)];
            for(int n = 0; n < matrix.GetLength(0); n++)
            {
                for(int m=0; m < matrix.GetLength(1); m++)
                {
                    matRes[n, m] = DeterminantValue(MinorMatrix_F(matrix, n, m));
                }
            }
            return matRes;
        }

        private static double[,] signMatrice(int r, int c)
        {
            int cs = 1;
            var sMat = new double[r, c]; 
            for(int i=0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    sMat[i, j] = cs;
                    cs *= -1;
                }
            }
            return sMat;
        }
        private static void Comatrice(double[,] matS, ref double[,] mat)
        {
            for(var i=0; i < matS.GetLength(0); i++)
            {
                for (var j=0; j < matS.GetLength(1); j++)
                {
                    mat[i, j] *= matS[i, j];
                }
            }
        }

        public static double[,] inverseMatrix(double[,] matrix)
        {
            if(matrix.Length > 4)
            {
                var res = GenerateMinorMatrix(matrix);
                //Debug.WriteLine(MatrixAsString(res));
                Comatrice(signMatrice(matrix.GetLength(0), matrix.GetLength(0)), ref res);

                res = TransposeMatrix(res);
                if (det == 0) throw new Exception("This matrixe doesn't have an inverse");
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        res[i, j] = res[i, j] * 1 / det;
                    }
                return res;
            }
            else
            {
                det = DeterminantValue(matrix);
                double[,] res = new double[2, 2];
                var Tmat = matrix;
                Comatrice(signMatrice(matrix.GetLength(0), matrix.GetLength(0)), ref Tmat);
                Debug.WriteLine(MatrixAsString(Tmat));
                Tmat = TransposeMatrix(Tmat);
                //Debug.WriteLine(MatrixAsString(Tmat));
                if (det == 0) throw new Exception("This matrixe doesn't have an inverse");
                for (var n = 0; n < matrix.GetLength(0); n++)
                    for(int i = 0; i < matrix.GetLength(1); i++)
                        res[n, i] = 1/det * Tmat[n, i];
                return res;
            }
        }
        public static double[,] ConvertArrayToMatrix(List<double> lst)
        {
            var res = new double[lst.Count, 1];
            for(int i = 0; i < lst.Count; i++)
            {
                res[i, 0] = lst[i];
            }
            return res;
        }
        public static double[,] extractLineOrColumn(int ind, double[,] mat, string c = "C")
        {
            if (c == "C")
            {
                double[,] res = new double[mat.GetLength(0), 1];
                for(int i = 0; i < mat.GetLength(0); i++)
                {
                    res[i, 0] = mat[i, ind];
                }
                return res;
            }
            else
            {
                double[,] res = new double[mat.GetLength(1), ind];
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    res[i, ind] = mat[i, ind];
                }
                return res;
            }

        }
        public static double[,] extractMatIntoMat(int r, int c, double[,] mat)
        {
            double[,] res = new double[r,c];
            for(var i = 0; i < r; i++)
            {
                for(var j = 0; j < c; j++)
                {
                    res[i,j] = mat[i,j];
                }
            }
            return res;
        }
        public static double[,] AddColunm(double[,] A, double[,] B, int position = 0)
        {
            var res = new double[A.GetLength(0), A.GetLength(1)+1];
            for (var i = 0; i < A.GetLength(0); i++)
            {
                for(var j = 0; j < A.GetLength(1)+1; j++)
                {
                    if(position == 0)
                    {
                        if (j - 1 == -1)
                        {
                            res[i, j] = B[i, 0];
                            res[i, j + 1] = A[i, 0];
                        }
                        else
                            if(j < A.GetLength(1)) res[i, j + 1] = A[i, j];
                    }else if(position == 1)
                    {
                        if (j < A.GetLength(1)) res[i, j] = A[i, j];
                        else if (j == A.GetLength(1)) res[i, j] = B[i, 0];
                    }
                }
            }
            return res;
        } 
    }
}
