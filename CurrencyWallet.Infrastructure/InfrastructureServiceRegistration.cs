using CurrencyWallet.Application.Contract.Infrastructure;
using CurrencyWallet.Application.Models.ApIModels;
using Microsoft.Extensions.Configuration;
using CurrencyWallet.Infrastructure.CurrencyConverter;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyWallet.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<ICurrencyConverterService, CurrencyConverterService>();
            return services;
        }
    }
}