using CurrencyWallet.Application.Contract.Persistence;
using CurrencyWallet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Persistence.Repositories
{
   public  class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {

        public WalletRepository(CurrencyWalletDbContext dbContext) : base(dbContext)
        {
        }

        //public async Task AddWalletTransaction(Wallet wallet, Transaction newTransaction)
        //{
        //    var transaction = _dbContext.Database.BeginTransaction();
        //    await _dbContext.Wallets.AddAsync(wallet);
        //    await _dbContext.SaveChangesAsync();
        //    await _dbContext.Tranasactions.AddAsync(newTransaction);
        //    await _dbContext.SaveChangesAsync();
        //    transaction.Commit();
        //}

        public async Task<ICollection<Wallet>> GetWalletByUserId(string UserId)
        {
           return  await _dbContext.Wallets.Where(x => x.UserId == UserId).ToListAsync();
        }

        //public async Task UpdateWalletTransaction(Wallet walletWithCurrency, Transaction newTransaction)
        //{
        //    var transaction = _dbContext.Database.BeginTransaction();
        //    _dbContext.Wallets.Update(walletWithCurrency);
        //    await _dbContext.SaveChangesAsync();
        //    await _dbContext.Tranasactions.AddAsync(newTransaction);
        //    await _dbContext.SaveChangesAsync();
        //    transaction.Commit();
        //}
    }
}
