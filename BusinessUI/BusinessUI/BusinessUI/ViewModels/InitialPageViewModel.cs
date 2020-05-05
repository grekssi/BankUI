using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using BusinessUI.Navigation;
using BusinessUI.Services;
using BusinessUI.Views;
using Xamarin.Forms;

namespace BusinessUI.ViewModels
{
    public sealed class InitialPageViewModel : BaseViewModel
    {
        public INavigationService Navigation { get; }
        public InitialPageViewModel()
        {
            this.Navigation = MainContext.Navigation;

            this.RegistrationCommand = new Command(this.NavigateToRegistrationPage);
            this.GetStartedCommand = new Command(this.NavigateToGetStartedPage);

            this.Image = ImageProvider.LoginImageLogoName;
            this.BackgroundImage = ImageProvider.BlueToPurpleBackGroundImageName;
            this.HeaderText = ResourceProvider.InitialPage_InitialHeaderText;
            this.ButtonText = ResourceProvider.InitialPage_GetStartedText;
            this.NoAccountText = ResourceProvider.InitialPage_NoAccountText;
            this.SignInText = ResourceProvider.InitialPage_SignInText;
        }

        public ICommand GetStartedCommand { get; }
        public string Image { get; }
        public string BackgroundImage { get; }
        public string HeaderText { get; }
        public string ButtonText { get; }
        public string NoAccountText { get; }
        public string SignInText { get; }

        public ICommand RegistrationCommand { get; }

        private async void NavigateToRegistrationPage()
        {
            //Application.Current.MainPage.Navigation.PushAsync(new AuthenticationPage());
            await this.Navigation.NavigateToAsync(NavigationPageSource.AuthenticationPage);
        }

        private async void NavigateToGetStartedPage()
        {
            await this.Navigation.NavigateToAsync(NavigationPageSource.GetStartedPage);
        }
    }
}
