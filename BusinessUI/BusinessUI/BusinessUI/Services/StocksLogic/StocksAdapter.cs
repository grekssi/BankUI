using System;
using System.Collections.Generic;
using System.Text;
using BusinessUI.Models;
using BusinessUI.Services.IncomeEntriesLogic;
using Microcharts;
using SkiaSharp;

namespace BusinessUI.Services.StocksLogic
{
    public sealed class StocksAdapter
    {
        public List<StockChartModel> GetChartModelsForLastWeekById(string stockId)
        {
            //GET INFO FOR PRICES FOR PAST WEEK FROM DB
            //EXAMPLE FOR RETURN TYPE OF STOCK 
            var rand = new Random();
            return new List<StockChartModel>
            {
                new StockChartModel(rand.Next(0, 10000), "Mon", SKColor.Parse("#77d065")),
                new StockChartModel(rand.Next(0, 10000), "Tue", SKColor.Parse("#77d065")),
                new StockChartModel(rand.Next(0, 10000), "Wed", SKColor.Parse("#77d065")),
                new StockChartModel(rand.Next(0, 10000), "Thu", SKColor.Parse("#77d065")),
                new StockChartModel(rand.Next(0, 10000), "Fry", SKColor.Parse("#77d065")),
                new StockChartModel(rand.Next(0, 10000), "Sat", SKColor.Parse("#77d065")),
                new StockChartModel(rand.Next(0, 10000), "Sun", SKColor.Parse("#77d065")),
            };
        }

        public List<List<StockChartModel>> GetAllStockChartModels()
        {
            throw new NotImplementedException();
        }

        public List<StockModel> GetAllStockModels()
        {
            //get from db
            return new List<StockModel>()
            {
                new StockModel("1", "Bitcoin", "bitcoinicon.png", "USD Bitstamp", "1800", "1440"),
                new StockModel("2", "Etherium", "ethereumicon.png", "Eth inc.", "987", "1113"),
                new StockModel("3", "Axis Bank", "AxisBankIcon", "Axis Bank Pvt. Ltd.", "322", "544"),
                new StockModel("4", "Hex", "hexicon.png", "Hex solutions", "423", "212"),
            };
        }
    }
}
