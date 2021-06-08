using CurrencyWallet.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Wallets.Command.FundWallet
{
    public class FundWalletResponse : BaseResponse
    {
        public string TransactionId { get; set; }
    }
}
