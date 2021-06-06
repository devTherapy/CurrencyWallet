using CurrencyWallet.Application.Models.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Contract.Infrastructure
{
   public  interface ICurrencyConverterService
    {
        Task<Rates> GetCurrencyRates();
        bool IsValidCurrency(string currency);
        Task<decimal> ConvertCurrency(string transactionCurrency, string MainCurrency, decimal amount);
        Task<decimal> SelectCurrencyRate(string currency);

    }
}
