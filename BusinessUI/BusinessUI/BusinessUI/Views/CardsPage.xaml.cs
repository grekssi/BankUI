using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessUI.Services.CreditCardsLogic;
using BusinessUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardsPage : ContentPage
    {
        public CardsPage()
        {
            InitializeComponent();
            this.BindingContext = new StaticCardsViewModel();
        }
    }
}