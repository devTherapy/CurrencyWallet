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
        public string TransactionType { get; set; }
        public string TransactionStatus { get; set; }
        public decimal BalanceBeforeTransaction { get; set; }
        public decimal BalanceAfterTransaction { get; set; }
        //navigational property
        public Wallet Wallet { get; set; }
    }
}
