using System.Threading.Tasks;
using Xamarin.Forms;


namespace BusinessUI.Services
{
    public sealed class Alerter
    {
        public static async void InvalidLoginAlert() => await Application.Current.MainPage.DisplayAlert("Invalid Credentials",
            RequestErrorMessages.InvalidLoginRequest, "Ok", "Cancel");

        public static async void InvalidRegistrationAlert() => await Application.Current.MainPage.DisplayAlert("Invalid Credentials",
            RequestErrorMessages.InvalidRegistrationRequest, "Ok", "Cancel");
        public static async void InvalidRegistrationAlert(string message) => await Application.Current.MainPage.DisplayAlert("Invalid Credentials",
            message, "Ok", "Cancel");

        public static async Task<string> CallBankPopUp(string number)
        {
            var popup = await Application.Current.MainPage.DisplayActionSheet($"Call {number}", "Cancel", null, $"Call");
            return popup;
        }
             

    }
}