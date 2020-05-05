using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BusinessUI.Navigation
{
    public interface INavigationService
    {
        void Initialize(INavigation navigation, PageMapper navigationMapper);
        Task NavigateToAsync(object navigationSource, object parameter = null);
        Task PopToRootAndNavigateAsync(object navigationSource, bool hasNavigationBar, object parameter = null);
        void NavigateFromAppShellAsync(string pageName, Type pageType);
        Task NavigateModalAsync(object navigationSource, bool hasNavigationBar, object parameter = null);
        Task SetMainPage(object navigationSource, bool hasNavigationBar, object parameter = null);
        Task GoBackAsync();
    }
}
