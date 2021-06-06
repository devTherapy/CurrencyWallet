using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Wallets.Command.CreateWallet
{
    public class CreateWalletValidator : AbstractValidator<CreateWalletCommand>
    {
        public CreateWalletValidator()
        {
            RuleFor(p => p.Currency)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed !0 characters");

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
