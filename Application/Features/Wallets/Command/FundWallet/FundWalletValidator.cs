using CurrencyWallet.Application.Contract.Infrastructure;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Wallets.Command.FundWallet
{
    public class FundWalletValidator : AbstractValidator<FundWalletCommand>
    {
        private readonly ICurrencyConverterService _currencyConverterService;

        public FundWalletValidator(ICurrencyConverterService currencyConverterService)
        {
            _currencyConverterService = currencyConverterService;
            RuleFor(p => p.Amount)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.Currency)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p)
                .Must(isValidCurrency);
        }

        private bool isValidCurrency(FundWalletCommand arg)
        {
            return _currencyConverterService.IsValidCurrency(arg.Currency);
        }
    }
}
