using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Models.Api
{
    public class ResponseData
    {
        public bool success { get; set; }
        public int timestamp { get; set; }
        public string @base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }
    }
}
