using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Wallets.Command.FundWallet
{
    public class FundWalletCommand : IRequest<FundWalletResponse>
    {
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string UserId { get; set; }
    }
}
