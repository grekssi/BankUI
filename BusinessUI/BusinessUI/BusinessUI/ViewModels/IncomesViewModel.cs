using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Android;
using BusinessUI.Models;
using BusinessUI.Services;
using BusinessUI.Services.IncomeEntriesLogic;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Char = System.Char;
using Entry = Microcharts.Entry;

namespace BusinessUI.ViewModels
{
    public sealed class IncomesViewModel : BaseViewModel
    {
        public Login Login { get; }
        public ObservableCollection<IncomeTimeButton> TimeButtons { get; }
        private IncomeHelper Helper { get; }

        public List<Chart> Charts { get; set; }

        public IncomesViewModel(IncomeHelper helper)
        {

            this.Helper = helper;
            var initialEntries = Helper.GetIncome(IncomeType.Year);

            this.Charts = new List<Chart>(MakeCharts(initialEntries));
            this.TimeButtons = new ObservableCollection<IncomeTimeButton>
            {
                new IncomeTimeButton("0", 0, "Day", new Command(GetEntries)),
                new IncomeTimeButton("1", 0, "Week", new Command(GetEntries)),
                new IncomeTimeButton("2", 0, "Month", new Command(GetEntries)),
                new IncomeTimeButton("3", 1, "Year", new Command(GetEntries)),
            };

            this.Login = MainContext.Login;

            SetUpIncomeAndBalanceBasedOnEntries(initialEntries);

            this.ExpensesText = ResourceProvider.IncomesPage_ExpensesText;
            this.BalanceText = ResourceProvider.IncomesPage_BalanceText;
            this.IncomeText = ResourceProvider.IncomesPage_IncomeText;
            this.AssetsText = ResourceProvider.IncomesPage_AssetsText;

            //TODO GET BALANCE FROM ACCOUNT
            this.Balance = "98,2410.84";
        }

        private void SetUpIncomeAndBalanceBasedOnEntries(Tuple<Entry[], Entry[]> entries)
        {
            //this should happen in the adapter!!!!!!!

            float income = 0;
            float expenses = 0;

            foreach (var entry in entries.Item1)
            {
                income += entry.Value;
            }
            foreach (var entry in entries.Item2)
            {
                expenses += entry.Value;
            }

            //TODO Parse to visual double
            this.Income = income.ToString();
            this.Expenses = expenses.ToString();
            this.Assets = (income - expenses).ToString();
            OnPropertyChanged(nameof(Income));
            OnPropertyChanged(nameof(Expenses));
            OnPropertyChanged(nameof(Assets));
        }

        public string BalanceText { get; }
        public string Balance { get; }
        public string IncomeText { get; }
        public string Income { get; set; }
        public string ExpensesText { get; }
        public string Expenses { get; set; }
        public string AssetsText { get; }
        public string Assets { get; set; }

        public List<Entry> Entries { get; set; }

        public void GetEntries(object buttonId)
        {
            //TODO:Helper for entries parsing
            var id = buttonId.ToString();
            ChangeStateOfTimeButtons(id);
            IncomeType enumtype = (IncomeType)Enum.Parse(typeof(IncomeType), id);
            var entries = Helper.GetIncome(enumtype);
            this.Charts = MakeCharts(entries);
            SetUpIncomeAndBalanceBasedOnEntries(entries);
            OnPropertyChanged(nameof(this.Charts));
            OnPropertyChanged(nameof(Income));
            OnPropertyChanged(nameof(Expenses));
        }

        private void ChangeStateOfTimeButtons(string id)
        {
            this.TimeButtons.Where(x => x.ButtonId != id).ForEach(x => x.BorderWidth = 0);
            this.TimeButtons.Where(x => x.ButtonId == id).ForEach(x => x.BorderWidth = 1);
        }

        private List<Chart> MakeCharts(Tuple<Entry[], Entry[]> entries)
        {
            var charts = new List<Chart>(2);
            charts.Add(new LineChart() { Entries = entries.Item1, BackgroundColor = SKColors.Transparent, LineSize = 8, LabelTextSize = 35, LineMode = LineMode.Straight, PointMode = PointMode.Square, LineAreaAlpha = 50, PointSize = 20 });
            charts.Add(new LineChart() { Entries = entries.Item2, BackgroundColor = SKColors.Transparent, LineSize = 8, LabelTextSize = 35, LineMode = LineMode.Straight, PointMode = PointMode.Square, LineAreaAlpha = 50, PointSize = 20 });
            return charts;
        }
    }
}
