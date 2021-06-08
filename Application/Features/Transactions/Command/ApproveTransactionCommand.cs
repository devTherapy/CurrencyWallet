using CurrencyWallet.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Features.Transactions.Command
{
   public  class ApproveTransactionCommand : IRequest<TransactionApprovalResponse>
    {
        public string TransactionId { get; set; }
    }
}
