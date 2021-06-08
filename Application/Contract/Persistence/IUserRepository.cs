using CurrencyWallet.Identity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Contract.Persistence
{
    public interface IUserRepository : IAsyncRepository<ApplicationUser>
    {
        Task<IList<string>> GetUserRoles(ApplicationUser appUser);
    }
}
