using CurrencyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Wallets.Command.CreateWallet
{
    public class CreateWalletResponse : BaseResponse
    {
        public CreateWalletDto Wallet { get; set; }
    }
}
