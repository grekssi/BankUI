using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using BusinessUI.Navigation;
using BusinessUI.Services.CreditCardsLogic;
using BusinessUI.Views;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Entry = Microcharts.Entry;

namespace BusinessUI.ViewModels
{
    public sealed class StaticCardsViewModel
    {
        public ObservableCollection<CreditCard> Cards { get; }
        private INavigationService Navigation { get; }

        private List<Entry> Entries { get; }

        public Chart Chart { get; set; } 

        public StaticCardsViewModel()
        {
            this.Navigation = DependencyService.Get<INavigationService>();
            this.Cards = new ObservableCollection<CreditCard>
            {
                new CreditCard("1", ParseToCreditCardCredentials.ParseToCreditCardNumber("8476345273647581"), "321", ParseToCreditCardCredentials.ParseToExpirationDate("1212"), "visaImage.png", @"#ADD8E6"),
                new CreditCard("2", ParseToCreditCardCredentials.ParseToCreditCardNumber("8476345273647581"), "321", ParseToCreditCardCredentials.ParseToExpirationDate("1202"), "masterCardLogo.png", @"#A9A9A9"),
            };

            this.AddNewCard = new Command(RedirectToNewCardPage);
        }

        public ICommand AddNewCard { get; }

        public async void RedirectToNewCardPage()
        {
            await Shell.Current.GoToAsync("NewCardPage");
            //this.Navigation.NavigateFromAppShellAsync("NewCardPage", typeof(NewCardPage));
        }

        public void GetAllCards()
        {
            throw new NotImplementedException();
        }
    }
}
