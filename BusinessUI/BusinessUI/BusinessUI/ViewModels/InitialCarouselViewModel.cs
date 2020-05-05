using System;
using System.Collections.Generic;
using System.Text;
using Android.Provider;
using BusinessUI.Services;
using Xamarin.Forms;

namespace BusinessUI.ViewModels
{
    public sealed class InitialCarouselViewModel : BaseViewModel
    {
        public List<ImageSource> Views { get; set; }
        public InitialCarouselViewModel()
        {
            this.Views = new List<ImageSource>
            {
                ImageProvider.GetStartedPhoneImage1,
                ImageProvider.GetStartedPhoneImage2,
                ImageProvider.GetStartedPhoneImage3,
            };

        }
    }
}
