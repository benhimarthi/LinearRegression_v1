using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double[,]> data = DataExtractor.input(DataExtractor.ExtractDatas("C:/Users/DELL/source/repos/WpfSample/rfm_customers.xlsx"));
        
        public MainWindow()
        {
            InitializeComponent();
            // Create the application's main window

            double[,] model = MatrixManager.AddColunm(data[0], data[1], 0);
            model = MatrixManager.AddColunm(model, MatrixManager.ConvertArrayToMatrix(ErrorCalculation.Errors()), 1);
            // Add the Grid as the Content of the Parent Window Object

            tab.Children.Add(DrawTable.table(model));
            //Print average data value
            List<double> valM = new List<double>() { Utilities.TabMeans(data[1])};
            List<double> valV = new List<double>() { Utilities.Variance(data[1], 0)};
            List<double> ET = new List<double>() { Utilities.EcartType(data[1], 0) };  
            List<double> valCV = new List<double>();
            for (var i = 0; i < data[0].GetLength(1)-1; i++)
            {
                valM.Add(Utilities.TabMeans(MatrixManager.extractLineOrColumn(i, data[0])));
                valV.Add(Utilities.Variance(data[0], i));
                ET.Add(Utilities.EcartType(data[0], i));
            }
            means.Child = ModelInformationForm.ModelAverageInfo(
                valM
                , "Moyenne");
            variance.Child = ModelInformationForm.ModelAverageInfo(
                valV
                , "Variance");
            ecartType.Child = ModelInformationForm.ModelAverageInfo(
                ET
                , "EcartType");
            ImpVar.Child = ModelInformationForm.Var(ErrorCalculation.x);
        }

        private void displayData(object sender, RoutedEventArgs e)
        {
            double[,] model = MatrixManager.AddColunm(data[0], data[1], 0);
            model = MatrixManager.AddColunm(model, MatrixManager.ConvertArrayToMatrix(ErrorCalculation.Errors()), 1);
            tab.Children.Clear();
            tab.Children.Add(DrawTable.table(model));
        }

        private void displayAnova(object sender, RoutedEventArgs e)
        {
            tab.Children.Clear();
            tab.Children.Add(ModelInformationForm.Fisher(Utilities.ANOVA(
                data[1], MatrixManager.ConvertArrayToMatrix(ErrorCalculation.YEval()), Utilities.TabMeans(data[1]), data[1].GetLength(0), data[0].GetLength(1) - 1)));
        }

        private void displayCov(object sender, RoutedEventArgs e)
        {
            /*tab.Children.Add(ModelInformationForm.CovarianceTable(
                Utilities.CovarianceTable
                ));*/
        }
    }
}
