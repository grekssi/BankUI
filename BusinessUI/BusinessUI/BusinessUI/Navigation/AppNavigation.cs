using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusinessUI.Views;
using Xamarin.Forms;

namespace BusinessUI.Navigation
{
    public sealed class AppNavigation
    {
        public async Task SetMainPage(string viewModelName)
        {
            if (viewModelName == null) throw new ArgumentNullException(nameof(viewModelName));
            var page = CreatePageAsync(viewModelName);
            var navigationPage = new NavigationPage(page);
            NavigationPage.SetHasNavigationBar(navigationPage, false);
            await InitializeAsync();
            Application.Current.MainPage = navigationPage;
        }

        public async Task NavigateModalAsync(string viewModelName)
        {
            if (viewModelName == null) throw new ArgumentNullException(nameof(viewModelName));

            var page = CreatePageAsync(viewModelName);

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task NavigateAsync(string viewModelName)
        {
            if (viewModelName == null) throw new ArgumentNullException(nameof(viewModelName));

            var page = CreatePageAsync(viewModelName);

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        private Page CreatePageAsync(string viewModelName)
        {
            if (viewModelName == null) throw new ArgumentNullException(nameof(viewModelName));

            Page contentPage;

            switch (viewModelName)
            {
                case nameof(InitialPage):
                    contentPage = new InitialPage();
                    break;
                case nameof(AuthenticationPage):
                    contentPage = new AuthenticationPage();
                    break;
                default:
                    throw new Exception("Content page does not exist");
            }

            return contentPage;
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
