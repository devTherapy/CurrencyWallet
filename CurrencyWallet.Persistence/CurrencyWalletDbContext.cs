using CurrencyWallet.Domain.Entities;
using CurrencyWallet.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Persistence
{
   public  class CurrencyWalletDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Tranasactions { get; set; }
        public DbSet<TransactionStatus> TransactionStatuses { get; set; }
        public DbSet<TransactionCategory``> TransactionTypes { get; set; }
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

            builder.Entity<Transaction>()
            .HasOne(e => e.TransactionStatus)
            .WithMany(e => e.Transactions)
            .HasForeignKey(e => e.TransactionStatusId)
            .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Transaction>()
            .HasOne(e => e.TransactionType)
            .WithMany(e => e.Transactions)
            .HasForeignKey(e => e.TransactionTypeId)
            .OnDelete(DeleteBehavior.ClientCascade);


            builder.Entity<Wallet>()
            .HasOne(e => e.User)
            .WithMany(e => e.Wallets)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);

        }
    }
}
