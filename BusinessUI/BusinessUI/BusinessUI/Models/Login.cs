using System;
using Xamarin.Forms;

namespace BusinessUI.Models
{
    public sealed class Login
    {
        public string Password { get; }
        public string Email { get; }
        public ImageSource ProfilePicture { get; }
        public decimal Balance { get; }

        public Login(string password, string email, string profilePicture, string balance)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (email == null) throw new ArgumentNullException(nameof(email));

            this.Balance = decimal.Parse(balance);
            this.ProfilePicture = profilePicture;
            this.Password = password;
            this.Email = email;
        }

        public Login(string password, string email)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (email == null) throw new ArgumentNullException(nameof(email));

            this.Password = password;
            this.Email = email;
        }
    }
}
