using CurrencyWallet.Application.Contract.Persistence;
using CurrencyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Persistence.Repositories
{
   public  class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(CurrencyWalletDbContext dbContext) : base(dbContext)
        {

        }
    }
}
