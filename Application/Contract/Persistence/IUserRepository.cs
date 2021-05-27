using CurrencyWallet.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Contract.Persistence
{
    public interface IUserRepository : IAsyncRepository<ApplicationUser>
    {
    }
}
