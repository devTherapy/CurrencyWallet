using CurrencyWallet.Application.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Contract.Identity
{
    public  interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task<PromoteUserResponse> DemoteUser(string userId);
        Task<PromoteUserResponse> PromoteUser(string userId);
    }
}
