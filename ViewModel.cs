using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WpfSample
{
    public class ViewModel
    {
        //private static readonly double[] val1 = Enumerable.Range(0, 10).Select(x=>(double)Math.Sin(x)).ToArray();
        static List<double> ErrorDatas = ErrorCalculation.Errors();
        static List<double> Yeval = ErrorCalculation.YEval();
        private static readonly IEnumerable<ObservablePoint> en = Enumerable.Range(0, ErrorDatas.Count).Select(x => new ObservablePoint(Yeval[x], ErrorDatas[x]));

        //private static readonly ObservableCollection<ObservablePoint> pts = DataExtractor.ExtractDatas("C:/Users/DELL/source/repos/WpfSample/Td_Regression.xlsx", "Feuil1")));
        public ISeries[] Series { get; set; }
            = 
            new ISeries[]
            {
                new ScatterSeries<ObservablePoint>{
                    Stroke = new SolidColorPaint(SkiaSharp.SKColors.Blue) { StrokeThickness = 1 },
                    Fill = null,
                    Values = en
                },
                /*new LineSeries<double>
                {
                    Stroke = new SolidColorPaint(SkiaSharp.SKColors.Blue) { StrokeThickness = 4 },
                    Values = val1,
                    Fill = null
                }*/
            };


    }
}
