using System;
using BusinessUI.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BusinessUI.Services;
using BusinessUI.Views;
using Org.Apache.Http.Conn;
using Android.Views;

namespace BusinessUI
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            var mainPage = new InitialPage();
            InitializeNavigation(mainPage);
            MainPage = new NavigationPage(mainPage);
        }
        private void InitializeNavigation(Page startPage)
        {
            var mapper = new PageMapper();
            mapper.AddMapping(typeof(InitialPage), NavigationPageSource.InitialPage);
            mapper.AddMapping(typeof(AuthenticationPage), NavigationPageSource.AuthenticationPage);
            mapper.AddMapping(typeof(AppShell), NavigationPageSource.AppShell);
            mapper.AddMapping(typeof(AppointmentPage), NavigationPageSource.AppointmentPage);
            mapper.AddMapping(typeof(CardsPage), NavigationPageSource.CardsPage);
            mapper.AddMapping(typeof(GetStartedPage), NavigationPageSource.GetStartedPage);

            var navigationService = DependencyService.Get<INavigationService>();
            navigationService.Initialize(startPage.Navigation, mapper);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
