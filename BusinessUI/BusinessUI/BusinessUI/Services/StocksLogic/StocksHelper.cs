using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using BusinessUI.Models;
using Microcharts;
using SkiaSharp;

namespace BusinessUI.Services.StocksLogic
{
    public sealed class StocksHelper
    {
        private StocksAdapter Adapter { get; }

        public StocksHelper(StocksAdapter stocksAdapter)
        {
            if(stocksAdapter == null) throw new ArgumentNullException(nameof(stocksAdapter));
            this.Adapter = stocksAdapter;
        }

        public IEnumerable<StockModel> SetUpStocks()
        {
            var stockModels = Adapter.GetAllStockModels();
            foreach (var stockModel in stockModels)
            {
                var chartModels = Adapter.GetChartModelsForLastWeekById(stockModel.Id);
                var chart = this.GetChart(chartModels);
                stockModel.SetUpChart(chart);
                bool isNegative = false;
                var priceLast = stockModel.PastDayStockPrice;
                var currentPrice = stockModel.CurrentStockPrice;
                if (priceLast > currentPrice) isNegative = true;
                var priceToPercentNumber = (Math.Max(priceLast, currentPrice) - Math.Min(currentPrice, priceLast));
                var percent = (priceToPercentNumber * 100) / Math.Max(priceLast, currentPrice);

                if (isNegative)
                {
                    percent *= -1;
                }

                stockModel.SetUpPercentage(percent.ToString(CultureInfo.InvariantCulture));

                yield return stockModel;
            }
        }

        public Chart GetChart(List<StockChartModel> models)
        {
            if(models == null) throw new ArgumentNullException(nameof(models));

            //var allCharts = this.StocksAdapter.GetAllStockChartModels();
            var entries = new List<Entry>();
            foreach (var model in models)
            {
                entries.Add(new Entry(model.Value)
                {
                    Color = model.Color, TextColor = model.Color, ValueLabel = string.Empty, Label = string.Empty
                });
            }

            var chart = new LineChart(){Entries = entries, LineAreaAlpha = 0, PointAreaAlpha = 0, PointSize = 0, BackgroundColor = SKColor.Empty, LineMode = LineMode.Spline, LineSize = 7};

            return chart;
        }
    }
}
