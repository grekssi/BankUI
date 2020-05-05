using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using BusinessUI.Models;
using BusinessUI.Navigation;
using BusinessUI.Services;
using BusinessUI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BusinessUI.ViewModels
{
    public sealed class MyProfileViewModel : BaseViewModel
    {
        private ICommand ShowCardsCommand { get; }
        private ICommand BankAppointmentCommand { get; }
        private ICommand CallBankCommand { get; }

        public INavigationService Navigation { get; }
        public ObservableCollection<CallFunction> CallFunctions { get; set; } 
        public Login Login { get; }

        public CallingServices CallingService { get; }
        public MyProfileViewModel()
        {
            InitializeCallFunctions();
            this.Login = MainContext.Login;
            this.Navigation = DependencyService.Get<INavigationService>();
            this.CallingService = new CallingServices();
            ShowCardsCommand = new Command(ShowAvailableCards);
            BankAppointmentCommand = new Command(CreateNewAppointment);
            CallBankCommand = new Command(CallBank);
            this.BalanceText = ResourceProvider.MyProfilePage_BalanceText;
            this.PersonalInformationText = ResourceProvider.MyProfilePage_PersonalInformationText;
        }

        public string BalanceText { get; } 
        public string PersonalInformationText { get; }

        public string MakeBankAppointmentText { get; set; }
        public string CallTheBankText { get; set; }
        public string ShowAvailableCardsText { get; set; }


        private async void ShowAvailableCards()
        {
            await Shell.Current.GoToAsync("CardsPage");
            //await Navigation.NavigateToAsync(new CardsPage());
        }

        private async void CreateNewAppointment()
        {
            await Navigation.NavigateModalAsync(new AppointmentPage(), false);
        }

        private async void CallBank()
        {
            string bankNumber = ResourceProvider.MyProfilePage_BankPhoneNumber;
            var action = await Alerter.CallBankPopUp(bankNumber);
            switch (action)
            {
                case "Call":
                    this.CallingService.Call(bankNumber);
                    break;
            }
        }

        private void InitializeCallFunctions()
        {
            this.CallFunctions = new ObservableCollection<Models.CallFunction>
            {
                new CallFunction("informatioImage.png", "Show available cards", new Command(ShowAvailableCards)),
                new CallFunction("informatioImage.png", "Make bank appointment", new Command(CreateNewAppointment)),
                new CallFunction("informatioImage.png", "Call the bank", new Command(CallBank)),
            };
        }
    }
}
