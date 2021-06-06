using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Contract.Identity.Policies
{
    public static class Policies
    {
        /// <summary>
        /// Admin role for our policy
        /// </summary>
        public const string Admin = "admin";
        /// <summary>
        /// Decadev role for our policy
        /// </summary>
        public const string Noob = "Noob";
        /// <summary>
        /// Vendor role for our policy
        /// </summary>
        public const string Elite = "Elite";
       

        /// <summary>
        /// Grants Admin right to User
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
        }

        /// <summary>
        /// Grants Decadev Access to a User
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy NoobPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Noob).Build();
        }

        /// <summary>
        /// Facility Policy
        /// </summary>
        /// <returns></returns>
        public static AuthorizationPolicy ElitePolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Elite).Build();
        }

    }
}
