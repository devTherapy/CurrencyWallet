using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
