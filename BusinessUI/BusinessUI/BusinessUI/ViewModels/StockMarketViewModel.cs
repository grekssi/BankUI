using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using BusinessUI.Models;
using BusinessUI.Services.StocksLogic;
using Xamarin.Forms;

namespace BusinessUI.ViewModels
{
    public sealed class StockMarketViewModel : BaseViewModel
    {
        private StocksHelper Helper { get; }

        public ObservableCollection<StockModel> Stocks { get; set; }

        public StockMarketViewModel(StocksHelper helper)
        {
            this.Helper = helper;
            this.Stocks = new ObservableCollection<StockModel>();

            SetUpStocks();
        }

        private void SetUpStocks()
        {
            foreach (var stockModel in this.Helper.SetUpStocks())
            {
                this.Stocks.Add(stockModel);
            }
        }
    }
}
