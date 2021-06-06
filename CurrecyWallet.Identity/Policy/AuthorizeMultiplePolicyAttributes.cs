using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Contract.Identity.Policy
{
   public  class AuthorizeMultiplePolicyAttributes : TypeFilterAttribute
    {
        /// <summary>
        /// AuthorizeMultiplePolicyAttribute constructor
        /// </summary>
        /// <param name="policies"></param>
        public AuthorizeMultiplePolicyAttributes(string[] policies) : base(typeof(AuthorizeMultiplePolicyFilters))
        {
            Arguments = new object[] { policies };
        }
    }
}
