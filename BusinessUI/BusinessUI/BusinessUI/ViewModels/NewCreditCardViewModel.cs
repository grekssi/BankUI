using BusinessUI.Services.CreditCardsLogic;
using System;
using System.Globalization;
using System.Windows.Input;
using BusinessUI.Services;
using Xamarin.Forms;

namespace BusinessUI.ViewModels
{
    public sealed class NewCreditCardViewModel : BaseViewModel
    {
        private CardNumberToImageConverter ImageConverter { get; }
        private CardNumberToBackgroundColorConverter BackgroundColorConverter { get; }
        public NewCreditCardViewModel(CardNumberToImageConverter converter, CardNumberToBackgroundColorConverter backgroundColorConverter)
        {
            this.ImageConverter = converter;
            this.BackgroundColorConverter = backgroundColorConverter;
            this.SecondaryColor = Color.Black;
            this.SaveCardText = ResourceProvider.NewCardPage_SaveCardText;
            this.ExpDateText = ResourceProvider.NewCardPage_ExpirationDateText;
            this.CvvText = ResourceProvider.NewCardPage_CvvText;
            this.CardNumberText = ResourceProvider.NewCardPage_CardNumberText;
            this.SaveCardCommand = new Command(SaveCard);
        }

        private string NormalizedCardNumber { get; set; }
        public string CvvText { get; }
        public string CardNumberText { get; }
        public string ExpDateText { get; }
        public string SaveCardText { get; }

        public ICommand SaveCardCommand { get; }

        public ImageSource CardProviderImage
        {
            get
            {
                return this.ImageConverter.Convert(this.NormalizedCardNumber);
            }
        }

        public Color SecondaryColor { get; }

        public Color CardColor
        {
            get
            {
                return this.BackgroundColorConverter.Convert(this.NormalizedCardNumber);
            }
        }

        private string _cardNumberEntryText = String.Empty;
        public string CardNumberEntryText
        {
            get => _cardNumberEntryText;
            set
            {
                if (value.Length <= 16)
                {
                    SetProperty(ref _cardNumberEntryText, value, nameof(CardNumber));
                }
            }
        }

        private string _cardNumber = "XXXX-XXXX-XXXX-XXXX";
        public string CardNumber
        {
            get
            {
                var ing = ParseToCreditCardCredentials.ParseToCreditCardNumber(_cardNumberEntryText);
                this.NormalizedCardNumber = _cardNumberEntryText;
                SetProperty(ref _cardNumber, ing);
                OnPropertyChanged(nameof(CardColor));
                OnPropertyChanged(nameof(CardProviderImage));
                return _cardNumber;
            }
        }

        private string _cvvEntry = string.Empty;
        public string CvvEntry
        {
            get => _cvvEntry;
            set
            {
                if (value.Length <= 3)
                    SetProperty(ref _cvvEntry, value, nameof(Cvv));
            }
        }

        private string _cvv = string.Empty;
        public string Cvv
        {
            get
            {
                var ing = ParseToCreditCardCredentials.ParseToCvv(_cvvEntry);
                SetProperty(ref _cvv, ing);
                return _cvv;
            }
        }

        public string _expirationDateEntry = string.Empty;
        public string ExpirationDateEntry
        {
            get => _expirationDateEntry;
            set
            {
                if(value.Length <= 4)
                    SetProperty(ref _expirationDateEntry, value, nameof(ExpirationDate));
            }
        }

        public string _expirationDate = "XX/XX";
        public string ExpirationDate
        {
            get
            {
                var ing = ParseToCreditCardCredentials.ParseToExpirationDate(_expirationDateEntry);
                SetProperty(ref _expirationDate, ing);
                return _expirationDate;
            }
        }

        public void SaveCard()
        {

        }
    }
}
