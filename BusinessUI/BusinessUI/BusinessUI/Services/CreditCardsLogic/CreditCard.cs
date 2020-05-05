using Xamarin.Forms;

namespace BusinessUI.Services.CreditCardsLogic
{
    public sealed class CreditCard
    {
        public string CardId { get; }
        public string CardNumber { get; }
        public string Cvv { get; }
        public string ExpirationDate { get; }
        public string CardProviderImage { get; }
        public Color CardColor { get; }

        public CreditCard(string cardId, string cardNumber, string cvv, string expDate, string cardProviderImage, string cardColor)
        {
            this.CardId = cardId;
            this.CardNumber = cardNumber;
            this.Cvv = cvv;
            this.ExpirationDate = expDate;
            this.CardProviderImage = cardProviderImage;
            this.CardColor = Color.FromHex(cardColor);
        }
    }
}
