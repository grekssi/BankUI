using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BusinessUI.Models;
using BusinessUI.Navigation;
using BusinessUI.Services;
using BusinessUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusinessUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage()
        {
            InitializeComponent();
            this.BindingContext = new MyProfileViewModel();
        }
    }
}