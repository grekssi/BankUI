using System;
using System.ComponentModel;
using System.Windows.Input;
using Android.Util;
using BusinessUI.Models;
using BusinessUI.Navigation;
using BusinessUI.Services;
using Xamarin.Forms;

namespace BusinessUI.ViewModels
{
    public sealed class LoginViewModel : BaseViewModel
    {
        private LoginService LoginService { get; }
        private INavigationService Navigation { get; }

        public LoginViewModel(LoginService loginService)
        {
            if (loginService == null) throw new ArgumentNullException(nameof(loginService));

            this.IsRegistration = true;
            this.EmailEntryImage = ImageProvider.EmailLoginInformationImage;
            this.PasswordEntryImage = ImageProvider.PasswordLoginInformationImage;
            this.HeaderText = ResourceProvider.AuthenticationPage_HeaderText;
            this.PasswordEntryText = ResourceProvider.AuthenticationPage_PasswordText;
            this.EmailEntryText = ResourceProvider.AuthenticationPage_EmailText;
            this.RememberMeText = ResourceProvider.AuthenticationPage_RememberMeText;
            this.ForgottenPasswordText = ResourceProvider.AuthenticationPage_ForgottenPasswordText;
            this.SignInButtonText = ResourceProvider.AuthenticationPage_SignInButtonText;
            this.CreateAccountButtonText = ResourceProvider.AuthenticationPage_CreateAccountText;
            this.ForgottenPasswordText = ResourceProvider.AuthenticationPage_ForgottenPasswordText;
            this.Navigation = DependencyService.Get<INavigationService>();
            this.LoginService = loginService;
            this.LoginCommand = new Command(this.Authenticate, this.CanAuthenticate);
            this.RegistrationCommand = new Command(this.PivotToRegistrationForm);
        }

        private bool _isRegistration;
        public bool IsRegistration
        {
            get => _isRegistration;
            set => SetProperty(ref _isRegistration, value);
        }

        private string _signInButtonText = string.Empty;
        public string SignInButtonText
        {
            get => _signInButtonText;
            set => SetProperty(ref _signInButtonText, value);
        }
        public string CreateAccountButtonText { get; }
        public bool IsRememberMe { get; set; }
        public string ForgottenPasswordText { get; }
        public string RememberMeText { get; }
        public string EmailEntryImage { get; }
        public string PasswordEntryImage { get; }
        public string HeaderText { get; }
        public string PasswordEntryText { get; }
        public string EmailEntryText { get; }


        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set
            {
                this.SetProperty(ref _password, value, onChanged: this.LoginCommand.ChangeCanExecute);
            }
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                this.SetProperty(ref _email, value);
            }
        }

        public Command LoginCommand { get; set; }
        public Command RegistrationCommand { get; set; }
        public Command ForgottenPasswordCommand { get; set; }

        private bool CanAuthenticate()
        {
            var canExecute = !string.IsNullOrEmpty(this.Password) &&
                             !string.IsNullOrEmpty(this.Email);
            return canExecute;
        }

        private void PivotToRegistrationForm()
        {
            this.IsRegistration = false;
            this.SignInButtonText = ResourceProvider.AuthenticationPage_RegisterButtonText;
        }

        private void Authenticate()
        {
            if (this.IsRegistration)
            {
                this.Login();
            }
            this.Register();
        }

        private void Login()
        {
            MainContext.Login = new Login("admin", "admin", ImageProvider.ProfileBasePicture, "123214");
            this.Navigation.SetMainPage(NavigationPageSource.AppShell, false);
            return;
            try
            {
                var password = this.Password ?? string.Empty;
                var email = this.Email ?? string.Empty;

                var login = new Login(password, email, ImageProvider.ProfileBasePicture, "0");

                var validationMessage = this.LoginService.Validate(login);

                if (string.IsNullOrEmpty(validationMessage))
                {
                    if (this.LoginService.LoginUserRequest(login).Result)
                    {
                        this.Navigation.SetMainPage(NavigationPageSource.AppShell, false);
                        return;
                    }
                    Alerter.InvalidLoginAlert();
                }
            }
            catch (Exception)
            {
                Alerter.InvalidLoginAlert();
            }
            this.Navigation.NavigateToAsync(NavigationPageSource.AuthenticationPage);
        }

        private void Register()
        {
            try
            {
                var password = this.Password ?? string.Empty;
                var email = this.Email ?? string.Empty;

                var login = new Login(password, email);

                var validationMessage = this.LoginService.Validate(login);

                if (string.IsNullOrEmpty(validationMessage))
                {
                    if (this.LoginService.RegisterNewUserRequest(login).Result)
                    {
                        this.Navigation.NavigateToAsync(NavigationPageSource.AuthenticationPage);
                        return;
                    }
                    Alerter.InvalidRegistrationAlert();
                }
            }
            catch (Exception)
            {
                Alerter.InvalidRegistrationAlert();
            }
            this.Navigation.NavigateToAsync(NavigationPageSource.AuthenticationPage);
        }
    }
}
