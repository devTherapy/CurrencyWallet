using CurrencyWallet.Application.Features.Wallets.Command.CreateWallet;
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
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WalletController(IMediator mediator )
        {
            _mediator = mediator; 
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createWalletCommand"></param>
        /// <returns></returns>
        [HttpPost("CreateWallet")]
        public async Task<ActionResult<CreateWalletResponse>> Create([FromBody] CreateWalletCommand createWalletCommand)
        {
           var dtos = await _mediator.Send(createWalletCommand);
            return Ok(dtos);
        }
    }
}
