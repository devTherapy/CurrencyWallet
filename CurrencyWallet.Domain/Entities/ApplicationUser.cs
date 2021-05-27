﻿
using CurrencyWallet.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Identity.Models
{
   public  class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }


        //navigational properties
        public ICollection<Wallet> Wallets { get; set; }

    }
}
