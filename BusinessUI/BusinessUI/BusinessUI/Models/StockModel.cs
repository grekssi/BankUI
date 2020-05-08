using System;
using System.Collections.Generic;
using System.Text;
using BusinessUI.ViewModels;
using Microcharts;
using Xamarin.Forms;

namespace BusinessUI.Models
{
    public sealed class StockModel : BaseViewModel
    {
        public string Id { get; }
        public string StockId { get; }
        public string Name { get; }
        public ImageSource Image { get; }
        public string StockProviderName { get; }
        public double PastDayStockPrice { get; }
        public double CurrentStockPrice { get; }
        public Chart Chart { get; set; }
        public double PricePercentage { get; set; }

        public Color StockPriceIndexColor
        {
            get => GetSelectedColor(this.PricePercentage);
        }

        private Color GetSelectedColor(double pricePercentage)
        {
            if (pricePercentage < 0)
            {
                return Color.Red;
            }

            return Color.LawnGreen;
        }

        public StockModel(string id, string name, string image, string stockProviderName, string pastDayStockPrice, string currentStockPrice)
        {
            this.Id = id;
            Name = name;
            Image = image;
            StockProviderName = stockProviderName;
            PastDayStockPrice = double.Parse(pastDayStockPrice);
            CurrentStockPrice = double.Parse(currentStockPrice);
        }

        public void SetUpChart(Chart chart)
        {
            if(chart == null) throw new ArgumentNullException(nameof(chart));
            this.Chart = chart;
        }

        public void SetUpPercentage(string percentage)
        {
            if(percentage == null) throw new ArgumentNullException(nameof(percentage));
            this.PricePercentage = double.Parse(percentage);
        }
    }
}
