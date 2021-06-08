using CurrencyWallet.Application.Features.Wallets.Command.CreateWallet;
using CurrencyWallet.Application.Features.Wallets.Command.FundWallet;
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

        public WalletController(IMediator mediator)
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
            var result = await _mediator.Send(createWalletCommand);
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fundWalletCommand"></param>
        /// <returns></returns>
        [HttpPost("FundWallet")]
        public async Task<ActionResult<FundWalletResponse>> FundWallet([FromBody] FundWalletCommand fundWalletCommand)
        {
            var result = await _mediator.Send(fundWalletCommand);
            if (result.Success) return Ok(result);       
            return BadRequest(result);
        }
    }
}
