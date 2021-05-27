using CurrencyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Contract.Persistence
{
    interface IWalletRepository : IAsyncRepository<Wallet>
    {
    }
}
