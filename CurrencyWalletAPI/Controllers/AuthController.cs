using CurrencyWallet.Application.Contract.Identity;
using CurrencyWallet.Application.Models.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyWallet.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authService"></param>
        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// Reguster a new user to the database
        /// </summary>
        /// <param name="registrationRequest"></param>
        /// <returns></returns>
        [HttpPost("Register-User")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync([FromBody] RegistrationRequest registrationRequest)
        {
         var response =  await _authService.RegisterAsync(registrationRequest);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }
       
        /// <summary>
        /// Authenticates user to use to application
        /// </summary>
        /// <param name="authenticationRequest"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>>AuthenticateAsync([FromBody]
        AuthenticationRequest authenticationRequest
        )
        {
            var response = await _authService.AuthenticateAsync(authenticationRequest);
            if (!response.Success) return BadRequest(response);
            return Ok(response);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPatch("Promote-User")]
        public async Task<ActionResult<PromoteUserResponse>> PromoteUser(string userId)
        {
            var response = await _authService.PromoteUser(userId);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPatch("Demote-User")]
        public async Task<ActionResult<PromoteUserResponse>> DemoteUser(string userId)
        {
            var response = await _authService.PromoteUser(userId);
            if (!response.Success) return BadRequest(response);
            return Ok(response);
        }
    }
}
