using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfSample
{
    internal static class ModelInformationForm
    {
        /// <summary>
        /// The the order of variables is very important, please respect it.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static Grid ModelAverageInfo(List<double> val, String ttl)
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(2, 2, 2, 2);
            grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            grid.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            for(int i = 0; i < val.Count + 1; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            TextBlock title = new TextBlock();
            title.Text = ttl;
            title.Foreground = Brushes.Navy;
            title.FontWeight = FontWeights.Bold;
            title.FontSize = 20;
            Grid.SetRow(title, 0);
            grid.Children.Add(title);
            for(int i = 0; i < val.Count; i++)
            {
                TextBlock value = new TextBlock();
                value.Text = i== 0 ? "y : " + val[i].ToString() : "x"+i.ToString()+" : " + val[i].ToString();
                value.FontWeight = FontWeights.Light;
                value.FontSize = 16;
                Grid.SetRow(value, i+1);
                grid.Children.Add(value);
            }
            return grid;
        }
        public static Grid Var(double[,] dt)
        {
            Grid grid = new Grid();
            grid.Margin = new Thickness(2, 2, 2, 2);
            grid.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            grid.VerticalAlignment = System.Windows.VerticalAlignment.Center;

            for(int i = 0; i < dt.GetLength(0); i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            TextBlock y = new TextBlock();
            y.Text = "x0 : " + dt[0, 0];
            y.Foreground = Brushes.Navy;
            //y.FontWeight = FontWeights.Bold;
            y.FontSize = 20;
            Grid.SetRow(y, 0);
            grid.Children.Add(y);
            Debug.WriteLine(dt.GetLength(0));
            for (int i = 1; i <= dt.GetLength(0)-2; i++)
            {
                TextBlock value = new TextBlock();
                value.Text = "x"+i.ToString()+" : " + dt[i, 0].ToString();
                //value.FontWeight = FontWeights.Light;
                value.Foreground = Brushes.Navy;
                value.FontSize = 20;
                Grid.SetRow(value, i);
                grid.Children.Add(value);
            }
            TextBlock b = new TextBlock();
            b.Text = "b : " + dt[dt.GetLength(0)-1, 0];
            b.Foreground = Brushes.Navy;
            b.FontSize = 20;
            Grid.SetRow(b, dt.GetLength(0) - 1);
            grid.Children.Add(b);
            return grid;
        }
        public static Grid CovarianceTable(double[,] tab)
        {
            Grid an = new Grid();
            an.Margin = new Thickness(2, 2, 2, 2);
            an.ShowGridLines = true;
            an.Width = 500;
            an.Height = 240;
            an.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            an.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                an.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < tab.GetLength(1); i++)
            {
                an.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for(int i = 0; i < tab.GetLength(0); i++)
            {
                for(int j = 0; j < tab.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        if (i >= 1 && i < tab.GetLength(0) - 1)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "x"+i.ToString();
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                        else if(i == tab.GetLength(0) - 1)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "b";
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                    }
                    if (i == 0)
                    {
                        if (j == 1 && j < tab.GetLength(1) - 1)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "x"+j.ToString();
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }else if(i == tab.GetLength(1) - 1)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "b" + j.ToString();
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                    }
                    else if (j > 0)
                    {
                        TextBlock value = new TextBlock();
                        value.Text = tab[i - 1, j - 1].ToString();
                        value.FontWeight = FontWeights.Light;
                        value.Foreground = Brushes.Navy;
                        value.FontSize = 16;
                        Grid.SetRow(value, i);
                        Grid.SetColumn(value, j);
                        an.Children.Add(value);
                    }
                }
            }
            return an;
        }
        public static Grid Fisher(double[,] anova)
        {
            Grid an = new Grid();
            an.Margin = new Thickness(2, 2, 2, 2);
            an.ShowGridLines = true;
            an.Width = 500;
            an.Height = 240;
            an.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            an.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            for (int i = 0; i < 4; i++)
            {
                an.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < 5; i++)
            {
                an.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (j == 0)
                    {
                        if (i == 1)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "SCR";
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            
                            an.Children.Add(value);
                        }
                        if (i == 2)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "SCE";
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                        if (i == 3)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "SCT";
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                    }
                    if (i == 0)
                    {
                        if(j == 1)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "Valeur";
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                        if (j == 2)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "Ddl";
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                        if (j == 3)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "Cm";
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                        if (j == 4)
                        {
                            TextBlock value = new TextBlock();
                            value.Text = "Fisher";
                            value.FontWeight = FontWeights.Bold;
                            value.Foreground = Brushes.Navy;
                            value.FontSize = 20;
                            Grid.SetRow(value, i);
                            Grid.SetColumn(value, j);
                            an.Children.Add(value);
                        }
                    }
                    else if(j > 0)
                    {
                        TextBlock value = new TextBlock();
                        value.Text = anova[i-1, j-1].ToString();
                        value.FontWeight = FontWeights.Light;
                        value.Foreground = Brushes.Navy;
                        value.FontSize = 16;
                        Grid.SetRow(value, i);
                        Grid.SetColumn(value, j);
                        an.Children.Add(value);
                    }
                }
            }
            return an;
        }
    }
}
