using System;
using System.Collections.Generic;
using System.Text;
using BusinessUI.Models;
using BusinessUI.Navigation;
using Xamarin.Forms;

namespace BusinessUI.Services
{
    public static class MainContext
    {
        public static INavigationService Navigation { get; } = DependencyService.Get<INavigationService>();
        public static Login Login { get; set; }
    }
}
