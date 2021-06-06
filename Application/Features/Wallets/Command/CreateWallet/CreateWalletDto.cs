using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Wallets.Command.CreateWallet
{
   public  class CreateWalletDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Currency { get; set; }
        public bool Main { get; set; }
    }
}
