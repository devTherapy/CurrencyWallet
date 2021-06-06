using CurrencyWallet.Application.Contract.Persistence;
using CurrencyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(CurrencyWalletDbContext dbContext) : base(dbContext)
        {

        }
    }
}
