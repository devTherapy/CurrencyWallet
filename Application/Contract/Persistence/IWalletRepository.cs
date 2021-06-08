using CurrencyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Contract.Persistence
{
    public interface IWalletRepository : IAsyncRepository<Wallet>
    {
        Task<ICollection<Wallet>> GetWalletByUserId(string id);
        //Task AddWalletTransaction(Wallet wallet, Transaction newTransaction);
        //Task UpdateWalletTransaction(Wallet walletWithCurrency, Transaction transaction);
    }
}
