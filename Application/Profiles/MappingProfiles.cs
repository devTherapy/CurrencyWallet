using AutoMapper;
using CurrencyWallet.Application.Features.Wallets.Command.CreateWallet;
using CurrencyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyWallet.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Wallet, CreateWalletDto>();
        }
    }
}
