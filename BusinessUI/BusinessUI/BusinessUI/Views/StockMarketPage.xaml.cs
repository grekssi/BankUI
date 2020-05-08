using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BusinessUI.Services.StocksLogic;
using BusinessUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockMarketPage : ContentPage
    {
        public StockMarketPage()
        {
            InitializeComponent();
            this.BindingContext = new StockMarketViewModel(new StocksHelper(new StocksAdapter()));
        }
    }
}
