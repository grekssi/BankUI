using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BusinessUI.Services
{
    public sealed class CallingServices
    {
        public void Call(string bankNumber)
        {
            PhoneDialer.Open(bankNumber);
        }
    }
}
