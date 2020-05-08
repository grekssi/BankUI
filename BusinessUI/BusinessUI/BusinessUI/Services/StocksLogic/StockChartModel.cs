using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;

namespace BusinessUI.Services.StocksLogic
{
    public sealed class StockChartModel
    {
        public string Id { get; }
        public float Value { get; }
        public string Label { get; }
        public SKColor Color { get; }

        public StockChartModel(float value, string label, SKColor color)
        {
            this.Value = value;
            this.Label = label;
            this.Color = color;
        }
    }
}
