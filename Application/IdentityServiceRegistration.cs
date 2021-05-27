using CurrencyWallet.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application
{
  public static class IdentityServiceRegistration
    {
        //public static void addidentityconfiguring(this iservicecollection services)
        //{
        //    services.addidentity<applicationuser, identityrole>()
        //        .addentityframeworkstores<currencywalletdbcontext>().adddefaulttokenproviders();

        //    services.configure<identityoptions>(options =>
        //    {
        //        options.password.requiredigit = false;
        //        options.password.requirelowercase = false;
        //        options.password.requirenonalphanumeric = false;
        //        options.password.requireuppercase = false;
        //        options.password.requiredlength = 6;
        //        options.user.requireuniqueemail = true;
        //    });
        //}
    }
}
