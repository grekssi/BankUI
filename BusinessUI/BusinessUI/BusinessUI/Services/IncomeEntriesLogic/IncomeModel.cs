using System;
using System.Collections.Generic;
using System.Text;
using Microcharts;
using SkiaSharp;

namespace BusinessUI.Services.IncomeEntriesLogic
{
    public sealed class IncomeModel
    {
        public string Id { get; }
        public float Value { get; }
        public string Label { get; }
        public SKColor Color { get; }

        public IncomeModel(float value, string label, SKColor color)
        {
            this.Value = value;
            this.Label = label;
            this.Color = color;
        }
    }
}
