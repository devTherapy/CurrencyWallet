using CurrencyWallet.Application.Contract.Identity;
using CurrencyWallet.Application.Contract.Infrastructure;
using CurrencyWallet.Application.Contract.Persistence;
using CurrencyWallet.Application.Models.Authentication;
using CurrencyWallet.Domain.Entities;
using CurrencyWallet.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Application.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICurrencyConverterService _currencyConverterService;
        private readonly IWalletRepository _walletRepo;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
               IOptions<JwtSettings> jwtSettings, SignInManager<ApplicationUser> signInManager, ICurrencyConverterService currencyConverterService, IWalletRepository walletRepo)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _currencyConverterService = currencyConverterService;
            _walletRepo = walletRepo;
        }
        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null &&  await _userManager.CheckPasswordAsync(user, request.Password))
            {
               var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            }
            else
            {
                throw new Exception($"Credentials for '{request.Email} aren't valid'.");
            }
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            AuthenticationResponse response = new AuthenticationResponse
            {
                UserId = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            };

            return response;

        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Duration),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            if (!_currencyConverterService.IsValidCurrency(request.MainCurrency))
            {
                throw new Exception("Invalid Currency Input");
            }
            var existingUser = await _userManager.FindByNameAsync(request.UserName);
            if (existingUser != null)
            {
                throw new Exception($"Username '{request.UserName}' already exists.");
            }

            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                throw new Exception($"Email '{request.Email}' already exists");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
            };
            //create a wallet form the choosen currency          
            var userWallet = new Wallet()
            {
                Currency = request.MainCurrency,
                Main = true,
                Balance = (decimal) 0.00,
                UserId = user.Id,
            };
            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _walletRepo.AddAsync(userWallet);
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                var errorList = new List<string>();
                foreach (var error in result.Errors)
                {
                    errorList.Add(error.Description);
                }
                throw new Exception($"{errorList[0]}");

           }

            //handle the password validation error.

        }


    }
}
