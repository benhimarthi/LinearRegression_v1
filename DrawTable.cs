using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfSample
{
    public class DrawTable
    {
        /// <summary>
        /// 
        /// </summary>
        public static Grid table(double[,] table)
        {
            // Create the Grid
            Grid myGrid = new Grid();
            myGrid.Width = 550;
            myGrid.Height = 90000;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = false;
            

            //Define the column
            for(int i = 0; i < table.GetLength(1); i++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            //Add the Rows
            for(int i=0; i < table.GetLength(0)+1; i++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition());
            }

            //Define the first row
            for(int i=0; i < table.GetLength(1); i++)
            {
                if (i == 0)
                {
                    TextBlock txt1 = new TextBlock();
                    txt1.Text = "Y";
                    txt1.FontWeight = FontWeights.Bold;
                    txt1.FontSize = 16;
                    Grid.SetColumn(txt1, i);
                    Grid.SetRow(txt1, 0);
                    myGrid.Children.Add(txt1);
                }
                else if (i < table.GetLength(1)-2)
                {
                    TextBlock txt1 = new TextBlock();
                    txt1.Text = "X" + i.ToString();
                    txt1.FontWeight = FontWeights.Bold;
                    txt1.FontSize = 20;
                    Grid.SetColumn(txt1, i);
                    Grid.SetRow(txt1, 0);
                    myGrid.Children.Add(txt1);
                }
                else if (i == table.GetLength(1) - 2)
                {
                    TextBlock txt1 = new TextBlock();
                    txt1.Text = "b";
                    txt1.FontWeight = FontWeights.Bold;
                    txt1.FontSize = 20;
                    Grid.SetColumn(txt1, i);
                    Grid.SetRow(txt1, 0);
                    myGrid.Children.Add(txt1);
                }
                else if(i == table.GetLength(1)-1)
                {
                    TextBlock txt1 = new TextBlock();
                    txt1.Text = "Error";
                    txt1.FontWeight = FontWeights.Bold;
                    txt1.FontSize = 20;
                    Grid.SetColumn(txt1, i);
                    Grid.SetRow(txt1, 0);
                    myGrid.Children.Add(txt1);
                }
            }
            //Add data
            for(int i = 0; i < table.GetLength(0); i++)
            {
                for(int j = 0; j < table.GetLength(1); j++)
                {
                    TextBlock txt1 = new TextBlock();
                    txt1.Text = table[i, j].ToString();
                    txt1.FontWeight = FontWeights.Light;
                    txt1.FontSize = 16;
                    Grid.SetRow(txt1, i+1);
                    Grid.SetColumn(txt1, j);
                    myGrid.Children.Add(txt1);
                }
            }
            return myGrid;
        }
    }
}
