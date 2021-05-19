using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Domain.Entities
{
    public class Transaction
    {
        public string Type { get; set; }
        public bool Status { get; set; }
        public decimal Currency { get; set; }
        public decimal Amount { get; set; }
    }
}
