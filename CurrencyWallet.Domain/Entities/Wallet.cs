using CurrencyWallet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public bool Main { get; set; }
    }
}
