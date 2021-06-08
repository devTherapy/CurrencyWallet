using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Wallets.Command.PromoteUser
{
   public  class PromoteUserCommendm : IRequest<PromoteUserResponse>
    {
        public string UserId { get; set; }
    }
}
