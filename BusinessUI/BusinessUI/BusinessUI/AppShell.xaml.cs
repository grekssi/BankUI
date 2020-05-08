using System;
using System.Collections.Generic;
using BusinessUI.Views;
using Xamarin.Forms;

namespace BusinessUI
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("CardsPage", typeof(CardsPage));
            Routing.RegisterRoute("NewCardPage", typeof(NewCardPage));
            Routing.RegisterRoute("ItemsPage", typeof(ItemsPage));
            Routing.RegisterRoute("IncomePage", typeof(IncomePage));
            Routing.RegisterRoute("StockMarketPage", typeof(StockMarketPage));
        }
    }
}
