using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Models.Authentication
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Key { get; set; }
        public string Audience { get; set; }
        public double Duration { get; set; }

    }
}
