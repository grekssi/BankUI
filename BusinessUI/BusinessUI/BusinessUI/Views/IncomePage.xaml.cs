using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessUI.Services.IncomeEntriesLogic;
using BusinessUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncomePage : ContentPage
    {
        public IncomePage()
        {
            InitializeComponent();
            this.BindingContext = new IncomesViewModel(new IncomeHelper());
        }
    }
}