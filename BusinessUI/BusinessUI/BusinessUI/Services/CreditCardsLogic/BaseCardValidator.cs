using System.Text.RegularExpressions;

namespace BusinessUI.Services.CreditCardsLogic
{
    public class BaseCardValidator
    {
        public static Regex VisaRegex = new Regex(@"^4[0-9]{6,}$");
        public static Regex MasterCardRegex = new Regex(@"^5[1-5][0-9]{5,}|222[1-9][0-9]{3,}|22[3-9][0-9]{4,}|2[3-6][0-9]{5,}|27[01][0-9]{4,}|2720[0-9]{3,}$");
    }
}