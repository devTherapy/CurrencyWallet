using CurrencyWallet.Domain.Entities;
using CurrencyWallet.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using CurrencyWallet.Domain.Common;

namespace CurrencyWallet.Persistence
{
   public  class CurrencyWalletDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Tranasactions { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers{ get; set; }
        public CurrencyWalletDbContext(DbContextOptions<CurrencyWalletDbContext>options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Transaction>()
            .HasOne(e => e.Wallet)
            .WithMany(e => e.Transactions)
            .HasForeignKey(e => e.WalletId)
            .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Wallet>()
            .HasOne(e => e.User)
            .WithMany(e => e.Wallets)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)

        {
            var entries = ChangeTracker
                .Entries()
                .Where(entry => entry.Entity is BaseEntity && (
                        entry.State == EntityState.Added
                        || entry.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).LastModifiedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
