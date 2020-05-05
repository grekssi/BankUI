using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetStartedPage : ContentPage
    {
        public GetStartedPage()
        {
            InitializeComponent();
            this.BindingContext = new InitialCarouselViewModel();
        }
    }
}