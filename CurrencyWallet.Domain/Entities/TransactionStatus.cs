using CurrencyWallet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Domain.Entities
{
    public class TransactionStatus : BaseEntity
    {
        public string Name { get; set; }

        //navigational properties
        public ICollection<Transaction>Transactions{get; set;}
    }
}
