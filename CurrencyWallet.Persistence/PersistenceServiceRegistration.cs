using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CurrencyWallet.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CurrencyWalletDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CurrencyWalletConnectionString")));
        }
    }
}
