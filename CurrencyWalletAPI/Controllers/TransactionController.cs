using CurrencyWallet.Application.Features.Transactions.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWallet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionId"></param>
        /// <returns></returns>
        [HttpPatch("{transactionId}/approve")]
        public async Task<ActionResult<TransactionApprovalResponse>> ApproveTransaction(string transactionId)
        {
            var result =  await _mediator.Send(new ApproveTransactionCommand() { TransactionId = transactionId });
            if (!result.Success) return BadRequest(result);
            return Ok(result);
        }

    }
}
