using System;
using System.Collections.Generic;
using System.Text;
using Android.Icu.Text;
using Xamarin.Forms;

namespace BusinessUI.Services.CreditCardsLogic
{
    public class ParseToCreditCardCredentials
    {
        public static string ParseToCreditCardNumber(string number)
        {
            var sb = new StringBuilder();
            sb.Append("XXXX-XXXX-XXXX-XXXX");
            var a = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (sb[a] == '-') a++;
                if (sb[a] == 'X')
                {
                    sb[a] = number[i];
                    a++;
                } 
            }
            return sb.ToString().Trim();
        }

        public static string ParseToExpirationDate(string number)
        {
            var sb = new StringBuilder();
            sb.Append("XX/XX");
            var a = 0;
            for (int i = 0; i < number.Length; i++)
            {
                if (sb[a] == '/') a++;
                sb[a] = number[i];
                a++;
            }

            return sb.ToString().TrimEnd();
        }

        public static string ParseToCvv(string number)
        {
            var sb = new StringBuilder();
            sb.Append("XXX");
            for (int i = 0; i < number.Length; i++)
            {
                sb[i] = number[i];
            }

            return sb.ToString().TrimEnd();
        }
    }
}
