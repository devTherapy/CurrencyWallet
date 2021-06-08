using CurrencyWallet.Application.Contract.Persistence;
using CurrencyWallet.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Persistence.Repositories
{
   public  class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(CurrencyWalletDbContext dbContext, UserManager<ApplicationUser> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }

        public async Task<IList<string>> GetUserRoles(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }
}
