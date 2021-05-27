using CurrencyWallet.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Domain.Entities
{
    public class Transaction : BaseEntity
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string WalletId { get; set; }
        public string TransactionTypeId { get; set; }
        public string TransactionStatusId { get; set; }

        //navigational property
        public Wallet Wallet { get; set; }
        public TransactionStatus  TransactionStatus { get; set; }
        public TransactionCategory TransactionType { get; set; }
    }
}
