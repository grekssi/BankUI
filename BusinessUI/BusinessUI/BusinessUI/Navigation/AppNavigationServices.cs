using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BusinessUI.Navigation;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppNavigationServices))]
namespace BusinessUI.Navigation
{
    public class AppNavigationServices : INavigationService
    {
        private INavigation _navigation;
        private PageMapper _navigationMapper;

        public async void NavigateFromAppShellAsync(string pageName, Type pageType)
        {
            Routing.RegisterRoute(pageName, pageType);
            await Shell.Current.GoToAsync(pageName);
        }

        public void Initialize(INavigation navigation, PageMapper navigationMapper)
        {
            _navigation = navigation;
            _navigationMapper = navigationMapper;
        }

        public async Task<Page> InitializePage(object navigationSource, object parameter = null)
        {
            CheckIsInitialized();

            var type = _navigationMapper.GetTypeSource(navigationSource);

            if (type == null)
            {
                throw new InvalidOperationException(
                    "Can't find associated type for " + navigationSource.ToString());
            }

            ConstructorInfo constructor;
            object[] parameters;

            if (parameter == null)
            {
                constructor = type.GetTypeInfo()
                    .DeclaredConstructors
                    .FirstOrDefault(c => !c.GetParameters().Any());

                parameters = new object[] { };
            }
            else
            {
                constructor = type.GetTypeInfo()
                    .DeclaredConstructors
                    .FirstOrDefault(c =>
                    {
                        var p = c.GetParameters();
                        return p.Count() == 1 &&
                               p[0].ParameterType == parameter.GetType();
                    });

                parameters = new[] { parameter };
            }

            if (constructor == null)
            {
                throw new InvalidOperationException(
                    "No suitable constructor found for page " + navigationSource.ToString());
            }

            var page = (constructor.Invoke(parameters) as Page);

            return page;
        }

        public async Task SetMainPage(object navigationSource, bool hasNavigationBar, object parameter = null)
        {
            var page = await InitializePage(navigationSource, parameter);
            NavigationPage.SetHasNavigationBar(page, hasNavigationBar);
            Application.Current.MainPage = page;
        }

        public async Task NavigateModalAsync(object navigationSource, bool hasNavigationBar, object parameter = null)
        {
            var page = await InitializePage(navigationSource, parameter);
            await _navigation.PushModalAsync(new NavigationPage(page));
        }

        public async Task PopToRootAndNavigateAsync(object navigationSource, bool hasNavigationBar, object parameter = null)
        {
            await this._navigation.PopToRootAsync();
            var page = await InitializePage(navigationSource, parameter);
            NavigationPage.SetHasNavigationBar(page, hasNavigationBar);
            await _navigation.PushAsync(page);
        }

        public async Task NavigateToAsync(object navigationSource, object parameter = null)
        {
            var page = await InitializePage(navigationSource, parameter);
            await _navigation.PushAsync(page);
        }

        public async Task GoBackAsync()
        {
            CheckIsInitialized();

            await _navigation.PopAsync();
        }

        private void CheckIsInitialized()
        {
            if (_navigation == null || _navigationMapper == null)
                throw new NullReferenceException("Call Initialize method first.");
        }
    }
}
