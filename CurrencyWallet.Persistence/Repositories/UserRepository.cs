using CurrencyWallet.Application.Contract.Persistence;
using CurrencyWallet.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Persistence.Repositories
{
   public  class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(CurrencyWalletDbContext dbContext) : base(dbContext)
        {

        }
    }
}
