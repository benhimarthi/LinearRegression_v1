using IronXL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample
{
    internal static class DataExtractor
    {
        public static int[] size = { 0, 0 };
        public static WorkSheet ExtractDatas(string paths, string workSheetName="")
        {
            try
            {
                var workbook = WorkBook.Load(paths);
                var worksheet = workSheetName=="" ? workbook.DefaultWorkSheet : workbook.GetWorkSheet(workSheetName);
                size[0] = worksheet.RowCount;
                size[1] = worksheet.ColumnCount;
                return worksheet;
            }
            catch (IOException e)
            {
                if (e.Source != null) Debug.WriteLine("IOException source : {0}", e.Source);
                return null;
            }
        }


        /*public static List<double[,]> input(WorkSheet worksheet, int limit = 1000)
        {
            var matX = size[0] < limit ? MatrixManager.MatrixCreate(size[0]-1, size[1]-1 > 0 ? size[1] - 1:1):
                MatrixManager.MatrixCreate(1000, size[1] - 2);

            //Debug.WriteLine(matX.GetLength(0));
            //Debug.WriteLine(matX.GetLength(1));
            var matY = size[0] < limit ? MatrixManager.MatrixCreate(size[0] - 1, 1): MatrixManager.MatrixCreate(1000, 1);
            int cnt = 0;
            for (int i = 2; i < matX.GetLength(0); i++)
            {
                for (int j = matX.GetLength(1)-1; j > -1; j--)
                {
                    if (j == matX.GetLength(1)-1) matX[cnt, j] = 1;
                    else matX[cnt, j] = worksheet[MapNumberToLetter(j) + i.ToString()].DoubleValue;
                    if(cnt < matX.GetLength(0)) cnt++;
                }
            }
            cnt = 0;
            for (int i = 2; i < 1000; i++)
            {
                matY[cnt, 0] = worksheet["B"+i.ToString()].DoubleValue;
                cnt++;
            }
            return new List<double[,]> { matX, matY };
        }*/
        public static List<double[,]> input(WorkSheet worksheet, int limit = 1000)
        {
            var matX = MatrixManager.MatrixCreate(2000, 3);

            //Debug.WriteLine(matX.GetLength(0));
            //Debug.WriteLine(matX.GetLength(1));
            var matY = MatrixManager.MatrixCreate(2000, 1);
            int cnt = 2;
            for (int i = 0; i < matX.GetLength(0); i++)
            {
                for (int j = matX.GetLength(1) - 1; j > -1; j--)
                {
                    if (j == matX.GetLength(1) - 1) matX[i, j] = 1;
                    if (j == 1)
                    {
                        matX[i, j] = worksheet["E" + cnt.ToString()].DoubleValue;
                    }
                    if(j == 0)
                    {
                        matX[i, j] = worksheet["D" + cnt.ToString()].DoubleValue;
                    }
                }
                cnt++;
            }
            cnt = 2;
            for (int i = 0; i < 2000; i++)
            {
                matY[i, 0] = worksheet["B" + cnt.ToString()].DoubleValue;
                cnt++;
            }
            return new List<double[,]> { matX, matY };
        }
        private static string MapNumberToLetter(int nb=0)
        {
            switch (nb)
            {
                case 0:return "A";
                case 1:return "B";
                case 2:return "C";
                case 3:return "D";
                case 4:return "E";
                case 5:return "F";
                case 6:return "G";
                case 7:return "H";
                case 8:return "I";
            }
            return "A";
        }
    }
}
