using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Android.Provider;
using Xamarin.Forms;

namespace BusinessUI.Services.CreditCardsLogic
{
    public class CardNumberToImageConverter : BaseCardValidator
    {
        public ImageSource Visa { get; set; }
        public ImageSource MasterCard { get; set; }
        public ImageSource NotRecognized { get; set; }

        public CardNumberToImageConverter()
        {
            this.Visa = ImageProvider.VisaCardLogoImage;
            this.MasterCard = ImageProvider.MasterCardLogoImage;
        }

        public ImageSource Convert(object value)
        {
            if (value == null) return NotRecognized;

            var number = value.ToString();
            var numberNormalized = number.Replace("-", string.Empty);

            if (VisaRegex.IsMatch(numberNormalized)) return Visa;

            if (MasterCardRegex.IsMatch(numberNormalized)) return MasterCard;

            return NotRecognized;
        }
    }

}
