using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Wallets.Command.CreateWallet
{
   public class CreateWalletCommand : IRequest<CreateWalletResponse>
    {
        public string Currency { get; set; }
        public string UserId { get; set; }
    }
}
