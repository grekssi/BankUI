using System;
using System.Globalization;
using Xamarin.Forms;

namespace BusinessUI.Services.CreditCardsLogic
{
    public class CardNumberToBackgroundColorConverter : BaseCardValidator
    {
        public Color Visa { get; set; }
        public Color MasterCard { get; set; }
        public Color NotRecognized { get; set; }

        public CardNumberToBackgroundColorConverter()
        {
            this.MasterCard = Color.DimGray;
            this.Visa = Color.AliceBlue;
            this.NotRecognized = Color.Transparent;
        }

        public Color Convert(object value)
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